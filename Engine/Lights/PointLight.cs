﻿using GK_4.Engine;
using GK_4.Engine.Mesh;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4.Lights
{
    public class PointLight : Light
    {

        public Vector<double> Position { get; set; }
        //Constant shading
        public Color CalculateLight(NewTriangle triangle) {
            //Distracted light
            double kd = 1;
            Vector<double> L = CreateVector.Dense(new double[] { 0, 0, 1, 0 });

            var N = triangle.A.NormalVector;
            var Io = triangle.Color;
            var NL = (N * L);

            var distractedR = (kd * Io.R * Color.R * NL / 255);
            var distractedG = (kd * Io.G * Color.G * NL / 255);
            var distractedB = (kd * Io.B * Color.B * NL / 255);

            //Reflected light
            double ks = 1;
            Vector<double> cameraPosition = CreateVector.Dense(new double[] { 10000, 10000, 10000, 1 });
            var v = cameraPosition - triangle.A.Position;
            v = v.Divide(v.Norm(2));
            var vectoR = 2 * (NL) * N - L;
            var VR = v * vectoR;
            var m = 5;

            var reflectedR = (ks * Io.R * Color.R * Math.Pow(VR,m) / 255);
            var reflectedG = (ks * Io.G * Color.G * Math.Pow(VR,m) / 255);
            var reflectedB = (ks * Io.B * Color.B * Math.Pow(VR,m) / 255);

         /*   reflectedR = 0;
            reflectedG = 0;
            reflectedB = 0;*/
            //Console.WriteLine($"{reflectedR} {reflectedG} {reflectedB}");

            int R = (int)(distractedR+reflectedR);
            int G = (int)(distractedG+reflectedG);
            int B = (int)(distractedB+reflectedB);

            return Light.CorrectColor(R, G, B);
        }
        public Color CalculateLight(NewTriangle triangle,Vector<double> point, Vector<double> normal, Vector<double> cameraPosition)
        {
            double kd = 1;
            Vector<double> L = Position - point;
            L = L.Divide(L.Norm(2));

            var N = normal;
            var Io = triangle.Color;

            double NL = (N * L);
            var distractedR = (kd * Io.R * Color.R * NL / 255);
            var distractedG = (kd * Io.G * Color.G * NL / 255);
            var distractedB = (kd * Io.B * Color.B * NL / 255);

            //Reflected light
            double ks = 1;
    
            var v = cameraPosition - point;
            v = v.Divide(v.Norm(2));
            var vectoR = 2 * (NL) * N - L;
            var VR = v * vectoR;
            var m = 1;

            var reflectedR = (ks * Io.R * Color.R * Math.Pow(VR, m) / 255);
            var reflectedG = (ks * Io.G * Color.G * Math.Pow(VR, m) / 255);
            var reflectedB = (ks * Io.B * Color.B * Math.Pow(VR, m) / 255);

            int R = (int)(distractedR + reflectedR);
            int G = (int)(distractedG + reflectedG);
            int B = (int)(distractedB + reflectedB);
            return Light.CorrectColor(R, G, B);
        }
    }
}