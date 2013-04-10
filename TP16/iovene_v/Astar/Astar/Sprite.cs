using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Astar
{
    class Sprite
    {
        Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        Texture2D texture;
        public Texture2D Texture
        {
            get { return texture; }
        }
        Rectangle? sourceRectangle = null;
        public Rectangle? SourceRectangle
        {
            get { return sourceRectangle; }
            set { sourceRectangle = value; }
        }
        Color color = Color.White;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        float rotation = 0;
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        Vector2 origin = Vector2.Zero;
        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }
        Vector2 scale = Vector2.One;
        public Vector2 Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        SpriteEffects effect = SpriteEffects.None;
        public SpriteEffects Effect
        {
            get { return effect; }
            set { effect = value; }
        }
        float layerDepth = 0;
        public float LayerDepth
        {
            get { return layerDepth; }
            set { layerDepth = value; }
        }
        public Sprite(Vector2 position)
        {
            this.position = position;
        }
        public Sprite(Vector2 position, Rectangle? sourceRectangle)
        {
            this.position = position;
            this.sourceRectangle = sourceRectangle;
        }
        public Sprite(Vector2 position, Rectangle? sourceRectangle, Color color)
        {
            this.position = position;
            this.sourceRectangle = sourceRectangle;
            this.color = color;
        }
        public Sprite(Vector2 position, Rectangle? sourceRectangle, Color color, float
        rotation)
        {
            this.position = position;
            this.sourceRectangle = sourceRectangle;
            this.color = color;
            this.rotation = rotation;
        }

        public Sprite(Vector2 position, Rectangle? sourceRectangle, Color color, float
        rotation, Vector2 origin)
        {
            this.position = position;
            this.sourceRectangle = sourceRectangle;
            this.color = color;
            this.rotation = rotation;
            this.origin = origin;
        }

        public Sprite(Vector2 position, Rectangle? sourceRectangle, Color color, float
        rotation, Vector2 origin, Vector2 scale)
        {
            this.position = position;
            this.sourceRectangle = sourceRectangle;
            this.color = color;
            this.rotation = rotation;
            this.origin = origin;
            this.scale = scale;
        }
        public Sprite(Vector2 position, Rectangle? sourceRectangle, Color color, float
        rotation, Vector2 origin, Vector2 scale, SpriteEffects effect)
        {
            this.position = position;
            this.sourceRectangle = sourceRectangle;
            this.color = color;
            this.rotation = rotation;
            this.origin = origin;
            this.scale = scale;
            this.effect = effect;
        }
        public Sprite(Vector2 position, Rectangle? sourceRectangle, Color color, float
        rotation, Vector2 origin, Vector2 scale, SpriteEffects effect, float layerDepth)
        {
            this.position = position;
            this.sourceRectangle = sourceRectangle;
            this.color = color;
            this.rotation = rotation;
            this.origin = origin;
            this.scale = scale;
            this.effect = effect;
            this.layerDepth = layerDepth;
        }
        public void LoadContent(ContentManager content, string assetName)
        {
            texture = content.Load<Texture2D>(assetName);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, color, rotation,
            origin, scale, effect, layerDepth);
        }
    }
}
