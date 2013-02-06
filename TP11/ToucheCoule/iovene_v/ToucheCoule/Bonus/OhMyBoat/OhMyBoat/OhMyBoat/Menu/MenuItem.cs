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

namespace OhMyBoat.Menu
{
    abstract class MenuItem
    {
        public delegate void OnClick(MenuState m);
        public OnClick Click;

        public MenuState subMenu = new MenuState(new List<MenuItem>(), true);

        public Rectangle Area;

        public bool Focused;

        public bool NoClick, FocusOnClick;

        public virtual void LoadContent(ContentManager content) { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }

        public virtual void SetPosition(int x, int y) { }
    }
}
