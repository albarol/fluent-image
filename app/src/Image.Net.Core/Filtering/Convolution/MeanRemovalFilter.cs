namespace ImageNet.Core.Filtering.Convolution
{
    internal class MeanRemovalFilter : MatrixFilter
    {
        public MeanRemovalFilter()
        {
            const int Weight = 9;
            ConvertMatrix = new ConvertMatrix();
            ConvertMatrix.SetAll(-1);
            ConvertMatrix.Pixel = Weight;
            ConvertMatrix.Factor = Weight - 8;
        }
    }
}
