namespace ImageNet.Tests.Unit
{
    using ImageNet.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture]
    public class RotateFixture
    {
        private FluentImage builder;

        [SetUp]
        public void SetUp()
        {
            this.builder = FluentImage.FromFile(IoHelper.ResolveUrl("Inverno.jpg"));
        }
        
        [Test]
        public void Rotate_ShouldRotateToLeft()
        {
            this.builder.Rotate.Left(90);
            this.builder.Current.Height.Should().Be.EqualTo(600);
        }


        [Test]
        public void Rotate_ShouldRotateToRight()
        {
            this.builder.Rotate.Right(90);
            this.builder.Current.Width.Should().Be.EqualTo(800);
        }
    }
}
