namespace ImageNet.Filtering.Hsls
{
    using System;
    using System.Drawing;

    using ImageNet.Filtering;

    internal class SaturationFilter : BaseFilter
    {
        private readonly float saturation;

        public SaturationFilter(float saturation)
        {
            this.saturation = Math.Max(-1.0f, Math.Min(1.0f, saturation));
        }

        protected override unsafe bool ApplyFilter()
        {
            int pixelSize = Image.GetPixelFormatSize(this.Bitmap.PixelFormat) / 8;
            byte* pointer = (byte*)this.Scan.ToPointer();

            for (int y = 0; y < this.Bitmap.Height; ++y)
            {
                for (int x = 0; x < this.Bitmap.Width; ++x)
                {
                    var rgb = new Rgb
                    {
                        Red = pointer[Rgb.RedPixel],
                        Green = pointer[Rgb.GreenPixel],
                        Blue = pointer[Rgb.BluePixel]
                    };

                    var hsl = Hsl.FromRgb(rgb);
                    hsl.Saturation = this.saturation;
                    rgb = hsl.ToRgb();

                    pointer[Rgb.RedPixel] = rgb.Red;
                    pointer[Rgb.GreenPixel] = rgb.Green;
                    pointer[Rgb.BluePixel] = rgb.Blue;
                    pointer += pixelSize;
                }

                pointer += this.Offset;

            }
            return true;
        }
    }
}
