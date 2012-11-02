namespace ImageNet.Tests.Unit.Filtering
{
    using System.Drawing;

    using ImageNet.Core;
    using ImageNet.Core.Filtering;
    using ImageNet.Tests.Unit.Helpers;

    using NUnit.Framework;

    [TestFixture]
    public class ColorFilteringFixture
    {
        private FluentImage builder;

        [SetUp]
        public void SetUp()
        {
            this.builder = FluentImage.Create(IoHelper.ResolveUrl("Pôr-do-sol.jpg"));
        }

        [TearDown]
        public void TearDown()
        {
            this.builder.Save(IoHelper.ResolveUrl("Inverno_NEW.jpg"));
        }

        [Test]
        public void Filter_ApplySephiaFilter()
        {
            this.builder.Filters.Add(Filters.Color.Sepia());
        }

        [Test]
        public void Filter_ApplyGrayscaleFilter()
        {
            this.builder.Filters.Add(Filters.Color.Grayscale());
        }

        [Test]
        public void Filter_ApplyGrayscaleBt709Filter()
        {
            this.builder.Filters.Add(Filters.Color.GrayscaleBt709());
        }

        [Test]
        public void Filter_ApplyGrayscaleRmyFilter()
        {
            this.builder.Filters.Add(Filters.Color.GrayscaleRmy());
        }

        [Test]
        public void Filter_ApplyInvertFilter()
        {
            this.builder.Filters.Add(Filters.Color.Invert());
        }

        [Test]
        public void Filter_ApplyRemappingColorToRed()
        {
            this.builder.Filters.Add(Filters.Color.RemappingColor(new Rgb { Red = 255 }));
        }

        [Test]
        public void Filter_ApplyRemappingColorToBlue()
        {
            this.builder.Filters.Add(Filters.Color.RemappingColor(new Rgb { Blue = 255 }));
        }

        [Test]
        public void Filter_ApplyRemappingColorToGreen()
        {
            this.builder.Filters.Add(Filters.Color.RemappingColor(new Rgb { Green = 255 }));
        }
    }
}
