using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracer
{
    public class Camera
    {
        public int Width, Height;

        public Vector3D D;

        public Camera(int width, int height, int depth)
        {
            Width = width;
            Height = height;
            D = new Vector3D(width / 2, height / 2, depth);
        }
    }
}
