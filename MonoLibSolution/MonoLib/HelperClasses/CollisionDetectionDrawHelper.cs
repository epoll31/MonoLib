using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoLib.CollisionDetection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLib
{
    public static partial class HelperExtensionFunctions
    {
        public static void DrawLine(this SpriteBatch spriteBatch, Line line)
        {
            spriteBatch.DrawLine(line, Color.Black, 1);
        }
        public static void DrawLine(this SpriteBatch spriteBatch, Line line, Color color)
        {
            spriteBatch.DrawLine(line, color, 1);
        }
        public static void DrawLine(this SpriteBatch spriteBatch, Line line, Color color, float thickness)
        {
            spriteBatch.Draw(spriteBatch.GetPixel(), (Vector2)line.First, null, color, line.Rotation, new Vector2(0, thickness / 2), new Vector2(line.Length, thickness), SpriteEffects.None, 0);
        }
        
        public static void DrawPolygon(this SpriteBatch spriteBatch, Polygon polygon)
        {
            spriteBatch.DrawPolygon(polygon, Color.Black, 1);
        }
        public static void DrawPolygon(this SpriteBatch spriteBatch, Polygon polygon, Color color)
        {
            spriteBatch.DrawPolygon(polygon, color, 1);
        }
        public static void DrawPolygon(this SpriteBatch spriteBatch, Polygon polygon, Color color, float thickness)
        {
            foreach (Line line in polygon.Edges)
            {
                spriteBatch.DrawLine(line, color, thickness);
            }
        }

    }
}
