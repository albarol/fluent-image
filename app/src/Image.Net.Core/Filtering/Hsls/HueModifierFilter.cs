namespace ImageNet.Core.Filtering.Hsls
{
    using System;
    using System.Drawing;

    internal class HueModifierFilter : BaseFilter
    {
        private readonly int hue;

        public HueModifierFilter(int hue)
        {
            this.hue = Math.Max(0, Math.Min(359, hue));
        }

        protected override unsafe bool ApplyFilter()
        {
            int pixelSize = Image.GetPixelFormatSize(Bitmap.PixelFormat) / 8;
            byte* pointer = (byte*)Scan.ToPointer();

            for (int y = 0; y < Bitmap.Height; ++y)
            {
                for (int x = 0; x < Bitmap.Width; ++x)
                {
                    var rgb = new Rgb
                    {
                        Red = pointer[Rgb.RedPixel],
                        Green = pointer[Rgb.GreenPixel],
                        Blue = pointer[Rgb.BluePixel]
                    };

                    var hsl = Hsl.FromRgb(rgb);
                    hsl.Hue = hue;
                    rgb = hsl.ToRgb();

                    pointer[Rgb.RedPixel] = rgb.Red;
                    pointer[Rgb.GreenPixel] = rgb.Green;
                    pointer[Rgb.BluePixel] = rgb.Blue;
                    pointer += pixelSize;
                }
                pointer += Offset;
            }
            return true;
        }
    }
}
