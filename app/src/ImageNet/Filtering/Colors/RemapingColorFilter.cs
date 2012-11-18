namespace ImageNet.Filtering.Colors
{
    using System;
    using System.Linq;

    using ImageNet.Filtering;

    internal class RemapingColorFilter : BaseFilter
    {
        private readonly int red;
        private readonly int green;
        private readonly int blue;

        public RemapingColorFilter(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }
        
        protected override unsafe bool ApplyFilter()
        {
            if (this.ContainsInvalidPixel())
            {
                return false;
            }

            byte* pointer = (byte*)this.Scan.ToPointer();

            for (int y = 0; y < this.Bitmap.Height; ++y)
            {
                for (int x = 0; x < this.Bitmap.Width; ++x)
                {
                    pointer[Rgb.RedPixel] = this.CalculateColor(pointer[Rgb.RedPixel], this.red);
                    pointer[Rgb.GreenPixel] = this.CalculateColor(pointer[Rgb.GreenPixel], this.green);
                    pointer[Rgb.BluePixel] = this.CalculateColor(pointer[Rgb.BluePixel], this.blue);
                    pointer += this.PixelSize;
                }

                pointer += this.Offset;
            }

            this.Bitmap.UnlockBits(this.BitmapData);
            return true;
        }

        private bool ContainsInvalidPixel()
        {
            var rgb = new[] { this.red, this.blue, this.green };
            return rgb.Any(item => item < -255 || item > 255);
        }

        private byte CalculateColor(int pointer, int color)
        {
            int pixel = pointer + color;
            pixel = Math.Max(pixel, 0);
            return (byte)Math.Min(255, pixel);
        }
    }
}
