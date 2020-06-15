using Microsoft.Xna.Framework;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLib.MathClasses
{
    public class Vector2D
    {
        public Matrix2D Matrix { get; private set; }

        public float X
        {
            get
            {
                return Matrix.X;
            }
            set
            {
                Matrix *= Matrix2D.CreateTranslation(value - X, 0);
            }
        }
        public float Y
        {
            get
            {
                return Matrix.Y;
            }
            set
            {
                Matrix *= Matrix2D.CreateTranslation( 0, value - Y);
            }
        }

        public Vector2D(float x, float y)
        {
            Matrix = Matrix2D.CreateTranslation(x, y);
        }
        public Vector2D(Vector2 data)
            : this(data.X, data.Y)
        {
        }
        public Vector2D(Vector2D data)
            : this (data.X, data.Y)
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

        public void RotateAbout(float theta, Vector2D focus)
            => RotateAbout(theta, focus.X, focus.Y);
        public void RotateAbout(float theta, Vector2 focus)
            => RotateAbout(theta, focus.X, focus.Y);
        public void RotateAbout(float theta, float x, float y)
        {
            Matrix *= Matrix2D.CreateRotationZ(theta, x, y);
        }

        public Vector2D Copy()
        {
            return new Vector2D(X, Y);
        }

        public static Vector2D Zero => new Vector2D(0, 0);
        public static Vector2D One => new Vector2D(1, 1);
        public static Vector2D UnitX => new Vector2D(1, 0);
        public static Vector2D UnitY => new Vector2D(0, 1);


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
