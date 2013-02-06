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
    public class Theme
    {
        // GENERAL //////////////////////////////////////////////////////////

        public string Name;

        public Texture2D LogoTexture, GameOverTexture;

        public SpriteFont GeneralFont;

        // MENU //////////////////////////////////////////////////////////

        public SpriteFont ButtonFont;
        public Texture2D ButtonTexture, ButtonTextureFocus;
        public short ButtonPaddingY;

        public SpriteFont TextBoxFont;
        public Texture2D TextBoxTexture, TextBoxTextureFocus, TextBoxCursorTexture;
        public short TextBoxCharsDisplayed;
        public short TextBoxPaddingX, TextBoxPaddingY, TextBoxLabelPaddingY;

        // MAP //////////////////////////////////////////////////////////

        public Texture2D[] CellsTextures;
        public Texture2D GridTexture;
        public Texture2D AimTexture;

        public short CellsNumber; // Nombre de cases qu'a la map
        public short CellSize; // Taille en pixels d'une case
        public short GridPadding; // Padding de la map (de la texture de la grille), peut etre nul en fonction de la texture
        public short GridSize; // Taille en pixels de la grille
        public short AimPadding; // Padding du viseur

        //////////////////////////////////////////////////////////

        public Theme(string name, short cellsNumber, short cellSize, short gridPadding, short aimPadding, short textBoxCharsDisplayed, short textBoxPaddingX, short textBoxLabelPaddingY, short textBoxPaddingY, short buttonPaddingY)
        {
            Name = name;
            CellsNumber = cellsNumber;
            CellSize = cellSize;
            GridPadding = gridPadding;
            GridSize = (short) (cellSize*CellsNumber + gridPadding*2);
            AimPadding = aimPadding;
            TextBoxCharsDisplayed = textBoxCharsDisplayed;
            TextBoxPaddingX = textBoxPaddingX;
            TextBoxPaddingY = textBoxPaddingY;
            ButtonPaddingY = buttonPaddingY;
        }

        public void Load(ContentManager content)
        {
            GeneralFont = content.Load<SpriteFont>("Themes/" + Name + "/GeneralFont");
            ButtonFont = content.Load<SpriteFont>("Themes/" + Name + "/ButtonFont");
            TextBoxFont = content.Load<SpriteFont>("Themes/" + Name + "/TextBoxFont");

            GameOverTexture = content.Load<Texture2D>("Themes/" + Name + "/GameOverTexture");

            ButtonTexture = content.Load<Texture2D>("Themes/" + Name + "/ButtonTexture");
            ButtonTextureFocus = content.Load<Texture2D>("Themes/" + Name + "/ButtonTextureFocus");

            TextBoxTexture = content.Load<Texture2D>("Themes/" + Name + "/TextBoxTexture");
            TextBoxTextureFocus = content.Load<Texture2D>("Themes/" + Name + "/TextBoxTextureFocus");
            TextBoxCursorTexture = content.Load<Texture2D>("Themes/" + Name + "/TextBoxCursorTexture");

            GridTexture = content.Load<Texture2D>("Themes/" + Name + "/Grid");

            AimTexture = content.Load<Texture2D>("Themes/" + Name + "/Aim");

            LogoTexture = content.Load<Texture2D>("Themes/" + Name + "/Logo");

            CellsTextures = new[]
                {
                    content.Load<Texture2D>("Themes/" + Name + "/WaterHidden"),
                    content.Load<Texture2D>("Themes/" + Name + "/Water"),
                    content.Load<Texture2D>("Themes/" + Name + "/BoatHidden"),
                    content.Load<Texture2D>("Themes/" + Name + "/BoatBurning"),
                    content.Load<Texture2D>("Themes/" + Name + "/BoatDestroyed")
                };
        }
    }
}
