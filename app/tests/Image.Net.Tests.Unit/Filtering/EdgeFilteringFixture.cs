namespace ImageNet.Tests.Unit.Filtering
{
    using System.Collections.Generic;

    using ImageNet.Core;
    using ImageNet.Core.Filtering;
    using ImageNet.Tests.Unit.Helpers;

    using NUnit.Framework;

    [TestFixture]
    public class EdgeFilteringFixture
    {
        private FluentImage builder;
        private KeyValuePair<string, string> resource = new KeyValuePair<string, string>("Ninféias.jpg", "Ninféias_NEW.jpg");

        [SetUp]
        public void SetUp()
        {
            this.builder = FluentImage.Create(IoHelper.ResolveUrl(this.resource.Key));
        }

        [TearDown]
        public void TearDown()
        {
            this.builder.Save(IoHelper.ResolveUrl(this.resource.Value));
        }

        [Test]
        public void Filter_ApplyEdgeQuickFilter()
        {
            this.builder.Filters.Add(Filters.Edges.Quick());
        }

        [Test]
        public void Filter_ApplyEdgeHomogenityFilter()
        {
            this.builder.Filters.Add(Filters.Edges.Homogenity(0));
        }

        [Test]
        public void Filter_ApplyEdgeEnhanceFilter()
        {
            this.builder.Filters.Add(Filters.Edges.Enhance(100));
        }

        [Test]
        public void Filter_ApplyEdgeDifferenceFilter()
        {
            this.builder.Filters.Add(Filters.Edges.Difference(10));
        }

        [Test]
        public void Filter_ApplyEdgeVerticalFilter()
        {
            this.builder.Filters.Add(Filters.Edges.DetectVertical());
        }

        [Test]
        public void Filter_ApplyEdgeHorizontalFilter()
        {
            this.builder.Filters.Add(Filters.Edges.DetectHorizontal());
        }
    }
}
