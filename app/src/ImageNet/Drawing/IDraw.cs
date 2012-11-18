namespace ImageNet.Drawing
{
    using System.Drawing;

    public interface IDraw
    {
        FluentImage AddBorder(BorderStyle borderStyle);
        FluentImage ApplyImage(Image image);
        FluentImage ApplyImage(Image image, Rectangle rectangle);
    }
}
