

using GK_4.Lights;
using System.Collections.Generic;
using System.Drawing;
using GK_4.Engine.Cameras;
using GK_4.Engine.Meshes.Triangles;

namespace GK_4.Engine.Shaders
{
    public abstract class Shader
    {
        protected Scene.Scene Scene { get; set; }
        private Triangle currentTriangle;
        public List<Light> Lights { get; set; }

        protected Shader(List<Light> lights,Scene.Scene scene,Triangle currentTriangle = null)
        {
            Scene = scene;
            Lights = lights;
            CurrentTriangle = currentTriangle;
        }

        public virtual Triangle CurrentTriangle { get { return currentTriangle; } set { currentTriangle = value; } }
        public abstract Color GetColor(int x, int y,int z);
    }
    
    public enum ShaderType  {
        CONSTANT,PHONG,GOURAUD
    }
}
