namespace ImageNet.Filtering.Edges
{
    using System;

    using ImageNet.Filtering;

    internal class EdgeEnhanceFilter : MatrixFilter
    {
        private readonly byte threshold;

        public EdgeEnhanceFilter(byte threshold)
        {
            this.threshold = threshold;
        }

        protected override unsafe bool ApplyFilter()
        {
            byte* pointer = (byte*)this.Scan.ToPointer();
            byte* sourcePointer = (byte*)this.ScanSource.ToPointer();

            int maxWidth = this.Bitmap.Width * this.PixelSize;

            pointer += this.BitmapData.Stride;
            sourcePointer += this.BitmapData.Stride;

            for (int row = 1; row < this.Bitmap.Height - 1; ++row)
            {
                pointer += this.PixelSize;
                sourcePointer += this.PixelSize;

                for (int pixel = this.PixelSize; pixel < maxWidth - this.PixelSize; ++pixel)
                {
                    int pixelMax = Math.Abs((sourcePointer - this.BitmapData.Stride + this.PixelSize)[0] - (sourcePointer + this.BitmapData.Stride - this.PixelSize)[0]);
                    int currentPixel = Math.Abs((sourcePointer + this.BitmapData.Stride + this.PixelSize)[0] - (sourcePointer - this.BitmapData.Stride - this.PixelSize)[0]);

                    if (currentPixel > pixelMax)
                    {
                        pixelMax = currentPixel;
                    }

                    currentPixel = Math.Abs((sourcePointer - this.BitmapData.Stride)[0] - (sourcePointer + this.BitmapData.Stride)[0]);

                    if (currentPixel > pixelMax)
                    {
                        pixelMax = currentPixel;
                    }

                    currentPixel = Math.Abs((sourcePointer + this.PixelSize)[0] - (sourcePointer - this.PixelSize)[0]);

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

                pointer += this.Offset + this.PixelSize;
                sourcePointer += this.Offset + this.PixelSize;
            }
            this.Bitmap.UnlockBits(this.BitmapData);
            this.BitmapSource.UnlockBits(this.BitmapDataSource);
            return true;
        }
    }
}
