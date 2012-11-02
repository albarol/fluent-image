using System;
using System.Drawing;

namespace ImageNet.Core.Resizer
{
    internal class ResizeImpl : IResize
    {
        private readonly FluentImage builder;
        
        internal ResizeImpl(FluentImage builder)
        {
            this.builder = builder;
        }
        
        public FluentImage Scale(int size)
        {
            var greaterSide = (builder.Current.Width >= builder.Current.Height)
                                  ? builder.Current.Width
                                  : builder.Current.Height;
            var percentual = (float)size/greaterSide;
            return Percentual(percentual);
        }

        public FluentImage Percentual(float percentual)
        {
            var height = Convert.ToInt32(builder.Current.Height * percentual);
            var width = Convert.ToInt32(builder.Current.Width * percentual);
            builder.Image = Resize(width, height);
            return builder;
        }

        public FluentImage Width(int value)
        {
            builder.Image = Resize(value, builder.Current.Height);
            return builder;
        }

        public FluentImage Height(int value)
        {
            builder.Image = Resize(builder.Current.Width, value);
            return builder;
        }

        public FluentImage ToSize(Size size)
        {
            if(!size.IsEmpty)
                builder.Image = Resize(size.Width, size.Height);
            return builder;
        }

        public FluentImage Crop(Rectangle rectangle)
        {
            var bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(builder.Image, new Rectangle(0, 0, rectangle.Width, rectangle.Height), rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel);
            builder.Image = bitmap;
            return builder;
        }

        private Image Resize(int width, int height)
        {
            var bitmap = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(builder.Image, new Rectangle(0, 0, width, height));
            return bitmap;
        }
    }
}

