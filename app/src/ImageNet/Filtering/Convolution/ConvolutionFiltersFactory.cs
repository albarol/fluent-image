namespace ImageNet.Filtering.Convolution
{
    using ImageNet.Filtering;

    internal class ConvolutionFiltersFactory : IConvolutionFilters
    {
        public IFilter Blur()
        {
            return new BlurFilter();
        }

        public IFilter Sharpen()
        {
            return new SharpenFilter();
        }

        public IFilter Emboss()
        {
            return new EmbossFilter();
        }

        public IFilter MeanRemoval()
        {
            return new MeanRemovalFilter();
        }
    }
}
