namespace ImageNet.Core
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;

    internal class RawImage : IRawImage
    {
        internal readonly FluentImage Builder;

        public RawImage(FluentImage builder)
        {
            this.Builder = builder;
        }

        public int Width
        {
            get { return this.Builder.Image.Width; }
        }

        public int Height
        {
            get { return this.Builder.Image.Height; }
        }

        public Size Size
        {
            get { return this.Builder.Image.Size; }
        }

        public ImageFormat RawFormat
        {
            get { return this.Builder.Image.RawFormat; }
        }

        public OutputFormat OutputFormat { get; set; }


        public override string ToString()
        {
            var imageConverter = new ImageConverter();
            var imageBytes = (byte[])imageConverter.ConvertTo(this.Builder.Image, typeof(byte[]));
            return imageBytes != null ? Convert.ToBase64String(imageBytes) : string.Empty;
        }
    }
}
