using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownsizerApplication
{
    internal class BitmapUtils
    {
        public IntPtr Iptr { get; set; }
        public BitmapData BitmapData { get; set; }

        public byte[] Pixels { get; set; }
        public int Depth { get; set; }
        public BitmapUtils(BitmapData bitmapData, byte[] pixels, int depth, IntPtr iptr)
        {
            BitmapData = bitmapData;
            Pixels = pixels;
            Depth = depth;
            Iptr = iptr;
        }
    }
}