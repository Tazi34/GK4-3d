using MathNet.Numerics.LinearAlgebra;

namespace GK_4.Engine.Utils
{
    class AlgebraUtils
    {

        public static Vector<double> CrossProduct(Vector<double> left, Vector<double> right)
        {
            var result = CreateVector.Dense<double>(3);
            result[0] = left[1] * right[2] - left[2] * right[1];
            result[1] = -left[0] * right[2] + left[2] * right[0];
            result[2] = left[0] * right[1] - left[1] * right[0];

            return result;
        }

        public static Vector<double> CalculateNormalVector(Vector<double> pointA, Vector<double> pointB, Vector<double> pointC) {
            var vector = CrossProduct(pointC - pointB, pointA - pointB);
            var normalVector = CreateVector.Dense<double>(4);
            normalVector[0] = vector[0];
            normalVector[1] = vector[1];
            normalVector[2] = vector[2];
            normalVector[3] = 0;
            normalVector.Normalize(2);
            return normalVector;
        }
        public static (double alfa,double beta, double gamma) Barycentric(Vector<double> p, Vector<double> a, Vector<double> b,Vector<double> c)
        {
            
            Vector<double> AB = b - a, AC = c - a, AP = p - a;
            double d00 = AB*AB;
            double d01 = AB*AC;
            double d11 = AC*AC;
            double d20 = AP*AB;
            double d21 = AP*AC;
            double denom = d00 * d11 - d01 * d01;
            var v = (d11 * d20 - d01 * d21) / denom;
            var w = (d00 * d21 - d01 * d20) / denom;
            var u = 1.0f - v - w;
            return (v, w, u);
        }
        
       
    }
}
