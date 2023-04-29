using ImageMagick;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace JPEGtoWEBPCompressor
{
    internal class ImageConverter : IImageConverter
    {
        public void ConvertAndSave(Bitmap resizedImage, string outputImagePath, int compressionPercentage)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                resizedImage.Save(stream, ImageFormat.Jpeg);
                stream.Position = 0;

                using (MagickImage image = new MagickImage(stream))
                {
                    image.Format = MagickFormat.WebP;
                    image.Quality = compressionPercentage;
                    image.AdaptiveSharpen();

                    image.Write(outputImagePath);
                }
            }
        }
    }
}
