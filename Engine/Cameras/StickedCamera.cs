using GK_4.Engine.Meshes;
using MathNet.Numerics.LinearAlgebra;

namespace GK_4.Engine.Cameras
{
    public class StickedCamera : Camera
    {
        public MeshEngine MeshEngine { get; set; }
        public StickedCamera(Vector<double> position, Vector<double> target, Vector<double> upVector,MeshEngine meshEngine = null) : base(position, target, upVector)
        {
            if (meshEngine != null)
            {
                MeshEngine = meshEngine;
                meshEngine.MeshMoved += ChangePosition;
            }
        }
        
        private void ChangePosition(object sender,Vector<double> vector)
        {
            Position += vector;
        }
    }
}