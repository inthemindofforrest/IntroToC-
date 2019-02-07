using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSharpProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            Polygon2D Temp1;
            Polygon2D Temp2;

            Vector2[] VectTemp = { new Vector2(0, 0), new Vector2(0, 1) };
            Temp1.Vertices = VectTemp;

            Temp2.Vertices = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1) };

            Debug.Assert(Temp1 == Temp2);
        }
    }
}
