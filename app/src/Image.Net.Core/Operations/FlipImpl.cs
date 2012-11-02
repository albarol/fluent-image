namespace ImageNet.Core.Operations
{
    using System.Drawing;

    internal class FlipImpl : IFlip
    {
        private readonly FluentImage builder;

        public FlipImpl(FluentImage builder)
        {
            this.builder = builder;
        }

        public FluentImage In(FlipType flipType)
        {
            var flip = (flipType == FlipType.Horizontal) ? RotateFlipType.RotateNoneFlipX : RotateFlipType.RotateNoneFlipY;
            builder.Image.RotateFlip(flip);
            return builder;
        }
    }
}