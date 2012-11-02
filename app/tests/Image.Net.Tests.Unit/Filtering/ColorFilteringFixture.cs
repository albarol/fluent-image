namespace ImageNet.Tests.Unit.Filtering
{
    using ImageNet.Core;
    using ImageNet.Core.Filtering;
    using ImageNet.Tests.Unit.Helpers;

    using NUnit.Framework;

    [TestFixture]
    public class ColorFilteringFixture
    {
        private FluentImage fluentImage;

        [SetUp]
        public void SetUp()
        {
            this.fluentImage = FluentImage.Create(IoHelper.ResolveUrl("Pôr-do-sol.jpg"));
        }

        [TearDown]
        public void TearDown()
        {
            this.fluentImage.Save(IoHelper.ResolveUrl("Inverno_NEW.jpg"));
        }

        [Test]
        public void Filter_ApplySephiaFilter()
        {
            this.fluentImage.Filters.Add(Filters.Color.Sepia());
        }

        [Test]
        public void Filter_ApplyGrayscaleFilter()
        {
            this.fluentImage.Filters.Add(Filters.Color.Grayscale());
        }

        [Test]
        public void Filter_ApplyGrayscaleBt709Filter()
        {
            this.fluentImage.Filters.Add(Filters.Color.GrayscaleBt709());
        }

        [Test]
        public void Filter_ApplyGrayscaleRmyFilter()
        {
            this.fluentImage.Filters.Add(Filters.Color.GrayscaleRmy());
        }

        [Test]
        public void Filter_ApplyInvertFilter()
        {
            this.fluentImage.Filters.Add(Filters.Color.Invert());
        }

        [Test]
        public void Filter_ApplyRemappingColorToRed()
        {
            this.fluentImage.Filters.Add(Filters.Color.RemappingColor(new Rgb { Red = 255 }));
        }

        [Test]
        public void Filter_ApplyRemappingColorToBlue()
        {
            this.fluentImage.Filters.Add(Filters.Color.RemappingColor(new Rgb { Blue = 255 }));
        }

        [Test]
        public void Filter_ApplyRemappingColorToGreen()
        {
            this.fluentImage.Filters.Add(Filters.Color.RemappingColor(new Rgb { Green = 255 }));
        }
    }
}
