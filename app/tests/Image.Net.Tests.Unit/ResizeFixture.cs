namespace ImageNet.Tests.Unit
{
    using System.Drawing;

    using ImageNet.Core;
    using ImageNet.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture]
    public class ResizeFixture
    {
        private FluentImage builder;

        [SetUp]
        public void SetUp()
        {
            this.builder = FluentImage.Create(IoHelper.ResolveUrl("Inverno.jpg"));
        }
        
        [Test]
        public void Resize_ShouldResizeWidthImage()
        {
            this.builder.Resize.Width(10);
            this.builder.Current.Width.Should().Be.EqualTo(10);    
        }

        [Test]
        public void Resize_ShouldResizeHeightImage()
        {
            this.builder.Resize.Height(10);
            this.builder.Current.Height.Should().Be.EqualTo(10);
            
        }

        [Test]
        public void Resize_ShouldResizePercentual()
        {
            this.builder.Resize.Percentual(0.3f);
            this.builder.Current.Width.Should().Be.EqualTo(240);
        }

        [Test]
        public void Resize_ShouldResizeInScale()
        {
            this.builder.Resize.Scale(240);
            this.builder.Current.Height.Should().Be.EqualTo(180);
            
        }

        [Test]
        public void Resize_ShouldDefineNewSize()
        {
            this.builder.Resize.ToSize(new Size(180, 180));
            this.builder.Current.Height.Should().Be.EqualTo(180);
            this.builder.Current.Width.Should().Be.EqualTo(180);
        }

        [Test]
        public void Crop_ShouldCropImage()
        {
            this.builder.Resize.Crop(new Rectangle(300, 0, 200, 900));
            this.builder.Current.Width.Should().Be.EqualTo(200);
        }
    }
}
