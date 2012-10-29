namespace ImageNet.Tests.Unit
{
    using System.Drawing;

    using ImageNet.Core;
    using ImageNet.Tests.Unit.Helpers;

    using NUnit.Framework;

    using SharpTestsEx;

    [TestFixture]
    public class BasicOperationsFixture
    {
        private ImageBuilder builder;

        [SetUp]
        public void SetUp()
        {
            
        }
        
        [Test]
        public void ToString_GetImageInBase64Format()
        {
            this.builder = new ImageBuilder(Image.FromFile(IoHelper.ResolveUrl("Inverno.jpg")));
            this.builder.Current.ToString().Should().Not.Be.Empty();
        }
    }
}
