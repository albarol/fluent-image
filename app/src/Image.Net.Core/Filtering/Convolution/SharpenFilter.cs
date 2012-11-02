namespace ImageNet.Core.Filtering.Convolution
{
    internal class SharpenFilter : MatrixFilter
    {
        public SharpenFilter()
        {
            const int Weight = 11;
            this.ConvertMatrix = new ConvertMatrix();
            this.ConvertMatrix.SetAll(0);
            this.ConvertMatrix.Pixel = Weight;
            this.ConvertMatrix.TopMid = this.ConvertMatrix.MidLeft = this.ConvertMatrix.MidRight = this.ConvertMatrix.BottomMid = -2;
            this.ConvertMatrix.Factor = Weight - 8;
        }
    }
}
