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
using OhMyBoat.Maps;
using OhMyBoat.Menu;
using OhMyBoat.Menu.MenuItems;
using OhMyBoat.Network;
using OhMyBoat.Network.Events;
using OhMyBoat.Network.Packets;

namespace OhMyBoat
{
    internal class PlayState : GameState
    {
        private Player _current, _enemy;
        private readonly Client _client;
        private readonly string _currentName;
        private bool _myTurn;
        private readonly Stack<GameState> _gameStates;

        private MenuState _gameOverMenuState;

        public PlayState(Client client, string currentName, ref Stack<GameState> gameStates, bool begin = false)
        {
            Parser.RegisterPackets(ManageNetworkEvents);
            _client = client;
            _currentName = currentName;
            _myTurn = begin;
            _gameStates = gameStates;
        }

        public override void Initialize()
        {
            _current = new Player(_currentName, Map.Generate());
            _current.Map.SetPosition(GameDatas.WindowWidth/2 - GameDatas.Theme.GridSize,
                                     GameDatas.WindowHeight - GameDatas.Theme.GridSize - 25);

            SendCurrentPlayer();
        }

        private void SendCurrentPlayer()
        {
            new BasicsDatasPacket().Pack(_client, _current.Map, _current.Name);
        }

        public void ManageNetworkEvents(NetworkEvent eventDatas)
        {
            switch (eventDatas.PacketOpCode)
            {
                case 1:
                    var basicsDatas = eventDatas as BasicsDatasEvent;
                    _enemy = new Player(basicsDatas.Enemy, basicsDatas.EnemyMap);
                    _enemy.Map.SetPosition(GameDatas.WindowWidth/2,
                                           GameDatas.WindowHeight - GameDatas.Theme.GridSize - 25);
                    return;
                case 2:
                    var fireDatas = eventDatas as FireDatasEvent;
                    if (_current.Play(fireDatas.Coordinates.X, fireDatas.Coordinates.Y) == FireResult.Fail)
                        _myTurn = true;
                    break;
            }
        }

        public override void LoadContent(ContentManager content)
        {
            var gameOverPassive = new MenuPassive(GameDatas.Theme.GameOverTexture);
            var gameOverItems = new List<MenuItem> {gameOverPassive};

            _gameOverMenuState = new MenuState(gameOverItems, true);
            _gameOverMenuState.SetPositions();
        }

        public override void Update(GameTime gameTime)
        {
            if (_enemy == null) // pas encore connecté
                return;

            if (!_client.Connected)
                _gameStates.Pop();

            if (_enemy.IsOver() || _current.IsOver())
            {
                _gameStates.Pop();
                _gameStates.Push(_gameOverMenuState);
                return;
            }

            if (!GameDatas.GameFocus)
                return;

            if (GameDatas.KeyboardFocus &&
                (GameDatas.MouseState.X != GameDatas.PreviousMouseState.X ||
                 GameDatas.MouseState.Y != GameDatas.PreviousMouseState.Y))
            {
                if (_current.Map.Area.Contains(GameDatas.MouseState.X, GameDatas.MouseState.Y))
                    GameDatas.KeyboardFocus = false;
            }

            if (!GameDatas.KeyboardFocus &&
                (GameDatas.KeyboardState.IsKeyDown(Keys.Right) || GameDatas.KeyboardState.IsKeyDown(Keys.Down) ||
                 GameDatas.KeyboardState.IsKeyDown(Keys.Up) || GameDatas.KeyboardState.IsKeyDown(Keys.Down) || GameDatas.KeyboardState.IsKeyDown(Keys.Enter)))
                GameDatas.KeyboardFocus = true;

            _current.Update();
            _enemy.Update();

            if ((!GameDatas.PreviousKeyboardState.IsKeyDown(Keys.Enter) || !GameDatas.KeyboardState.IsKeyUp(Keys.Enter)) &&
                (GameDatas.KeyboardFocus || GameDatas.MouseState.LeftButton != ButtonState.Released ||
                 GameDatas.PreviousMouseState.LeftButton != ButtonState.Pressed) || !_myTurn) return;

            if (_enemy.Play(_enemy.Map.Aim.Y, _enemy.Map.Aim.X) == FireResult.Fail)
                _myTurn = false;
            new FireDatasPacket().Pack(_client, new Point(_enemy.Map.Aim.Y, _enemy.Map.Aim.X));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_enemy == null) // pas encore connecté
                return;

            spriteBatch.Draw(GameDatas.Theme.LogoTexture,
                             new Rectangle((GameDatas.WindowWidth - GameDatas.Theme.LogoTexture.Width)/2, 15,
                                           GameDatas.Theme.LogoTexture.Width, GameDatas.Theme.LogoTexture.Height),
                             Color.White);

            _current.Map.Draw(spriteBatch, true);
            _enemy.Map.Draw(spriteBatch, false);

            spriteBatch.DrawString(GameDatas.Theme.GeneralFont, "Adversaire : " + _enemy.Name,
                                   new Vector2(
                                       GameDatas.WindowWidth -
                                       GameDatas.Theme.GeneralFont.MeasureString("Adversaire : " + _enemy.Name).X, 0),
                                   Color.Violet);
            spriteBatch.DrawString(GameDatas.Theme.GeneralFont, _myTurn ? "A toi de jouer, avec Bendai" : _enemy.Name + " joue",
                                   new Vector2(
                                       GameDatas.WindowWidth -
                                       GameDatas.Theme.GeneralFont.MeasureString(_myTurn
                                                                                     ? "A toi de jouer, avec Bendai"
                                                                                     : _enemy.Name + " joue").X - 50,
                                       150), Color.LightGreen);
        }
    }
}