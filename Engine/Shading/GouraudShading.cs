using GK_4.Engine.Mesh;
using GK_4.Lights;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4.Engine.Shading
{
    class GouraudShading : Shading
    {
        private Color ColorA { get; set; }
        private Color ColorB { get; set; }
        private Color ColorC { get; set; }
        public override NewTriangle CurrentTriangle
        {
            set
            {
                base.CurrentTriangle = value;
                if (value != null)
                    SetColors();
            }
        }
        private void SetColors() {
            ColorA = CalculateColorInVertex(CurrentTriangle.A);
            ColorB = CalculateColorInVertex(CurrentTriangle.B);
            ColorC = CalculateColorInVertex(CurrentTriangle.C);

        }
        private Color CalculateColorInVertex(ModelVertex modelVertex) {
            int R = 0;
            int G = 0;
            int B = 0;
            
            foreach (var l in Lights)
            {
                var color = (l as PointLight).CalculateLight(CurrentTriangle, modelVertex.Position, modelVertex.NormalVector,Camera.Position);
                R += color.R;
                B += color.B;
                G += color.G;
            }
            return Light.CorrectColor(R, G, B);
        }

        private Color GetInterpolatedColor(int x, int y)
        {
           
            var triangle = CurrentTriangle;
            var A = triangle.A.Position;
            var B = triangle.B.Position;
            var C = triangle.C.Position;

            int dA = (int)Math.Sqrt((A[0] - x) * (A[0] - x) + (A[1] - y) * (A[1] - y));
            int dB = (int)Math.Sqrt((B[0] - x) * (B[0] - x) + (B[1] - y) * (B[1] - y));
            int dC = (int)Math.Sqrt((C[0] - x) * (C[0] - x) + (C[1] - y) * (C[1] - y));

            if (dA == 0)
                return ColorA;
            if (dB == 0)
                return ColorB;
            if (dC == 0)
                return ColorC;

            double wA = 1 / (double)dA;
            double wB = 1 / (double)dB;
            double wC = 1 / (double)dC;

            int r = (int)((wA * ColorA.R + wB * ColorB.R + wC * ColorC.R) / (wA + wB + wC));
            int g = (int)((wA *ColorA.G + wB *ColorB.G + wC * ColorC.G) / (wA + wB + wC));
            int b = (int)((wA * ColorA.B + wB * ColorB.B + wC * ColorC.B) / (wA + wB + wC));
            var color = Light.CorrectColor(r, g, b);
            return color;
        }
        public GouraudShading(NewTriangle currentTriangle, List<Light> lights,Camera camera) : base(currentTriangle,lights,camera) {
            CurrentTriangle = currentTriangle;
        }


        public override Color GetColor(int x, int y, int z )
        {
            var color = GetInterpolatedColor(x, y);
            return color;
        }






        //private void CalculateColor
    }
}
