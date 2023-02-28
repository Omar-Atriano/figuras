using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figuras
{
    public class Figures
    {
        public Figures(Vertex[] vertices, int[,] faces)
        {
            Vertices = vertices;
            Faces = faces;
        }

        public Vertex[] Vertices { get; set; }

        public int[,] Faces { get; set; }
    }
}
