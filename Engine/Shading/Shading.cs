using GK_4.Engine.Mesh;
using GK_4.Lights;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4.Engine.Shading
{
    public abstract class Shading
    {
        private NewTriangle currentTriangle;
        public List<Light> Lights { get; set; }

        protected Shading(NewTriangle currentTriangle,List<Light> lights)
        {
            Lights = lights;
            CurrentTriangle = currentTriangle;
        }

        public virtual NewTriangle CurrentTriangle { get { return currentTriangle; } set { currentTriangle = value; } }
        public abstract Color GetColor(int x, int y,int z);
    }
}
