using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageNet.Core.Filtering
{
    public abstract class BaseFilter : IFilter
    {
        protected Bitmap Bitmap { get; set; }
        protected BitmapData BitmapData { get; set; }
        protected IntPtr Scan { get; set; }
        protected int Offset { get { return BitmapData.Stride - Bitmap.Width*PixelSize; } }

        protected int PixelSize
        {
            get { return Bitmap.PixelFormat == PixelFormat.Format24bppRgb ? 3 : 4; }
        }

        public unsafe bool ProcessFilter(Image image)
        {
            MapProperties(image);
            return ApplyFilter();
        }

        protected abstract bool ApplyFilter();

        protected virtual void MapProperties(Image image)
        {
            Bitmap = (Bitmap) image;
            BitmapData = Bitmap.LockBits(new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            Scan = BitmapData.Scan0;
        }

    }
}
