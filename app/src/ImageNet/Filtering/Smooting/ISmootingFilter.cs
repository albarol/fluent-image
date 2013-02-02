using System.Drawing;

namespace ImageNet.Filtering.Smooting
{
    using ImageNet.Filtering;

    public interface ISmootingFilter
    {
        IFilter Smooth();
        IFilter Median(int size);
    }
}
