namespace ImageNet.Filtering.Edges
{
    using System;

    using ImageNet.Filtering;

    internal class EdgeDetectDifferenceFilter : MatrixFilter
    {
        private readonly byte threshold;

        public EdgeDetectDifferenceFilter(byte threshold)
        {
            this.threshold = threshold;
        }
        
        protected override unsafe bool ApplyFilter()
        {
            var pointer = (byte*)this.BitmapData.Scan0.ToPointer();
            var sourcePointer = (byte*)this.BitmapDataSource.Scan0.ToPointer();

            int maxWidth = this.Bitmap.Width * this.PixelSize;

            pointer += this.BitmapData.Stride;
            sourcePointer += this.BitmapData.Stride;

            for (int row = 1; row < this.Bitmap.Height - 1; ++row)
            {
                pointer += this.PixelSize;
                sourcePointer += this.PixelSize;

                for (int pixel = this.PixelSize; pixel < maxWidth - this.PixelSize; ++pixel)
                {
                    pointer[Rgb.BluePixel] = this.GetHigherPixel(sourcePointer);
                    ++pointer;
                    ++sourcePointer;
                }

                pointer += this.PixelSize + this.Offset;
                sourcePointer += this.PixelSize + this.Offset;
            }

            this.Bitmap.UnlockBits(this.BitmapData);
            this.BitmapSource.UnlockBits(this.BitmapDataSource);

            return true;
        }

        private unsafe byte GetHigherPixel(byte* sourcePointer)
        {
            int higherPixel = Math.Abs((sourcePointer - this.BitmapData.Stride + this.PixelSize)[0] - (sourcePointer + this.BitmapData.Stride - this.PixelSize)[0]);
            int currentPixel = Math.Abs((sourcePointer + this.BitmapData.Stride + this.PixelSize)[0] - (sourcePointer - this.BitmapData.Stride - this.PixelSize)[0]);
            
            if (currentPixel > higherPixel)
            {
                higherPixel = currentPixel;
            }

            currentPixel = Math.Abs((sourcePointer - this.BitmapData.Stride)[0] - (sourcePointer + this.BitmapData.Stride)[0]);
            
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
