using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_4.Engine.Meshes.Triangles;
using MathNet.Numerics.LinearAlgebra;
namespace GK_4.Engine
{
    public class Mesh
    {
        public List<Vector<double>> Vertices { get;set; }
        public List<Triangle> Triangles { get; set; }
    }
}
