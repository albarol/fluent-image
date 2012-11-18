namespace ImageNet.Filtering.Edges
{
    using System;

    using ImageNet.Filtering;

    internal class EdgetDetectHomogenityFilter : MatrixFilter
    {
        private readonly byte threshold;

        public EdgetDetectHomogenityFilter(byte threshold)
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
                    pointer[Rgb.BluePixel] = this.GetHigherPixel(pointer, sourcePointer);
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

        public unsafe byte GetHigherPixel(byte* pointer, byte* sourcePointer)
        {
            int higherPixel = Math.Abs(sourcePointer[0] - (sourcePointer + this.BitmapData.Stride - this.PixelSize)[0]);
            int currentPixel = Math.Abs(sourcePointer[0] - (sourcePointer + this.BitmapData.Stride)[0]);

            higherPixel = this.EnsureLimit(currentPixel, higherPixel);
            
            currentPixel = Math.Abs(sourcePointer[0] - (sourcePointer + this.BitmapData.Stride + this.PixelSize)[0]);
            higherPixel = this.EnsureLimit(currentPixel, higherPixel);

            currentPixel = Math.Abs(sourcePointer[0] - (sourcePointer - this.BitmapData.Stride)[0]);
            higherPixel = this.EnsureLimit(currentPixel, higherPixel);

            currentPixel = Math.Abs(sourcePointer[0] - (sourcePointer + this.BitmapData.Stride)[0]);
            higherPixel = this.EnsureLimit(currentPixel, higherPixel);

            currentPixel = Math.Abs(sourcePointer[0] - (sourcePointer - this.BitmapData.Stride - this.PixelSize)[0]);
            higherPixel = this.EnsureLimit(currentPixel, higherPixel);

            currentPixel = Math.Abs(sourcePointer[0] - (sourcePointer - this.BitmapData.Stride)[0]);
            higherPixel = this.EnsureLimit(currentPixel, higherPixel);

            currentPixel = Math.Abs(sourcePointer[0] - (sourcePointer - this.BitmapData.Stride + this.PixelSize)[0]);
            higherPixel = this.EnsureLimit(currentPixel, higherPixel);

            if (higherPixel < this.threshold)
            {
                higherPixel = 0;
            }

            return (byte)higherPixel;
        }

        private int EnsureLimit(int currentPixel, int higherPixel)
        {
            return currentPixel > higherPixel ? higherPixel : currentPixel;
        }
    }
}
