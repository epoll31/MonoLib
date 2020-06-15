using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MonoLib
{
    public static partial class HelperExtensionFunctions
    {
        private static readonly Dictionary<GraphicsDevice, Texture2D> pixels = new Dictionary<GraphicsDevice, Texture2D>();
        public static Texture2D GetPixel(this SpriteBatch sb)
        {
            if (!pixels.ContainsKey(sb.GraphicsDevice))
            {
                Texture2D pixel = new Texture2D(sb.GraphicsDevice, 1, 1);
                pixel.SetData(new[] { Color.White });
                pixels.Add(sb.GraphicsDevice, pixel);
               //pixels.Add(sb.GraphicsDevice, sb.CreateRectangle(1, 1, Color.White));
            }
            return pixels[sb.GraphicsDevice];
        }

        public static Texture2D CreateCircle(this SpriteBatch sb, Color color, int radius)
        {
            Texture2D circle = new Texture2D(sb.GraphicsDevice, radius * 2, radius * 2);
            Color[] colors = new Color[radius * radius * 4];
            for (int i = 0; i < colors.Length; i++)
            {
                int x = i % (radius * 2);
                int y = i / (radius * 2);

                if (Math.Sqrt(Math.Pow(x - radius, 2) + Math.Pow(y - radius, 2)) < radius)
                {
                    colors[i] = color;
                }
                else
                {
                    colors[i] = Color.Transparent;
                }
            }
            circle.SetData(colors);
            return circle;
        }
        public static Texture2D CreateRectangle(this SpriteBatch sb, int width, int height, int border, Color borderColor, Color fillColor)
        {
            Texture2D rectangle = new Texture2D(sb.GraphicsDevice, width, height);
            Color[] colors = new Color[width * height];
            for (int i = 0; i < colors.Length; i++)
            {
                int x = i % width;
                int y = i / width;

                if (x < border || x > width - border || y < border || y > height - border)
                {
                    colors[i] = borderColor;
                }
                else
                {
                    colors[i] = fillColor;
                }
            }
            rectangle.SetData(colors);
            return rectangle;
        }
        public static Texture2D CreateRectangle(this SpriteBatch sb, int width, int height, Color fillColor)
        {
            Texture2D rectangle = new Texture2D(sb.GraphicsDevice, width, height);
            Color[] colors = new Color[width * height];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = fillColor;
            }
            rectangle.SetData(colors);
            return rectangle;
        }
    }
}
