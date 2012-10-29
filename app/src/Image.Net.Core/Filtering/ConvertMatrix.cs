namespace ImageNet.Core.Filtering
{
    internal class ConvertMatrix
    {
        public ConvertMatrix()
        {
            this.Factor = 1;
            this.Pixel = 1;
        }
        
        public int TopLeft { get; set; }
        public int TopMid { get; set; }
        public int TopRight { get; set; }
        public int MidLeft { get; set; }
        public int Pixel { get; set; }
        public int MidRight { get; set; }
        public int BottomLeft { get; set; }
        public int BottomMid { get; set; }
        public int BottomRight { get; set; }
        public int Factor { get; set; }
        public int Offset { get; set; }
        
        public void SetAll(int value)
        {
            this.TopLeft = this.TopMid = this.TopRight = this.MidLeft = this.Pixel = this.BottomLeft = this.BottomMid = this.BottomRight = value;
        }
    }
}
