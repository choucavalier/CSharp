using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Astar
{
    enum TileType
    {
        Wall = -1,
        Normal = 0,
        Tree = 1,
        Water = 2,
        Human = -1,
    };

    class Tile : Sprite, IComparable
    {        
        int x;
        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        int y;
        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        int IComparable.CompareTo(object obj)
        {
            if (obj.Equals(this))
                return 1;
            else
                return 0;
        }

        TileType type;
        public TileType Type
        {
            get { return type; }
        }
        public Tile(int y, int x, byte type)
            : base(new Vector2(x * 50, y * 50))
        {
            this.x = x;
            this.y = y;
            switch (type)
            {
                case 1:                   
                    this.type = TileType.Wall;
                    break;
                case 3:
                    this.type = TileType.Tree;
                    break;
                case 2:
                    this.type = TileType.Water;
                    break;
                case 4:
                    this.type = TileType.Human;
                    break;
                default:
                    this.type = TileType.Normal;
                    break;
            }
        }
    }
}