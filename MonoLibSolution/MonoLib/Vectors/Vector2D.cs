using Microsoft.Xna.Framework;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLib.Vectors
{
    public class Vector2D
    {
        public float X { get; private set; }
        public float Y { get; private set; }

        public Vector2D(Vector2 data)
        {
            X = data.X;
            Y = data.Y;
        }
        public Vector2D(float x, float y)
            : this(new Vector2(x, y))
        {
        }
        public Vector2D()
            : this(new Vector2(0, 0))
        {

        }

        public float Length()
        {
            return (float)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }
        public float LengthSquared()
        {
            return (float)(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }
        public void Normalize()
        {
            X /= Length();
            Y /= Length();
        }
        public void Deconstruct(out float x, out float y)
        {
            x = X;
            y = Y;
        }

        public static float Distance(Vector2D first, Vector2D second)
        {
            return (float)Math.Sqrt(Math.Pow(second.X - first.X, 2) + Math.Pow(second.Y - first.Y, 2));
        }
        public static float DistanceSquared(Vector2D first, Vector2D second)
        {
            return (float)(Math.Pow(second.X - first.X, 2) + Math.Pow(second.Y - first.Y, 2));
        }
        public static float Dot(Vector2D first, Vector2D second)
        {
            return first.X * second.X + first.Y * second.Y;
        }

        public void RotateAbout(Vector2D focus, float theta)
        {
            float distance = Distance(focus, this);
            float rotation = (float)Math.Atan2(this.Y - focus.Y, this.X - focus.X);
            float newRotation = rotation + theta;
            X = focus.X + (float)Math.Cos(newRotation) * distance;
            Y = focus.Y + (float)Math.Sin(newRotation) * distance;
        }

        public Vector2D Copy()
        {
            return new Vector2D(X, Y);
        }

        public static Vector2D Zero => (Vector2D)Vector2.Zero;
        public static Vector2D One => (Vector2D)Vector2.One;
        public static Vector2D UnitX => (Vector2D)Vector2.UnitX;
        public static Vector2D UnitY => (Vector2D)Vector2.UnitY;


        public static explicit operator Vector2(Vector2D vector2D)
        {
            return new Vector2(vector2D.X, vector2D.Y);
        }
        public static explicit operator Vector2D(Vector2 vector2)
        {
            return new Vector2D(vector2);
        }

        public static Vector2D operator +(Vector2D left, Vector2D right)
        {
            return new Vector2D(left.X + right.X, left.Y + right.Y);
        }
        public static Vector2D operator +(Vector2D left, Vector2 right)
        {
            return new Vector2D(left.X + right.X, left.Y + right.Y);
        }
        public static Vector2 operator +(Vector2 left, Vector2D right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
        }

        public static Vector2D operator -(Vector2D vector)
        {
            return new Vector2D(-vector.X, -vector.Y);
        }
        public static Vector2D operator -(Vector2D left, Vector2D right)
        {
            return new Vector2D(left.X - right.X, left.Y - right.Y);
        }
        public static Vector2D operator -(Vector2D left, Vector2 right)
        {
            return new Vector2D(left.X - right.X, left.Y - right.Y);
        }
        public static Vector2 operator -(Vector2 left, Vector2D right)
        {
            return new Vector2(left.X - right.X, left.Y - right.Y);
        }

        public static Vector2D operator *(Vector2D left, Vector2D right)
        {
            return new Vector2D(left.X * right.X, left.Y * right.Y);
        }
        public static Vector2D operator *(Vector2D left, Vector2 right)
        {
            return new Vector2D(left.X * right.X, left.Y * right.Y);
        }
        public static Vector2 operator *(Vector2 left, Vector2D right)
        {
            return new Vector2(left.X * right.X, left.Y * right.Y);
        }
        public static Vector2D operator *(Vector2D left, float right)
        {
            return new Vector2D(left.X * right, left.Y * right);
        }

        public static Vector2D operator /(Vector2D left, Vector2D right)
        {
            return new Vector2D(left.X / right.X, left.Y / right.Y);
        }
        public static Vector2D operator /(Vector2D left, Vector2 right)
        {
            return new Vector2D(left.X / right.X, left.Y / right.Y);
        }
        public static Vector2 operator /(Vector2 left, Vector2D right)
        {
            return new Vector2(left.X / right.X, left.Y / right.Y);
        }
        public static Vector2D operator /(Vector2D left, float right)
        {
            return new Vector2D(left.X / right, left.Y / right);
        }
    }
}
