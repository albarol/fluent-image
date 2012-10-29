using System.Drawing;
using System.Drawing.Drawing2D;

namespace ImageNet.Core.Drawing
{
    public struct BorderStyle
    {
        private readonly Color color;

        public BorderStyle(Color color) : this()
        {
            this.color = color;
            BorderWidth = 0;
            DashStyle = DashStyle.Solid;
        }

        public Pen Pen
        {
            get
            {
                var widthInPixelUnit = BorderWidth*2;
                return new Pen(color) { Width = widthInPixelUnit, DashStyle = DashStyle };
            }
        }

        public int BorderWidth { get; set; }
        public DashStyle DashStyle { get; set; }
    }
}