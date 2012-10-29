namespace ImageNet.Core.Filtering.Edges
{
    using System;

    internal class EdgeEnhanceFilter : MatrixFilter
    {
        private readonly byte threshold;

        public EdgeEnhanceFilter(byte threshold)
        {
            this.threshold = threshold;
        }

        protected override unsafe bool ApplyFilter()
        {
            byte* pointer = (byte*)Scan.ToPointer();
            byte* sourcePointer = (byte*)ScanSource.ToPointer();

            int maxWidth = Bitmap.Width * PixelSize;

            pointer += BitmapData.Stride;
            sourcePointer += BitmapData.Stride;

            for (int row = 1; row < Bitmap.Height - 1; ++row)
            {
                pointer += PixelSize;
                sourcePointer += PixelSize;

                for (int pixel = PixelSize; pixel < maxWidth - PixelSize; ++pixel)
                {
                    int pixelMax = Math.Abs((sourcePointer - BitmapData.Stride + PixelSize)[0] - (sourcePointer + BitmapData.Stride - PixelSize)[0]);
                    int currentPixel = Math.Abs((sourcePointer + BitmapData.Stride + PixelSize)[0] - (sourcePointer - BitmapData.Stride - PixelSize)[0]);

                    if (currentPixel > pixelMax)
                    {
                        pixelMax = currentPixel;
                    }

                    currentPixel = Math.Abs((sourcePointer - BitmapData.Stride)[0] - (sourcePointer + BitmapData.Stride)[0]);

                    if (currentPixel > pixelMax)
                    {
                        pixelMax = currentPixel;
                    }

                    currentPixel = Math.Abs((sourcePointer + PixelSize)[0] - (sourcePointer - PixelSize)[0]);

                    if (currentPixel > pixelMax)
                    {
                        pixelMax = currentPixel;
                    }

                    if (pixelMax > this.threshold && pixelMax > pointer[Rgb.BluePixel])
                    {
                        pointer[Rgb.BluePixel] = (byte)Math.Max(pointer[Rgb.BluePixel], pixelMax);
                    }

                    ++pointer;
                    ++sourcePointer;
                }

                pointer += Offset + PixelSize;
                sourcePointer += Offset + PixelSize;
            }
            Bitmap.UnlockBits(BitmapData);
            BitmapSource.UnlockBits(BitmapDataSource);
            return true;
        }
    }
}
