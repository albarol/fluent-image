namespace ImageNet.Core.Filtering.Edges
{
    internal class EdgeDetectHorizontalFilter : MatrixFilter
    {
        private int DoublePixelSize
        {
            get { return PixelSize * 2; }
        }

        private int TriplePixelSize
        {
            get { return PixelSize * 3; }
        }
        
        protected override unsafe bool ApplyFilter()
        {
            byte* pointer = (byte*)BitmapData.Scan0.ToPointer();
            byte* sourcePointer = (byte*)BitmapDataSource.Scan0.ToPointer();

            int maxWidth = Bitmap.Width * PixelSize;

            pointer += BitmapData.Stride;
            sourcePointer += BitmapData.Stride;

            for (int row = 1; row < Bitmap.Height - 1; ++row)
            {
                pointer += this.TriplePixelSize;
                sourcePointer += this.TriplePixelSize;

                for (int pixel = this.TriplePixelSize; pixel < maxWidth - this.TriplePixelSize; ++pixel)
                {
                    var currentPixel = pointer + BitmapData.Stride;
                    currentPixel[Rgb.BluePixel] = this.GetHorizontalPixel(sourcePointer);
                    ++pointer;
                    ++sourcePointer;
                }

                pointer += this.TriplePixelSize + this.Offset;
                sourcePointer += this.TriplePixelSize + this.Offset;
            }

            Bitmap.UnlockBits(BitmapData);
            BitmapSource.UnlockBits(BitmapDataSource);

            return true;
        }

        private unsafe byte GetHorizontalPixel(byte* sourcePointer)
        {
            int currentPixel = (sourcePointer + this.BitmapData.Stride - this.TriplePixelSize)[Rgb.BluePixel] +
                        (sourcePointer + this.BitmapData.Stride - this.DoublePixelSize)[Rgb.BluePixel] +
                        (sourcePointer + BitmapData.Stride - PixelSize)[Rgb.BluePixel] +
                        (sourcePointer + BitmapData.Stride)[Rgb.BluePixel] +
                        (sourcePointer + BitmapData.Stride + PixelSize)[Rgb.BluePixel] +
                        (sourcePointer + this.BitmapData.Stride + this.DoublePixelSize)[Rgb.BluePixel] +
                        (sourcePointer + this.BitmapData.Stride + this.TriplePixelSize)[Rgb.BluePixel] -
                        (sourcePointer - this.BitmapData.Stride - this.TriplePixelSize)[Rgb.BluePixel] -
                        (sourcePointer - this.BitmapData.Stride - this.DoublePixelSize)[Rgb.BluePixel] -
                        (sourcePointer - BitmapData.Stride - PixelSize)[Rgb.BluePixel] -
                        (sourcePointer - BitmapData.Stride)[Rgb.BluePixel] -
                        (sourcePointer - BitmapData.Stride + PixelSize)[Rgb.BluePixel] -
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
