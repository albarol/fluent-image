namespace ImageNet.Core.Filtering.Edges
{
    using System;

    internal class EdgetDetectHomogenityFilter : MatrixFilter
    {
        private readonly byte threshold;

        public EdgetDetectHomogenityFilter(byte threshold)
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
                    pointer[Rgb.BluePixel] = this.GetHigherPixel(pointer, sourcePointer);
                    ++pointer;
                    ++sourcePointer;
                }

                pointer += PixelSize + Offset;
                sourcePointer += PixelSize + Offset;
            }

            Bitmap.UnlockBits(BitmapData);
            BitmapSource.UnlockBits(BitmapDataSource);

            return true;
        }

        public unsafe byte GetHigherPixel(byte* pointer, byte* sourcePointer)
        {
            int higherPixel = Math.Abs(sourcePointer[0] - (sourcePointer + BitmapData.Stride - PixelSize)[0]);
            int currentPixel = Math.Abs(sourcePointer[0] - (sourcePointer + BitmapData.Stride)[0]);

            higherPixel = this.EnsureLimit(currentPixel, higherPixel);
            
            currentPixel = Math.Abs(sourcePointer[0] - (sourcePointer + BitmapData.Stride + PixelSize)[0]);
            higherPixel = this.EnsureLimit(currentPixel, higherPixel);

            currentPixel = Math.Abs(sourcePointer[0] - (sourcePointer - BitmapData.Stride)[0]);
            higherPixel = this.EnsureLimit(currentPixel, higherPixel);

            currentPixel = Math.Abs(sourcePointer[0] - (sourcePointer + BitmapData.Stride)[0]);
            higherPixel = this.EnsureLimit(currentPixel, higherPixel);

            currentPixel = Math.Abs(sourcePointer[0] - (sourcePointer - BitmapData.Stride - PixelSize)[0]);
            higherPixel = this.EnsureLimit(currentPixel, higherPixel);

            currentPixel = Math.Abs(sourcePointer[0] - (sourcePointer - BitmapData.Stride)[0]);
            higherPixel = this.EnsureLimit(currentPixel, higherPixel);

            currentPixel = Math.Abs(sourcePointer[0] - (sourcePointer - BitmapData.Stride + PixelSize)[0]);
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
