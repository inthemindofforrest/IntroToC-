using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProperties
{
    struct Vector3
    {
        public double x;
        public double y;
        public double z;

        Vector3(double X, double Y, double Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        public Vector3 Sum(Vector3 Other)
        {
            return (new Vector3(x + Other.x, y + Other.y, z + Other.z));
        }
        public Vector3 Sub(Vector3 Other)
        {
            return (new Vector3(x - Other.x, y - Other.y, z - Other.z));
        }
        public double Magnitude()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
        public Vector3 GetNormalized()
        {
            double magnitude = this.Magnitude();
            return (new Vector3(x / magnitude, y / magnitude, z / magnitude));
        }
        public double DotProduct(Vector3 Other)
        {
            return (x * Other.x + y * Other.y + z * Other.z);
        }


    }
}
