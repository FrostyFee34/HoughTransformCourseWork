using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace HoughTransformApp
{
    public class HoughTransform
    {
        // Accumulator (Hough space)
        public int[,] Accumulator { get; private set; }

        // Accumulator size for convenience 
        public Dictionary<char, int> AccumulatorSize { get; } = new Dictionary<char, int>
        {
            {'X', 0},
            {'Y', 0}
        };

        /*
        /// <summary>
        ///     Convert image to GrayScale(black and white) format
        /// </summary>
        public static void GrayScale(Bitmap img)
        {
            for (var y = 0; y < img.Height; y++)
            for (var x = 0; x < img.Width; x++)
            {
                var pixel = img.GetPixel(x, y);

                var px = (int) (pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                img.SetPixel(x, y, Color.FromArgb(pixel.A, px, px, px));
            }
        }*/

        /// <summary>
        ///     Convert image to binary(black and white) format
        /// </summary>
        private void Binarization(Bitmap image)
        {
            double avgBright = 0;
            for (var y = 0; y < image.Height; y++)
            for (var x = 0; x < image.Width; x++)
                // Get the brightness of this pixel
                avgBright += image.GetPixel(x, y).GetBrightness();

            // Get the average brightness and limit it's min / max
            avgBright = avgBright / (image.Width * image.Height);
            if (avgBright < .3)
                avgBright = .3;
            else if (avgBright > .7)
                avgBright = .7;
            // Loop through image
            for (var y = 0; y < image.Height; y++)
            for (var x = 0; x < image.Width; x++)
                // Set this pixel to black or white based on threshold
                image.SetPixel(x, y, image.GetPixel(x, y).GetBrightness() > avgBright ? Color.White : Color.Black);
        }

        /// <summary>
        ///     Detecting the edges of an image with sobel-operator
        ///     and binarize the resulting image after.
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Binarized(black and white) image edges.</returns>
        public Bitmap Sobel(Bitmap image)
        {
            var imageEdges = new Bitmap(image.Width, image.Height);
            // Sobel operator
            // Horizontal
            int[,] sobelX =
            {
                {-1, 0, 1},
                {-2, 0, 2},
                {-1, 0, 1}
            };
            // Vertical
            int[,] sobelY =
            {
                {-1, -2, -1},
                {0, 0, 0},
                {1, 2, 1}
            };

            // GrayScale the image
            // GrayScale(imageEdges);

            // Loop through image
            for (var y = 0; y < image.Height - 1; y++)
            for (var x = 0; x < image.Width - 1; x++)
            {
                int sumY, sumX;
                sumX = sumY = 0;
                int sum;
                if (y == 0 || y == image.Height - 1)
                {
                    sum = 0;
                }
                else if (x == 0 || x == image.Width - 1)
                {
                    sum = 0;
                }
                else
                {
                    // Convolution loop with the Sobel operator
                    for (var i = -1; i < 2; i++)
                    for (var j = -1; j < 2; j++)
                    {
                        // Take pixel 
                        int c = image.GetPixel(x + i, y + j).R;
                        // The sum of the products of a pixel by a value from matrix Y
                        sumY += c * sobelY[i + 1, j + 1];
                        // The sum of the products of a pixel by a value from matrix X
                        sumX += c * sobelX[i + 1, j + 1];
                    }

                    // The approximate gradient value 
                    sum = (int) Math.Sqrt(Math.Pow(sumX, 2) + Math.Pow(sumY, 2));
                }

                // Normalization
                if (sum > 255) sum = 255;
                else if (sum < 0) sum = 0;

                // Write result to output image
                imageEdges.SetPixel(x, y, Color.FromArgb(255, sum, sum, sum));
            }

            Binarization(imageEdges);
            return imageEdges;
        }

        /// <summary>
        ///     Fill the accumulator with possible straight lines.
        /// </summary>
        /// <param name="inputImage"></param>
        /// <returns>Bitmap Hough-space image.</returns>
        public  Bitmap FillTheAccumulator(Bitmap inputImage)
        {
            // Y = rho(Image diagonal), X = theta
            AccumulatorSize['X'] = 180;
            AccumulatorSize['Y'] =
                (int) Math.Round(Math.Sqrt(Math.Pow(inputImage.Width, 2) + Math.Pow(inputImage.Height, 2)));

            // Hough space
            Accumulator = new int[AccumulatorSize['X'], AccumulatorSize['Y']];
            // 1 degree to radians
            var dt = Math.PI / 180.0;

            // Loop through image
            for (var y = 0; y < inputImage.Height; y++)
            for (var x = 0; x < inputImage.Width; x++)
                // If edge exist 
                if (inputImage.GetPixel(x, y).R == 255)
                    for (var degreeTheta = 0; degreeTheta < AccumulatorSize['X']; degreeTheta++)
                    {
                        // Line equation where dt * i is Theta
                        var rho = (int) Math.Round(x * Math.Cos(dt * degreeTheta) + y * Math.Sin(dt * degreeTheta));
                        // If line exists -> increment accumulator at this rho and theta
                        if (rho < AccumulatorSize['Y'] && rho > 0)
                            Accumulator[degreeTheta, rho]++;
                    }

            // Find maximum in accumulator
            var accumulatorMax = AccumulatorMax();

            if (accumulatorMax != 0)
            {
                inputImage = new Bitmap(AccumulatorSize['X'], AccumulatorSize['Y']);
                // Normalize accumulator to create a image
                Normalize(accumulatorMax);

                // Create Hough space image
                for (var x = 0; x < AccumulatorSize['X']; x++)
                for (var y = 0; y < AccumulatorSize['Y']; y++)
                {
                    // Brightness of pixel
                    var houghCount = Accumulator[x, y];
                    inputImage.SetPixel(x, y, Color.FromArgb(houghCount, houghCount, houghCount));
                }
            }

            return inputImage;
        }

        /// <summary>
        ///     Finds the largest point in Hough space (longest line in XY space). And removes it after.
        /// </summary>
        /// <param name="threshold"></param>
        /// <returns>The biggest Point, where X is a Theta(in degrees) and Y is a rho.</returns>
        public Point TakeTheLargesLine(int threshold)
        {
            var max = 0;
            var pt = new Point(0, 0);
            // Loop through the Hough space
            // Find the max in accumulator 
            for (var y = 0; y < AccumulatorSize['Y']; y++)
            for (var x = 0; x < AccumulatorSize['X']; x++)
                if (max < Accumulator[x, y])
                {
                    max = Accumulator[x, y];
                    pt.X = x;
                    pt.Y = y;
                }

            // If less then threshold return -1
            if (max < threshold) pt.X = -1;
            // When max is founded, clear this "cell" from hough space
            else Accumulator[pt.X, pt.Y] = 0;

            return pt;
        }

        /// <summary>
        ///     Normalize the accumulator(put all value between 0 and 255).
        /// </summary>
        private void Normalize(int max)
        {
            for (var x = 0; x < AccumulatorSize['X']; x++)
            for (var y = 0; y < AccumulatorSize['Y']; y++)
            {
                var c = (int) (Accumulator[x, y] / (double) max * 255.0);
                Accumulator[x, y] = c;
            }
        }

        /// <summary>
        ///     Find max value from Accumulator.
        /// </summary>
        private int AccumulatorMax()
        {
            return Accumulator.Cast<int>().Max();
        }
    }
}