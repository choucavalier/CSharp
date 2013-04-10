using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Astar.Astar
{
    class Cost // Affichage des couts sur la map.
    {
        Hero heros;

        SpriteFont font;
        int man = 0, cost = 0, tot = 0;

        public Cost(Hero heros)
        { this.heros = heros; }

        public void LoadContent(ContentManager content)
        { font = content.Load<SpriteFont>("Courier New"); }

        public void Update(Hero heros)
        { this.heros = heros; }

        private int getCost(Tile tile)
        {
            if (tile.Type == TileType.Normal)
                return 1;
            else if (tile.Type == TileType.Tree)
                return 2;
            else if (tile.Type == TileType.Water)
                return 3;
            return -1;
        }

        public void drawCost(SpriteBatch spriteBatch, Tile tile)
        {
            spriteBatch.DrawString(font, "M:" + man, tile.Position, Color.Black);
            spriteBatch.DrawString(font, "C:" + cost, new Vector2(tile.Position.X + 30, tile.Position.Y), Color.Black);
            spriteBatch.DrawString(font, "T:" + tot, new Vector2(tile.Position.X, tile.Position.Y + 30), Color.Black);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 arrive)
        {
            foreach (Node node in Pathfinding.PossibleNode)
            {
                man = Math.Abs((int)arrive.X - (int)node.Tile.X) + Math.Abs((int)arrive.Y - (int)node.Tile.Y);
                cost = getCost(node.Tile);
                tot = man + cost;
                drawCost(spriteBatch, node.Tile);
            }

        }


    }
}
