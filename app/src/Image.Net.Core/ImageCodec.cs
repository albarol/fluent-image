namespace ImageNet.Core
{
    using System.Drawing.Imaging;
    using System.Linq;

    internal class ImageCodec
    {
        private static readonly ImageCodecInfo[] Codecs = ImageCodecInfo.GetImageEncoders();

        private ImageCodec()
        {
        }

        public static ImageCodecInfo Jpeg
        {
            get { return Codecs.First(c => c.MimeType == "image/jpeg"); }
        }

        public static ImageCodecInfo Bmp
        {
            get { return Codecs.First(c => c.MimeType == "image/bmp"); }
        }

        public static ImageCodecInfo Gif
        {
            get { return Codecs.First(c => c.MimeType == "image/gif"); }
        }

        public static ImageCodecInfo Tiff
        {
            get { return Codecs.First(c => c.MimeType == "image/tiff"); }
        }

        public static ImageCodecInfo Png
        {
            get { return Codecs.First(c => c.MimeType == "image/png"); }
        }

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
    }
}
