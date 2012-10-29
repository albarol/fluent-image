namespace ImageNet.Core.Filtering.Hsls
{
    public interface IHslFilters
    {
        IFilter Brightness(int luminance);
        IFilter Contrast(sbyte factor);
        IFilter Hue(int hue);
        IFilter Saturation(float saturation);
    }
}
