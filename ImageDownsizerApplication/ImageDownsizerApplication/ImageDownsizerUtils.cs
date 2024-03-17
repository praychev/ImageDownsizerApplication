using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownsizerApplication
{
    internal class ImageDownsizerUtils
    {
        public static BitmapUtils LockBits(Bitmap bitmap)
        {
            int Width = bitmap.Width;
            int Height = bitmap.Height;
            int PixelCount = Width * Height;

            Rectangle rect = new Rectangle(0, 0, Width, Height);

            int Depth = System.Drawing.Bitmap.GetPixelFormatSize(bitmap.PixelFormat);

            if (Depth != 8 && Depth != 24 && Depth != 32)
            {
                throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
            }

            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            int step = Depth / 8;
            byte[] Pixels = new byte[PixelCount * step];
            IntPtr Iptr = bitmapData.Scan0;

            Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);
            return new BitmapUtils(bitmapData, Pixels, Depth, Iptr);
        }

        public static void UnlockBits(Bitmap bitmap, BitmapUtils bitmapUtils)
        {
            Marshal.Copy(bitmapUtils.Pixels, 0, bitmapUtils.Iptr, bitmapUtils.Pixels.Length);
            bitmap.UnlockBits(bitmapUtils.BitmapData);
        }

        public static Color GetPixel(int x, int y, Bitmap bitmap, BitmapUtils bitmapUtils)
        {
            Color color = Color.Empty;
            int cCount = bitmapUtils.Depth / 8;
            int i = ((y * bitmap.Width) + x) * cCount;

            if (i > bitmapUtils.Pixels.Length - cCount)
                throw new IndexOutOfRangeException();

            if (bitmapUtils.Depth == 32)
            {
                byte blue = bitmapUtils.Pixels[i];
                byte green = bitmapUtils.Pixels[i + 1];
                byte red = bitmapUtils.Pixels[i + 2];
                byte a = bitmapUtils.Pixels[i + 3];
                color = Color.FromArgb(a, red, green, blue);
            }
            if (bitmapUtils.Depth == 24)
            {
                byte blue = bitmapUtils.Pixels[i];
                byte green = bitmapUtils.Pixels[i + 1];
                byte red = bitmapUtils.Pixels[i + 2];
                color = Color.FromArgb(red, green, blue);
            }
            if (bitmapUtils.Depth == 8)
            {
                byte c = bitmapUtils.Pixels[i];
                color = Color.FromArgb(c, c, c);
            }
            return color;
        }

        public static void SetPixel(int x, int y, Color color, Bitmap bitmap, BitmapUtils bitmapUtils)
        {
            int cCount = bitmapUtils.Depth / 8;
            int i = ((y * bitmap.Width) + x) * cCount;

            if (bitmapUtils.Depth == 32)
            {
                bitmapUtils.Pixels[i] = color.B;
                bitmapUtils.Pixels[i + 1] = color.G;
                bitmapUtils.Pixels[i + 2] = color.R;
                bitmapUtils.Pixels[i + 3] = color.A;
            }
            if (bitmapUtils.Depth == 24)
            {
                bitmapUtils.Pixels[i] = color.B;
                bitmapUtils.Pixels[i + 1] = color.G;
                bitmapUtils.Pixels[i + 2] = color.R;
            }
            if (bitmapUtils.Depth == 8)
            {
                bitmapUtils.Pixels[i] = color.B;
            }
        }

        public static Bitmap downScale(Bitmap image, int scalingFactor)
        {
            Graphics myGraphics = Graphics.FromImage(image);
            BitmapUtils originData = LockBits(image);
            double scalling = (double)scalingFactor / 100;
            double newWidth = (int)(image.Width * scalling);
            double newHeight = (int)(image.Height * scalling);

            double widthRatio = (double)image.Width / newWidth;
            double heightRatio = (double)image.Height / newHeight;

            Bitmap newBitmap = new Bitmap((int)newWidth, (int)newHeight);
            BitmapUtils newData = LockBits(newBitmap);
            if (newHeight < newHeight)
            {
                double swap = newHeight;
                newHeight = newWidth;
                newWidth = swap;
            }

            for (int y = 0; y < newHeight; y++)
            {
                for (int x = 0; x < newWidth; x++)
                {

                    float originalX = (int)(x * (float)widthRatio);
                    float originalY = (int)(y * (float)heightRatio);

                    originalX = Math.Min(originalX, image.Width - 1);
                    originalY = Math.Min(originalY, image.Height - 1);

                    Color nearestColor = GetPixel((int)originalX, (int)originalY, image, originData);

                    SetPixel(x, y, nearestColor, newBitmap, newData);
                }
            }

            myGraphics.Dispose();
            UnlockBits(image, originData);
            UnlockBits(newBitmap, newData);

            return newBitmap;
        }

        public static Bitmap downScaleParallel(Bitmap image, int scalingFactor)
        {
            Graphics myGraphics = Graphics.FromImage(image);
            BitmapUtils originData = LockBits(image);
            double scalling = (double)scalingFactor / 100;
            double newWidth = (int)(image.Width * scalling);
            double newHeight = (int)(image.Height * scalling);

            double widthRatio = (double)image.Width / newWidth;
            double heightRatio = (double)image.Height / newHeight;

            Bitmap newBitmap = new Bitmap((int)newWidth, (int)newHeight);
            BitmapUtils newBitmapData = LockBits(newBitmap);
            object lockObject = new object();

            Parallel.For(0, (int)newHeight, y =>
            {
                for (int x = 0; x < newWidth; x++)
                {
                    float originalX = (int)(x * (float)widthRatio);
                    float originalY = (int)(y * (float)heightRatio);

                    lock (lockObject)
                    {
                        originalX = Math.Min(originalX, image.Width - 1);
                        originalY = Math.Min(originalY, image.Height - 1);

                    }
                    Color nearestColor;

                    lock (lockObject)
                    {
                        nearestColor = GetPixel((int)originalX, (int)originalY, image, originData);
                    }

                    lock (lockObject)
                    {
                        SetPixel(x, y, nearestColor, newBitmap, newBitmapData);
                    }
                }
            });

            myGraphics.Dispose();
            UnlockBits(image, originData);
            UnlockBits(newBitmap, newBitmapData);

            return newBitmap;
        }
    }
}
