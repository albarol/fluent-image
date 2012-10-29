    namespace ImageNet.Core.Filtering.Smooting
{
    public class SmoothFilter : MatrixFilter
    {
        public SmoothFilter()
        {
            const int Weight = 1;
            ConvertMatrix = new ConvertMatrix();
            ConvertMatrix.SetAll(1);
            ConvertMatrix.Pixel = Weight;
            ConvertMatrix.Factor = Weight + 8;
        }
    }
}
