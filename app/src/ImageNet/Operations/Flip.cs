namespace ImageNet.Operations
{
    using System.Drawing;

    internal class Flip : IFlip
    {
        private readonly FluentImage builder;

        public Flip(FluentImage builder)
        {
            this.builder = builder;
        }

        public FluentImage In(FlipType flipType)
        {
            var flip = (flipType == FlipType.Horizontal) ? RotateFlipType.RotateNoneFlipX : RotateFlipType.RotateNoneFlipY;
            this.builder.Image.RotateFlip(flip);
            return this.builder;
        }
    }
}