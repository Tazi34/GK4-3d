using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GK_4.Engine.Meshes.Triangles;
using System.Threading.Tasks;

namespace GK_4.Engine.Meshes { 
    class Sphere : Mesh
    {
        public Sphere() {
            Triangles = new List<Triangle>();

            List<Vector<double>> vectors = new List<Vector<double>>();
            List<int> indices = new List<int>();
            GeometryProvider.Icosahedron(vectors, indices);
            for (int i = 0; i <3; i++)
            {
                GeometryProvider.Subdivide(vectors, indices, true);
            }
           

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
                Triangles.Add(
                    new Triangle
                    (
                         new ModelVertex { Position = Vertices[indices[i]], NormalVector = CalculateNormalVector(Vertices[indices[i]]) },
                         new ModelVertex { Position = Vertices[indices[i + 1]], NormalVector = CalculateNormalVector(Vertices[indices[i+1]]) },
                        new ModelVertex { Position = Vertices[indices[i + 2]], NormalVector = CalculateNormalVector(Vertices[indices[i+2]]) },
                       Color.Red
                    ));

            }

        }
        private Vector<double> CalculateNormalVector(Vector<double> position) {
            var vector = CreateVector.Dense<double>(4);
            vector[0] = position[0]; // length;
            vector[1] = position[1]; /// length;
            vector[2] = position[2]; /// length;
            vector[3] = 0;
            return vector;
        }
    }
}
