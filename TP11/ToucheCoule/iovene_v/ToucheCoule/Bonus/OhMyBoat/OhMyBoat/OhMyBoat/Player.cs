using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OhMyBoat.IO;
using OhMyBoat.Maps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace OhMyBoat
{
    public class Player
    {
        public string Name { get; private set; }

        public int Shots;

        public Map Map { get; set; }

        public Player(string name) : this(name, Map.Generate())
        {
        }

        public Player(string name, Map map)
        {
            Name = name;
            Map = map;
            Shots = 0;
            Map.Aim = new Point(0, 0);
        }

        public FireResult Play(int x, int y)
        {
            if (!Shoot(x, y))
                return FireResult.Fail;
            
            if (Sink(x, y))
                Achieve(x, y);
            
            return FireResult.Shoot;
        }

        public void Update()
        {
            if (GameDatas.KeyboardFocus)
            {
                if (GameDatas.PreviousKeyboardState.IsKeyDown(Keys.Left) &&
                    (GameDatas.KeyboardState.IsKeyUp(Keys.Left) || Map.AimPeriodEvolve == GameDatas.MapPeriod))
                {
                    Map.Aim.X = (Map.Aim.X - 1) < 0 ? (GameDatas.Theme.CellsNumber - 1) : (Map.Aim.X - 1);
                    Map.AimPeriodEvolve = 0;
                }

                if (GameDatas.PreviousKeyboardState.IsKeyDown(Keys.Right) &&
                    (GameDatas.KeyboardState.IsKeyUp(Keys.Right) || Map.AimPeriodEvolve == GameDatas.MapPeriod))
                {
                    Map.Aim.X = (Map.Aim.X + 1) > (GameDatas.Theme.CellsNumber - 1) ? 0 : (Map.Aim.X + 1);
                    Map.AimPeriodEvolve = 0;
                }

                if (GameDatas.PreviousKeyboardState.IsKeyDown(Keys.Up) &&
                    (GameDatas.KeyboardState.IsKeyUp(Keys.Up) || Map.AimPeriodEvolve == GameDatas.MapPeriod))
                {
                    Map.Aim.Y = (Map.Aim.Y - 1) < 0 ? (GameDatas.Theme.CellsNumber - 1) : (Map.Aim.Y - 1);
                    Map.AimPeriodEvolve = 0;
                }

                if (GameDatas.PreviousKeyboardState.IsKeyDown(Keys.Down) &&
                    (GameDatas.KeyboardState.IsKeyUp(Keys.Down) || Map.AimPeriodEvolve == GameDatas.MapPeriod))
                {
                    Map.Aim.Y = (Map.Aim.Y + 1) > (GameDatas.Theme.CellsNumber - 1) ? 0 : (Map.Aim.Y + 1);
                    Map.AimPeriodEvolve = 0;
                }

                if (GameDatas.KeyboardState.IsKeyDown(Keys.Right) || GameDatas.KeyboardState.IsKeyDown(Keys.Down) ||
                    GameDatas.KeyboardState.IsKeyDown(Keys.Up) || GameDatas.KeyboardState.IsKeyDown(Keys.Left))
                    Map.AimPeriodEvolve++;
            }

            else
            {
                if (Map.Area.Contains(GameDatas.MouseState.X, GameDatas.MouseState.Y))
                {
                    Map.Aim.X = (GameDatas.MouseState.X - Map.X - GameDatas.Theme.GridPadding)/GameDatas.Theme.CellSize;
                    Map.Aim.Y = (GameDatas.MouseState.Y - Map.Y - GameDatas.Theme.GridPadding)/GameDatas.Theme.CellSize;
                }
            }
        }

        public bool IsOver()
        {
            for (var i = 0; i < GameDatas.Theme.CellsNumber; i++)
                for (var j = 0; j < GameDatas.Theme.CellsNumber; j++)
                    if (Map.Datas[i, j] == (byte) CellState.BoatHidden)
                        return false;

            return true;
        }

        public bool Shoot(int x, int y)
        {
            switch (Map.Datas[x, y])
            {
                case (byte) CellState.BoatHidden:
                    Shots++;
                    Map.Datas[x, y] = (byte) CellState.BoatBurning;
                    return true;
                case (byte) CellState.WaterHidden:
                    Shots++;
                    Map.Datas[x, y] = (byte) CellState.Water;
                    return false;
                default:
                    return false;
            }
        }

        public bool Sink(int x, int y)
        {
            return Sink(x - 1, y, -1, 0) && Sink(x + 1, y, 1, 0) && Sink(x, y - 1, 0, -1) && Sink(x, y + 1, 0, 1);
        }

        public bool Sink(int x, int y, int dirx, int diry)
        {
            return (x < 0 || y < 0 || x > (GameDatas.Theme.CellsNumber - 1) || y > (GameDatas.Theme.CellsNumber - 1) ||
                    Map.Datas[x, y] == (byte) CellState.WaterHidden || Map.Datas[x, y] == (byte) CellState.Water) ||
                   (Map.Datas[x, y] == (byte) CellState.BoatBurning && Sink(x + dirx, y + diry, dirx, diry));
        }

        public void Achieve(int x, int y)
        {
            Achieve(x, y, 0, 0);
            Achieve(x - 1, y, -1, 0);
            Achieve(x + 1, y, 1, 0);
            Achieve(x, y - 1, 0, -1);
            Achieve(x, y + 1, 0, 1);
        }

        public bool Achieve(int x, int y, int dirx, int diry)
        {
            if (x < 0 || y < 0 || x > (GameDatas.Theme.CellsNumber - 1) || y > (GameDatas.Theme.CellsNumber - 1) ||
                Map.Datas[x, y] == (byte) CellState.WaterHidden || Map.Datas[x, y] == (byte) CellState.Water)
            {
                return true;
            }

            if (Map.Datas[x, y] == (byte) CellState.BoatBurning &&
                (dirx == diry || Achieve(x + dirx, y + diry, dirx, diry)))
            {
                Map.Datas[x, y] = (byte) CellState.BoatDestroyed;

                if (x - 1 >= 0 && Map.Datas[x - 1, y] == (byte) CellState.WaterHidden)
                    Map.Datas[x - 1, y] = (byte) CellState.Water;

                if (x + 1 < GameDatas.Theme.CellsNumber && Map.Datas[x + 1, y] == (byte) CellState.WaterHidden)
                    Map.Datas[x + 1, y] = (byte) CellState.Water;

                if (y - 1 >= 0 && Map.Datas[x, y - 1] == (byte) CellState.WaterHidden)
                    Map.Datas[x, y - 1] = (byte) CellState.Water;

                if (y + 1 < GameDatas.Theme.CellsNumber && Map.Datas[x, y + 1] == (byte) CellState.WaterHidden)
                    Map.Datas[x, y + 1] = (byte) CellState.Water;

                return true;
            }

            return false;
        }
    }

    public enum FireResult
    {
        Fail,
        Shoot
    }
}
