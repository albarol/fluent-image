namespace ImageNet.Core.Filtering.Colors
{
    internal class GrayscaleFilter : BaseFilter
    {
        protected double RedCoefficient = .299;
        protected double GreenCoefficient = .587;
        protected double BlueCoefficient = .114;

        protected GrayscaleFilter(double redCoefficient, double greenCoefficient, double blueCoefficient)
        {
            RedCoefficient = redCoefficient;
            GreenCoefficient = greenCoefficient;
            BlueCoefficient = blueCoefficient;
        }

        public GrayscaleFilter() { }
        
        protected override unsafe bool ApplyFilter()
        {
            var pointer = (byte*) Scan.ToPointer();
            for (int y = 0; y < Bitmap.Height; ++y)
            {
                for (int x = 0; x < Bitmap.Width; ++x)
                {
                    var grayscale = GetGrayscaleToPixel(pointer);
                    pointer[Rgb.RedPixel] = grayscale;
                    pointer[Rgb.GreenPixel] = grayscale;
                    pointer[Rgb.BluePixel] = grayscale;
                    pointer += PixelSize;
                }
                pointer += Offset;
            }
            Bitmap.UnlockBits(BitmapData);
            return true;
        }

        private unsafe byte GetGrayscaleToPixel(byte* pointer)
        {
            return (byte)((RedCoefficient * pointer[Rgb.RedPixel]) +
                          (GreenCoefficient * pointer[Rgb.GreenPixel]) +
                          (BlueCoefficient * pointer[Rgb.BluePixel]));
        }
    }
}
