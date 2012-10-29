namespace ImageNet.Core.Filtering.Hsls
{
    internal class ContrastFilter : BaseFilter
    {
        private readonly sbyte factor;

        public ContrastFilter(sbyte factor)
        {
            this.factor = factor;
        }

        private double Contrast
        {
            get
            {
                double contrast = (100.0 + this.factor) / 100.0;
                contrast *= contrast;
                return contrast;
            }
        }

        private bool IsValidFactor
        {
            get { return this.factor >= -100 && this.factor <= 100; }
        }

        protected override unsafe bool ApplyFilter()
        {
            if (!this.IsValidFactor)
            {
                return false;
            }

            byte* pointer = (byte*)Scan.ToPointer();

            for (int row = 0; row < Bitmap.Height; ++row)
            {
                for (int line = 0; line < Bitmap.Width; ++line)
                {
                    pointer[Rgb.RedPixel] = this.ProcessContrast(pointer[Rgb.RedPixel]);
                    pointer[Rgb.GreenPixel] = this.ProcessContrast(pointer[Rgb.GreenPixel]);
                    pointer[Rgb.BluePixel] = this.ProcessContrast(pointer[Rgb.BluePixel]);
                    pointer += PixelSize;
                }

                pointer += Offset;
            }

            Bitmap.UnlockBits(BitmapData);
            return true;
        }

        private byte ProcessContrast(int pointer)
        {
            double pixel = pointer / 255.0;
            pixel -= 0.5;
            pixel *= this.Contrast;
            pixel += 0.5;
            pixel *= 255;
            return this.EnsureLimit(pixel);
        }

        private byte EnsureLimit(double pixel)
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
