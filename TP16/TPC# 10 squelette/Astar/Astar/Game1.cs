using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Astar.Astar;
using Astar.MyLinkedList;

namespace Astar
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Tile startTile;
        Map map;
        Hero heros;
        Cost cost;
        int mouseX = 0, mouseY = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            ServiceHelper.Game = this;
            Components.Add(new MouseService(this));
            Content.RootDirectory = "Content";
            map = new Map(new byte[,] {
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 1, 1, 0},
                {0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 1, 0},
                {0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 1, 1, 0, 1, 0, 1, 0, 1, 2, 1, 1, 1, 1, 0, 0, 0},
                {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 2, 2, 0, 0, 1, 0, 1, 0},
                {1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 2, 0, 0, 1, 0, 1, 0},
                {0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 1, 0, 1, 1},
                {0, 0, 0, 1, 0, 1, 0, 0, 3, 3, 0, 1, 2, 0, 0, 0, 0, 1},
                {0, 0, 0, 1, 0, 1, 1, 3, 3, 1, 1, 1, 2, 0, 1, 0, 0, 1},
                {0, 0, 0, 1, 0, 0, 1, 3, 3, 3, 3, 2, 2, 0, 1, 1, 0, 1},
                {0, 0, 0, 1, 0, 0, 1, 3, 3, 3, 3, 2, 1, 1, 1, 0, 0, 0},
                {0, 0, 0, 1, 0, 0, 0, 3, 1, 1, 3, 2, 0, 0, 1, 0, 0, 0},
                {0, 0, 0, 1, 0, 0, 3, 3, 1, 1, 3, 2, 0, 0, 0, 0, 0, 0}
            });
            graphics.PreferredBackBufferWidth = map.TileList.GetLength(1) * 50;
            graphics.PreferredBackBufferHeight = map.TileList.GetLength(0) * 50;
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            heros = new Hero(0, 13, 4);
            cost = new Cost(heros);
            startTile = map.TileList[heros.Y, heros.X];

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            foreach (Tile tile in map.TileList)
            {
                switch (tile.Type)
                {
                    case TileType.Wall:
                        tile.LoadContent(Content, "mur");
                        break;
                    case TileType.Water:
                        tile.LoadContent(Content, "eau");
                        break;
                    case TileType.Tree:
                        tile.LoadContent(Content, "arbre");
                        break;
                    default:
                        tile.LoadContent(Content, "herbe");
                        break;
                }
            }
            cost.LoadContent(Content);
            heros.LoadContent(Content, "hero");

        }

        protected override void Update(GameTime gameTime)
        {
            if (ServiceHelper.Get<IMouseService>().LeftButtonHasBeenPressed())
            {
                startTile.Color = Color.White;
                startTile = map.TileList[heros.Y, heros.X];
                if (heros.Lastpath != null) // suppression des couleurs sur l'ancien chemin
                {
                    MyNode<Tile> head = heros.Lastpath.Head;
                    while (head != null)
                    {
                        head.Data.Color = Color.White;
                        head = head.NextNode;
                    }
                }
                if (heros.WalkingList != null) // suppression des couleurs sur le chemin si on relance un astar en plein calcul.
                {
                    MyNode<Tile> head = heros.WalkingList.Head;
                    while (head != null)
                    {
                        head.Data.Color = Color.White;
                        head = head.NextNode;
                    }
                }

                mouseX = (int)ServiceHelper.Get<IMouseService>().GetCoordinates().X / 50; // on recupere la case destination
                mouseY = (int)ServiceHelper.Get<IMouseService>().GetCoordinates().Y / 50;

                if (heros.X != mouseX || heros.Y != mouseY)
                {
                    heros.Lastpath.Clear(); 
                    heros.WalkingList = Pathfinding.CalculatePathWithAStar(map, heros, map.TileList[mouseY, mouseX]);
                }

                if (heros.WalkingList != null && heros.WalkingList.Size != 0)
                {
                    MyNode<Tile> head = heros.WalkingList.Head;

                    startTile.Color = Color.Red;
                    while (head != null)
                    {
                        head.Data.Color = Color.Orange;
                        head = head.NextNode;
                    }
                }
            }
            cost.Update(heros);
            heros.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            map.Draw(spriteBatch);
            heros.Draw(spriteBatch);
            cost.Draw(spriteBatch, new Vector2(mouseX, mouseY));
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
