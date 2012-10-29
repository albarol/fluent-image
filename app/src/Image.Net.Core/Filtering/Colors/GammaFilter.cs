using System;

namespace ImageNet.Core.Filtering.Colors
{
    internal class GammaFilter : BaseFilter
    {
        private readonly double red;
        private readonly double green;
        private readonly double blue;
        
        public GammaFilter(double red, double green, double blue)
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

            var redGamma = new byte[256];
            var greenGamma = new byte[256];
            var blueGamma = new byte[256];

            for (int index = 0; index < redGamma.Length; ++index)
            {
                redGamma[index] = CalculateGamma(index, red);
                greenGamma[index] = CalculateGamma(index, green);
                blueGamma[index] = CalculateGamma(index, blue);
            }

            byte* pointer = (byte*)Scan.ToPointer();

            for (int y = 0; y < Bitmap.Height; ++y)
            {
                for (int x = 0; x < Bitmap.Width; ++x)
                {
                    pointer[Rgb.RedPixel] = redGamma[pointer[Rgb.RedPixel]];
                    pointer[Rgb.GreenPixel] = greenGamma[pointer[Rgb.GreenPixel]];
                    pointer[Rgb.BluePixel] = blueGamma[pointer[Rgb.BluePixel]];
                    pointer += 3;
                }
                pointer += Offset;
            }
            Bitmap.UnlockBits(BitmapData);
            return true;
        }

        private byte CalculateGamma(int index, double value)
        {
            return (byte) Math.Min(255, (int) ((255.0*Math.Pow(index/255.0, 1.0/value)) + 0.5));
        }

        private bool IsValidRange(double value)
        {
            return value < .2 || value > 5;
        }
    }
}
