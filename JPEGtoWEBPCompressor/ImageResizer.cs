using System;
using System.Drawing;

namespace JPEGtoWEBPCompressor
{
    internal class ImageResizer : IImageResizer
    {
        public Bitmap ResizeImage(Bitmap image, int maxDimension)
        {
            int newWidth;
            int newHeight;

            if (image.Width > image.Height)
            {
                newWidth = maxDimension;
                newHeight = (int)Math.Round(image.Height * (newWidth / (double)image.Width));
            }
            else
            {
                newHeight = maxDimension;
                newWidth = (int)Math.Round(image.Width * (newHeight / (double)image.Height));
            }

            Bitmap resizedImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }
    }
}
