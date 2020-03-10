using System;
using GK_4.Engine.Cameras;
using GK_4.Engine.Shaders;
using MathNet.Numerics.LinearAlgebra;

namespace GK_4.Engine.Rotators
{
    public class Rotator
    {
        public IRotating Rotating { get; set; }

        public Rotator(Camera rotating)
        {
            Rotating = rotating;
        }

        private double GetZRadius()
        {
            var vector = Rotating.Position - Rotating.Target;
            var radius = (Math.Sqrt(Math.Pow(vector[0],2) + Math.Pow(vector[1],2)));
            return radius;
        }
        private double GetYRadius()
        {
            var vector = Rotating.Position - Rotating.Target;
            var radius = (Math.Sqrt(Math.Pow(vector[0], 2) + Math.Pow(vector[2], 2)));
            return radius;
        }

        // xNew = a + r*cos(alfa+beta)
        public void MoveX(double alfa)
        { 
            
            var a = Rotating.Target[0];
            var b = Rotating.Target[1];

            var x = Rotating.Position[0];
            var y = Rotating.Position[1];
            
            var r = GetZRadius();
            var newPosition = CreateVector.Dense(new double[] { Math.Cos(alfa) * x - Math.Sin(alfa) * y, Math.Cos(alfa) * y + Math.Sin(alfa) * x, Rotating.Position[2], 1});
            Rotating.Position = newPosition;
        }

        public void Move(double alfa, double beta)
        {
            MoveX(alfa);
            MoveY(beta);

        }

        public void MoveY(double alfa)
        {

            var a = Rotating.Target[0];
            var b = Rotating.Target[1];

            var x = Rotating.Position[0];
            var z = Rotating.Position[2];
            
            var r = GetYRadius();
            var newPosition = CreateVector.Dense(new double[] { Math.Cos(alfa) * x - Math.Sin(alfa) * z,  Rotating.Position[1], Math.Cos(alfa) * z + Math.Sin(alfa) * x, 1 });
            Rotating.Position = newPosition;
        }
    }
}