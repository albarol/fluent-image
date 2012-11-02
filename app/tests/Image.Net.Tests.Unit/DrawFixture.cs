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
        private FluentImage image;

        [SetUp]
        public void SetUp()
        {
            this.image = FluentImage.Create(IoHelper.ResolveUrl("Inverno.jpg"));
        }

        [TearDown]
        public void TearDown()
        {
            this.image.Save(IoHelper.ResolveUrl("Inverno_NEW.bmp"));
        }
        
        [Test]
        public void AddBorder_ShouldApplyBorderInImage()
        {
            this.image.Draw.AddBorder(new BorderStyle(Color.DodgerBlue) { BorderWidth = 20, DashStyle = DashStyle.Dot });
        }

        [Test]
        public void ApplyImage_ShouldApplyPartOfImage()
        {
            var partOfImage = FluentImage.Create(IoHelper.ResolveUrl("Montanhas azuis.jpg"));
            partOfImage.Resize.Crop(new Rectangle(100, 0, 200, partOfImage.Current.Height));
            this.image.Draw.ApplyImage(partOfImage);
        }

        [Test]
        public void ApplyImage_ShouldApplyImageInCenter()
        {
            var partOfImage = FluentImage.Create(IoHelper.ResolveUrl("Montanhas azuis.jpg"));
            this.image.Draw.ApplyImage(partOfImage, new Rectangle(Convert.ToInt32(this.image.Current.Width / 2), Convert.ToInt32(this.image.Current.Height / 2), 200, 200));
        }
    }
}
