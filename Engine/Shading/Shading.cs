

using GK_4.Lights;
using System.Collections.Generic;
using System.Drawing;
using GK_4.Engine.Cameras;

namespace GK_4.Engine.Shading
{
    public abstract class Shading
    {
        protected Camera Camera { get; set; }
        private Triangle currentTriangle;
        public List<Light> Lights { get; set; }

        protected Shading(Triangle currentTriangle,List<Light> lights, Camera camera)
        {
            Camera = camera;
            Lights = lights;
            CurrentTriangle = currentTriangle;
        }

        public virtual Triangle CurrentTriangle { get { return currentTriangle; } set { currentTriangle = value; } }
        public abstract Color GetColor(int x, int y,int z);
    }
}
