using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;

namespace GeneticAlgorithm
{
    public class Population
    {
        public List<Genome> members; 

        public Population(int n, int r)
        {
            this.members = new List<Genome>();

            for (int i = 0; i < 10; i++)
            {
                Genome g = new Genome(400);
                g.Randomize(r);
                members.Add(g);
            }
        }
    }
}
