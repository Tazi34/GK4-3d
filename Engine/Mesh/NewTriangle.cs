using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_4.Engine.Mesh
{
    public class NewTriangle
    {
        public Color Color { get; set; }
        public ModelVertex A { get; set; }
        public ModelVertex B { get; set; }
        public ModelVertex C { get; set; }

        public ModelVertex[] GetVertices() {
            return new ModelVertex[] { A, B, C };
        }
        public double GetZ(int x, int y)
        {
            var B = (this.B as MappedVertex);
            var A = (this.A as MappedVertex);
            var C = (this.C as MappedVertex);
            double denominator = (B.ProjectedPosition[1] - C.ProjectedPosition[1]) * (A.ProjectedPosition[0] - C.ProjectedPosition[0]) + (C.ProjectedPosition[0] - B.ProjectedPosition[0]) * (A.ProjectedPosition[1] - C.ProjectedPosition[1]);
            var w0 = ((B.ProjectedPosition[1] - C.ProjectedPosition[1]) * (x - C.ProjectedPosition[0]) + (C.ProjectedPosition[0] - B.ProjectedPosition[0]) * (y - C.ProjectedPosition[1])) / denominator;
            var w1 = ((C.ProjectedPosition[1] - A.ProjectedPosition[1]) * (x - C.ProjectedPosition[0]) + (A.ProjectedPosition[0] - C.ProjectedPosition[0]) * (y - C.ProjectedPosition[1])) / denominator;
            var w2 = 1 - w1 - w0;

            return (w0 * A.ProjectedPosition[2] + w1 * B.ProjectedPosition[2] + w2 * C.ProjectedPosition[2]);
        }

        public override string ToString()
        {
            return $"Triangle\n{Color} {A}\n {B}\n {C}\n";
        }
    }
}
