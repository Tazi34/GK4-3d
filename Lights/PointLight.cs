using GK_4.Engine;
using GK_4.Engine.Mesh;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4.Lights
{
    public class PointLight : Light
    {
        private Vector<double> normVector(Vector<double> vector) {
            var length = vector.Norm(2);
            for (int i = 0; i < 3; i++)
                vector[i] /= length;
            return vector;
        }
        public Vector<double> Position { get; set; }
        public Color CalculateLight(NewTriangle triangle) {
            double kd = 1;
            Vector<double> L = CreateVector.Dense(new double[] { 0, 0, 1, 0 });

            var N = triangle.A.NormalVector;
            var Io = triangle.Color;

            
           
            var NL = (N * L);
           


            int R =(int)  (kd * Io.R * Color.R *  NL/255);
            int G = (int) (kd * Io.G * Color.G * NL/255);
            int B = (int) (kd * Io.B * Color.B * NL/255);

            R = R > 255 ? 255 : R;
            G = G > 255 ? 255 : G;
            B = B > 255 ? 255 : B;

            R = R <0 ? 0 : R;
            G = G <0 ? 0 : G;
            B = B <0 ? 0 : B;
            var color = Color.FromArgb(R, G, B);

            return color;
        }
        public Color CalculateLight(NewTriangle triangle,Vector<double> point, Vector<double> normal)
        {
            double kd = 1;
            Vector<double> L = Position - point;
            L = L.Divide(L.Norm(2));

            var N = normal;
            var Io = triangle.Color;

            double NL = (N * L);
         

            int R = (int)(kd * Io.R * Color.R * NL / 255);
            int G = (int)(kd * Io.G * Color.G * NL / 255);
            int B = (int)(kd * Io.B * Color.B * NL / 255);

            R = R > 255 ? 255 : R;
            G = G > 255 ? 255 : G;
            B = B > 255 ? 255 : B;

            R = R < 0 ? 0 : R;
            G = G < 0 ? 0 : G;
            B = B < 0 ? 0 : B;
            var color = Color.FromArgb(R, G, B);
         
            // Console.WriteLine(color);


            return color;
        }
    }
}
