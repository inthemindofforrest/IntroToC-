using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProperties
{
    public struct Polygon2D
    {
        public Vector2[] Vertices;
        public float VertexCount { get { return Vertices.Length; } }



        public bool Equals(Polygon2D RHS)
        {
            if (VertexCount != RHS.VertexCount)
                return false;
            for (int i = 0; i < VertexCount; i++)
                if (Vertices[i] != RHS.Vertices[i])
                    return false;
            return true;
        }
        public override bool Equals(Object RHS)
        {
            return this.Equals((Polygon2D)RHS);
        }
        public static bool operator ==(Polygon2D LHS, Polygon2D RHS)
        {
            return LHS.Equals(RHS);
        }
        public static bool operator !=(Polygon2D LHS, Polygon2D RHS)
        {
            return !(LHS == RHS);
        }
        public override int GetHashCode()
        {
            int temp = 0;
            for (int i = 0; i < VertexCount; i++)
                temp += (int)Vertices[i].x ^ (int)Vertices[i].y;
            return temp;
        }
    }
}
