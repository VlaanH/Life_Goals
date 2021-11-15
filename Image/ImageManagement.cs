using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using LifeGoals.Cryptography;

namespace LifeGoals.Images
{
    public static class ImageManagement
    {
        public enum ImageFormat
        {
            jpeg,
            gif,
            png,
            unknown
        }

        public static string GetRandomImageName()
        {
            var randomValue = new Random().Next(-2222,2222);
            long unixTimeNow = ((DateTimeOffset) DateTime.Now).ToUnixTimeSeconds();
            var hash = HashingSha1.GetHash(randomValue.ToString()+unixTimeNow.ToString() );

            return hash;
        }

        public static void ResizeImage(string imagePath, Size size)
        {
            Image imgToResize = new Bitmap(imagePath);
            
            new Bitmap(imgToResize, size).Save(imagePath);
        }

        public static ImageFormat GetImageFormat(string fileName)
        {
            byte[] bytes = File.ReadAllBytes(fileName);
           
        
            var gif    = Encoding.ASCII.GetBytes("GIF");    // GIF
            var png    = new byte[] { 137, 80, 78, 71 };    // PNG
            var jpeg   = new byte[] { 255, 216, 255, 224 }; // jpeg
            var jpeg2  = new byte[] { 255, 216, 255, 225 }; // jpeg canon
            

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return ImageFormat.gif;

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return ImageFormat.png;
            
            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return ImageFormat.jpeg;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return ImageFormat.jpeg;

            return ImageFormat.unknown;
        }
    }
}