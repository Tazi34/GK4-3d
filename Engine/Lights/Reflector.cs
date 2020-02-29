
using GK_4.Engine;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4.Lights
{
    public class Reflector : Light
    {
        public Vector<double> Position { get; set; }
        public Vector<double> Direction { get; set; }
        public int Coefficiant { get; set;}


        public override Color CalculateLightForPoint(Triangle triangle, Vector<double> point, Vector<double> normal, Vector<double> cameraPosition)
        {
            double kd = 1;
            Vector<double> L = Position - point;
            L = L.Divide(L.Norm(2));
            var N = normal;
            //var Io = triangle.Color;

            double NL = (N * L);
           
            //Calculate intensity
            var IrefR = Color.R * Math.Pow((Direction.Multiply(-1) * L), Coefficiant);
            var IrefG = Color.G * Math.Pow((Direction.Multiply(-1) * L), Coefficiant);
            var IrefB = Color.B * Math.Pow((Direction.Multiply(-1) * L), Coefficiant);

          
            //Calculate distracted light
            var distractedR = (kd  * Color.R * NL );
            var distractedG = (kd  * Color.G * NL );
            var distractedB = (kd  * Color.B * NL );


            //adding color from object
          /*  var distractedR = (kd * Io.R * Color.R * NL / 255);
            var distractedG = (kd * Io.G * Color.G * NL / 255);
            var distractedB = (kd * Io.B * Color.B * NL / 255);
            var reflectedR = (ks * IrefR * Color.R * Math.Pow(VR, m) / 255);
            var reflectedG = (ks * IrefG * Color.G * Math.Pow(VR, m) / 255);
            var reflectedB = (ks * IrefB * Color.B * Math.Pow(VR, m) / 255);*/


            //Reflected light
            double ks = 1;
            var v = cameraPosition - point;
            v = v.Divide(v.Norm(2));
            var vectorR = 2 * (NL) * N - L;
            var VR = v * vectorR;
            var m = 1;
           
           

            var reflectedR = (ks * IrefR * Math.Pow(VR, m) );
            var reflectedG = (ks * IrefG * Math.Pow(VR, m) );
            var reflectedB = (ks * IrefB * Math.Pow(VR, m) );

            int R = (int)(distractedR + reflectedR);
            int G = (int)(distractedG + reflectedG);
            int B = (int)(distractedB + reflectedB);
            return Light.CorrectColor(R, G, B);
        }

        public override Color CalculateLightForTriangle(Triangle triangle)
        {
            return Color.Green;
            ///throw new NotImplementedException();
        }
    }
}
