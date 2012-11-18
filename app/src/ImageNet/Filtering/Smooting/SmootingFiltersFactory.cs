namespace ImageNet.Filtering.Smooting
{
    using ImageNet.Filtering;

    internal class SmootingFiltersFactory : ISmootingFilter
    {
        public IFilter Smooth()
        {
            return new SmoothFilter();
        }
    }
}
