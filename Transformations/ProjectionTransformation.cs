using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4
{
    class ProjectionTransformation : Transformation
    {

        public double N { get; }
        public double F { get;  }
        private double aspectRatio;
        public double FOV { get; }
        private double e;
        public double Width
        {
            get
            { return width; }
            set
            {
                width = value;
                aspectRatio = height / width;
                SetParameters();
            }
        }
        public double Height
        {
            get
            { return height; }
            set
            {
                height = value;
                aspectRatio = height/width;
                SetParameters();
            }
        }
        private double width;
        private double height;

        private void SetParameters() {
            Matrix[0, 0] = e;
            Matrix[1, 1] = e / aspectRatio;
            Matrix[2, 2] = (-1) * (F + N) / (F - N);
            Matrix[2, 3] = 2 * F * N * (-1) / (F - N);
            Matrix[3, 2] = -1;
            Matrix[3, 3] = 0;
        }

        protected override void CalculateMatrix()
        {
            throw new NotImplementedException();
        }

        public ProjectionTransformation(int width, int height) {
            N = 1;
            F = 45;
            this.width = width;
            this.height = height;
            aspectRatio = height / width;
            FOV = 45;
            
            e = 1 / Math.Tan(Math.PI * FOV / 180 / 2);
            Matrix = Matrix<double>.Build.Dense(4, 4, 0);
            SetParameters();


        }

    }
}
