namespace ImageNet.Core.Filtering
{
    using ImageNet.Core.Filtering.Colors;
    using ImageNet.Core.Filtering.Convolution;
    using ImageNet.Core.Filtering.Edges;
    using ImageNet.Core.Filtering.Hsls;

    public class Filters
    {
        private static IColorFilters colorFilters;
        private static IConvolutionFilters convolutionFilters;
        private static IHslFilters hslFilters;
        private static IEdgeFilters edgeFilters;
        
        public static IColorFilters Color
        {
            get { return colorFilters ?? (colorFilters = new ColorFiltersImpl()); }
        }

        public static IConvolutionFilters Convolution
        {
            get { return convolutionFilters ?? (convolutionFilters = new ConvolutionFiltersImpl()); }
        }

        public static IHslFilters Hsl
        {
            get { return hslFilters ?? (hslFilters = new HslFiltersImpl()); }
        }

        public static IEdgeFilters Edges
        {
            get { return edgeFilters ?? (edgeFilters = new EdgeFiltersImpl()); }
        }
    }
}
