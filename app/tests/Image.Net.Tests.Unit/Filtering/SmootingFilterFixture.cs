using ImageNet.Filtering;
using ImageNet.Tests.Unit.Helpers;
using NUnit.Framework;

namespace ImageNet.Tests.Unit.Filtering
{
    [TestFixture]
    public class SmootingFilterFixture
    {
        private FluentImage fluentImage;

        [SetUp]
        public void SetUp()
        {
            this.fluentImage = FluentImage.FromFile(IoHelper.ResolveUrl("Inverno.jpg"));
        }

        [TearDown]
        public void TearDown()
        {
            this.fluentImage.Save(IoHelper.ResolveUrl("Inverno_NEW.jpg"));
        }

        [Test]
        public void Filter_MedianFilter()
        {
            this.fluentImage.Filters.Add(Filters.Smooting.Median(5));
        }

        [Test]
        public void Filter_SmoothFilter()
        {
            this.fluentImage.Filters.Add(Filters.Smooting.Smooth());
        }
    }
}
