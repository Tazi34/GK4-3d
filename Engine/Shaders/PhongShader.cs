
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
using GK_4.Engine.Utils;
using MathNet.Numerics.LinearAlgebra.Double;

namespace GK_4.Engine.Shaders
{
    class PhongShader : Shader
    {
        public override Color GetColor( int x, int y, int z)
        {
            int R = 0;
            int G = 0;
            int B = 0;
   
            var interpolated = InterpolatePoint(x,y);

            var interpolatedVector = interpolated.normalVector;
            var interpolatedPointInScene = interpolated.pointScene;
            foreach (var l in Lights)
            {
                var color = l.CalculateLightForPoint(CurrentTriangle,interpolatedPointInScene ,interpolatedVector ,Scene.Camera.Position);
                R += color.R;
                B += color.B;
                G += color.G;
            }
            return Light.CorrectColor(R, G, B);
        }
        public (Vector<double> pointScene, Vector<double> normalVector) InterpolatePoint(double x, double y)
        {
            var A = CurrentTriangle.A as MappedVertex;
            var B = CurrentTriangle.B as MappedVertex;
            var C = CurrentTriangle.C as MappedVertex;
            
            var a = CreateVector.Dense(new double[] {A.ProjectedPosition[0], A.ProjectedPosition[1]});
            var b = CreateVector.Dense(new double[] {B.ProjectedPosition[0], B.ProjectedPosition[1]});
            var c = CreateVector.Dense(new double[] {C.ProjectedPosition[0], C.ProjectedPosition[1]});

            var bar = AlgebraUtils.Barycentric(CreateVector.Dense(new double[] {x, y}), a, b, c);
           
            var nA = CurrentTriangle.A.NormalVector;
            var nB = CurrentTriangle.B.NormalVector;
            var nC = CurrentTriangle.C.NormalVector;

            var interpolatedVector = bar.alfa * nA + bar.beta * nB + bar.gamma * nC;
            var interpolatedPointInSceneView = bar.alfa * CurrentTriangle.A.Position +
                                               bar.beta * CurrentTriangle.B.Position +
                                               bar.gamma * CurrentTriangle.C.Position;

            return (interpolatedPointInSceneView, interpolatedVector);
        }
        public PhongShader(List<Light> lights, Scene.Scene scene, Triangle currentTriangle = null) : base(lights, scene, currentTriangle)
        {
            CurrentTriangle = currentTriangle;
        }
    }
}
