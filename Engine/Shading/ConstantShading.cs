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
    public class ConstantShading : Shading
    {
        private Color color;

        public ConstantShading(NewTriangle currentTriangle, List<Light> lights) : base(currentTriangle,lights)
        {
            CurrentTriangle = currentTriangle;
        }

        public override NewTriangle CurrentTriangle {
            set {
                base.CurrentTriangle = value;
                if(value != null)
                    SetColor();
            }
        }

        public override Color GetColor(int x, int y, int z )
        {
            return color;
        }

        private void SetColor() {
            int R = 0;
            int G = 0;
            int B = 0;
             foreach (var l in Lights) { 
                var color =  (l as PointLight).CalculateLight(CurrentTriangle);
                R += color.R;
                B += color.B;
                G += color.G;
            }
            color = Light.CorrectColor(R, G, B);
        }
     
  
  


   
    }
}
