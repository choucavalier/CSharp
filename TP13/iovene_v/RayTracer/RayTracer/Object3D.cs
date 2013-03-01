using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace RayTracer
{
    public abstract class Object3D
    {
        public Vector3D Position;

        public Color Color;

        public virtual List<Vector3D> GetIntersections(Ray ray)
        {
            return null;
        }

        public virtual Vector3D GetNormal(Vector3D intersection)
        {
            return null;
        }
    }
}
