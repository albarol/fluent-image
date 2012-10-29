using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace ImageNet.Core
{
    internal class ImageDecorator : IImage
    {
        internal readonly ImageBuilder Builder;

        public ImageDecorator(ImageBuilder builder)
        {
            Builder = builder;
        }

        public int Width
        {
            get { return Builder.Image.Width; }
        }

        public int Height
        {
            get { return Builder.Image.Height; }
        }

        public Size Size
        {
            get { return Builder.Image.Size; }
        }

        public ImageFormat RawFormat
        {
            get { return Builder.Image.RawFormat; }
        }

        public OutputFormat OutputFormat { get; set; }

        public void Save(string path)
        {
            if (Builder.Filtering != null && Builder.Filtering.Filters.Count > 0)
            {
                foreach (var filter in Builder.Filtering.Filters)
                    filter.ProcessFilter(Builder.Image);
            }

            var realPath = string.Format(@"{0}\{1}{2}", Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path), Path.GetExtension(path));
            Builder.Image.Save(realPath, ImageCodec.FromOutputFormat(OutputFormat), 
                Builder.Encoders.Count > 0 
                ? new EncoderParameters {Param = Builder.Encoders.ToArray()}
                : null);
        }

        public override string ToString()
        {
            var imageConverter = new ImageConverter();
            var imageBytes = (byte[])imageConverter.ConvertTo(Builder.Image, typeof(byte[]));
            if(imageBytes != null)
                return Convert.ToBase64String(imageBytes);
            return "";
        }
    }
}
