using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace RayTracer.Objects3D
{
    public class Sphere : Object3D
    {
        public int R;

        public Sphere(Vector3D position, int r, Color color)
        {
            Position = position;
            R = r;
            Color = color;
        }

        public override List<Vector3D> GetIntersections(Ray ray)
        {
            Vector3D v = ray.Origin - Position;
            double scalarvd = Vector3D.Scalar(v, ray.Direction);

            double undersquare = scalarvd*scalarvd - Vector3D.Scalar(v, v) + R*R;

            if (undersquare < 0)
                return null;

            undersquare = Math.Sqrt(undersquare);

            double t1 = -scalarvd - undersquare,
                   t2 = -scalarvd + undersquare;

            Vector3D i1 = ray.Origin + t1 * ray.Direction,
                     i2 = ray.Origin - t2 * ray.Direction;

            return new List<Vector3D> {i1, i2};
        }

        public override Vector3D GetNormal(Vector3D intersection)
        {
            Vector3D normal = intersection - Position;
            return normal / normal.Norm();
        }
    }
}
