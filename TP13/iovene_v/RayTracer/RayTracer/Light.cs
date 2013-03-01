using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace RayTracer
{
    public class Light
    {
        public Vector3D Position;

        public int Intensity;

        public Light(Vector3D position, int intensity)
        {
            Position = position;
            Intensity = intensity;
        }
    }
}
