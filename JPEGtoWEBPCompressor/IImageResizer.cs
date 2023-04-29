using System.Drawing;

namespace JPEGtoWEBPCompressor
{
    internal interface IImageResizer
    {
        Bitmap ResizeImage(Bitmap image, int maxDimension);
    }
}
