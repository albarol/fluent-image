namespace ImageNet.Core.Filtering.Convolution
{
    internal class EmbossFilter : MatrixFilter
    {
        public EmbossFilter()
        {
            ConvertMatrix = new ConvertMatrix();
            ConvertMatrix.SetAll(-1);
            ConvertMatrix.TopMid = ConvertMatrix.MidLeft = ConvertMatrix.MidRight = ConvertMatrix.BottomMid = 0;
            ConvertMatrix.Pixel = 4;
            ConvertMatrix.Offset = 127;
        }
    }
}
