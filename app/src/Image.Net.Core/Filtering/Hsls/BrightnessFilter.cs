namespace ImageNet.Core.Filtering.Hsls
{
    internal class BrightnessFilter : BaseFilter
    {
        private readonly float brightness;

        public BrightnessFilter(float brightness)
        {
            this.brightness = brightness;
        }

        protected override unsafe bool ApplyFilter()
        {
            var pointer = (byte*)(void*)Scan;
            int width = Bitmap.Width * PixelSize;
            for (int row = 0; row < Bitmap.Height; ++row)
            {
                for (int line = 0; line < width; ++line)
                {
                    pointer[Rgb.BluePixel] = this.GetBrightness(pointer[Rgb.BluePixel]);
                    ++pointer;
                }

                pointer += Offset;
            }

            Bitmap.UnlockBits(BitmapData);
            return true;
        }

        private byte GetBrightness(int pointer)
        {
            float currentBrigthness = pointer + this.brightness;
            return this.EnsureLimit(currentBrigthness);
        }

        private byte EnsureLimit(float brigthness)
        {
            if (brigthness < 0)
            {
                brigthness = 0;
            }

            if (brigthness > 255)
            {
                brigthness = 255;
            }

            return (byte)brigthness;
        }
    }
}
