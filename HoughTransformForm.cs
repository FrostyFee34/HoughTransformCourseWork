using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoughTransformApp
{
    public partial class HoughTransformForm : Form
    {
        private readonly HoughTransform _houghTransform = new HoughTransform();
        public HoughTransformForm()
        {
            InitializeComponent();
        }

        private async void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Shows the original and prepared for the transformation image
            using (var openFileDialog = new OpenFileDialog
            {
                Title = "Open image",
                Filter = "Image files (*.bmp , *.jpg , *.png )|*.bmp;*.jpg;*.png"
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxInputImage.Image = new Bitmap(openFileDialog.FileName);
                    using (var task = Task.Run(() => _houghTransform.Sobel(new Bitmap(openFileDialog.FileName))))
                    {
                        await task;
                        pictureBoxSobel.Image = task.Result;
                    }
                }
            }
        }

        private void HoughTransformForm_Load(object sender, EventArgs e)
        {
        }

        private async void findLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBoxSobel.Image == null || pictureBoxInputImage.Image == null)
            {
                MessageBox.Show(@"Upload the picture and wait while it is processed");
                return;
            }

            // Add the image of Hough space to pictureBox 
            using (var houghSpaceTask =
                Task.Run(() => _houghTransform.FillTheAccumulator(new Bitmap(pictureBoxSobel.Image))))
            {
                await houghSpaceTask;
                pictureBoxHoughSpace.Image = houghSpaceTask.Result;
            }

            int threshold = Convert.ToInt32(textBoxThreshold.Text);
            if (threshold < 1) threshold = 1;

            // Add the result image  to pictureBox 
            using (var resultImageTask = Task.Run(() => BuildLines(new Pen(Color.Red, 2), threshold)))
            {
                await resultImageTask;
                pictureBoxResult.Image = resultImageTask.Result;
            }
        }

        private Bitmap BuildLines(Pen pen, int threshold)
        {
            // Input image
            Bitmap resultImage = new Bitmap(pictureBoxInputImage.Image);
            // Variable for future line-building
            Graphics lineBuilder = Graphics.FromImage(resultImage);

            while (true)
            {
                // Y = rho(Image diagonal), X = theta
                Point houghPoint = _houghTransform.TakeTheLargesLine(threshold);
                if (houghPoint.X == -1) break;
                if (houghPoint.X > 0)
                {
                    // Transform degrees to radians
                    var theta = houghPoint.X * (Math.PI / 180);
                    // Find the y coordinates of line with formula:
                    // (cos(theta)/ sin(theta)) * x + ro/sin(theta)
                    // X = 0
                    int y1 = (int) (-Math.Cos(theta) / Math.Sin(theta) * 0 + houghPoint.Y / Math.Sin(theta));
                    // X = image width
                    int y2 = (int) ((-Math.Cos(theta) / Math.Sin(theta)) * resultImage.Width +
                                    houghPoint.Y / Math.Sin(theta));
                    // Build a line on a result image
                    lineBuilder.DrawLine(pen, 0, y1, resultImage.Width, y2);
                }
            }

            return resultImage;
        }

        private void saveImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ask user to select directory
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                // If the user selected something
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    // Create a new folder in selected directory
                    var directoryName = $"{folderBrowserDialog.SelectedPath}/{DateTime.Now:MM-dd-yyyy HH-mm-ss}";
                    Directory.CreateDirectory(directoryName);

                    // Save the image (if it is not null) to the created directory
                    pictureBoxInputImage.Image?.Save(directoryName+"/Input.jpeg");
                    pictureBoxSobel.Image?.Save(directoryName+"/Sobel.jpeg");
                    pictureBoxHoughSpace.Image?.Save(directoryName+"/HoughSpace.jpeg");
                    pictureBoxResult.Image?.Save(directoryName+"/Result.jpeg");
                }
            }
        }

        private void textBoxThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Accept only positive integers
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}