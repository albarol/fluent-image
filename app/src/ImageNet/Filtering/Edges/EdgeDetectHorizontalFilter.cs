namespace ImageNet.Filtering.Edges
{
    using ImageNet.Filtering;

    internal class EdgeDetectHorizontalFilter : MatrixFilter
    {
        private int DoublePixelSize
        {
            get { return this.PixelSize * 2; }
        }

        private int TriplePixelSize
        {
            get { return this.PixelSize * 3; }
        }
        
        protected override unsafe bool ApplyFilter()
        {
            byte* pointer = (byte*)this.BitmapData.Scan0.ToPointer();
            byte* sourcePointer = (byte*)this.BitmapDataSource.Scan0.ToPointer();

            int maxWidth = this.Bitmap.Width * this.PixelSize;

            pointer += this.BitmapData.Stride;
            sourcePointer += this.BitmapData.Stride;

            for (int row = 1; row < this.Bitmap.Height - 1; ++row)
            {
                pointer += this.TriplePixelSize;
                sourcePointer += this.TriplePixelSize;

                for (int pixel = this.TriplePixelSize; pixel < maxWidth - this.TriplePixelSize; ++pixel)
                {
                    var currentPixel = pointer + this.BitmapData.Stride;
                    currentPixel[Rgb.BluePixel] = this.GetHorizontalPixel(sourcePointer);
                    ++pointer;
                    ++sourcePointer;
                }

                pointer += this.TriplePixelSize + this.Offset;
                sourcePointer += this.TriplePixelSize + this.Offset;
            }

            this.Bitmap.UnlockBits(this.BitmapData);
            this.BitmapSource.UnlockBits(this.BitmapDataSource);

            return true;
        }

        private unsafe byte GetHorizontalPixel(byte* sourcePointer)
        {
            int currentPixel = (sourcePointer + this.BitmapData.Stride - this.TriplePixelSize)[Rgb.BluePixel] +
                        (sourcePointer + this.BitmapData.Stride - this.DoublePixelSize)[Rgb.BluePixel] +
                        (sourcePointer + this.BitmapData.Stride - this.PixelSize)[Rgb.BluePixel] +
                        (sourcePointer + this.BitmapData.Stride)[Rgb.BluePixel] +
                        (sourcePointer + this.BitmapData.Stride + this.PixelSize)[Rgb.BluePixel] +
                        (sourcePointer + this.BitmapData.Stride + this.DoublePixelSize)[Rgb.BluePixel] +
                        (sourcePointer + this.BitmapData.Stride + this.TriplePixelSize)[Rgb.BluePixel] -
                        (sourcePointer - this.BitmapData.Stride - this.TriplePixelSize)[Rgb.BluePixel] -
                        (sourcePointer - this.BitmapData.Stride - this.DoublePixelSize)[Rgb.BluePixel] -
                        (sourcePointer - this.BitmapData.Stride - this.PixelSize)[Rgb.BluePixel] -
                        (sourcePointer - this.BitmapData.Stride)[Rgb.BluePixel] -
                        (sourcePointer - this.BitmapData.Stride + this.PixelSize)[Rgb.BluePixel] -
                        (sourcePointer - this.BitmapData.Stride + this.DoublePixelSize)[Rgb.BluePixel] -
                        (sourcePointer - this.BitmapData.Stride + this.TriplePixelSize)[Rgb.BluePixel];
            
            return this.EnsureLimit(currentPixel);
        }

        private unsafe byte EnsureLimit(int pixel)
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
