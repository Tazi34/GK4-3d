
using GK_4.Lights;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_4.Engine.Cameras;
using GK_4.Engine.Meshes.Triangles;

namespace GK_4.Engine.Shaders
{
    public class FlatShader : Shader
    {
        private Color color;

   

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
             foreach (var l in Lights)
             {
                 var color = l.CalculateLightForPoint(CurrentTriangle, CurrentTriangle.A.Position,
                     CurrentTriangle.A.NormalVector,Scene.Camera.Position);
                R += color.R;
                B += color.B;
                G += color.G;
            }
            color = Light.CorrectColor(R, G, B);
        }


        public FlatShader(List<Light> lights, Scene.Scene scene, Triangle currentTriangle = null) : base(lights, scene, currentTriangle)
        {
            CurrentTriangle = currentTriangle;
        }
    }
}
