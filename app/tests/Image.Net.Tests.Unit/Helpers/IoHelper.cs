using ImageNet.Core;

namespace ImageNet.Tests.Unit.Helpers
{
    public class IoHelper
    {
        public static string ResolveUrl(string fileName)
        {
            var path = typeof(IoHelper).Assembly.CodeBase
                                       .Replace("tests/Image.Net.Tests.Unit/bin/Debug/ImageNet.Tests.Unit.DLL", "")
                                       .Replace("file:///", "");
                                                
            return string.Format("{0}{1}{2}", 
                    path,
                    "resources/ImagesToResize/",
                    fileName
            );
        }
    }
}
