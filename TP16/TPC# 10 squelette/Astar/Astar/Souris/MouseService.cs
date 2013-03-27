using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Astar
{
    public class MouseService : GameComponent, IMouseService
    {
        MouseState mouseState = Mouse.GetState();
        MouseState lastMouseState;
        public MouseService(Game game)
            : base(game)
        {
            ServiceHelper.Add<IMouseService>(this);
        }
        public bool LeftButtonHasBeenPressed()
        {
            return mouseState.LeftButton == ButtonState.Released &&
            lastMouseState.LeftButton == ButtonState.Pressed;
        }
        public Vector2 GetCoordinates()
        {
            return new Vector2(mouseState.X, mouseState.Y);
        }
        public override void Update(GameTime gameTime)
        {
            lastMouseState = mouseState;
            mouseState = Mouse.GetState();
        }
    }
}
