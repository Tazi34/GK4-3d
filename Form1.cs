

using GK_4;
using GK_4.Engine;
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
using System.Windows.Forms.VisualStyles;

using GK_4.Engine.Cameras;
using GK_4.Scene;

namespace GK_4
{


    public partial class Form1 : Form
    {
        private ScenePainter scenePainter = new ScenePainter();
        private SceneCalculator sceneCalculator;
        private Scene.Scene scene;
        private CameraRotator cameraRotator;
        private double movementCounter = 0;
        private int movementSign = 1;

        public Form1()
        {
            InitializeComponent();
            var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;
            scene = SceneInitializer.InitializeScene(pictureBox1.Width,pictureBox1.Height);
            sceneCalculator = new SceneCalculator(scene);
            sceneCalculator.bitmap = new DirectBitmap(pictureBox1.Width, pictureBox1.Height);
            cameraRotator = new CameraRotator(scene.Camera);
            timer1.Start();
            PaintPictureBox();
        }

    
        private void PaintPictureBox()
        {
            //Console.WriteLine(pictureBox1.Width);
            //scenePainter.PaintScene(pictureBox1, sceneCalculator);
            sceneCalculator.CalculateColors();
            pictureBox1.Image = sceneCalculator.bitmap.Bitmap;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // scene.MovingCube.RotateX(0.1);
            if (movementCounter > 30 || movementCounter < 0)
                movementSign *= -1;

            movementCounter += movementSign;

            scene.MovingCube.MoveZ(movementSign*0.1);
            

            //scene.StationaryCube.MoveZ(0.3);
            //scene.Sphere.RotateX(0.2);
            //cameraRotator.Move(0.01,0);
          // scene.MovingReflector.Position[2] +=1;
            PaintPictureBox();
        }
        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            if (scene != null)
            {
                sceneCalculator.bitmap = new DirectBitmap(pictureBox1.Width, pictureBox1.Height);
                scene.SetSize(pictureBox1.Width, pictureBox1.Height);
                PaintPictureBox();
            }

        }


        public class Edge
        {
            public Vector<double> A { get; set; }
            public Vector<double> B { get; set; }

            public int YMax
            {
                get => (int) (A[1] > B[1] ? A[1] : B[1]);
                set { }
            }

            public double Slope { get; set; }
            public double X { get; set; }

            public override string ToString()
            {
                return $"{A}  {B}";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyHandler.HandleKeyPress(e.KeyCode, scene, cameraRotator))
                PaintPictureBox();

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
