using System.Drawing;

namespace ImageNet.Core.Resizer
{
    public interface IResize
    {
        ImageBuilder Scale(int size);
        ImageBuilder Percentual(float percentual);
        ImageBuilder Width(int value);
        ImageBuilder Height(int value);
        ImageBuilder ToSize(Size size);
        ImageBuilder Crop(Rectangle rectangle);
    }
}
