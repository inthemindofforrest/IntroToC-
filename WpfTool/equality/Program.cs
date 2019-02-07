using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equality
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public struct Polygon2D
    {
        public int[] vertices;
        public float vertexCount { get { return vertices.Length; } }
    }

}
