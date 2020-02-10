using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4.Engine.Mesh
{
    public class Cube : Mesh
    {
        public Cube() {

			double[][] verticesArray = {
				new double[] {0, 0, 0 , 1},
				new double[] {1, 0, 0 , 1},
				new double[] {1, 1, 0 , 1},
				new double[] {0, 1, 0 , 1},
				new double[] {0, 1, 1 , 1},
				new double[] {1, 1, 1 , 1},
				new double[] {1, 0, 1 , 1},
				new double[] { 0, 0, 1, 1 }
			};

			Vertices = verticesArray.Select((el) => CreateVector.Dense(el)).ToList();

			
			int[][] trianglesVerticesIndexes = {
				new int[] {0, 2, 1 }, //face front
				new int[] {0, 3, 2},
				new int[] {2, 3, 4}, //face top
				new int[] {2, 4, 5},
				new int[] {1, 2, 5}, //face right
				new int[] {1, 5, 6},
				new int[] {0, 7, 4}, //face left
				new int[] {0, 4, 3},
				new int[] {5, 4, 7}, //face back
				new int[] {5, 7, 6},
				new int[] {0, 6, 7}, //face bottom
				new int[] {0, 1, 6}
			};




			Triangles = trianglesVerticesIndexes.Select((el) => {
				var A = Vertices[el[0]];
				var B = Vertices[el[1]];
				var C = Vertices[el[2]];
				var normal = AlgebraUtils.CalculateNormalVector(A, B, C);



				return new NewTriangle
				{
					A = new ModelVertex { Position = A, NormalVector = normal },
					B = new ModelVertex { Position = B, NormalVector = normal },
					C = new ModelVertex { Position = C, NormalVector = normal },
					Color = Color.Yellow,
				};
				}).ToList();

			//Triangles.ForEach((el) => Console.WriteLine(el));
		}
    }
}
