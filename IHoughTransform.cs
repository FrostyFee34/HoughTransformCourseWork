using System.Collections.Generic;
using System.Drawing;

namespace HoughTransformApp
{
    public interface IHoughTransform
    {
        int[,] Accumulator { get; }
        Dictionary<char, int> AccumulatorSize { get; }

        void Binarization(Bitmap image);

        Bitmap Sobel(Bitmap image);

        Bitmap FillTheAccumulator(Bitmap houghSpaceImage);

        Point SearchLine(int threshold);

        void Normalize(int max);

        int AccumulatorMax();
    }
}