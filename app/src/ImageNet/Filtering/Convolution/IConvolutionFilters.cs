namespace ImageNet.Filtering.Convolution
{
    using ImageNet.Filtering;

    public interface IConvolutionFilters
    {
        IFilter Blur();
        IFilter Sharpen();
        IFilter Emboss();
        IFilter MeanRemoval();
    }
}
