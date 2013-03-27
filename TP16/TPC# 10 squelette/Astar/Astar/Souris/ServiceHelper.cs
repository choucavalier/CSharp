using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Astar
{
    static class ServiceHelper
    {
        static Game game;
        public static Game Game
        {
            set { game = value; }
        }
        public static void Add<T>(T service) where T : class
        {
            game.Services.AddService(typeof(T), service);
        }
        public static T Get<T>() where T : class
        {
            return game.Services.GetService(typeof(T)) as T;
        }
    }
}
