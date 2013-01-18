namespace ImageNet
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;

    using ImageNet.Drawing;
    using ImageNet.Filtering;
    using ImageNet.Operations;
    using ImageNet.Resizer;

    public class FluentImage
    {
        private readonly RawImage current;
        
        private FluentImage(Image image)
        {
            this.Image = image;
            this.current = new RawImage(this);
            this.Encoders = new List<EncoderParameter>();
            this.Filtering = new FilterList(this);
        }

        public IList<EncoderParameter> Encoders { get; private set; }

        public IRawImage Current
        {
            get { return this.current; }
        }

        public IResize Resize
        {
            get { return new Resize(this); }
        }

        public IRotate Rotate
        {
            get { return new Rotate(this); }
        }

        public IFlip Turn
        {
            get { return new Flip(this); }
        }

        public IDraw Draw
        {
            get { return new Draw(this); }
        }

        public IFiltering Filters
        {
            get { return this.Filtering; }
        }

        internal Image Image { get; set; }
        internal FilterList Filtering { get; set; }

        public static FluentImage FromImage(Image image)
        {
            return new FluentImage(image);
        }

        public static FluentImage FromStream(Stream stream)
        {
            var image = Image.FromStream(stream);
            return new FluentImage(image);
        }

        public static FluentImage FromFile(string filename)
        {
            var image = Image.FromFile(filename);
            return new FluentImage(image);
        }

        public static implicit operator Image(FluentImage builder)
        {
            return builder.Image;
        }

        public void Save(string path)
        {
            this.Save(path, OutputFormat.Jpeg);
        }

        public void Save(string path, OutputFormat format)
        {
            var realPath = string.Format(@"{0}\{1}{2}", Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path), Path.GetExtension(path));
            using (var fileStream = new FileStream(realPath, FileMode.Create)) {
                Save(fileStream, format);
            }
        }

        public void Save(Stream imageStream, OutputFormat format) {
            foreach (var filter in this.Filtering.Filters) {
                filter.ProcessFilter(this.Image);
            }

            this.Image.Save(
                imageStream,
                ImageCodec.FromOutputFormat(format),
                this.Encoders.Count > 0 ? new EncoderParameters { Param = this.Encoders.ToArray() } : null);
        }

        public override string ToString()
        {
            var imageConverter = new ImageConverter();
            var imageBytes = (byte[])imageConverter.ConvertTo(this.Image, typeof(byte[]));
            return imageBytes != null ? Convert.ToBase64String(imageBytes) : string.Empty;
        }
    }
}