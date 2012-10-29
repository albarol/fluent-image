using System.Drawing.Imaging;
using System.Linq;

namespace ImageNet.Core
{
    internal class ImageCodec
    {
        private static readonly ImageCodecInfo[] Codecs = ImageCodecInfo.GetImageEncoders();

        private ImageCodec() { }

        public static ImageCodecInfo FromOutputFormat(OutputFormat outputFormat)
        {
            switch (outputFormat)
            {
                case OutputFormat.Bmp:
                    return Bmp;
                case OutputFormat.Gif:
                    return Gif;
                case OutputFormat.Png:
                    return Png;
                case OutputFormat.Tiff:
                    return Tiff;
                default:
                    return Jpeg;
            }
        }
        
        public static ImageCodecInfo Jpeg
        {
            get { return Codecs.Where(c => c.MimeType == "image/jpeg").First(); }
        }
        
        public static ImageCodecInfo Bmp
        {
            get { return Codecs.Where(c => c.MimeType == "image/bmp").First(); }
        }

        public static ImageCodecInfo Gif
        {
            get { return Codecs.Where(c => c.MimeType == "image/gif").First(); }
        }

        public static ImageCodecInfo Tiff
        {
            get { return Codecs.Where(c => c.MimeType == "image/tiff").First(); }
        }

        public static ImageCodecInfo Png
        {
            get { return Codecs.Where(c => c.MimeType == "image/png").First(); }
        }
    }
}
