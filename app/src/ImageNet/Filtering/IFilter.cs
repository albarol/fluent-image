namespace ImageNet.Filtering
{
    using System.Drawing;

    public interface IFilter
    {
        bool ProcessFilter(Image image);
    }
}
