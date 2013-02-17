using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracer
{
    public class Vector3D
    {
        public double X, Y, Z;

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vector3D operator *(double c, Vector3D v)
        {
            return new Vector3D(c*v.X, c*v.Y, c*v.Z);
        }

        public static Vector3D operator /(Vector3D v1, double i)
        {
            return new Vector3D(v1.X / i, v1.Y / i, v1.Z / i);
        }

        public static double Scalar(Vector3D v1, Vector3D v2)
        {
            return v1.X*v2.X + v1.Y*v2.Y + v1.Z*v2.Z;
        }

        public double Norm()
        {
            return Math.Sqrt(X*X + Y*Y + Z*Z);
        }
    }
}
