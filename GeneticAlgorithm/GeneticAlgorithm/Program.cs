using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;

namespace GeneticAlgorithm
{
    class Program
    {
        public static List<Genome> fellows;
 
        public static void Main(string[] args)
        {
            Events.Quit += new EventHandler<QuitEventArgs>(ApplicationQuitEventHandler);

            Surface plate = Video.SetVideoMode(220, 220, 32, false, false, false, true);
            Surface pic = new Surface("nyanbig.png");
            pic.Update();

            Population fellows = new Population(15, 100);
            List<float> fitnesses;

            while (fellows.members[0].fitness < 700f)
            {
                fitnesses = new List<float>();
                foreach (Genome g in fellows.members)
                {
                    g.Draw(plate);
                    Console.Read();
                    float f = g.GetFitness(plate, pic);
                    fitnesses.Add(f);
                    g.fitness = f;
                }

                fellows.members.Sort();
                fellows.members[0].Draw(plate);
                Console.WriteLine(fellows.members[0].fitness);
                int x = 0;
            }
        }

        private static void ApplicationQuitEventHandler(object sender, QuitEventArgs args)
        {
            Events.QuitApplication();
        }
    }
}
