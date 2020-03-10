using GK_4.Engine;

using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_4.Engine.Meshes.Triangles;

namespace GK_4.Lights
{
    public class PointLight : Light
    {

        public Vector<double> Position { get; set; }


        public override Color CalculateLightForPoint(Triangle triangle,Vector<double> point, Vector<double> normal, Vector<double> cameraPosition)
        {
            double kd = 1;
            Vector<double> L = Position - point;
            L = L.Divide(L.Norm(2));
           // Console.WriteLine(point);
            var N = normal;
            var Io = triangle.Color;
           

            double NL = (N * L);
            var distractedR = (kd * Io.R * Color.R * NL / 255);
            var distractedG = (kd * Io.G * Color.G * NL / 255);
            var distractedB = (kd * Io.B * Color.B * NL / 255);

            //Reflected light
            double ks = 1;
    
            var v = cameraPosition - point;
            v = v.Divide(v.Norm(2));
            var vectoR = 2 * (NL) * N - L;
            var VR = v * vectoR;
            var m = 1;

            var reflectedR = (ks * Io.R * Color.R * Math.Pow(VR, m) / 255);
            var reflectedG = (ks * Io.G * Color.G * Math.Pow(VR, m) / 255);
            var reflectedB = (ks * Io.B * Color.B * Math.Pow(VR, m) / 255);

            int R = (int)(distractedR + reflectedR);
            int G = (int)(distractedG + reflectedG);
            int B = (int)(distractedB + reflectedB);
            return Light.CorrectColor(R, G, B);
        }
    }
}
