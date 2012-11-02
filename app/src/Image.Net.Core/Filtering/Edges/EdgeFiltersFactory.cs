namespace ImageNet.Core.Filtering.Edges
{
    internal class EdgeFiltersFactory : IEdgeFilters
    {
        public IFilter Quick()
        {
            return new EdgeQuickFilter();
        }

        public IFilter Homogenity(byte threshold)
        {
            return new EdgetDetectHomogenityFilter(threshold);
        }

        public IFilter Enhance(byte threshold)
        {
            return new EdgeEnhanceFilter(threshold);
        }

        public IFilter Difference(byte threshold)
        {
            return new EdgeDetectDifferenceFilter(threshold);
        }

        public IFilter DetectVertical()
        {
            return new EdgeDetectVerticalFilter();
        }

        public IFilter DetectHorizontal()
        {
            return new EdgeDetectHorizontalFilter();
        }
    }
}
