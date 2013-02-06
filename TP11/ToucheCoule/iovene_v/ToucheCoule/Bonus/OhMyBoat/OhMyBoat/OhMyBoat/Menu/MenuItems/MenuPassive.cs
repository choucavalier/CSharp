using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace OhMyBoat.Menu.MenuItems
{
    class MenuPassive : MenuItem
    {
        public Texture2D Texture;

        public MenuPassive(Texture2D texture)
        {
            Click = DoNothing;
            Texture = texture;
            NoClick = true;
        }

        public void DoNothing(MenuState m) { }

        public override void SetPosition(int x, int y)
        {
            Area = new Rectangle(x, y, Texture.Width, Texture.Height);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Area, Color.White);
        }
    }
}
