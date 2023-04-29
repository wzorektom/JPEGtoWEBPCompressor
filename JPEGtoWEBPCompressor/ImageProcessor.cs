using System.Drawing.Imaging;
using System.Drawing;

namespace JPEGtoWEBPCompressor
{
    internal class ImageProcessor
    {
        private readonly IImageResizer _imageResizer;
        private readonly IImageConverter _imageConverter;

        public ImageProcessor(IImageResizer imageResizer, IImageConverter imageConverter)
        {
            _imageResizer = imageResizer;
            _imageConverter = imageConverter;
        }

        public void ProcessImage(string inputImagePath, string resizedImagePath, string outputImagePath, int maxDimension, int compressionPercentage)
        {
            using (Bitmap image = new Bitmap(inputImagePath))
            {
                Bitmap resizedImage = _imageResizer.ResizeImage(image, maxDimension);
                resizedImage.Save(resizedImagePath, ImageFormat.Jpeg);

                _imageConverter.ConvertAndSave(resizedImage, outputImagePath, compressionPercentage);
            }
        }
    }
}
