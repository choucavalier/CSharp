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

namespace OhMyBoat
{
    static class GameDatas
    {
        public static bool GameFocus;
        static public int WindowWidth;
        static public int WindowHeight;

        static public MouseState MouseState;
        static public MouseState PreviousMouseState;

        static public bool KeyboardFocus = false;
        static public KeyboardState KeyboardState;
        static public KeyboardState PreviousKeyboardState;

        public static Theme Theme;

        public const byte MapPeriod = 9;
        public const byte MenuPeriod = 15;
        public const byte MenuTextBoxPeriod = 20;
        public const byte MenuTextBoxCursorPeriod = 15;
    }
}
