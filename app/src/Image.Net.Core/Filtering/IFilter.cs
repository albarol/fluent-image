using System.Drawing;

namespace ImageNet.Core.Filtering
{
    public interface IFilter
    {
        bool ProcessFilter(Image image);
    }
}
