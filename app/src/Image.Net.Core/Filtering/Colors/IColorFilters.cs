namespace ImageNet.Core.Filtering.Colors
{
    public interface IColorFilters
    {
        IFilter Grayscale();
        IFilter GrayscaleRmy();
        IFilter GrayscaleBt709();
        IFilter GrayscaleY();
        IFilter Gamma(Rgb rgb);
        IFilter Sepia();
        IFilter Invert();
        IFilter RemappingColor(Rgb rgb);
    }
}
