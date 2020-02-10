using GK_4;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4
{
    class TranslationTransformation : Transformation
    {
        public Vector<double> TranslationVector { 
            get 
            { 
                return translationVector; 
            }
            set 
            {
                translationVector = value;
                UpdateMatrix();
            } 
        }

        private Vector<double> translationVector;
        public TranslationTransformation() {
            translationVector = Vector<double>.Build.Dense(3,0);
            Matrix = Matrix<double>.Build.DenseIdentity(4);
        }

        public void TranslateX(double x) {
            AddToVectorIndex(0, x);
            UpdateMatrix();
        }

        public void TranslateY(double x)
        {
            AddToVectorIndex(1, x);
            UpdateMatrix();
        }

        public void TranslateZ(double x)
        {
            AddToVectorIndex(2, x);
            UpdateMatrix();
        }

        public void UpdateMatrix() {
            Matrix[0, 3] = translationVector[0];
            Matrix[1, 3] = translationVector[1];
            Matrix[2, 3] = translationVector[2];
        }

        private void AddToVectorIndex(int index, double value) {
            translationVector[index] += value;
        }

        protected override void CalculateMatrix()
        {
            throw new NotImplementedException();
        }
    }
}
