using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToucheCoule
{
    class Player
    {
        private string name;

        private Terrain ennemy_map;

        public Player(string player_name, string path)
        {
            name = player_name;
            ennemy_map = new Terrain(path);
        }

        public string get_name()
        {
            return name;
        }

        public void show_board()
        {
            ennemy_map.display_hidden();
        }

        public bool play(int x, int y)
        {
            if (ennemy_map.touche(x, y))
            {
                Console.WriteLine("###########################");
                Console.WriteLine("YOU TOUCHED YOUR TARGET !!!");
                Console.WriteLine("###########################");
                if (ennemy_map.coule(x, y))
                {
                    Console.WriteLine("###########################");
                    Console.WriteLine("YOU OWNED A BOAT !!!");
                    Console.WriteLine("###########################");
                    return ennemy_map.game_over();
                }
            }
            return false;
        }
    }
}
