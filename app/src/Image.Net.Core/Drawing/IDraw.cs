namespace ImageNet.Core.Drawing
{
    using System.Drawing;

    public interface IDraw
    {
        ImageBuilder AddBorder(BorderStyle borderStyle);
        ImageBuilder ApplyImage(Image image);
        ImageBuilder ApplyImage(Image image, Rectangle rectangle);
    }
}
