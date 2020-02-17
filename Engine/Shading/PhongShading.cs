using GK_4.Engine.Mesh;
using GK_4.Lights;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4.Engine.Shading
{
    class PhongShading : Shading
    {
        public PhongShading(NewTriangle currentTriangle, List<Light> lights,Camera camera) : base(currentTriangle, lights,camera)
        {
            CurrentTriangle = currentTriangle;
        }

      
        public override Color GetColor(int x, int y, int z)
        {
            int R = 0;
            int G = 0;
            int B = 0;

            foreach (var l in Lights)
            {
                var color = (l as PointLight).CalculateLight(CurrentTriangle, CreateVector.Dense(new double[] {x,y,z,1 }), CurrentTriangle.A.NormalVector,Camera.Position);
                R += color.R;
                B += color.B;
                G += color.G;
            }
            var color2 = Light.CorrectColor(R, G, B);
         
            return color2;
        }

       
    }
}
