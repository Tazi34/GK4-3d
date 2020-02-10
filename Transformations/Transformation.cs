using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4
{
    public abstract class Transformation
    {
        public Matrix<double> Matrix { get; set; }

        protected Transformation(Matrix<double> matrix)
        {
            Matrix = matrix;
        }

        protected Transformation()
        {
            Matrix = CreateMatrix.DenseIdentity<double>(4);
        }

        protected abstract void CalculateMatrix();

        public Vector<double> transform(Vector<double> v) {
            return Matrix * v;
        }

    }
}
