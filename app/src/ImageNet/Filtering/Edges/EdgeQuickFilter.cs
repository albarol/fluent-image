namespace ImageNet.Filtering.Edges
{
    using ImageNet.Filtering;

    internal class EdgeQuickFilter : MatrixFilter
    {
        public EdgeQuickFilter()
        {
            this.ConvertMatrix = new ConvertMatrix();
            this.ConvertMatrix.TopLeft = this.ConvertMatrix.TopMid = this.ConvertMatrix.TopRight = -1;
            this.ConvertMatrix.MidLeft = this.ConvertMatrix.Pixel = this.ConvertMatrix.MidRight = 0;
            this.ConvertMatrix.BottomLeft = this.ConvertMatrix.BottomMid = this.ConvertMatrix.BottomRight = 1;
            this.ConvertMatrix.Offset = 127;
        }
    }
}
