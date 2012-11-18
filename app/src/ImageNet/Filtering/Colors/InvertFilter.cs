namespace ImageNet.Filtering.Colors
{
    using ImageNet.Filtering;

    internal class InvertFilter : BaseFilter
    {
        protected override unsafe bool ApplyFilter()
        {
            var pointer = (byte*)(void*)this.Scan;
            int width = this.Bitmap.Width * this.PixelSize;
            for (int y = 0; y < this.Bitmap.Height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    pointer[Rgb.BluePixel] = (byte)(255 - pointer[Rgb.BluePixel]);
                    ++pointer;
                }
                pointer += this.Offset;
            }
            this.Bitmap.UnlockBits(this.BitmapData);
            return true;
        }
    }
}
