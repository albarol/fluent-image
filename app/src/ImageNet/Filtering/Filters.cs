namespace ImageNet.Filtering
{
    using ImageNet.Filtering.Colors;
    using ImageNet.Filtering.Convolution;
    using ImageNet.Filtering.Edges;
    using ImageNet.Filtering.Hsls;
    using ImageNet.Filtering.Smooting;

    public class Filters
    {
        private static IColorFilters colorFilters;
        private static IConvolutionFilters convolutionFilters;
        private static IHslFilters hslFilters;
        private static IEdgeFilters edgeFilters;
        private static ISmootingFilter smootingFilters;
        
        public static IColorFilters Color
        {
            get { return colorFilters ?? (colorFilters = new ColorFiltersFactory()); }
        }

        public static IConvolutionFilters Convolution
        {
            get { return convolutionFilters ?? (convolutionFilters = new ConvolutionFiltersFactory()); }
        }

        public static IHslFilters Hsl
        {
            get { return hslFilters ?? (hslFilters = new HslFiltersFactory()); }
        }

        public static IEdgeFilters Edges
        {
            get { return edgeFilters ?? (edgeFilters = new EdgeFiltersFactory()); }
        }

        public static ISmootingFilter Smooting
        {
            get { return smootingFilters ?? (smootingFilters = new SmootingFiltersFactory()); }
        }
    }
}
