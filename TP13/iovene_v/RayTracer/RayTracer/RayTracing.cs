using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RayTracer.Objects3D;

namespace RayTracer
{
    public partial class RayTracing : Form
    {
        public Scene Scene;

        public RayTracing()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Scene = new Scene(new Camera(pictureBox1.Width, pictureBox1.Height, -10000));
            Scene.LightIntensity = trackBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            Scene.Lights.Add(new Light(new Vector3D(Scene.Camera.D.X, Scene.Camera.D.Y, -50), 1));

            for (int i = 0; i < 15; i++)
            {
                Scene.Objects3D.Add(new Sphere(new Vector3D(rand.Next(pictureBox1.Width), rand.Next(pictureBox1.Height), rand.Next(100, 10000)), rand.Next(5, 80), Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256))));
            }

            pictureBox1.Image = Scene.Render();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Scene.LightIntensity = trackBar1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            Scene.Objects3D = new List<Object3D>();

            int r = 400;
            int period = 20;

            for (int t = 0; t < 500; t++)
            {
                double angle = Math.PI * (t % period) / (period / 2);

                int x = (int)Scene.Camera.D.X + (int)(r * Math.Cos(angle));
                int y = (int)Scene.Camera.D.Y + (int)(r * Math.Sin(angle));

                Scene.Objects3D.Add(new Sphere(new Vector3D(x, y, t * 200), 35, Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256))));
            }

            pictureBox1.Image = Scene.Render();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Scene.Grain = checkBox1.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Scene.Objects3D = new List<Object3D>();

            pictureBox1.Image = Scene.Render();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            Scene.Objects3D = new List<Object3D>();

            int r = 800;
            int period = 80;

            for (int t = 0; t < 1000; t++)
            {
                double angle = Math.PI * (t % period) / (period / 2);

                int x = (int)Scene.Camera.D.X + (int)(r * Math.Cos(angle));
                int y = (int)Scene.Camera.D.Y + (int)(r * Math.Sin(angle));

                Scene.Objects3D.Add(new Sphere(new Vector3D(x, y, t * 600), 35, Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256))));
            }

            pictureBox1.Image = Scene.Render();
        }
    }
}
