using GK_4.Engine;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4.Transformations
{
    class CameraTransformation : Transformation
    {
   
        public Camera Camera {
            get
            {
                return camera;
            }

            set {
                camera = value;
                CalculateMatrix();
            }
        }
        public void Update() {
            CalculateMatrix();
        }

        private Camera camera;

        public CameraTransformation(Camera camera)
        {
            Camera = camera;
            CalculateMatrix();
        }
      

        protected override void CalculateMatrix()
        {
            var cPos = Camera.Position;
            var cTarget = Camera.Target;
            var cUp = Camera.UpVector;

            var cZ = (cPos - cTarget).Normalize(2);
            var cX = AlgebraUtils.CrossProduct(cUp, cZ).Normalize(2);
            //Console.WriteLine("cX " + cX);


            var cY = AlgebraUtils.CrossProduct(cZ, cX).Normalize(2);


            /*    Console.WriteLine("cPos " + cPos);
                Console.WriteLine("cTarget " + cTarget);
                Console.WriteLine("cUp " + cUp);*/

            /*            Console.WriteLine("cX " + cX);
                        Console.WriteLine("cY " + cY);*/

            /*Console.WriteLine("cZ " + (cPos - cTarget));
            Console.WriteLine("cZ " + cZ);*/


            Matrix[0, 0] = cX[0];
            Matrix[1, 0] = cX[1];
            Matrix[2, 0] = cX[2];


            Matrix[0, 1] = cY[0];
            Matrix[1, 1] = cY[1];
            Matrix[2, 1] = cY[2];

            Matrix[0, 2] = cZ[0];
            Matrix[1, 2] = cZ[1];
            Matrix[2, 2] = cZ[2];

            Matrix[0, 3] =  cPos[0];
            Matrix[1, 3] =  cPos[1];
            Matrix[2, 3] =  cPos[2];
     
            Matrix = Matrix.Inverse();
 

        }

   
    }
}
