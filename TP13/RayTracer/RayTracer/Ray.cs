using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracer
{
    public class Ray
    {
        public Vector3D Origin, Direction;

        public double Intensity;

        public Ray(Vector3D origin, Vector3D direction, double intensity)
        {
            Origin = origin;
            double n = direction.Norm();
            Direction = new Vector3D(direction.X/n, direction.Y/n, direction.Z/n);
            Intensity = intensity;
        }
    }
}
