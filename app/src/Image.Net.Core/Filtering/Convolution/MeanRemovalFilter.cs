namespace ImageNet.Core.Filtering.Convolution
{
    internal class MeanRemovalFilter : MatrixFilter
    {
        public MeanRemovalFilter()
        {
            const int Weight = 9;
            this.ConvertMatrix = new ConvertMatrix();
            this.ConvertMatrix.SetAll(-1);
            this.ConvertMatrix.Pixel = Weight;
            this.ConvertMatrix.Factor = Weight - 8;
        }
    }
}
