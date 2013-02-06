using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;

namespace GeneticAlgorithm
{
    public class Gene
    {
        public Point p;
        public Couleur c;
        public int side;

        static Random ran = new Random();

        public Gene(Point p, Couleur c, int side)
        {
            this.p = p;
            this.c = c;
            this.side = side;
        }

        public static Gene RandomGene()
        {
            Point p = new Point(ran.Next(101), ran.Next(101));
            Couleur c = new Couleur(ran.Next(256), ran.Next(256), ran.Next(256));
            int side = ran.Next(101);

            return new Gene(p, c, side);
        }
    }
}
