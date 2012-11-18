    namespace ImageNet.Filtering.Smooting
{
    using ImageNet.Filtering;

    public class SmoothFilter : MatrixFilter
    {
        public SmoothFilter()
        {
            const int Weight = 1;
            this.ConvertMatrix = new ConvertMatrix();
            this.ConvertMatrix.SetAll(1);
            this.ConvertMatrix.Pixel = Weight;
            this.ConvertMatrix.Factor = Weight + 8;
        }
    }
}
