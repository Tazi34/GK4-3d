using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4.Engine
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
    }
}
