namespace ImageNet.Filtering.Hsls
{
    using ImageNet.Filtering;

    public interface IHslFilters
    {
        IFilter Brightness(int luminance);
        IFilter Contrast(sbyte factor);
        IFilter Hue(int hue);
        IFilter Saturation(float saturation);
    }
}
