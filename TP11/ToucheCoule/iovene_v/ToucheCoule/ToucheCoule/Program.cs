using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToucheCoule
{
    class Program
    {
        static void Main(string[] args)
        {
            Game touchecoule = new Game();

            touchecoule.game_loop();
            Console.ReadLine();
        }
    }
}
