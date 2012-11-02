namespace ImageNet.Core.Filtering.Edges
{
    using System;

    internal class EdgeDetectDifferenceFilter : MatrixFilter
    {
        private readonly byte threshold;

        public EdgeDetectDifferenceFilter(byte threshold)
        {
            this.threshold = threshold;
        }
        
        protected override unsafe bool ApplyFilter()
        {
            var pointer = (byte*)BitmapData.Scan0.ToPointer();
            var sourcePointer = (byte*)BitmapDataSource.Scan0.ToPointer();

            int maxWidth = Bitmap.Width * PixelSize;

            pointer += BitmapData.Stride;
            sourcePointer += BitmapData.Stride;

            for (int row = 1; row < Bitmap.Height - 1; ++row)
            {
                pointer += this.PixelSize;
                sourcePointer += this.PixelSize;

                for (int pixel = PixelSize; pixel < maxWidth - this.PixelSize; ++pixel)
                {
                    pointer[Rgb.BluePixel] = this.GetHigherPixel(sourcePointer);
                    ++pointer;
                    ++sourcePointer;
                }

                pointer += this.PixelSize + this.Offset;
                sourcePointer += this.PixelSize + this.Offset;
            }

            Bitmap.UnlockBits(this.BitmapData);
            BitmapSource.UnlockBits(this.BitmapDataSource);

            return true;
        }

        private unsafe byte GetHigherPixel(byte* sourcePointer)
        {
            int higherPixel = Math.Abs((sourcePointer - BitmapData.Stride + PixelSize)[0] - (sourcePointer + BitmapData.Stride - PixelSize)[0]);
            int currentPixel = Math.Abs((sourcePointer + BitmapData.Stride + PixelSize)[0] - (sourcePointer - BitmapData.Stride - PixelSize)[0]);
            
            if (currentPixel > higherPixel)
            {
                higherPixel = currentPixel;
            }

            currentPixel = Math.Abs((sourcePointer - BitmapData.Stride)[0] - (sourcePointer + BitmapData.Stride)[0]);
            
            if (currentPixel > higherPixel)
            {
                higherPixel = currentPixel;
            }

            currentPixel = Math.Abs((sourcePointer + 3)[0] - (sourcePointer - 3)[0]);
            
            if (currentPixel > higherPixel)
            {
                higherPixel = currentPixel;
            }

            if (higherPixel < this.threshold)
            {
                higherPixel = 0;
            }

            return (byte)higherPixel;
        }
    }
}
