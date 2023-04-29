using System.Drawing;

namespace JPEGtoWEBPCompressor
{
    internal interface IImageConverter
    {
        void ConvertAndSave(Bitmap resizedImage, string outputImagePath, int compressionPercentage);
    }
}
