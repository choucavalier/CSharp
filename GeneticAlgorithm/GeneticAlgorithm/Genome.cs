using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;

namespace GeneticAlgorithm
{
    public class Genome : IComparable<Genome>
    {
        public Gene[] genes;

        static Random ran = new Random();

        public float fitness;

        public void Draw(Surface s)
        {
            for (int i = 0; i < this.genes.Length; i++)
            {
                DrawSquare(s, this.genes[i].p.X*s.Width/100, this.genes[i].p.Y*s.Width/100, this.genes[i].side*s.Width/100, this.genes[i].c.r, this.genes[i].c.g, this.genes[i].c.b);
                s.Update();
            }
        }

        public Genome(int n)
        {
            this.genes = new Gene[n];
            for (int i = 0; i < this.genes.Length; i++)
                    this.genes[i] = Gene.RandomGene();
        }

        public void Randomize(int n)
        {
            for (int i = 0; i < this.genes.Length; i++)
                if (ran.Next(n) == 0)
                    this.genes[i] = Gene.RandomGene();
        }

        public Genome Cross(Genome g1, Genome g2)
        {
            Genome g = new Genome(g1.genes.Length);
            for (int i = 0; i < g.genes.Length; i++)
                if (ran.Next(2) == 0)
                    g.genes[i] = g2.genes[i];
                else
                    g.genes[i] = g1.genes[i];
            return g;
        }

        public void DrawSquare(Surface s, int x, int y, int side, int r, int g, int b)
        {
            s.Fill(new Rectangle(x, y, side, side), Color.FromArgb(r, g, b));
            s.Update();
        }

        public float GetFitness(Surface a, Surface b)
        {
            float diff = 0;
            for (int i = 0; i < a.Width; i++)
            {
                for (int j = 0; j < a.Height; j++)
                {
                    Point p = new Point(i, j);
                    diff += Math.Abs(a.GetPixel(p).R - b.GetPixel(p).R) +
                            Math.Abs(a.GetPixel(p).G - b.GetPixel(p).G) +
                            Math.Abs(a.GetPixel(p).B - b.GetPixel(p).B);
                }
            }

            return 756 - diff / (a.Width * a.Height);
        }

        public int CompareTo(Genome g)
        {
            if (g == null) return 1;

            if (g != null)
                return this.fitness.CompareTo(this.fitness);
            else
                throw new ArgumentException("Object is not a Genome");
        }
    }
}
