using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
namespace GK_4.Engine.Mesh
{
    public class Mesh
    {
        
        public List<Vector<double>> Vertices { get;set; }
        public List<NewTriangle> Triangles { get; set; }

    }
}
