

using GK_4;
using GK_4.Engine;
using GK_4.Engine.Shaders;
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
using GK_4.Engine.Utils;
using GK_4.Scene;
using Rotator = GK_4.Engine.Rotators.Rotator;

namespace GK_4
{


    public partial class Form1 : Form
    {

        private readonly SceneCalculator sceneCalculator;
        private readonly Scene.Scene scene;
        private readonly Rotator rotator;
        private double movementCounter = 0;
        private int movementSign = 1;

        private readonly Dictionary<CameraType, Camera> cameras = new Dictionary<CameraType, Camera>();
        private readonly Dictionary<ShaderType, Shader> shaders = new Dictionary<ShaderType, Shader>();
        
        



        public Form1()
        {
            InitializeComponent();
            var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;

            var (scene1, dictionary, shadings) = SceneInitializer.InitializeProject(pictureBox1.Width, pictureBox1.Height);
            scene = scene1;
            cameras = dictionary;
            shaders = shadings;
            
            sceneCalculator = new SceneCalculator(scene);
            sceneCalculator.bitmap = new DirectBitmap(pictureBox1.Width, pictureBox1.Height);
            rotator = new Rotator(scene.Camera);
            timer1.Start();
            
            gouraudShadingRadioButton.Checked = true;
            stationaryCameraRadioButton.Checked = true;
            xNumeric.Value = (decimal) scene.Camera.Position[0];
            yNumeric.Value = (decimal) scene.Camera.Position[1];
            zNumeric.Value = (decimal) scene.Camera.Position[2];
            PaintPictureBox();
        }
        
        private void PaintPictureBox()
        {
            sceneCalculator.PaintScene();
            pictureBox1.Image = sceneCalculator.bitmap.Bitmap;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (movementCounter > 20 || movementCounter < -5)
                movementSign *= -1;

            movementCounter += movementSign;

            scene.MovingCube.MoveZ(movementSign*0.2);
            rotator.Rotating = scene.MovingReflector;
           rotator.Move(0.1,0);
           scene.MovingCube.Rotate(0.1,0.1,0.1);
           PaintPictureBox();
        }
        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            if (scene != null)
            {
                scene.SetSize(pictureBox1.Width, pictureBox1.Height);
                PaintPictureBox();
            }
        }
        private void stationaryCameraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (stationaryCameraRadioButton.Checked)
            {
                cameraPoistionContainer.Visible = true;
                scene.Camera = cameras[CameraType.STATIONARY];
                PaintPictureBox();
            }
        }

        private void followingCameraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (followingCameraRadioButton.Checked)
            {
                scene.Camera = cameras[CameraType.FOLLOWING];
                cameraPoistionContainer.Visible = true;
                PaintPictureBox();
            }
        }

        private void movingCameraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (movingCameraRadioButton.Checked)
            {
                cameraPoistionContainer.Visible = false;
                scene.Camera = cameras[CameraType.STICKY];
                PaintPictureBox();
            }
        }

        private void constantShadingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (constantShadingRadioButton.Checked)
            {
                scene.Shader = shaders[ShaderType.CONSTANT];
                PaintPictureBox();
            }
        }

        private void gouraudShadingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (gouraudShadingRadioButton.Checked)
            {
                scene.Shader = shaders[ShaderType.GOURAUD];
                PaintPictureBox();
            }
        }
        private void phongShadingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (phongShadingRadioButton.Checked)
            {
                scene.Shader = shaders[ShaderType.PHONG];
                PaintPictureBox();
            }
        }
        private void xNumeric_ValueChanged(object sender, EventArgs e)
        {
            scene.Camera.Position[0] = (double) xNumeric.Value;
        }
        private void yNumeric_ValueChanged(object sender, EventArgs e)
        {
            scene.Camera.Position[1] = (double) yNumeric.Value;
        }
        private void zNumeric_ValueChanged(object sender, EventArgs e)
        {
            scene.Camera.Position[2] = (double) zNumeric.Value;
        }
    }
}
