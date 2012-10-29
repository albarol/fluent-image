using System.Drawing;

namespace ImageNet.Core.Operations
{
    internal class FlipImpl : IFlip
    {
        private readonly ImageBuilder builder;

        public FlipImpl(ImageBuilder builder)
        {
            this.builder = builder;
        }

        public ImageBuilder In(FlipType flipType)
        {
            var flip = (flipType == FlipType.Horizontal) ? RotateFlipType.RotateNoneFlipX : RotateFlipType.RotateNoneFlipY;
            builder.Image.RotateFlip(flip);
            return builder;
        }
    }
}