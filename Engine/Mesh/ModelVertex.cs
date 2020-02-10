using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4.Engine.Mesh
{
    public class ModelVertex
    {
        public Vector<double> Position { get; set; }
        public Vector<double> NormalVector { get; set; }

        public override string ToString()
        {
            return $"ModelVertex\n Pos:{Position}\nNormal:{NormalVector} ";
        }
    }
}
