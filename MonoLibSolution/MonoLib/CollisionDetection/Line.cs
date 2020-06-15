using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoLib.CollisionDetection.SeparatingAxisTheorem;
using MonoLib.Vectors;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MonoLib
{
    public class Line : ISATAble
    {
        public Vector2D First { get; private set; }
        public Vector2D Second { get; private set; }

        public float Rotation => (float)Math.Atan2(Second.Y - First.Y, Second.X - First.X);
        public float Length => Vector2D.Distance(First, Second);

        public Vector2D Center => (First + Second) / 2;

        public Vector2D Delta => Second - First;
        public float DeltaX => Second.X - First.X;
        public float DeltaY => Second.Y - First.Y;
        
        public Line PerpendicularLine => new Line(Center + new Vector2D(-DeltaY / 2, DeltaX / 2), Center + new Vector2D(DeltaY / 2, -DeltaX / 2));

        public Line(Vector2D first, Vector2D second)
        {
            First = first;
            Second = second;
        }

        public void RotateAroundCenter(float theta)
        {
            if (theta == 0)
            {
                return;
            }
            Vector2D center = Center;
            /*float newRotation = Rotation + theta;
            float halfLength = Length / 2;

            Vector2D newVector = new Vector2D((float)Math.Cos(newRotation) * halfLength, (float)Math.Sin(newRotation) * halfLength);
            First = center - newVector;
            Second = center + newVector;*/

            First.RotateAbout(center, theta);
            Second.RotateAbout(center, theta);
        }
        public void TranslateBy(Vector2D delta)
        {
            First += delta;
            Second += delta;
        }
        public void TranslateTo(Vector2D position) => TranslateBy(position - Center);

        public bool Intersects(Line other) => this.RunSAT(other);

        public (float min, float max) ProjectOntoLine(Line line)
        {
            float first = Vector2D.Dot(First, line.Delta) / (float)Math.Pow(line.Length, 2);
            float second = Vector2D.Dot(Second, line.Delta) / (float)Math.Pow(line.Length, 2);

            if (first < second)
            {
                return (first, second);
            }
            else
            {
                return (second, first);
            }
        }

        public IEnumerable<Line> GetProjectionLines()
        {
            return new[] { PerpendicularLine };
        }
    }
}
