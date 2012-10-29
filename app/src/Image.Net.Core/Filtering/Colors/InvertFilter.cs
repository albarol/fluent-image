namespace ImageNet.Core.Filtering.Colors
{
    internal class InvertFilter : BaseFilter
    {
        protected override unsafe bool ApplyFilter()
        {
            var pointer = (byte*)(void*)Scan;
            int width = Bitmap.Width * PixelSize;
            for (int y = 0; y < Bitmap.Height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    pointer[Rgb.BluePixel] = (byte)(255 - pointer[Rgb.BluePixel]);
                    ++pointer;
                }
                pointer += Offset;
            }
            Bitmap.UnlockBits(BitmapData);
            return true;
        }
    }
}
