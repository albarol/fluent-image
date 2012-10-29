using System.Drawing;
using System.Drawing.Imaging;

namespace ImageNet.Core
{
    public interface IImage
    {
        int Width { get; }
        int Height { get; }
        Size Size { get; }
        ImageFormat RawFormat { get; }
        OutputFormat OutputFormat { set; get; }
        void Save(string path);
    }
}
