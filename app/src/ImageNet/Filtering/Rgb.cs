namespace ImageNet.Filtering
{
    using System.Drawing;

    public struct Rgb
    {
        public const int RedPixel = 2;
        public const int GreenPixel = 1;
        public const int BluePixel = 0;
        public const int AlphaPixel = 3;

        private byte red;
        private byte green;
        private byte blue;
        private byte alpha;
        
        public Rgb(byte red, byte green, byte blue) : this()
        {
            this.Red = red;
            this.Green = green;
            this.Blue  = blue;
            this.Alpha = 255;
        }

        public Rgb(byte red, byte green, byte blue, byte alpha) 
            : this()
        {
            this.Red   = red;
            this.Green = green;
            this.Blue  = blue;
            this.Alpha = alpha;
        }

        public Rgb(Color color) 
            : this()
        {
            this.Red   = color.R;
            this.Green = color.G;
            this.Blue  = color.B;
            this.Alpha = color.A;
        }
        
        public Color Color
        {
            get { return Color.FromArgb(this.Alpha, this.Red, this.Green, this.Blue); }
        }


        public byte Red
        {
            get
            {
                return this.red;
            }

            set
            {
                this.red = this.EnsureLimit(value);
            }
        }
        
        public byte Green
        {
            get
            {
                return this.green;
            }

            set
            {
                this.green = this.EnsureLimit(value);
            }
        }

        public byte Blue
        {
            get
            {
                return this.blue;
            }

            set
            {
                this.blue = this.EnsureLimit(value);
            }
        }

        public byte Alpha
        {
            get
            {
                return this.alpha;
            }

            set
            {
                this.alpha = this.EnsureLimit(value);
            }
        }

        private byte EnsureLimit(byte value)
        {
            if (value < -255)
            {
                return 0;
            }

            if (value > 255)
            {
                return 255;
            }

            return value;
        }
    }
}
