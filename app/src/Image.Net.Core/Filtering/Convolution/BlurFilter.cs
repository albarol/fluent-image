namespace ImageNet.Core.Filtering.Convolution
{
    internal class BlurFilter : MatrixFilter
    {
        public BlurFilter()
        {
            const int Weight = 4;
            ConvertMatrix = new ConvertMatrix();
            ConvertMatrix.SetAll(1);
            ConvertMatrix.Pixel = Weight;
            ConvertMatrix.TopMid = ConvertMatrix.MidLeft = ConvertMatrix.MidRight = ConvertMatrix.BottomMid = 2;
            ConvertMatrix.Factor = Weight + 12;
        }
    }
}
