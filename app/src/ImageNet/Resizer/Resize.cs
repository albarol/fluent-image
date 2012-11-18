namespace ImageNet.Resizer
{
    using System;
    using System.Drawing;

    internal class Resize : IResize
    {
        private readonly FluentImage builder;
        
        internal Resize(FluentImage builder)
        {
            this.builder = builder;
        }
        
        public FluentImage Scale(int size)
        {
            var greaterSide = (this.builder.Current.Width >= this.builder.Current.Height)
                                  ? this.builder.Current.Width
                                  : this.builder.Current.Height;
            var percentual = (float)size / greaterSide;
            return this.Percentual(percentual);
        }

        public FluentImage Percentual(float percentual)
        {
            var height = Convert.ToInt32(this.builder.Current.Height * percentual);
            var width = Convert.ToInt32(this.builder.Current.Width * percentual);
            this.builder.Image = this.ResizeTo(width, height);
            return this.builder;
        }

        public FluentImage Width(int value)
        {
            this.builder.Image = this.ResizeTo(value, this.builder.Current.Height);
            return this.builder;
        }

        public FluentImage Height(int value)
        {
            this.builder.Image = this.ResizeTo(this.builder.Current.Width, value);
            return this.builder;
        }

        public FluentImage ToSize(Size size)
        {
            if (!size.IsEmpty)
            {
                this.builder.Image = this.ResizeTo(size.Width, size.Height);
            }
            return this.builder;
        }

        public FluentImage Crop(Rectangle rectangle)
        {
            var bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(this.builder.Image, new Rectangle(0, 0, rectangle.Width, rectangle.Height), rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel);
            this.builder.Image = bitmap;
            return this.builder;
        }

        private Image ResizeTo(int width, int height)
        {
            var bitmap = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(this.builder.Image, new Rectangle(0, 0, width, height));
            return bitmap;
        }
    }
}

