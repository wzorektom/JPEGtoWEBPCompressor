using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPEGtoWEBPCompressor
{
    internal class Program
    {

        static int maxDimension = 800;
        static int compressionPercentage = 50;
        static string imageFolderPath = @"D:\Images";
        static string resizedFolderPath = Path.Combine(imageFolderPath, "ResizedJPEGImages");
        static string convertedFolderPath = Path.Combine(imageFolderPath, "WEBpConvertedImages");
        static string[] supportedExtensions = { ".jpg", ".jpeg" };
        static void Main(string[] args)
        {
            Process.Start("explorer.exe", imageFolderPath);

            Console.WriteLine("Current default values:");
            Console.WriteLine($"Max dimension: {maxDimension}px");
            Console.WriteLine($"Compression percentage: {compressionPercentage}%");

            Console.Write("Do you want to change the default values? (y/n): ");

            if (Console.ReadLine().ToLower() == "y")
            {
                SetNewMaxDimension();
                SetNewCompressionPercentage();

                Console.WriteLine("Updated values:");
                Console.WriteLine($"Max dimension: {maxDimension}px");
                Console.WriteLine($"Compression percentage: {compressionPercentage}%");
            }

            Directory.CreateDirectory(resizedFolderPath);
            Directory.CreateDirectory(convertedFolderPath);

            Console.WriteLine("Monitoring the folder for new images...");

            using (var watcher = new FileSystemWatcher())
            {
                watcher.Path = imageFolderPath;
                watcher.Filter = "*.*";
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size;
                watcher.Created += OnImageCreated;
                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Press 'q' to quit or close the console window.");
                while (Console.Read() != 'q') ;

                Console.WriteLine("Clearing directories...");
                ClearDirectory(imageFolderPath);
                Console.WriteLine("Directories cleared. Exiting...");
            }
        }

        private static void SetNewMaxDimension()
        {
            Console.Write("Enter new max dimension: ");

            if (int.TryParse(Console.ReadLine(), out int newMaxDimension) && newMaxDimension > 0)
            {
                maxDimension = newMaxDimension;
            }
            else
            {
                Console.WriteLine("Invalid max dimension value. Keeping the default value.");
            }
        }

        private static void SetNewCompressionPercentage()
        {
            Console.Write("Enter new compression percentage: ");

            if (int.TryParse(Console.ReadLine(), out int newCompressionPercentage) &&
                newCompressionPercentage >= 0 && newCompressionPercentage <= 100)
            {
                compressionPercentage = newCompressionPercentage;
            }
            else
            {
                Console.WriteLine("Invalid compression percentage value. Keeping the default value.");
            }
        }

        private static async void OnImageCreated(object sender, FileSystemEventArgs e)
        {
            string fileExtension = Path.GetExtension(e.FullPath).ToLowerInvariant();

            if (!supportedExtensions.Contains(fileExtension)) return;

            await Task.Delay(1000); // Add a delay of 1 second

            if (!IsFileReady(e.FullPath)) return;

            Console.WriteLine($"New image detected: {Path.GetFileName(e.FullPath)}");

            string resizedImagePath = Path.Combine(resizedFolderPath, Path.GetFileName(e.FullPath));
            string outputImagePath = Path.Combine(convertedFolderPath, Path.GetFileNameWithoutExtension(e.FullPath) + ".webp");

            var imageResizer = new ImageResizer();
            var imageConverter = new ImageConverter();
            var imageProcessor = new ImageProcessor(imageResizer, imageConverter);

            imageProcessor.ProcessImage(e.FullPath, resizedImagePath, outputImagePath, maxDimension, compressionPercentage);

            Console.WriteLine($"Resized and converted {Path.GetFileName(e.FullPath)} to WEBP");
        }

        private static bool IsFileReady(string path)
        {
            try
            {
                using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return true;
                }
            }
            catch (IOException)
            {
                return false;
            }
        }

        static void ClearDirectory(string directoryPath)
        {
            DirectoryInfo di = new DirectoryInfo(directoryPath);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}
