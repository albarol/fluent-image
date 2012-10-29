using System.Drawing;
using System.Drawing.Text;

namespace ImageNet.Core.Operations
{
    internal class RotateImpl : IRotate
    {
        private readonly ImageBuilder builder;

        public RotateImpl(ImageBuilder builder)
        {
            this.builder = builder;
        }

        public ImageBuilder Left(int degrees)
        {
            var negative = -1*degrees;
            builder.Image = Rotate(negative);
            return builder;
        }

        public ImageBuilder Left(RotateType rotateType)
        {
            return Left((int) rotateType);
        }

        public ImageBuilder Right(int degrees)
        {
            builder.Image = Rotate(degrees);
            return builder;
        }

        public ImageBuilder Right(RotateType rotateType)
        {
            return Right((int)rotateType);
        }

        private Image Rotate(int dregrees)
        {
            var returnBitmap = new Bitmap(builder.Current.Width, builder.Current.Height);
            var g = Graphics.FromImage(returnBitmap);
            if (builder.Current.OutputFormat == OutputFormat.Png)
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.TranslateTransform((float)builder.Current.Width / 2, (float)builder.Current.Height / 2);
            g.RotateTransform(dregrees);
            g.TranslateTransform(-(float)builder.Current.Width / 2, -(float)builder.Current.Height / 2);
            g.DrawImage(builder.Image, new Point(0, 0));
            return returnBitmap;
        }
    }
}
