namespace ImageNet.Tests.Unit
{
    using ImageNet.Operations;
    using ImageNet.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture]
    public class FlipFixture
    {
        private FluentImage builder;

        [SetUp]
        public void SetUp()
        {
            this.builder = FluentImage.Create(IoHelper.ResolveUrl("Inverno.jpg"));
        }

        [Test]
        public void Turn_ShouldFlipHorizontal()
        {
            this.builder.Turn.In(FlipType.Horizontal);
            this.builder.Current.Width.Should().Be.EqualTo(800);
        }

        [Test]
        public void Turn_ShouldFlipVertical()
        {
            this.builder.Turn.In(FlipType.Vertical);
            this.builder.Current.Height.Should().Be.EqualTo(600);
        }
    }
}
