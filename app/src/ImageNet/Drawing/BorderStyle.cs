namespace ImageNet.Drawing
{
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public struct BorderStyle
    {
        private readonly Color color;

        public BorderStyle(Color color) : this()
        {
            this.color = color;
            this.BorderWidth = 0;
            this.DashStyle = DashStyle.Solid;
        }

        public Pen Pen
        {
            get
            {
                var widthInPixelUnit = this.BorderWidth * 2;
                return new Pen(this.color) { Width = widthInPixelUnit, DashStyle = this.DashStyle };
            }
        }

        public int BorderWidth { get; set; }
        public DashStyle DashStyle { get; set; }
    }
}