using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4
{
    public class ProjectionTransformation : Transformation
    {
        private double N { get; }
        private double F { get;  }
        private double aspectRatio;
        private double FOV { get; }
        private double e;
        public double Width
        {
            get => width;
            set
            {
                width = value;
                aspectRatio =  (height / width);
                CalculateMatrix();
            }
        }
        public double Height
        {
            get => height;
            set
            {
                height = value;
                aspectRatio = height/width;
                CalculateMatrix();
            }
        }
        private double width;
        private double height;
        
        private void CalculateMatrix()
        {
            Matrix[0, 0] = e;
            Matrix[1, 1] = e / aspectRatio;
            Matrix[2, 2] = (-1) * (F + N) / (F - N);
            Matrix[2, 3] = 2 * F * N * (-1) / (F - N);
            Matrix[3, 2] = -1;
            Matrix[3, 3] = 0;
        }
        public ProjectionTransformation(int width, int height) {
            N = 1;
            F = 45;
            FOV = 45;
            
            e = 1 / Math.Tan(Math.PI * FOV / 180 / 2);
            Matrix = Matrix<double>.Build.Dense(4, 4, 0);
            SetSize(width, height);
        }
        public void SetSize(int width, int height)
        {
            this.width = width;
            this.height = height;
            aspectRatio = (double) height  / (double) width;
            CalculateMatrix();
        }
    }
}
