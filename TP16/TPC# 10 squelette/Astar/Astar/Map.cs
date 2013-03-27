using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Astar
{
    class Map
    {
        Tile[,] tileList;

        public Tile[,] TileList
        { get { return tileList; } set { tileList = value; } }

        public Map(byte[,] table)
        {
            tileList = new Tile[table.GetLength(0), table.GetLength(1)];
            for (int y = 0; y < table.GetLength(0); y++)
                for (int x = 0; x < table.GetLength(1); x++)
                    tileList[y, x] = new Tile(y, x, table[y, x]);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in tileList)
                tile.Draw(spriteBatch);
        }

        public bool ValidCoordinates(int x, int y)
        {
            if (x < 0)
                return false;
            if (y < 0)
                return false;
            if (x >= tileList.GetLength(1))
                return false;
            if (y >= tileList.GetLength(0))
                return false;
            return true;
        }
    }
}