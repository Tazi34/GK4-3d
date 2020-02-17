

using GK_4;
using GK_4.Engine;
using GK_4.Engine.Mesh;
using GK_4.Engine.Shading;
using GK_4.Lights;
using GK_4.Transformations;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_4
{


    public partial class Form1 : Form
    {
        private double time = 0;
        private double angle = 0;
        private Matrix<double> rotationMatrix = CreateMatrix.DenseIdentity<double>(4);
        private CameraTransformation cameraTransformation;
        TranslationTransformation translation = new TranslationTransformation();
        private List<Light> lights = new List<Light>();
        private ProjectionTransformation projectionTransformation;
        private Shading shading;
        

        private Camera camera = new Camera
        {
            Position = CreateVector.Dense(new double[] {3,3,3,1 }),
            Target = CreateVector.Dense(new double[] { 0, 0.5,0.5,1 }),
            UpVector = CreateVector.Dense(new double[] { 0, 0, 1,1 })
        };
    
        private List<Mesh> meshes = new List<Mesh>();
        public Form1()
        {
            lights.Add(new PointLight { Position =// camera.Position });
                   CreateVector.Dense(new double[] { 2, 2, 2, 1 }) });
                                                                       //pointLight = new PointLight { Position = camera.Position };
            InitializeComponent();
           
            meshes.Add(new Sphere());
            //meshes.Add(new Cube());
   
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            cameraTransformation = new CameraTransformation(camera);
            projectionTransformation = new ProjectionTransformation(pictureBox1.Width, pictureBox1.Height); ;
            timer1.Start();

            //shading = new ConstantShading(null, lights,camera);
            shading = new GouraudShading(null, lights,camera);
            //shading = new PhongShading(null, lights,camera);

            PaintScene();
        }
      
        private void PaintScene()
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            projectionTransformation.Width = width;
            projectionTransformation.Height = height;

            var zBuffor = new double[width][];
            for (int i = 0; i < width; i++) {
                zBuffor[i] = new double[height];
                for (int j = 0; j < height; j++) {
                    zBuffor[i][j] = double.MaxValue;
                }
            }
            var bitmapColors = new Color[width,height];
            foreach (var mesh in meshes) { 
                var transformedMeshTriangles = mesh.Triangles.Select((triangle) =>
                {

                    var vertices = triangle.GetVertices();
                    Vector<double>[] viewVertices = new Vector<double>[3];
                    Vector<double>[] viewNormalVectors = new Vector<double>[3];
                    Vector<double>[] projectedVertices = new Vector<double>[3];

                    for (int j = 0; j < vertices.Length; j++) {
                        viewVertices[j] = cameraTransformation.transform(rotationMatrix.Multiply(translation.transform(vertices[j].Position)));
                        projectedVertices[j] = projectionTransformation.transform(viewVertices[j]);
                        NormalizeVector(projectedVertices[j]);
                        projectedVertices[j] = AdjustToScreen(projectedVertices[j], width, height);
                        viewNormalVectors[j] = cameraTransformation.transform(rotationMatrix.Multiply(translation.transform(vertices[j].NormalVector)));
                        viewNormalVectors[j] = viewNormalVectors[j].Divide(viewNormalVectors[j].Norm(2));
                    }
                    var tri = new NewTriangle()
                    {
                        A = new MappedVertex { Position = viewVertices[0], NormalVector = viewNormalVectors[0], ProjectedPosition = projectedVertices[0] },
                        B = new MappedVertex { Position = viewVertices[1], NormalVector = viewNormalVectors[1], ProjectedPosition = projectedVertices[1] },
                        C = new MappedVertex { Position = viewVertices[2], NormalVector = viewNormalVectors[2], ProjectedPosition = projectedVertices[2] },
                        Color = triangle.Color,
                    };
                    return tri;
                }).ToList();

                Pen pen = new Pen(Brushes.Black);
                transformedMeshTriangles.ForEach((el) => {
                    FillTriangle(el,shading, zBuffor, bitmapColors);

                });
               
            }

            var bitmap = FillBitmap(bitmapColors, width, height);
            pictureBox1.Image = bitmap;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            angle += 0.1;
            rotationMatrix = TransformationBuilder.GetYRotationMatrix(angle);
            //* TransformationBuilder.GetXRotationMatrix(angle)*TransformationBuilder.GetZRotationMatrix(angle);
                                                                             //var radius = 3;
                                                                             //var x = radius * Math.Cos(time);
                                                                             // var y = radius * Math.Sin(time);
                                                                             //time += 0.1;
                                                                             //camera.Position = CreateVector.Dense(new double[] { 3 , 0.5 + y, 0.5, 1 });
                                                                             // cameraTransformation.Update();
            PaintScene();
            //translation.TranslationVector[0] = translation.TranslationVector[0] + 0.1;
            // translation.TranslationVector[1] = translation.TranslationVector[1] + 0.1;
            //translation.TranslationVector[2] = translation.TranslationVector[2] + 0.1;
            //translation.UpdateMatrix();

        }
        public void FillTriangle(NewTriangle triangle, Shading shader, double[][] zBuffor, Color[,] pixelsColors)
        {         

            var points = triangle.GetVertices().Select((vertex) => (vertex as MappedVertex).ProjectedPosition).ToList();
            shader.CurrentTriangle = triangle;

            int yMin = points.Min(a => (int)a[1]);
            int yMax = points.Max(a => (int)a[1]);
            var ET = new List<Edge>[yMax - yMin + 1];


            //CREATE EDGE BUCKET
            for (int i = 0; i < points.Count; i++)
            {
                var p1 = points[i];
                var p2 = points[i == points.Count - 1 ? 0 : i + 1];

                //HORIZONTAL LINE
                if (p1[1] == p2[1]) continue;
                //swap
                if (p1[1] > p2[1])
                {
                    var tmp = p2;
                    p2 = p1;
                    p1 = tmp;
                }

                var edge = new Edge
                {
                    A = p1,
                    B = p2,
                    YMax = (int)p2[1],
                    X = p1[0],
                    Slope = (double)(p1[0] - p2[0]) / (p1[1] - p2[1])
                };


                //IF FIRST EDGE
                if (ET[(int)(p1[1] - yMin)] == null)
                    ET[(int)(p1[1] - yMin)] = new List<Edge>();
                ET[(int)(p1[1] - yMin)].Add(edge);
            }



            var AET = new List<Edge>();

            //PROCESS EDGE BUCKET
            for (int k = yMin; k < yMax; k++)
            {
                if (ET[k - yMin] != null)
                {
                    var tempList = ET[k - yMin];
                    AET.AddRange(tempList);
                }
                //SORT AET 
                AET = AET.OrderBy(a => a.X).ToList();
                for (int i = 0; i < AET.Count; i += 2)
                {
                    //JUMP LAST ELEMENT 
                    if (AET.Count - i == 1)
                    {
                        continue;
                    }
                    var firstEdge = AET[i];
                    var secondEdge = AET[i + 1];

                    //DRAW LINE
                    for (int j = (int)firstEdge.X; j < secondEdge.X; j++)
                    {

                        if (k >= 0 && k < zBuffor[0].Length && j< zBuffor.GetLength(0)  && j >= 0)
                        {
                            var z = triangle.GetZ(j, k);
                            if (z <= zBuffor[j][k])
                            {
                                zBuffor[j][k] = z;
                                
                                var color = shader.GetColor(j, k,(int)z);
                                pixelsColors[j, k] = color;
                            }
                        }
                    }

                }
                foreach (var edge in AET.ToList())
                {
                    //IF PROCESSED (maxY = k+1) remove
                    if (edge.YMax == k + 1)
                    {
                        AET.Remove(edge);
                    }
                    //MOVE X 
                    else
                    {
                        edge.X += edge.Slope;
                    }
                }
            }
        }
        
        public Bitmap FillBitmap(Color[,] colors,int width, int height) {
            Bitmap bitmap = new Bitmap(width,height);
            unsafe
            {
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width,height), ImageLockMode.ReadWrite, bitmap.PixelFormat);

                int bytesPerPixel = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, heightInPixels, y =>
                {
                    byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        currentLine[x] = colors[x / 4, y].B;
                        currentLine[x + 1] = colors[x / 4, y].G;
                        currentLine[x + 2] = colors[x / 4, y].R;
                        currentLine[x + 3] = colors[x / 4, y].A;
                    }
                });
                bitmap.UnlockBits(bitmapData);
            }
            return bitmap;
        }
        public Vector<double> AdjustToScreen(Vector<double> vector,int width,int height) {
            var x = vector[0];
            vector[0] = (x + 1) *width / 2;

            var y = vector[1];
            vector[1] = (y + 1) * height / 2;

            return vector;
        }  
   
        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            PaintScene();
        }
        public static void NormalizeVector(Vector<double> vector)
        {
            for (int i = 0; i < vector.Count; i++)
            {
                vector[i] = vector[i] / vector[3];
            }
        }
    }

    public class Edge
    {
        public Vector<double> A { get; set; }
        public Vector<double> B { get; set; }

        public int YMax
        {
            get
            {
                return (int) ( A[1] > B[1] ? A[1] : B[1]);
            }
            set { }
        }
        public double Slope { get; set; }
        public double X { get; set; }

        public override string ToString()
        {
            return $"{A}  {B}";
        }
    }
}
