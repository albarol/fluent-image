namespace ImageNet.Filtering
{
    using System;

    // TODO: Finalizar o refactoring desta classe
    public class Hsl
    {
        public int Hue { get; set; }
        public float Saturation { get; set; }
        public float Luminance { get; set; }

        public Hsl()
        {
        }

        public Hsl(int hue, float saturation, float luminance)
        {
            this.Hue = hue;
            this.Saturation = saturation;
            this.Luminance = luminance;
        }

        public static Hsl FromRgb(Rgb rgb)
        {
            const float MaxDivisor = 255.0f;
            
            var hsl = new Hsl();

            float red = rgb.Red / MaxDivisor;
            float green = rgb.Green / MaxDivisor;
            float blue = rgb.Blue / MaxDivisor;

            float min = Math.Min(Math.Min(red, green), blue);
            float max = Math.Max(Math.Max(red, green), blue);
            float diff = max - min;

            hsl.Luminance = (max + min) / 2;

            if (!diff.Equals(0))
            {
                hsl.Saturation = (hsl.Luminance <= 0.5) ? (diff / (max + min)) : (diff / (2 - max - min));

                float hue;

                if (red.Equals(max))
                {
                    hue = ((green - blue) / 6) / diff;
                }
                else if (green.Equals(max))
                {
                    hue = (1.0f / 3) + ((blue - red) / 6) / diff;
                }
                else
                {
                    hue = (2.0f / 3) + ((red - green) / 6) / diff;
                }

                if (hue < 0)
                {
                    hue += 1;
                }

                if (hue > 1)
                {
                    hue -= 1;
                }

                hsl.Hue = (int)(hue * 360);
            }

            return hsl;
        }

        public static Rgb ToRgb(Hsl hsl)
        {
            var rgb = new Rgb();

            if (hsl.Saturation == 0)
            {
                rgb.Red = rgb.Green = rgb.Blue = (byte)(hsl.Luminance * 255);
            }
            else
            {
                float v1, v2;
                float hue = (float)hsl.Hue / 360;

                v2 = (hsl.Luminance < 0.5)
                         ? (hsl.Luminance * (1 + hsl.Saturation))
                         : ((hsl.Luminance + hsl.Saturation) - (hsl.Luminance * hsl.Saturation));
                v1 = 2 * hsl.Luminance - v2;

                rgb.Red = (byte)(255 * HueToRgb(v1, v2, hue + (1.0f / 3)));
                rgb.Green = (byte)(255 * HueToRgb(v1, v2, hue));
                rgb.Blue = (byte)(255 * HueToRgb(v1, v2, hue - (1.0f / 3)));
                rgb.Alpha = 255;
            }

            return rgb;
        }

        public Rgb ToRgb()
        {
            return ToRgb(this);
        }

        private static float HueToRgb( float v1, float v2, float vH )
        {
            if (vH < 0)
            {
                vH += 1;
            }

            if (vH > 1)
            {
                vH -= 1;
            }

            if ((6 * vH) < 1)
            {
                return v1 + (v2 - v1) * 6 * vH;
            }

            if ((2 * vH) < 1)
            {
                return v2;
            }

            if ((3 * vH) < 2)
            {
                return (v1 + (v2 - v1) * ((2.0f / 3) - vH) * 6);
            }

            return v1;
        }
        
    }
}
