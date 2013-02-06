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
    class MenuButton : MenuItem
    {
        private Vector2 _textPosition;

        public string Text;

        public MenuButton(string text)
        {
            Text = text;
            NoClick = false;
        }

        public override void SetPosition(int x, int y)
        {
            Area = new Rectangle(x, y, GameDatas.Theme.TextBoxTexture.Width, GameDatas.Theme.TextBoxTexture.Height);

            _textPosition = new Vector2(Area.X + (Area.Width - (int)GameDatas.Theme.TextBoxFont.MeasureString(Text).X) / 2, Area.Y + GameDatas.Theme.ButtonPaddingY);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Focused ? GameDatas.Theme.ButtonTextureFocus : GameDatas.Theme.ButtonTexture, Area, Color.White);

            spriteBatch.DrawString(GameDatas.Theme.TextBoxFont, Text, _textPosition, new Color(236, 0, 140));
        }
    }
}
