namespace ImageNet.Core.Drawing
{
    using System.Drawing;

    internal class Draw : IDraw
    {
        private readonly FluentImage builder;

        public Draw(FluentImage builder)
        {
            this.builder = builder;
        }

        public FluentImage AddBorder(BorderStyle borderStyle)
        {
            var size = new Size
            {
                Height = this.builder.Image.Height + (borderStyle.BorderWidth * 2),
                Width = this.builder.Image.Width + (borderStyle.BorderWidth * 2)
            };
            var bitmap = new Bitmap(size.Width, size.Height);
            var graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(this.builder.Image, new Rectangle(borderStyle.BorderWidth, borderStyle.BorderWidth, this.builder.Image.Width, this.builder.Image.Height));
            graphics.DrawLine(borderStyle.Pen, 0, 0, size.Width, 0);
            graphics.DrawLine(borderStyle.Pen, 0, 0, 0, size.Height);
            graphics.DrawLine(borderStyle.Pen, size.Width, 0, size.Width, size.Height);
            graphics.DrawLine(borderStyle.Pen, 0, size.Height, size.Width, size.Height);
            this.builder.Image = bitmap;
            return this.builder;
        }
        
        public FluentImage ApplyImage(Image image)
        {
            return this.ApplyImage(image, new Rectangle(0, 0, image.Width, image.Height));
        }

        public FluentImage ApplyImage(Image image, Rectangle rectangle)
        {
            var bitmap = new Bitmap(this.builder.Current.Width, this.builder.Current.Height);
            var graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(this.builder.Image, new Rectangle(0, 0, this.builder.Current.Width, this.builder.Current.Height));
            graphics.DrawImage(image, rectangle);
            this.builder.Image = bitmap;
            return this.builder;
        }
    }
}
