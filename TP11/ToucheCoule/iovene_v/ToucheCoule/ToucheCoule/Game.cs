using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToucheCoule
{
    class Game
    {
        //FIXME

        public struct Point
        {
            public int x;
            public int y;
        }

        private void check_coord(Point p)
        {
            //FIXME
            //THROW ERROR IF THE INPUT IS WRONG
        }

        public void game_loop()
        {
            Console.Write("Name player 1 > ");
            string name1 = Console.ReadLine();
            Console.Write("\n");
            Console.Write("Path 1 > ");
            string path1 = Console.ReadLine();
            Console.Write("\n");

            Console.Write("Name player 2 > ");
            string name2 = Console.ReadLine();
            Console.Write("\n");
            Console.Write("Path 2 > ");
            string path2 = Console.ReadLine();
            Console.Write("\n");

            Player p1 = new Player(name1, path2);
            Player p2 = new Player(name2, path1);

            int i = 0;
            while (true)
            {
                for (int t1 = 0; t1 < 10; t1++)
                    for (int t2 = 0; t2 < 10; t2++)
                    {
                        if ((i % 2) == 0)
                        {
                            p1.show_board();
                            Console.WriteLine("Your Target, Player1 > ");
                            Console.Write("   X (ligne) > ");
                            int x = int.Parse(Console.ReadLine());
                            Console.Write("   Y (colonne) > ");
                            int y = int.Parse(Console.ReadLine());
                            Console.Write("\n");
                            Console.Write("\n");
                            if (p1.play(x, y))
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                break;
                            }
                        }
                        else
                        {
                            p2.show_board();
                            Console.WriteLine("Your Target, Player 2 > ");
                            Console.Write("   X (ligne) > ");
                            int x = int.Parse(Console.ReadLine());
                            Console.Write("   Y (colonne) > ");
                            int y = int.Parse(Console.ReadLine());
                            Console.Write("\n");
                            Console.Write("\n");
                            if (p2.play(x, y))
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                break;
                            }
                        }
                        Console.WriteLine("#############");
                        i++;
                    }
            }
            Console.WriteLine("#############");
            Console.WriteLine("GAME OVER");
            p1.show_board();
            p2.show_board();
            Console.WriteLine("GAME OVER");
            Console.WriteLine("#############");
        }
    }
}
