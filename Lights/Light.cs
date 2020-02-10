using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4.Lights
{
    public abstract class Light
    {
        public static Color CorrectColor(int R, int G,int B)
        {
            if (R > 255)
                R = 255;
            if (G > 255)
                G = 255;
            if (B > 255)
                B = 255;

            if (R < 0)
                R = 0;
            if (G < 0)
                G = 0;
            if (B < 0)
                B = 0;

            return Color.FromArgb(R, G, B);
        }


        protected Light()
        {
            Color = Color.White;
        }

        public Color Color { get; set; }
    }
   
}
