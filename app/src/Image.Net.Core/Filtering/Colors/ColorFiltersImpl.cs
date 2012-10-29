namespace ImageNet.Core.Filtering.Colors
{
    internal class ColorFiltersImpl : IColorFilters
    {
        public IFilter RemapingColor(Rgb rgb)
        {
            return new RemapingColorFilter(rgb.Red, rgb.Green, rgb.Blue);
        }

        public IFilter Grayscale()
        {
            return new GrayscaleFilter();
        }

        public IFilter GrayscaleRmy()
        {
            return new GrayscaleRmyFilter();
        }

        public IFilter GrayscaleBt709()
        {
            return new GrayscaleBt709Filter();
        }

        public IFilter GrayscaleY()
        {
            return new GrayscaleYFilter();
        }

        public IFilter Gamma(Rgb rgb)
        {
            return new GammaFilter(rgb.Red, rgb.Green, rgb.Blue);
        }

        public IFilter Sepia()
        {
            return new SepiaFilter();
        }

        public IFilter Invert()
        {
            return new InvertFilter();
        }
    }
}
