namespace ImageNet.Core
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;

    using ImageNet.Core.Drawing;
    using ImageNet.Core.Filtering;
    using ImageNet.Core.Operations;
    using ImageNet.Core.Resizer;

    public class ImageBuilder
    {
        private readonly ImageDecorator current;
        
        public ImageBuilder(Image image)
        {
            Image = image;
            this.current = new ImageDecorator(this);
            this.Encoders = new List<EncoderParameter>();
        }

        public IList<EncoderParameter> Encoders { get; private set; }

        public IImage Current
        {
            get { return this.current; }
        }

        public IResize Resize
        {
            get { return new ResizeImpl(this); }
        }

        public IRotate Rotate
        {
            get { return new RotateImpl(this); }
        }

        public IFlip Turn
        {
            get { return new FlipImpl(this); }
        }

        public IDraw Draw
        {
            get { return new DrawImpl(this); }
        }

        public IFiltering Filters
        {
            get { return this.Filtering ?? (this.Filtering = new FilteringImpl(this)); }
        }

        internal Image Image { get; set; }
        internal FilteringImpl Filtering { get; set; }

        public static implicit operator Image(ImageBuilder builder)
        {
            return builder.Image;
        }

    }
}