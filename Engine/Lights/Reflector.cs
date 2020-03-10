
using GK_4.Engine;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_4.Engine.Meshes.Triangles;
using GK_4.Engine.Rotators;
using GK_4.Engine.Shaders;

namespace GK_4.Lights
{
    public class Reflector : Light, IRotating
    {
        private Vector<double> target;
        private Vector<double> position;

        public Vector<double> Position
        {
            get => position;
            set {
                position = value;
                Direction = target - Position;
                Direction = Direction.Normalize(2);
            }
        }

        public Reflector(Vector<double> target, Vector<double> position)
        {
            this.target = target;
            this.position = position;
            Target = target;
            Position = position;
            Color = Color = Color.White;
        }

        public Vector<double> Direction { get; private set; }

        public Vector<double> Target
        {
            get => target;
            set {
                target = value;
                Direction = target - Position;
                Direction = Direction.Normalize(2);
            }
        }

        public int Coefficiant { get; set;}


        public override Color CalculateLightForPoint(Triangle triangle, Vector<double> point, Vector<double> normal, Vector<double> cameraPosition)
        {
            double kd = 1;
            
            Vector<double> L = Position - point;
            L = L.Normalize(2);
            var N = normal;
            var Io = triangle.Color;

            double NL = (N * L);
        
            //Calculate intensity
            var IrefR = Color.R * Math.Pow((Direction.Multiply(-1) * L), Coefficiant);
            var IrefG = Color.G * Math.Pow((Direction.Multiply(-1) * L), Coefficiant);
            var IrefB = Color.B * Math.Pow((Direction.Multiply(-1) * L), Coefficiant);

          
            //Calculate distracted light
            var distractedR = (kd  *Io.R * IrefR* NL /255);
            var distractedG = (kd  *Io.G * IrefG* NL /255);
            var distractedB = (kd  *Io.B * IrefB* NL /255);
            
            //Reflected light
            double ks = 1;
            var v = cameraPosition - point;
            v = v.Divide(v.Norm(2));
            var vectorR = 2 * (NL) * N - L;
            var VR = v * vectorR;
            var m = 100;

            var reflectedR = (ks *Io.R* IrefR * Math.Pow(VR, m)/255 );
            var reflectedG = (ks *Io.G* IrefG * Math.Pow(VR, m) /255);
            var reflectedB = (ks *Io.B* IrefB * Math.Pow(VR, m)/255 );

            int R = (int)(distractedR + reflectedR);
            int G = (int)(distractedG + reflectedG);
            int B = (int)(distractedB + reflectedB);
           
            return CorrectColor(R, G, B);
        }
        

        // public override Color CalculateLightForTriangle(Triangle triangle)
        // {
        //     return Color.Green;
        // }
    }
}
