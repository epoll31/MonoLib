using Microsoft.Xna.Framework;
using MonoLib.CollisionDetection.SeparatingAxisTheorem;
using MonoLib.Vectors;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MonoLib.CollisionDetection
{
    public class Polygon : ISATAble
    {
        public Vector2D[] Vertices { get; private set; }
        public Line[] Edges { get; private set; }

        public Vector2D Center
        {
            get
            {
                Vector2D center = Vector2D.Zero;

                foreach (Vector2D vertex in Vertices)
                {
                    center += vertex;
                }
                return center / Vertices.Length;
            }
            private set
            {
                Vector2D delta = value - Center;

                for (int i = 0; i < Vertices.Length; i++)
                {
                    Vertices[i] += delta;
                }
            }
        }

        public Polygon(params Vector2D[] vertices)
        {
            if (vertices.Length < 3)
            {
                throw new ArgumentException("You must supply 3 or more vertices");
            }

            Vertices = vertices;
            
            Edges = new Line[Vertices.Length];
            for (int i = 0; i < Vertices.Length; i++)
            {
                int j = (i + 1) % Vertices.Length;

                Edges[i] = new Line(Vertices[i], Vertices[j]);
            }
        }
        public Polygon(Vector2D position, int numberOfVertices, float radius, float startTheta)
        {
            if (numberOfVertices < 3)
            {
                throw new ArgumentException("'numberOfVertices' must be 3 or more.");
            }
            Vertices = new Vector2D[numberOfVertices];

            for (int i = 0; i < numberOfVertices; i++)
            {
                Vertices[i] = position + new Vector2D((float)Math.Cos(startTheta), (float)Math.Sin(startTheta)) * radius;
                startTheta += (float)Math.PI * 2 / numberOfVertices;
            }

            Edges = new Line[numberOfVertices];
            for (int i = 0; i < Vertices.Length; i++)
            {
                int j = (i + 1) % Vertices.Length;

                Edges[i] = new Line(Vertices[i], Vertices[j]);
            }
        }

        public void RotateBy(float theta)
        {
            if (theta == 0)
            {
                return;
            }

            Vector2D center = Center.Copy();
            foreach (Vector2D vertex in Vertices)
            {
                vertex.RotateAbout(center, theta);
            }
        }
        public void TranslateTo(Vector2D position)
        {
            Center = position;
        }


        public (float min, float max) ProjectOntoLine(Line line)
        {
            float min = float.MaxValue;
            float max = float.MinValue;
            for (int i = 0; i < Edges.Length; i++)
            {
                (float currMin, float currMax) = Edges[i].ProjectOntoLine(line);
                if (currMin < min)
                {
                    min = currMin;
                }
                if (currMax > max)
                {
                    max = currMax;
                }
            }

            return (min, max);
        }
        public IEnumerable<Line> GetProjectionLines()
        {
            Line[] projectionLines = new Line[Edges.Length];
            for (int i = 0; i < Edges.Length; i++)
            {
                projectionLines[i] = Edges[i].PerpendicularLine;
            }

            return projectionLines;
        }

        public bool Intersects(Polygon other)
        {
            return this.RunSAT(other);
        }
    }
}
