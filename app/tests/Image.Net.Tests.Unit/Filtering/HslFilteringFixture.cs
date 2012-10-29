namespace ImageNet.Tests.Unit.Filtering
{
    using System.Drawing;

    using ImageNet.Core;
    using ImageNet.Core.Filtering;
    using ImageNet.Tests.Unit.Helpers;

    using NUnit.Framework;

    [TestFixture]
    public class HslFilteringFixture
    {
        private ImageBuilder builder;

        [SetUp]
        public void SetUp()
        {
            this.builder = new ImageBuilder(Image.FromFile(IoHelper.ResolveUrl("Montanhas azuis.jpg")));
        }

        [TearDown]
        public void TearDown()
        {
            this.builder.Current.Save(IoHelper.ResolveUrl("Inverno_NEW.jpg"));
        }

        [Test]
        public void Filter_ApplyBrightnessFilter()
        {
            this.builder.Filters.Add(Filters.Hsl.Brightness(200));
        }

        [Test]
        public void Filter_ApplyContrastFilter()
        {
            this.builder.Filters.Add(Filters.Hsl.Contrast(50));
        }

        [Test]
        public void Filter_ApplyHueFilter()
        {
            this.builder.Filters.Add(Filters.Hsl.Hue(80));
        }

        [Test]
        public void Filter_ApplySaturationFilter()
        {
            this.builder.Filters.Add(Filters.Hsl.Saturation(-10));
        }
    }
}
