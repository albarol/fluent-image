namespace ImageNet.Filtering.Colors
{
    using System;
    using System.Linq;

    using ImageNet.Filtering;

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
            if (this.ContainsInvalidPixel())
            {
                return false;
            }
            
            var redGamma = new byte[256];
            var greenGamma = new byte[256];
            var blueGamma = new byte[256];

            for (int index = 0; index < redGamma.Length; ++index)
            {
                redGamma[index] = this.CalculateGamma(index, this.red);
                greenGamma[index] = this.CalculateGamma(index, this.green);
                blueGamma[index] = this.CalculateGamma(index, this.blue);
            }

            byte* pointer = (byte*)this.Scan.ToPointer();

            for (int y = 0; y < this.Bitmap.Height; ++y)
            {
                for (int x = 0; x < this.Bitmap.Width; ++x)
                {
                    pointer[Rgb.RedPixel] = redGamma[pointer[Rgb.RedPixel]];
                    pointer[Rgb.GreenPixel] = greenGamma[pointer[Rgb.GreenPixel]];
                    pointer[Rgb.BluePixel] = blueGamma[pointer[Rgb.BluePixel]];
                    pointer += 3;
                }
                pointer += this.Offset;
            }
            this.Bitmap.UnlockBits(this.BitmapData);
            return true;
        }

        private byte CalculateGamma(int index, double value)
        {
            return (byte)Math.Min(255, (int)((255.0 * Math.Pow(index / 255.0, 1.0 / value)) + 0.5));
        }

        private bool ContainsInvalidPixel()
        {
            var rgb = new[] { this.red, this.blue, this.green };
            return rgb.Any(item => item < .2 || item > 5);
        }
    }
}
