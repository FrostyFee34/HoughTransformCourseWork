
namespace HoughTransformApp
{
    partial class HoughTransformForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBoxInputImage = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.houghToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxSobel = new System.Windows.Forms.PictureBox();
            this.labelInput = new System.Windows.Forms.Label();
            this.labelSobelBinary = new System.Windows.Forms.Label();
            this.labelHoughSpace = new System.Windows.Forms.Label();
            this.pictureBoxHoughSpace = new System.Windows.Forms.PictureBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.textBoxThreshold = new System.Windows.Forms.TextBox();
            this.labelThreshold = new System.Windows.Forms.Label();
            this.toolTipThreshold = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInputImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSobel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHoughSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxInputImage
            // 
            this.pictureBoxInputImage.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxInputImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxInputImage.Location = new System.Drawing.Point(14, 53);
            this.pictureBoxInputImage.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBoxInputImage.Name = "pictureBoxInputImage";
            this.pictureBoxInputImage.Size = new System.Drawing.Size(326, 187);
            this.pictureBoxInputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxInputImage.TabIndex = 2;
            this.pictureBoxInputImage.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.houghToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(697, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveImagesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
            // 
            // saveImagesToolStripMenuItem
            // 
            this.saveImagesToolStripMenuItem.Name = "saveImagesToolStripMenuItem";
            this.saveImagesToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.saveImagesToolStripMenuItem.Text = "Save images";
            this.saveImagesToolStripMenuItem.Click += new System.EventHandler(this.saveImagesToolStripMenuItem_Click);
            // 
            // houghToolStripMenuItem
            // 
            this.houghToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findLinesToolStripMenuItem});
            this.houghToolStripMenuItem.Name = "houghToolStripMenuItem";
            this.houghToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.houghToolStripMenuItem.Text = "Hough";
            // 
            // findLinesToolStripMenuItem
            // 
            this.findLinesToolStripMenuItem.Name = "findLinesToolStripMenuItem";
            this.findLinesToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.findLinesToolStripMenuItem.Text = "Find lines";
            this.findLinesToolStripMenuItem.Click += new System.EventHandler(this.findLinesToolStripMenuItem_Click);
            // 
            // pictureBoxSobel
            // 
            this.pictureBoxSobel.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxSobel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSobel.Location = new System.Drawing.Point(14, 270);
            this.pictureBoxSobel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBoxSobel.Name = "pictureBoxSobel";
            this.pictureBoxSobel.Size = new System.Drawing.Size(326, 187);
            this.pictureBoxSobel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSobel.TabIndex = 4;
            this.pictureBoxSobel.TabStop = false;
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(12, 28);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(94, 20);
            this.labelInput.TabIndex = 5;
            this.labelInput.Text = "Input image:";
            // 
            // labelSobelBinary
            // 
            this.labelSobelBinary.AutoSize = true;
            this.labelSobelBinary.Location = new System.Drawing.Point(10, 245);
            this.labelSobelBinary.Name = "labelSobelBinary";
            this.labelSobelBinary.Size = new System.Drawing.Size(237, 20);
            this.labelSobelBinary.TabIndex = 6;
            this.labelSobelBinary.Text = "Sobel edge detection + binarized:";
            // 
            // labelHoughSpace
            // 
            this.labelHoughSpace.AutoSize = true;
            this.labelHoughSpace.Location = new System.Drawing.Point(358, 28);
            this.labelHoughSpace.Name = "labelHoughSpace";
            this.labelHoughSpace.Size = new System.Drawing.Size(101, 20);
            this.labelHoughSpace.TabIndex = 8;
            this.labelHoughSpace.Text = "Hough space:";
            // 
            // pictureBoxHoughSpace
            // 
            this.pictureBoxHoughSpace.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxHoughSpace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxHoughSpace.Location = new System.Drawing.Point(357, 53);
            this.pictureBoxHoughSpace.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBoxHoughSpace.Name = "pictureBoxHoughSpace";
            this.pictureBoxHoughSpace.Size = new System.Drawing.Size(326, 187);
            this.pictureBoxHoughSpace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHoughSpace.TabIndex = 7;
            this.pictureBoxHoughSpace.TabStop = false;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(356, 245);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(53, 20);
            this.labelResult.TabIndex = 11;
            this.labelResult.Text = "Result:";
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxResult.Location = new System.Drawing.Point(357, 270);
            this.pictureBoxResult.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(326, 187);
            this.pictureBoxResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxResult.TabIndex = 10;
            this.pictureBoxResult.TabStop = false;
            // 
            // textBoxThreshold
            // 
            this.textBoxThreshold.Location = new System.Drawing.Point(552, 0);
            this.textBoxThreshold.Name = "textBoxThreshold";
            this.textBoxThreshold.Size = new System.Drawing.Size(133, 25);
            this.textBoxThreshold.TabIndex = 12;
            this.textBoxThreshold.Text = "140";
            this.textBoxThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxThreshold_KeyPress);
            // 
            // labelThreshold
            // 
            this.labelThreshold.AutoSize = true;
            this.labelThreshold.Location = new System.Drawing.Point(467, 3);
            this.labelThreshold.Name = "labelThreshold";
            this.labelThreshold.Size = new System.Drawing.Size(79, 20);
            this.labelThreshold.TabIndex = 13;
            this.labelThreshold.Text = "Threshold:";
            this.toolTipThreshold.SetToolTip(this.labelThreshold, "255 for the longest line");
            // 
            // HoughTransformForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(697, 468);
            this.Controls.Add(this.labelThreshold);
            this.Controls.Add(this.textBoxThreshold);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.pictureBoxResult);
            this.Controls.Add(this.labelHoughSpace);
            this.Controls.Add(this.pictureBoxHoughSpace);
            this.Controls.Add(this.labelSobelBinary);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.pictureBoxSobel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBoxInputImage);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "HoughTransformForm";
            this.Text = "HoughTransform";
            this.Load += new System.EventHandler(this.HoughTransformForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInputImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSobel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHoughSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxInputImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBoxSobel;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Label labelSobelBinary;
        private System.Windows.Forms.Label labelHoughSpace;
        private System.Windows.Forms.PictureBox pictureBoxHoughSpace;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.ToolStripMenuItem saveImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem houghToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findLinesToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxThreshold;
        private System.Windows.Forms.Label labelThreshold;
        private System.Windows.Forms.ToolTip toolTipThreshold;
    }
}

