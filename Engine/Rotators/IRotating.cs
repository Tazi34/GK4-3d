using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace GK_4.Engine.Rotators
{
    public interface IRotating
    {
        Vector<double> Position { get; set; }
        Vector<double> Target { get; set; }
    }
}