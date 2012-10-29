namespace ImageNet.Core.Filtering.Convolution
{
    internal class SharpenFilter : MatrixFilter
    {
        public SharpenFilter()
        {
            const int Weight = 11;
            ConvertMatrix = new ConvertMatrix();
            ConvertMatrix.SetAll(0);
            ConvertMatrix.Pixel = Weight;
            ConvertMatrix.TopMid = ConvertMatrix.MidLeft = ConvertMatrix.MidRight = ConvertMatrix.BottomMid = -2;
            ConvertMatrix.Factor = Weight - 8;
        }
    }
}
