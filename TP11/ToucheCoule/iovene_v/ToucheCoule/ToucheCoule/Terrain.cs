using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToucheCoule
{
    class Terrain
    {
        private char[,] matrice = null /*FIXME*/;

        private enum SlotType {
            Invalid,
            Water,
            WaterTouch,
            BoatOwned,
            Boat
        };

        public Terrain(string path)
        {
            matrice = new char[10, 10];
            load_file(path);
        }

        SlotType get_slot_type(char c)
        {
            switch (c)
            {
                case 'O':
                    return SlotType.Boat;
                case 'X':
                    return SlotType.BoatOwned;
                case '~':
                    return SlotType.Water;
                default:
                    return SlotType.Invalid;
            }
        }
        
        public void display_full()
        {
        }

        public void display_hidden()
        {
            Console.WriteLine("   0 1 2 3 4 5 6 7 8 9");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + "  ");
                for (int j = 0; j < 10; j++)
                    Console.Write((matrice[i, j] == 'O' ? '~' : matrice[i, j]).ToString() + ' ');
                Console.WriteLine();
            }
        }

        public void load_file(string path)
        {
            var sr = new StreamReader(File.Open(path, FileMode.Open));
            string map = sr.ReadToEnd().Replace("\n", "").Replace("\r", "");
            sr.Close();

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    matrice[i, j] = map[10 * i + j];
        }

        public bool game_over()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (matrice[i, j] == 'O')
                        return false;

            return true;
        }

        public bool touche(int x, int y)
        {
            if (get_slot_type(matrice[x, y]) == SlotType.Boat)
            {
                matrice[x, y] = 'X';
                return true;
            }
            matrice[x, y] = ' ';
            return false;
        }

        private bool coule_rec(int x, int y, int dirx, int diry)
        {
            return (x < 0 || y < 0 || x > 9 || y > 9 || matrice[x, y] == '~') || (matrice[x, y] == 'X' && coule_rec(x + dirx, y + diry, dirx, diry));
        }

        public bool coule(int x, int y)
        {
            return (x >= 0 && y >= 0 && x <= 9 && y <= 9 && coule_rec(x - 1, y, -1, 0) && coule_rec(x + 1, y, 1, 0) && coule_rec(x, y - 1, 0, -1) && coule_rec(x, y + 1, 0, 1));
        }
    }
}
