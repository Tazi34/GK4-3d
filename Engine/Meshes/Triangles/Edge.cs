using MathNet.Numerics.LinearAlgebra;

namespace GK_4.Engine.Meshes.Triangles
{
    public class Edge
    {
        public Vector<double> A { get; set; }
        public Vector<double> B { get; set; }

        public int YMax
        {
            get => (int) (A[1] > B[1] ? A[1] : B[1]);
            set { }
        }

        public double Slope { get; set; }
        public double X { get; set; }

        public override string ToString()
        {
            return $"{A}  {B}";
        }
    }
}