namespace ImageNet.Tests.Unit.Filtering
{
    using ImageNet.Filtering;
    using ImageNet.Tests.Unit.Helpers;

    using NUnit.Framework;

    [TestFixture]
    public class ConvolutionFilteringFixture
    {
        private FluentImage builder;

        [SetUp]
        public void SetUp()
        {
            this.builder = FluentImage.Create(IoHelper.ResolveUrl("Ninféias.jpg"));
        }

        [TearDown]
        public void TearDown()
        {
            this.builder.Save(IoHelper.ResolveUrl("Inverno_NEW.jpg"));
        }

        [Test]
        public void Filter_ApplyBlurFilter()
        {
            this.builder.Filters.Add(Filters.Convolution.Blur());
        }

        [Test]
        public void Filter_ApplySharpenFilter()
        {
            this.builder.Filters.Add(Filters.Convolution.Sharpen());
        }

        [Test]
        public void Filter_ApplyEmbossFilter()
        {
            this.builder.Filters.Add(Filters.Convolution.Emboss());
        }

        [Test]
        public void Filter_ApplyMeanRemovalFilter()
        {
            this.builder.Filters.Add(Filters.Convolution.MeanRemoval());
        }
    }
}
