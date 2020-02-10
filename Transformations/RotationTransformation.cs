using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace GK_4
{
    class TransformationBuilder
    {
        public static Matrix<double>  GetZRotationMatrix(double angle) {
            var matrix = Matrix<double>.Build.DenseIdentity(4);
            matrix[0, 0] = Math.Cos(angle);
            matrix[0, 1] = (-1) * Math.Sin(angle);
            matrix[1, 0] = Math.Sin(angle);
            matrix[1, 1] = Math.Cos(angle);
            return matrix;
        }

        public static Matrix<double>  GetXRotationMatrix(double angle)
        {
            var matrix = Matrix<double>.Build.DenseIdentity(4);
            matrix[1, 1] = Math.Cos(angle);
            matrix[1, 2] = (-1) * Math.Sin(angle);
            matrix[2, 1] = Math.Sin(angle);
            matrix[2, 2] = Math.Cos(angle);
            return matrix;
        }

        public static Matrix<double> GetYRotationMatrix(double angle)
        {
            var matrix = Matrix<double>.Build.DenseIdentity(4);
            matrix[0, 0] = Math.Cos(angle);
            matrix[0, 2] =  Math.Sin(angle);
            matrix[2, 0] = (-1)*Math.Sin(angle);
            matrix[2, 2] = Math.Cos(angle);
            return matrix;
        }
        public static Matrix<double> GetTranslationMatrix(Vector<double> translationVector)
        {
            var matrix = Matrix<double>.Build.DenseIdentity(4);
            matrix[0, 3] = translationVector[0];
            matrix[1, 3] = translationVector[1];
            matrix[2, 3] = translationVector[2];
            return matrix;
        }


    }
}
