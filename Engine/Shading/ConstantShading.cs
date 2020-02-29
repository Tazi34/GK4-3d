
using GK_4.Lights;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_4.Engine.Cameras;
namespace GK_4.Engine.Shading
{
    public class ConstantShading : Shading
    {
        private Color color;

        public ConstantShading(Triangle currentTriangle, List<Light> lights, Camera camera) : base(currentTriangle,lights, camera)
        {
            CurrentTriangle = currentTriangle;
        }

        public override Triangle CurrentTriangle {
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
                var color =  l.CalculateLightForTriangle(CurrentTriangle);
                R += color.R;
                B += color.B;
                G += color.G;
            }
            color = Light.CorrectColor(R, G, B);
        }
     
  
  


   
    }
}
