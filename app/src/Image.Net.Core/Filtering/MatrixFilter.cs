using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageNet.Core.Filtering
{
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
            BitmapSource = (Bitmap)Bitmap.Clone();
            BitmapDataSource = BitmapSource.LockBits(
                new Rectangle(0, 0, BitmapSource.Width, BitmapSource.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb
            );
            StrideSource = BitmapData.Stride*2;
            ScanSource = BitmapDataSource.Scan0;
        }
        
        protected override unsafe bool ApplyFilter()
        {
            if (ConvertMatrix.Factor  == 0)
                return false; 

            byte* pointer = (byte*)Scan.ToPointer();
            byte* sourcePointer = (byte*)ScanSource.ToPointer();
            int nWidth = Bitmap.Width - 2;
            int nHeight = Bitmap.Height - 2;

            for (int y = 0; y < nHeight; ++y)
            {
                for (int x = 0; x < nWidth; ++x)
                {
                    
                    pointer[5 + BitmapData.Stride] = GetRedPixel(sourcePointer);
                    pointer[4 + BitmapData.Stride] = GetGreenPixel(sourcePointer);
                    pointer[3 + BitmapData.Stride] = GetBluePixel(sourcePointer);

                    pointer += PixelSize;
                    sourcePointer += PixelSize;
                }

                pointer += Offset;
                sourcePointer += Offset;
            }

            Bitmap.UnlockBits(BitmapData);
            BitmapSource.UnlockBits(BitmapDataSource);
            return true; 
        }

        private unsafe byte GetRedPixel(byte* sourcePointer)
        {
            var pixel = ((((sourcePointer[2] * ConvertMatrix.TopLeft) +
                                (sourcePointer[5] * ConvertMatrix.TopMid) +
                                (sourcePointer[8] * ConvertMatrix.TopRight) +
                                (sourcePointer[2 + BitmapData.Stride] * ConvertMatrix.MidLeft) +
                                (sourcePointer[5 + BitmapData.Stride] * ConvertMatrix.Pixel) +
                                (sourcePointer[8 + BitmapData.Stride] * ConvertMatrix.MidRight) +
                                (sourcePointer[2 + StrideSource] * ConvertMatrix.BottomLeft) +
                                (sourcePointer[5 + StrideSource] * ConvertMatrix.BottomMid) +
                                (sourcePointer[8 + StrideSource] * ConvertMatrix.BottomRight))
                               / ConvertMatrix.Factor) + ConvertMatrix.Offset);

            if (pixel < 0) pixel = 0;
            if (pixel > 255) pixel = 255;
            return (byte)pixel;
        }

        private unsafe byte GetGreenPixel(byte* sourcePointer)
        {
            var pixel = ((((sourcePointer[1] * ConvertMatrix.TopLeft) +
                                (sourcePointer[4] * ConvertMatrix.TopMid) +
                                (sourcePointer[7] * ConvertMatrix.TopRight) +
                                (sourcePointer[1 + BitmapData.Stride] * ConvertMatrix.MidLeft) +
                                (sourcePointer[4 + BitmapData.Stride] * ConvertMatrix.Pixel) +
                                (sourcePointer[7 + BitmapData.Stride] * ConvertMatrix.MidRight) +
                                (sourcePointer[1 + StrideSource] * ConvertMatrix.BottomLeft) +
                                (sourcePointer[4 + StrideSource] * ConvertMatrix.BottomMid) +
                                (sourcePointer[7 + StrideSource] * ConvertMatrix.BottomRight))
                               / ConvertMatrix.Factor) + ConvertMatrix.Offset);

            if (pixel < 0) pixel = 0;
            if (pixel > 255) pixel = 255;
            return (byte)pixel;
        }

        private unsafe byte GetBluePixel(byte* sourcePointer)
        {
            var pixel = ((((sourcePointer[0] * ConvertMatrix.TopLeft) +
                                (sourcePointer[3] * ConvertMatrix.TopMid) +
                                (sourcePointer[6] * ConvertMatrix.TopRight) +
                                (sourcePointer[0 + BitmapData.Stride] * ConvertMatrix.MidLeft) +
                                (sourcePointer[3 + BitmapData.Stride] * ConvertMatrix.Pixel) +
                                (sourcePointer[6 + BitmapData.Stride] * ConvertMatrix.MidRight) +
                                (sourcePointer[0 + StrideSource] * ConvertMatrix.BottomLeft) +
                                (sourcePointer[3 + StrideSource] * ConvertMatrix.BottomMid) +
                                (sourcePointer[6 + StrideSource] * ConvertMatrix.BottomRight))
                               / ConvertMatrix.Factor) + ConvertMatrix.Offset);

            if (pixel < 0) pixel = 0;
            if (pixel > 255) pixel = 255;
            return (byte)pixel;
        }
    }
}
