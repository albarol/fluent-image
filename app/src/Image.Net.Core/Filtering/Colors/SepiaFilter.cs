namespace ImageNet.Core.Filtering.Colors
{
    internal class SepiaFilter : BaseFilter
    {
        private const float RedCoefficient = 0.299f;
        private const float GreenCoefficient = 0.587f;
        private const float BlueCoefficient = 0.114f;
        
        protected override unsafe bool ApplyFilter()
        {
            var pointer = (byte*)Scan.ToPointer();
            for (int y = 0; y < Bitmap.Height; ++y)
            {
                for (int x = 0; x < Bitmap.Width; ++x)
                {
                    var sepia = CalculateSepiaToPixel(pointer);
                    pointer[Rgb.RedPixel] = (byte)((sepia > 206) ? 255 : sepia + 49);
                    pointer[Rgb.GreenPixel] = (byte)((sepia < 14) ? 0 : sepia - 14);
                    pointer[Rgb.BluePixel] = (byte)((sepia < 56) ? 0 : sepia - 56);
                    pointer += PixelSize;
                }
                pointer += Offset;
            }
            Bitmap.UnlockBits(BitmapData);
            return true;
        }

        private static unsafe byte CalculateSepiaToPixel(byte* pointer)
        {
            return (byte)((RedCoefficient * pointer[Rgb.RedPixel]) 
                          + (GreenCoefficient * pointer[Rgb.GreenPixel]) 
                          + BlueCoefficient * pointer[Rgb.BluePixel]);
        }
    }
}

