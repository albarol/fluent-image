using System;

namespace ImageNet.Core.Filtering.Colors
{
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
            if (IsValidRange(red)) return false;
            if (IsValidRange(green)) return false;
            if (IsValidRange(blue)) return false;

            byte* pointer = (byte*) Scan.ToPointer();

            for (int y = 0; y < Bitmap.Height; ++y)
            {
                for (int x = 0; x < Bitmap.Width; ++x)
                {
                    pointer[Rgb.RedPixel] = CalculateColor(pointer[Rgb.RedPixel], red);
                    pointer[Rgb.GreenPixel] = CalculateColor(pointer[Rgb.GreenPixel], green);
                    pointer[Rgb.BluePixel] = CalculateColor(pointer[Rgb.BluePixel], blue);
                    pointer += PixelSize;
                }
                pointer += Offset;
            }
            Bitmap.UnlockBits(BitmapData);
            return true;
        }

        private bool IsValidRange(int value)
        {
            return value < -255 || value > 255;
        }

        private byte CalculateColor(int pointer, int color)
        {
            int pixel = pointer + color;
            pixel = Math.Max(pixel, 0);
            return (byte)Math.Min(255, pixel);
        }
    }
}
