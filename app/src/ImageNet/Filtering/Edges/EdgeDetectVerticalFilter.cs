namespace ImageNet.Filtering.Edges
{
    using ImageNet.Filtering;

    internal class EdgeDetectVerticalFilter : MatrixFilter
    {
        private int DoubleStride
        {
            get { return this.BitmapData.Stride * 2; }
        }

        private int TripleStride
        {
            get { return this.BitmapData.Stride * 3; }
        }
        
        protected override unsafe bool ApplyFilter()
        {
            byte* pointer = (byte*)this.BitmapData.Scan0.ToPointer();
            byte* sourcePointer = (byte*)this.BitmapDataSource.Scan0.ToPointer();

            int maxWidth = this.Bitmap.Width * this.PixelSize;

            pointer += this.TripleStride;
            sourcePointer += this.TripleStride;

            for (int row = this.PixelSize; row < this.Bitmap.Height - this.PixelSize; ++row)
            {
                pointer += this.PixelSize;
                sourcePointer += this.PixelSize;

                for (int pixel = this.PixelSize; pixel < maxWidth - this.PixelSize; ++pixel)
                {
                    pointer[Rgb.BluePixel] = this.GetVerticalPixel(sourcePointer);
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

        private unsafe byte GetVerticalPixel(byte* sourcePointer)
        {
            var currentPixel = (sourcePointer + this.TripleStride + this.PixelSize)[0] +
                              (sourcePointer + this.DoubleStride + this.PixelSize)[0] +
                              (sourcePointer + this.BitmapData.Stride + 3)[0] +
                              (sourcePointer + this.PixelSize)[0] +
                              (sourcePointer - this.BitmapData.Stride + this.PixelSize)[0] +
                              (sourcePointer - this.DoubleStride + this.PixelSize)[0] +
                              (sourcePointer - this.TripleStride + this.PixelSize)[0] -
                              (sourcePointer + this.TripleStride - this.PixelSize)[0] -
                              (sourcePointer + this.DoubleStride - this.PixelSize)[0] -
                              (sourcePointer + this.BitmapData.Stride - this.PixelSize)[0] -
                              (sourcePointer - this.PixelSize)[0] -
                              (sourcePointer - this.BitmapData.Stride - this.PixelSize)[0] -
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
