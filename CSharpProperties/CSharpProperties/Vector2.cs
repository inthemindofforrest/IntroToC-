using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProperties
{
    public struct Vector2 : IEquatable<Vector2>
    {
        public double x;
        public double y;

        public Vector2(double X, double Y)
        {
            x = X;
            y = Y;
        }

        public Vector2 Sum(Vector2 Other)
        {
            return (new Vector2(x + Other.x, y + Other.y));
        }
        public Vector2 Sub(Vector2 Other)
        {
            return (new Vector2(x - Other.x, y - Other.y));
        }
        public double Magnitude()
        {
            return Math.Sqrt(x * x + y * y);
        }
        public Vector2 GetNormalized()
        {
            double magnitude = this.Magnitude();
            return (new Vector2(x / magnitude, y / magnitude));
        }
        public double DotProduct(Vector2 Other)
        {
            return (x * Other.x + y * Other.y);
        }
        public bool Equals(Vector2 RHS)
        {
            return (Math.Abs(x - RHS.x + y - RHS.y) < float.Epsilon * 200);
        }
        public override bool Equals(Object RHS)
        {
            return this.Equals((Vector2)RHS);
        }
        public static bool operator == (Vector2 LHS, Vector2 RHS)
        {
            return LHS.Equals(RHS);
        }
        public static bool operator !=(Vector2 LHS, Vector2 RHS)
        {
            return !(LHS == RHS);
        }
        public override int GetHashCode()
        {
            return (int)x ^ (int)y;
        }

    }
}
