namespace ImageNet.Core.Filtering.Smooting
{
    internal class SmootingFiltersFactory : ISmootingFilter
    {
        public IFilter Smooth()
        {
            return new SmoothFilter();
        }
    }
}
