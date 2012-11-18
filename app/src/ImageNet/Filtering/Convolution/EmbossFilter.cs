namespace ImageNet.Filtering.Convolution
{
    using ImageNet.Filtering;

    internal class EmbossFilter : MatrixFilter
    {
        public EmbossFilter()
        {
            this.ConvertMatrix = new ConvertMatrix();
            this.ConvertMatrix.SetAll(-1);
            this.ConvertMatrix.TopMid = this.ConvertMatrix.MidLeft = this.ConvertMatrix.MidRight = this.ConvertMatrix.BottomMid = 0;
            this.ConvertMatrix.Pixel = 4;
            this.ConvertMatrix.Offset = 127;
        }
    }
}
