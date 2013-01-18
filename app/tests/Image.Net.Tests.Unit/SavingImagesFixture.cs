using System.IO;
using ImageNet.Tests.Unit.Helpers;
using NUnit.Framework;

namespace ImageNet.Tests.Unit {
    [TestFixture]
    public class SavingImagesFixture {
        private string destImageStream;
        private string destImageFile;

        [SetUp]
        public void SetUp() {
            destImageStream = IoHelper.ResolveUrl("Inverno_NEW_stream.jpg");
            destImageFile = IoHelper.ResolveUrl("Inverno_NEW.jpg");

            DeleteIfExists(destImageStream);
            DeleteIfExists(destImageFile);
        }

        private static void DeleteIfExists(string destImage) {
            if (File.Exists(destImage))
                File.Delete(destImage);
        }

        [Test]
        public void Save_ShouldSaveToStream() {
            var sourceImage = IoHelper.ResolveUrl("Inverno.jpg");

            using (var fileStream = new FileStream(destImageStream, FileMode.Create)) {
                FluentImage.FromFile(sourceImage)
                           .Save(fileStream, OutputFormat.Jpeg);
            }

            FluentImage.FromFile(sourceImage)
                       .Save(destImageFile, OutputFormat.Jpeg);

            FileAssert.AreEqual(destImageStream, destImageFile);
        }
    }
}