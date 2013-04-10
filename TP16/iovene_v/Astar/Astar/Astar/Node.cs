using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Astar
{
    class Node
    {
        Tile tile;
        public Tile Tile
        {
            get { return tile; }
        }
        Node parent;
        public Node Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        int estimatedMovement;
        public int EstimatedMovement
        {
            get { return estimatedMovement; }
        }
        public Node(Tile tile, Node parent, Tile destination)
        {
            this.tile = tile;
            this.parent = parent;

            this.estimatedMovement = (int) (Math.Abs(destination.Position.X - tile.Position.X) +
                                     Math.Abs(destination.Position.Y - tile.Position.Y));
        }
        public List<Node> GetPossibleNode(Map map, Tile destination) // recupère les 8 cases adjacentes
        {
            List<Node> result = new List<Node>();
            // Bottom
            if (map.ValidCoordinates(tile.X, tile.Y + 1) && map.TileList[tile.Y + 1,
            tile.X].Type != TileType.Wall)
                result.Add(new Node(map.TileList[tile.Y + 1, tile.X], this,
                destination));
            // Right
            if (map.ValidCoordinates(tile.X + 1, tile.Y) && map.TileList[tile.Y,
            tile.X + 1].Type != TileType.Wall)
                result.Add(new Node(map.TileList[tile.Y, tile.X + 1], this,
                destination));
            // Top
            if (map.ValidCoordinates(tile.X, tile.Y - 1) && map.TileList[tile.Y - 1,
            tile.X].Type != TileType.Wall)
                result.Add(new Node(map.TileList[tile.Y - 1, tile.X], this,
                destination));
            // Left
            if (map.ValidCoordinates(tile.X - 1, tile.Y) && map.TileList[tile.Y,
            tile.X - 1].Type != TileType.Wall)
                result.Add(new Node(map.TileList[tile.Y, tile.X - 1], this,
                destination));
            // Bottom Left
            if (map.ValidCoordinates(tile.X - 1, tile.Y + 1) && map.TileList[tile.Y + 1,
            tile.X - 1].Type != TileType.Wall)
                result.Add(new Node(map.TileList[tile.Y + 1, tile.X - 1], this,
                destination));
            // Bottom Right
            if (map.ValidCoordinates(tile.X + 1, tile.Y + 1) && map.TileList[tile.Y + 1,
            tile.X + 1].Type != TileType.Wall)
                result.Add(new Node(map.TileList[tile.Y + 1, tile.X + 1], this,
                destination));
            // Top Left
            if (map.ValidCoordinates(tile.X - 1, tile.Y - 1) && map.TileList[tile.Y - 1,
            tile.X - 1].Type != TileType.Wall)
                result.Add(new Node(map.TileList[tile.Y - 1, tile.X - 1], this,
                destination));
            // Top Right
            if (map.ValidCoordinates(tile.X + 1, tile.Y - 1) && map.TileList[tile.Y - 1,
            tile.X + 1].Type != TileType.Wall)
                result.Add(new Node(map.TileList[tile.Y - 1, tile.X + 1], this,
                destination));
            return result;
        }
    }
}
