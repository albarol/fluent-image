namespace ImageNet.Core.Operations
{
    using System.Drawing;

    internal class Rotate : IRotate
    {
        private readonly FluentImage builder;

        public Rotate(FluentImage builder)
        {
            this.builder = builder;
        }

        public FluentImage Left(int degrees)
        {
            var negative = degrees * -1;
            this.builder.Image = this.RotateIn(negative);
            return this.builder;
        }

        public FluentImage Left(RotateType rotateType)
        {
            return this.Left((int)rotateType);
        }

        public FluentImage Right(int degrees)
        {
            this.builder.Image = this.RotateIn(degrees);
            return this.builder;
        }

        public FluentImage Right(RotateType rotateType)
        {
            return this.Right((int)rotateType);
        }

        private Image RotateIn(int dregrees)
        {
            var returnBitmap = new Bitmap(this.builder.Current.Width, this.builder.Current.Height);
            var g = Graphics.FromImage(returnBitmap);
            
            // if (builder.Current.OutputFormat == OutputFormat.Png)
            
            // g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            g.TranslateTransform((float)this.builder.Current.Width / 2, (float)this.builder.Current.Height / 2);
            g.RotateTransform(dregrees);
            g.TranslateTransform(-(float)this.builder.Current.Width / 2, -(float)this.builder.Current.Height / 2);
            g.DrawImage(this.builder.Image, new Point(0, 0));
            return returnBitmap;
        }
    }
}
