namespace ImageNet.Core.Filtering.Edges
{
    internal class EdgeDetectVerticalFilter : MatrixFilter
    {
        private int DoubleStride
        {
            get { return BitmapData.Stride * 2; }
        }

        private int TripleStride
        {
            get { return BitmapData.Stride * 3; }
        }
        
        protected override unsafe bool ApplyFilter()
        {
            byte* pointer = (byte*)BitmapData.Scan0.ToPointer();
            byte* sourcePointer = (byte*)BitmapDataSource.Scan0.ToPointer();

            int maxWidth = Bitmap.Width * PixelSize;

            pointer += this.TripleStride;
            sourcePointer += this.TripleStride;

            for (int row = PixelSize; row < Bitmap.Height - PixelSize; ++row)
            {
                pointer += PixelSize;
                sourcePointer += PixelSize;

                for (int pixel = PixelSize; pixel < maxWidth - PixelSize; ++pixel)
                {
                    pointer[Rgb.BluePixel] = this.GetVerticalPixel(sourcePointer);
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

        private unsafe byte GetVerticalPixel(byte* sourcePointer)
        {
            var currentPixel = (sourcePointer + this.TripleStride + this.PixelSize)[0] +
                              (sourcePointer + this.DoubleStride + this.PixelSize)[0] +
                              (sourcePointer + BitmapData.Stride + 3)[0] +
                              (sourcePointer + PixelSize)[0] +
                              (sourcePointer - BitmapData.Stride + PixelSize)[0] +
                              (sourcePointer - this.DoubleStride + this.PixelSize)[0] +
                              (sourcePointer - this.TripleStride + this.PixelSize)[0] -
                              (sourcePointer + this.TripleStride - this.PixelSize)[0] -
                              (sourcePointer + this.DoubleStride - this.PixelSize)[0] -
                              (sourcePointer + BitmapData.Stride - PixelSize)[0] -
                              (sourcePointer - PixelSize)[0] -
                              (sourcePointer - BitmapData.Stride - PixelSize)[0] -
                              (sourcePointer - this.DoubleStride - this.PixelSize)[0] -
                              (sourcePointer - this.TripleStride - this.PixelSize)[0];

            return this.EnsureLimit(currentPixel);
        }

        private byte EnsureLimit(int pixel)
        {
            if (pixel < 0)
            {
                pixel = 0;
            }

            if (pixel > 255)
            {
                pixel = 255;
            }

            return (byte)pixel;
        }

    }
}
