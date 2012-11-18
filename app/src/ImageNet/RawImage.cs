namespace ImageNet
{
    using System.Drawing;
    using System.Drawing.Imaging;

    internal class RawImage : IRawImage
    {
        private readonly FluentImage builder;

        public RawImage(FluentImage builder)
        {
            this.builder = builder;
        }

        public int Width
        {
            get { return this.builder.Image.Width; }
        }

        public int Height
        {
            get { return this.builder.Image.Height; }
        }

        public Size Size
        {
            get { return this.builder.Image.Size; }
        }

        public ImageFormat RawFormat
        {
            get { return this.builder.Image.RawFormat; }
        }
    }
}
