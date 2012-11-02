namespace ImageNet.Core.Filtering.Colors
{
    internal class GrayscaleFilter : BaseFilter
    {
        public GrayscaleFilter()
        {
            this.RedCoefficient = .299;
            this.GreenCoefficient = .587;
            this.BlueCoefficient = .114;
        }
        
        protected GrayscaleFilter(double redCoefficient, double greenCoefficient, double blueCoefficient)
        {
            this.RedCoefficient = redCoefficient;
            this.GreenCoefficient = greenCoefficient;
            this.BlueCoefficient = blueCoefficient;
        }

        protected double RedCoefficient { get; set; }
        protected double GreenCoefficient { get; set; }
        protected double BlueCoefficient { get; set; }
        
        protected override unsafe bool ApplyFilter()
        {
            var pointer = (byte*) Scan.ToPointer();
            for (int y = 0; y < Bitmap.Height; ++y)
            {
                for (int x = 0; x < Bitmap.Width; ++x)
                {
                    var grayscale = this.GetGrayscaleToPixel(pointer);
                    pointer[Rgb.RedPixel] = grayscale;
                    pointer[Rgb.GreenPixel] = grayscale;
                    pointer[Rgb.BluePixel] = grayscale;
                    pointer += this.PixelSize;
                }
                pointer += this.Offset;
            }
            Bitmap.UnlockBits(this.BitmapData);
            return true;
        }

        private unsafe byte GetGrayscaleToPixel(byte* pointer)
        {
            return (byte)((this.RedCoefficient * pointer[Rgb.RedPixel]) +
                          (this.GreenCoefficient * pointer[Rgb.GreenPixel]) +
                          (this.BlueCoefficient * pointer[Rgb.BluePixel]));
        }
    }
}
