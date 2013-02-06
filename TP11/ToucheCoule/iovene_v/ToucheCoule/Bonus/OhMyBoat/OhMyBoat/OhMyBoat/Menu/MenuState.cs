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
    class MenuState : GameState
    {
        public List<MenuItem> Items;
        private int _selectedItemIndex;

        private readonly bool _loop;
        private int _menuPeriod;

        public MenuState(List<MenuItem> items, bool loop)
        {
            Items = items;
            _loop = loop;
            _menuPeriod = 0;
            _selectedItemIndex = 0;
            
            if (items.Count > 0)
                Items[0].Focused = true;
        }

        public void SetPositions()
        {
            foreach (var menuItem in Items)
            {
                menuItem.SetPosition(0, 0);
            }

            var startY = 15;
            Items[0].SetPosition((GameDatas.WindowWidth - Items[0].Area.Width)/2, startY);

            for (var i = 1; i < Items.Count; i++)
            {
                var x = Items[i - 1].Area.X;
                if (Items[i - 1].Area.Width != Items[i].Area.Width)
                    x = x + (Items[i - 1].Area.Width - Items[i].Area.Width)/2;
                Items[i].SetPosition(x,
                                     Items[i - 1].Area.Y + Items[i - 1].Area.Height + 10);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!GameDatas.GameFocus)
                return;

            if (GameDatas.KeyboardFocus &&
                (GameDatas.MouseState.X != GameDatas.PreviousMouseState.X ||
                 GameDatas.MouseState.Y != GameDatas.PreviousMouseState.Y))
                foreach (var item in Items.Where(item => item.Area.Contains(GameDatas.MouseState.X, GameDatas.MouseState.Y)))
                    GameDatas.KeyboardFocus = false;

            if (!GameDatas.KeyboardFocus && (GameDatas.KeyboardState.GetPressedKeys().Length > 0))
                GameDatas.KeyboardFocus = true;

            if (GameDatas.KeyboardFocus)
            {
                Items[_selectedItemIndex].Focused = false;

                if (GameDatas.PreviousKeyboardState.IsKeyDown(Keys.Up) && (GameDatas.KeyboardState.IsKeyUp(Keys.Up) || _menuPeriod == GameDatas.MenuPeriod))
                {
                    if (_selectedItemIndex - 1 >= 0 && Items[_selectedItemIndex - 1].NoClick)
                        _selectedItemIndex = _selectedItemIndex - 2;
                    else
                        _selectedItemIndex--;
                    _menuPeriod = 0;
                }

                if (GameDatas.PreviousKeyboardState.IsKeyDown(Keys.Down) && (GameDatas.KeyboardState.IsKeyUp(Keys.Down) || _menuPeriod == GameDatas.MenuPeriod))
                {
                    if (_selectedItemIndex + 1 < Items.Count && Items[_selectedItemIndex + 1].NoClick)
                        _selectedItemIndex = _selectedItemIndex + 2;
                    else
                        _selectedItemIndex++;
                    _menuPeriod = 0;
                }

                if (GameDatas.PreviousKeyboardState.IsKeyDown(Keys.Enter) && GameDatas.KeyboardState.IsKeyUp(Keys.Enter) && !Items[_selectedItemIndex].NoClick)
                {
                    if (Items[_selectedItemIndex].Click != null)
                        Items[_selectedItemIndex].Click(Items[_selectedItemIndex].subMenu);
                }

                if (_loop)
                {
                    if (_selectedItemIndex < 0)
                        _selectedItemIndex = Items.Count - 1;
                    else if (_selectedItemIndex >= Items.Count)
                        _selectedItemIndex = Items.IndexOf(Items.Find(x => x.NoClick == false));
                }

                else
                {
                    if (_selectedItemIndex < 0)
                        _selectedItemIndex = Items.IndexOf(Items.Find(x => x.NoClick == false));
                    else if (_selectedItemIndex >= Items.Count)
                        _selectedItemIndex = Items.Count - 1;
                }

                Items[_selectedItemIndex].Focused = true;
            }

            else
            {
                for (var i = 0; i < Items.Count; i++)
                {
                    if (!Items[i].Area.Contains(GameDatas.MouseState.X, GameDatas.MouseState.Y)) continue;
                    if (Items[i].NoClick) break;

                    if (!Items[i].FocusOnClick)
                    {
                        Items[_selectedItemIndex].Focused = false;
                        _selectedItemIndex = i;
                        Items[_selectedItemIndex].Focused = true;
                    }

                    if (GameDatas.MouseState.LeftButton != ButtonState.Released ||
                        GameDatas.PreviousMouseState.LeftButton != ButtonState.Pressed) continue;

                    if (Items[i].FocusOnClick)
                    {
                        Items[_selectedItemIndex].Focused = false;
                        _selectedItemIndex = i;
                        Items[_selectedItemIndex].Focused = true;
                    }

                    else
                        if (Items[_selectedItemIndex].Click != null)
                        Items[_selectedItemIndex].Click(Items[_selectedItemIndex].subMenu);
                }
            }

            foreach (var menuItem in Items)
            {
                menuItem.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var menuItem in Items)
            {
                menuItem.Draw(spriteBatch);
            }
        }
    }
}
