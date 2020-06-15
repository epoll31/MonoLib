using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoLib.Sprites
{
    public class Sprite
    {
        public Texture2D Image { get; private set; }
        private Vector2 position;
        public ref Vector2 Position  => ref position;
        public Color Tint { get; private set; }

        public Rectangle? SourceRectangle { get; private set; }
        public float Rotation { get; private set; }
        public Vector2 Origin { get; private set; }
        public Vector2 Scale { get; private set; }
        public SpriteEffects SpriteEffects { get; private set; }
        public int LayerDepth { get; private set; }

        public Sprite(Texture2D image, Vector2 position)
        {
            Image = image;
            Position = position;
            Tint = Color.White;
            SourceRectangle = null;
            Rotation = 0;
            Origin = Vector2.Zero;
            Scale = Vector2.One;
            SpriteEffects = SpriteEffects.None;
            LayerDepth = 0;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Image, Position, SourceRectangle, Tint, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }
    }
}
