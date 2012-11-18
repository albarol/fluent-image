namespace ImageNet.Tests.Unit
{
    using System.Drawing;

    using ImageNet.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture]
    public class BasicOperationsFixture
    {
        private FluentImage builder;

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Constructor_CanCreateFluentImageByImage()
        {
            // Arrange:
            var image = FluentImage.Create(Image.FromFile(IoHelper.ResolveUrl("Inverno.jpg")));

            // Act:
            var result = image.ToString();

            // Assert:
            result.Should().Not.Be.Empty();
        }

        [Test]
        public void Constructor_CanCreateFluentImageByFilename()
        {
            // Arrange:
            var image = FluentImage.Create(IoHelper.ResolveUrl("Inverno.jpg"));

            // Act:
            var result = image.ToString();

            // Assert:
            result.Should().Not.Be.Empty();
        }
        
        [Test]
        public void ToString_GetImageInBase64Format()
        {
            // Arrange:
            this.builder = FluentImage.Create(IoHelper.ResolveUrl("Inverno.jpg"));

            // Act:
            var result = this.builder.ToString();

            // Assert:
            result.Should().Not.Be.Empty();
        }
    }
}
