namespace ImageNet
{
    using System.Drawing;
    using System.Drawing.Imaging;

    public interface IRawImage
    {
        int Width { get; }
        int Height { get; }
        Size Size { get; }
        ImageFormat RawFormat { get; }
    }
}
