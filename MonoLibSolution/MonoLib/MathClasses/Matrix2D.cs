using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLib.MathClasses
{
    public class Matrix2D
    {
        public float[,] Matrix { get; private set; }
        public ref float M11 => ref Matrix[0, 0];
        public ref float M12 => ref Matrix[0, 1];
        public ref float M13 => ref Matrix[0, 2];
        public ref float M21 => ref Matrix[1, 0];
        public ref float M22 => ref Matrix[1, 1];
        public ref float M23 => ref Matrix[1, 2];
        public ref float M31 => ref Matrix[2, 0];
        public ref float M32 => ref Matrix[2, 1];
        public ref float M33 => ref Matrix[2, 2];

        public ref float X => ref M31;
        public ref float Y => ref M32;
        public float Theta => (float)Math.Acos(M11);

        public Matrix2D(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
        {
            Matrix = new float[3, 3];
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M31 = m31;
            M32 = m32;
            M33 = m33;
        }
        public Matrix2D(float[,] matrix)
        {
            if (matrix.Length != 3 || matrix.GetLength(0) != 3)
            {
                throw new ArgumentException("'matrix' must be a 3x3 array");
            }

            Matrix = matrix;
        }

        public static Matrix2D Identity => new Matrix2D(1, 0, 0, 0, 1, 0, 0, 0, 1);

        public static Matrix2D CreateTranslation(Vector2D position) => CreateTranslation(position.X, position.Y);
        public static Matrix2D CreateTranslation(Vector2 position) => CreateTranslation(position.X, position.Y);
        public static Matrix2D CreateTranslation(float x, float y) => new Matrix2D(1, 0, 0, 0, 1, 0, x, y, 1);
        public static Matrix2D CreateRotationZ(float radians)
        {
            float c = (float)Math.Cos(radians);
            float s = (float)Math.Sin(radians);

            float m11 = c;
            float m12 = s;
            float m22 = c;
            float m21 = -s;

            return new Matrix2D(m11, m12, 0, m21, m22, 0, 0, 0, 1);
        }
        public static Matrix2D CreateRotationZ(float radians, float centerX, float centerY)
        {
            float c = (float)Math.Cos(radians);
            float s = (float)Math.Sin(radians);

            float x = centerX * (1 - c) + centerY * s;
            float y = centerY * (1 - c) - centerX * s;

            float m11 = c;
            float m12 = s;
            float m22 = c;
            float m21 = -s;

            return new Matrix2D(m11, m12, 0, m21, m22, 0, x, y, 1);
        }

        public static Matrix2D operator +(Matrix2D left, Matrix2D right)
        {
            return new Matrix2D(left.M11 + right.M11,
                                left.M12 + right.M12,
                                left.M13 + right.M13,
                                left.M21 + right.M21,
                                left.M22 + right.M22,
                                left.M23 + right.M23,
                                left.M31 + right.M31,
                                left.M32 + right.M32,
                                left.M33 + right.M33);
        }
        public static Matrix2D operator -(Matrix2D left, Matrix2D right)
        {
            return new Matrix2D(left.M11 - right.M11,
                                left.M12 - right.M12,
                                left.M13 - right.M13,
                                left.M21 - right.M21,
                                left.M22 - right.M22,
                                left.M23 - right.M23,
                                left.M31 - right.M31,
                                left.M32 - right.M32,
                                left.M33 - right.M33);
        }
        public static Matrix2D operator *(Matrix2D left, Matrix2D right)
        {
            float m11 = left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31;
            float m12 = left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32;
            float m13 = left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33;

            float m21 = left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31;
            float m22 = left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32;
            float m23 = left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33;

            float m31 = left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31;
            float m32 = left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32;
            float m33 = left.M31 * right.M13 + left.M32 * right.M23 + left.M33 * right.M33;

            return new Matrix2D(m11, m12, m13, m21, m22, m23, m31, m32, m33);
        }
        public static Matrix2D operator *(Matrix2D left, float right)
        {
            float m11 = left.M11 * right + left.M12 * right + left.M13 * right;
            float m12 = left.M11 * right + left.M12 * right + left.M13 * right;
            float m13 = left.M11 * right + left.M12 * right + left.M13 * right;

            float m21 = left.M21 * right + left.M22 * right + left.M23 * right;
            float m22 = left.M21 * right + left.M22 * right + left.M23 * right;
            float m23 = left.M21 * right + left.M22 * right + left.M23 * right;

            float m31 = left.M31 * right + left.M32 * right + left.M33 * right;
            float m32 = left.M31 * right + left.M32 * right + left.M33 * right;
            float m33 = left.M31 * right + left.M32 * right + left.M33 * right;

            return new Matrix2D(m11, m12, m13, m21, m22, m23, m31, m32, m33);
        }
    }
}
