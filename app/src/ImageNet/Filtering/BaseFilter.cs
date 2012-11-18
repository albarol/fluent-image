namespace ImageNet.Filtering
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public abstract class BaseFilter : IFilter
    {
        protected Bitmap Bitmap { get; set; }
        protected BitmapData BitmapData { get; set; }

        protected IntPtr Scan { get; set; }

        protected int Offset
        {
            get
            {
                return this.BitmapData.Stride - (this.Bitmap.Width * this.PixelSize);
            }
        }

        protected int PixelSize
        {
            get { return this.Bitmap.PixelFormat == PixelFormat.Format24bppRgb ? 3 : 4; }
        }

        public bool ProcessFilter(Image image)
        {
            this.MapProperties(image);
            return this.ApplyFilter();
        }

        protected abstract bool ApplyFilter();

        protected virtual void MapProperties(Image image)
        {
            this.Bitmap = (Bitmap) image;
            this.BitmapData = this.Bitmap.LockBits(new Rectangle(0, 0, this.Bitmap.Width, this.Bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            this.Scan = this.BitmapData.Scan0;
        }

    }
}
