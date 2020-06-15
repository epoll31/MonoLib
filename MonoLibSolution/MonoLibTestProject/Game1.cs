using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoLib;
using MonoLib.CollisionDetection;
using MonoLib.MathClasses;
using System;
using System.Diagnostics;

namespace MonoLibTestProject
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Polygon first;
        Polygon second;

        MouseState ms;
        MouseState lms;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            IsMouseVisible = true;

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            first = new Polygon(new Vector2D(GraphicsDevice.Viewport.Width / 2, 150), 4, 75, (float)Math.PI / 4);
            second = new Polygon(new Vector2D(GraphicsDevice.Viewport.Width / 2, 300), 4, 75, 0);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            ms = Mouse.GetState();

            second.RotateBy((ms.ScrollWheelValue - lms.ScrollWheelValue) * 0.0001f);
            second.TranslateTo(ms.Position.ToVector2D());

            lms = ms;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            bool intersects = first.Intersects(second);
            spriteBatch.DrawPolygon(first, intersects ? Color.Red : Color.Black, 1);
            spriteBatch.DrawPolygon(second, intersects ? Color.Red : Color.Black, 1);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
