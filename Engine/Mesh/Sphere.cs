using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4.Engine.Mesh
{
    class Sphere : Mesh
    {
        public Sphere() {
            Triangles = new List<NewTriangle>();

            List<Vector<double>> vectors = new List<Vector<double>>();
            List<int> indices = new List<int>();
            GeometryProvider.Icosahedron(vectors, indices);
            GeometryProvider.Subdivide(vectors, indices, true);

            Vertices = vectors.Select((vector) => 
            {
                vector = vector.Normalize(2);
               
                var vector4D = CreateVector.Dense<double>(4);

                for (int i = 0; i < 3; i++)
                    vector4D[i] = vector[i];
                vector4D[3] = 1;
                
                return vector4D;
            }).ToList();
    
            for (int i = 0; i < indices.Count; i += 3)
            {
                var normal = AlgebraUtils.CalculateNormalVector(Vertices[indices[i]], Vertices[indices[i + 1]], Vertices[indices[i + 2]]);
                normal = normal.Divide(normal.Norm(2));
                Triangles.Add(
                    new NewTriangle
                    {
                        A = new ModelVertex { Position = Vertices[indices[i]], NormalVector = normal },
                        B = new ModelVertex { Position = Vertices[indices[i + 1]], NormalVector = normal },
                        C = new ModelVertex { Position = Vertices[indices[i + 2]], NormalVector = normal },
                        Color = Color.Red
                    }); ;
               
            }
            //Triangles.ForEach(el => Console.WriteLine(el));

        }
    }
}
