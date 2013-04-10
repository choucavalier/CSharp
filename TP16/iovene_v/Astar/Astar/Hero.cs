using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Astar.MyLinkedList;

namespace Astar
{
    class Hero : Tile
    {
        MyLinkedList<Tile> lastpath = new MyLinkedList<Tile>();
        int msElapsed = 0;
        MyLinkedList<Tile> walkingList = new MyLinkedList<Tile>();
        public MyLinkedList<Tile> WalkingList
        {
            get { return walkingList; }
            set { if (value != null) walkingList = value; }
        }

        public MyLinkedList<Tile> Lastpath
        {
            get { return lastpath; }
            set { if (value != null) lastpath = value; }
        }

        public Hero(int x, int y, byte type)
            : base(x, y, type)
        {
        }
        public void Update(GameTime gameTime)
        {
            msElapsed += gameTime.ElapsedGameTime.Milliseconds;
            if (walkingList.Size != 0)
                if (msElapsed >= 100)
                {
                    // on met a jour la position du héros
                    X = walkingList.Head.Data.X;
                    Y = walkingList.Head.Data.Y;
                    Position = walkingList.Head.Data.Position; 

                    // on conserve ses déplacements dans la liste lastpath
                    lastpath.AddFirst(walkingList.Head.Data);

                    // on supprime la case où l'on vient d'avancer pour rappeler sur la suivante.
                    walkingList.RemoveFirst(walkingList.Head.Data);
                    msElapsed = 0;
                }
        }
    }
}