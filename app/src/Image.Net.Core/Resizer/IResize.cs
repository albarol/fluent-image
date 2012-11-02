namespace ImageNet.Core.Resizer
{
    using System.Drawing;

    public interface IResize
    {
        FluentImage Scale(int size);
        FluentImage Percentual(float percentual);
        FluentImage Width(int value);
        FluentImage Height(int value);
        FluentImage ToSize(Size size);
        FluentImage Crop(Rectangle rectangle);
    }
}
