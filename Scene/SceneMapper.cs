using System.Collections.Generic;
using System.Linq;
using GK_4.Engine.Meshes;
using GK_4.Engine.Meshes.Triangles;
using GK_4.Transformations;
using MathNet.Numerics.LinearAlgebra;

namespace GK_4.Scene
{
    public class SceneMapper
    {
         public List<Triangle> MapMeshTo2D(MeshEngine meshEngine,ProjectionTransformation projectionTransformation,CameraTransformation cameraTransformation)
        {
            double width = projectionTransformation.Width;
            double height = projectionTransformation.Height;

            var transformedMeshTriangles = meshEngine.Mesh.Triangles.Select((triangle) =>
            {
                var vertices = triangle.GetVertices();
                Vector<double>[] sceneVertices = new Vector<double>[3];
                Vector<double>[] sceneNormalVectors = new Vector<double>[3];
                Vector<double>[] projectedVertices = new Vector<double>[3];

                for (int j = 0; j < vertices.Length; j++)
                {
                    sceneVertices[j] = meshEngine.ModelTransformationMatrix * vertices[j].Position;
                    sceneNormalVectors[j] = meshEngine.ModelTransformationMatrix * vertices[j].NormalVector;
                    projectedVertices[j] = projectionTransformation.transform(cameraTransformation.transform((sceneVertices[j])));
                    NormalizeVector(projectedVertices[j]);
                    AdjustSize(projectedVertices[j],(int) width,(int) height);
                }
                var tri = new Triangle
                (
                    new MappedVertex
                    {
                        Position = sceneVertices[0], NormalVector = sceneNormalVectors[0],
                        ProjectedPosition = projectedVertices[0]
                    },
                   new MappedVertex
                    {
                        Position = sceneVertices[1], NormalVector = sceneNormalVectors[1],
                        ProjectedPosition = projectedVertices[1]
                    },
                   new MappedVertex
                    {
                        Position = sceneVertices[2], NormalVector = sceneNormalVectors[2],
                        ProjectedPosition = projectedVertices[2]
                    },
                    triangle.Color
                );
                return tri;
            }).ToList();

            return transformedMeshTriangles;
        }
         private void NormalizeVector(Vector<double> vector)
         {
             for (int i = 0; i < vector.Count; i++)
             {
                 vector[i] = vector[i] / vector[3];
             }
         }

         private void AdjustSize(Vector<double> vector,int width,int height)
         {

             var x = vector[0];
             vector[0] = (x + 1) * width / 2;

             var y = vector[1];
             vector[1] = (y + 1) * height / 2;
         }

    }
}