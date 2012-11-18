namespace ImageNet.Filtering
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public abstract class MatrixFilter : BaseFilter
    {
        internal ConvertMatrix ConvertMatrix { get; set; }
        protected Bitmap BitmapSource { get; set; }
        protected BitmapData BitmapDataSource { get; set; }
        protected int StrideSource { get; set; }
        protected IntPtr ScanSource { get; set; }

        internal MatrixFilter(){}

        protected override void MapProperties(Image image)
        {
            base.MapProperties(image);
            this.BitmapSource = (Bitmap)this.Bitmap.Clone();
            this.BitmapDataSource = this.BitmapSource.LockBits(
                new Rectangle(0, 0, this.BitmapSource.Width, this.BitmapSource.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb
            );
            this.StrideSource = this.BitmapData.Stride*2;
            this.ScanSource = this.BitmapDataSource.Scan0;
        }
        
        protected override unsafe bool ApplyFilter()
        {
            if (this.ConvertMatrix.Factor  == 0)
                return false; 

            byte* pointer = (byte*)this.Scan.ToPointer();
            byte* sourcePointer = (byte*)this.ScanSource.ToPointer();
            int nWidth = this.Bitmap.Width - 2;
            int nHeight = this.Bitmap.Height - 2;

            for (int y = 0; y < nHeight; ++y)
            {
                for (int x = 0; x < nWidth; ++x)
                {
                    
                    pointer[5 + this.BitmapData.Stride] = this.GetRedPixel(sourcePointer);
                    pointer[4 + this.BitmapData.Stride] = this.GetGreenPixel(sourcePointer);
                    pointer[3 + this.BitmapData.Stride] = this.GetBluePixel(sourcePointer);

                    pointer += this.PixelSize;
                    sourcePointer += this.PixelSize;
                }

                pointer += this.Offset;
                sourcePointer += this.Offset;
            }

            this.Bitmap.UnlockBits(this.BitmapData);
            this.BitmapSource.UnlockBits(this.BitmapDataSource);
            return true; 
        }

        private unsafe byte GetRedPixel(byte* sourcePointer)
        {
            var pixel = ((((sourcePointer[2] * this.ConvertMatrix.TopLeft) +
                                (sourcePointer[5] * this.ConvertMatrix.TopMid) +
                                (sourcePointer[8] * this.ConvertMatrix.TopRight) +
                                (sourcePointer[2 + this.BitmapData.Stride] * this.ConvertMatrix.MidLeft) +
                                (sourcePointer[5 + this.BitmapData.Stride] * this.ConvertMatrix.Pixel) +
                                (sourcePointer[8 + this.BitmapData.Stride] * this.ConvertMatrix.MidRight) +
                                (sourcePointer[2 + this.StrideSource] * this.ConvertMatrix.BottomLeft) +
                                (sourcePointer[5 + this.StrideSource] * this.ConvertMatrix.BottomMid) +
                                (sourcePointer[8 + this.StrideSource] * this.ConvertMatrix.BottomRight))
                               / this.ConvertMatrix.Factor) + this.ConvertMatrix.Offset);

            if (pixel < 0) pixel = 0;
            if (pixel > 255) pixel = 255;
            return (byte)pixel;
        }

        private unsafe byte GetGreenPixel(byte* sourcePointer)
        {
            var pixel = ((((sourcePointer[1] * this.ConvertMatrix.TopLeft) +
                                (sourcePointer[4] * this.ConvertMatrix.TopMid) +
                                (sourcePointer[7] * this.ConvertMatrix.TopRight) +
                                (sourcePointer[1 + this.BitmapData.Stride] * this.ConvertMatrix.MidLeft) +
                                (sourcePointer[4 + this.BitmapData.Stride] * this.ConvertMatrix.Pixel) +
                                (sourcePointer[7 + this.BitmapData.Stride] * this.ConvertMatrix.MidRight) +
                                (sourcePointer[1 + this.StrideSource] * this.ConvertMatrix.BottomLeft) +
                                (sourcePointer[4 + this.StrideSource] * this.ConvertMatrix.BottomMid) +
                                (sourcePointer[7 + this.StrideSource] * this.ConvertMatrix.BottomRight))
                               / this.ConvertMatrix.Factor) + this.ConvertMatrix.Offset);

            if (pixel < 0) pixel = 0;
            if (pixel > 255) pixel = 255;
            return (byte)pixel;
        }

        private unsafe byte GetBluePixel(byte* sourcePointer)
        {
            var pixel = ((((sourcePointer[0] * this.ConvertMatrix.TopLeft) +
                                (sourcePointer[3] * this.ConvertMatrix.TopMid) +
                                (sourcePointer[6] * this.ConvertMatrix.TopRight) +
                                (sourcePointer[0 + this.BitmapData.Stride] * this.ConvertMatrix.MidLeft) +
                                (sourcePointer[3 + this.BitmapData.Stride] * this.ConvertMatrix.Pixel) +
                                (sourcePointer[6 + this.BitmapData.Stride] * this.ConvertMatrix.MidRight) +
                                (sourcePointer[0 + this.StrideSource] * this.ConvertMatrix.BottomLeft) +
                                (sourcePointer[3 + this.StrideSource] * this.ConvertMatrix.BottomMid) +
                                (sourcePointer[6 + this.StrideSource] * this.ConvertMatrix.BottomRight))
                               / this.ConvertMatrix.Factor) + this.ConvertMatrix.Offset);

            if (pixel < 0) pixel = 0;
            if (pixel > 255) pixel = 255;
            return (byte)pixel;
        }
    }
}
