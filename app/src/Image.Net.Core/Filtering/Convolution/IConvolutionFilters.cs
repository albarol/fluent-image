namespace ImageNet.Core.Filtering.Convolution
{
    public interface IConvolutionFilters
    {
        IFilter Blur();
        IFilter Sharpen();
        IFilter Emboss();
        IFilter MeanRemoval();
    }
}
