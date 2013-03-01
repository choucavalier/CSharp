using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using RayTracer.Objects3D;

namespace RayTracer
{
    public class Scene
    {
        public List<Object3D> Objects3D;

        public List<Light> Lights;

        public Camera Camera;

        public bool Grain;

        public int LightIntensity;

        public Scene(Camera camera)
        {
            Objects3D = new List<Object3D>();
            Lights = new List<Light>();
            Camera = camera;
        }

        public Bitmap Render()
        {
            Bitmap bitmap = new Bitmap(Camera.Width, Camera.Height);

            if (Objects3D.Count < 1)
                return bitmap;

            for (int x = 0; x < Camera.Width; x++)
                for (int y = 0; y < Camera.Height; y++)
                {
                    Ray ray = new Ray(new Vector3D(x, y, 0),
                                        new Vector3D(x - Camera.D.X, y - Camera.D.Y,
                                                    -Camera.D.Z), 1);

                    Vector3D intersection = null;
                    Object3D selectedObject = null;

                    foreach (var object3D in Objects3D)
                    {
                        Vector3D objectIntersection = SelectIntersection(object3D.GetIntersections(ray));

                        if (objectIntersection == null)
                            continue;

                        if (selectedObject == null || objectIntersection.Z < intersection.Z)
                        {
                            selectedObject = object3D;
                            intersection = objectIntersection;
                        }
                    }

                    if (intersection != null)
                    {
                        double cosAngle = Math.Abs(ReflectedRayAngleCos(ray, selectedObject.GetNormal(intersection)));

                        cosAngle = Math.Pow(cosAngle, LightIntensity + 1);

                        int r = (int) (selectedObject.Color.R*cosAngle*ray.Intensity);
                        int g = (int) (selectedObject.Color.G*cosAngle*ray.Intensity);
                        int b = (int) (selectedObject.Color.B*cosAngle*ray.Intensity);

                        if (Grain && x%2 == 0 && y%2 == 0)
                        {
                            r += 20;
                            g += 20;
                            b += 20;
                        }

                        r = r < 0 ? 0 : r > 255 ? 255 : r;
                        g = g < 0 ? 0 : g > 255 ? 255 : g;
                        b = b < 0 ? 0 : b > 255 ? 255 : b;

                        bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }

            return bitmap;
        }

        public static Vector3D SelectIntersection(List<Vector3D> l)
        {
            if (l == null || l.Count < 1)
                return null;

            Vector3D result = l[0];

            for (int i = 1; i < l.Count - 1; i++)
                if (l[i].Z < l[i - 1].Z)
                    result = l[i - 1];

            return result;
        }

        public static double ReflectedRayAngleCos(Ray ray, Vector3D intersectionNormale)
        {
            double cos = Vector3D.Scalar(ray.Direction, intersectionNormale)/(ray.Direction.Norm()*intersectionNormale.Norm());
            return Math.Pow(-Math.Log(cos + 1), 2);
        }
    }
}
