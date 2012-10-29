namespace ImageNet.Core.Filtering.Edges
{
    internal class EdgeQuickFilter : MatrixFilter
    {
        public EdgeQuickFilter()
        {
            ConvertMatrix = new ConvertMatrix();
            ConvertMatrix.TopLeft = ConvertMatrix.TopMid = ConvertMatrix.TopRight = -1;
            ConvertMatrix.MidLeft = ConvertMatrix.Pixel = ConvertMatrix.MidRight = 0;
            ConvertMatrix.BottomLeft = ConvertMatrix.BottomMid = ConvertMatrix.BottomRight = 1;
            ConvertMatrix.Offset = 127;
        }
    }
}
