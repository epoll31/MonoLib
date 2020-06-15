using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoLib.Vectors;
using System;
using System.Collections.Generic;

namespace MonoLib
{
    public static partial class HelperExtensionFunctions
    {
        public static Vector2D ToVector2D(this Point point)
        {
            return new Vector2D(point.X, point.Y);
        }
    }
}
