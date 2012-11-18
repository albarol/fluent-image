namespace ImageNet.Filtering.Colors
{
    internal class GrayscaleBt709Filter : GrayscaleFilter
    {
        public GrayscaleBt709Filter() : base(0.2125, 0.7154, 0.0721)
        {
        }
    }
}
