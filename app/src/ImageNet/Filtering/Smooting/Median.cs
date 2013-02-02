using System;

namespace ImageNet.Filtering.Smooting
{
    internal class Median : MatrixFilter
    {
        private int size;
        private byte[] red, green, blue;

        public Median(int size)
        {
            this.Size = size;
            this.red = new byte[Size * Size];
            this.green = new byte[Size * Size];
            this.blue = new byte[Size * Size];
        }

        public int Size
        {
            get { return size; }
            set { size = Math.Max(3, Math.Min(25, value | 1)); }
        }

        protected override unsafe bool ApplyFilter()
        {
            int sourceOffset = this.BitmapDataSource.Stride - this.BitmapData.Width * this.PixelSize;
            int destinationOffset = this.BitmapData.Stride - this.BitmapData.Width * this.PixelSize;

            int rangeRow, rangeColumn, currentPixel;
            int radius = size >> 1;
            int length;

            
            var source = (byte*) BitmapDataSource.Scan0.ToPointer();
            var destination = (byte*) BitmapData.Scan0.ToPointer();


            for (int row = 0; row < this.Bitmap.Height; row++)
            {
                for (int column = 0; column < this.Bitmap.Width; column++, source += PixelSize, destination += PixelSize)
                {
                    length = 0;

                    for (rangeRow = -radius; rangeRow <= radius; rangeRow++)
                    {
                        currentPixel = row + rangeRow;

                        if (currentPixel < 0)
                            continue;

                        if (currentPixel >= this.Bitmap.Height)
                            break;

                        for (rangeColumn = -radius; rangeColumn <= radius; rangeColumn++)
                        {
                            currentPixel = column + rangeColumn;

                            if (currentPixel < 0)
                                continue;

                            if (currentPixel < this.Bitmap.Width)
                            {
                                byte* pointer = &source[rangeRow * this.BitmapDataSource.Stride + rangeColumn * PixelSize];

                                red[length] = pointer[Rgb.RedPixel];
                                green[length] = pointer[Rgb.GreenPixel];
                                blue[length] = pointer[Rgb.BluePixel];
                                length++;
                            }
                        }
                    }

                    currentPixel = length >> 1;
                    GetMedian(destination, currentPixel, length);
                }
                source += sourceOffset;
                destination += destinationOffset;
            }
            return true;
        }

        private unsafe void GetMedian(byte* destination, int currentPixel, int length)
        {
            Array.Sort(red, 0, length);
            Array.Sort(green, 0, length);
            Array.Sort(blue, 0, length);

            destination[Rgb.RedPixel] = this.red[currentPixel];
            destination[Rgb.GreenPixel] = this.green[currentPixel];
            destination[Rgb.BluePixel] = this.blue[currentPixel];
        }
    }
}
