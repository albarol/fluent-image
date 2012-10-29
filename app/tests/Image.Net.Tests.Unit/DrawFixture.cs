namespace ImageNet.Tests.Unit
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    using ImageNet.Core;
    using ImageNet.Core.Drawing;
    using ImageNet.Tests.Unit.Helpers;

    using NUnit.Framework;

    [TestFixture]
    public class DrawFixture
    {
        private ImageBuilder builder;

        [SetUp]
        public void SetUp()
        {
            this.builder = new ImageBuilder(Image.FromFile(IoHelper.ResolveUrl("Inverno.jpg")));
        }

        [TearDown]
        public void TearDown()
        {
            this.builder.Current.Save(IoHelper.ResolveUrl("Inverno_NEW.bmp"));
        }
        
        [Test]
        public void AddBorder_ShouldApplyBorderInImage()
        {
            this.builder.Draw.AddBorder(new BorderStyle(Color.DodgerBlue) { BorderWidth = 20, DashStyle = DashStyle.Dot });
        }

        [Test]
        public void ApplyImage_ShouldApplyPartOfImage()
        {
            var partOfImage = new ImageBuilder(Image.FromFile(IoHelper.ResolveUrl("Montanhas azuis.jpg")));
            partOfImage.Resize.Crop(new Rectangle(100, 0, 200, partOfImage.Current.Height));
            this.builder.Draw.ApplyImage(partOfImage);
        }

        [Test]
        public void ApplyImage_ShouldApplyImageInCenter()
        {
            var partOfImage = new ImageBuilder(Image.FromFile(IoHelper.ResolveUrl("Montanhas azuis.jpg")));
            this.builder.Draw.ApplyImage(partOfImage, new Rectangle(Convert.ToInt32(this.builder.Current.Width / 2), Convert.ToInt32(this.builder.Current.Height / 2), 200, 200));
        }
    }
}
