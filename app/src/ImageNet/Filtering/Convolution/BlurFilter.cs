namespace ImageNet.Filtering.Convolution
{
    using ImageNet.Filtering;

    internal class BlurFilter : MatrixFilter
    {
        public BlurFilter()
        {
            const int Weight = 4;
            this.ConvertMatrix = new ConvertMatrix();
            this.ConvertMatrix.SetAll(1);
            this.ConvertMatrix.Pixel = Weight;
            this.ConvertMatrix.TopMid = this.ConvertMatrix.MidLeft = this.ConvertMatrix.MidRight = this.ConvertMatrix.BottomMid = 2;
            this.ConvertMatrix.Factor = Weight + 12;
        }
    }
}
