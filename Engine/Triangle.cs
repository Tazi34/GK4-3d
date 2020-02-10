using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4.Engine
{
    public class Triangle
    {
        public Color color = Color.Blue;
        public Vector<double> A { get; set; }
        public Vector<double> B { get; set; }
        public Vector<double> C { get; set; }

        public Vector<double> NormalVector { get; set; }
        public Triangle(Vector<double> a, Vector<double> b, Vector<double> c)
        {
            A = a;
            B = b;
            C = c;
        }
        public Vector<double> CalculateNormal() { 
            var vector = AlgebraUtils.CrossProduct(C - B, A - B);
            NormalVector = CreateVector.Dense<double>(4);
            NormalVector[0] = vector[0];
            NormalVector[1] = vector[1];
            NormalVector[2] = vector[2];
            NormalVector[3] = 0;
            NormalVector.Normalize(2);
            return NormalVector;
        }
        public Triangle()
        {
            
        }

        public List<Vector<double>> GetVertices() {
            return new List<Vector<double>> { A, B, C };
        }
        public double GetZ(int x, int y)
        {
            double denominator = (B[1] - C[1]) * (A[0] - C[0]) + (C[0] - B[0]) * (A[1] - C[1]);
            var w0 = ((B[1] - C[1]) * (x - C[0]) + (C[0] - B[0]) * (y - C[1])) / denominator;
            var w1 = ((C[1] - A[1]) * (x - C[0]) + (A[0] - C[0]) * (y - C[1])) / denominator;
            var w2 = 1 - w1 - w0;

            return (w0 * A[2] + w1 * B[2] + w2 * C[2]);
        }

        public override string ToString()
        {
            return $"{A} {B} {C}";
        }
    }
}
