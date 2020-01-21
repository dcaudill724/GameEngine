using System;
using System.Drawing;
using System.Numerics;

namespace GameEngine {
    public class Frame : IDisposable {
        public Bitmap Image;
        private Graphics graphics;

        public Frame (float width, float height) {
            Image = new Bitmap((int)width, (int)height);
            graphics = Graphics.FromImage(Image);
        }

        public void DrawLine (int x1, int y1, int x2, int y2, Color color, float lineWeight) {
            graphics.DrawLine(new Pen(color, lineWeight), x1, y1, x2, y2);
        }

        public void DrawTriangle (Vector3 pt1, Vector3 pt2, Vector3 pt3, Color color, int lineWeight) {
            Pen pen = new Pen(color, lineWeight);
            graphics.DrawLine(pen, pt1.X, pt1.Y, pt2.X, pt2.Y);
            graphics.DrawLine(pen, pt1.X, pt1.Y, pt3.X, pt3.Y);
            graphics.DrawLine(pen, pt2.X, pt2.Y, pt3.X, pt3.Y);
        }

        public void DrawTriangle (Vector3[] points, Color color, int lineWeight) {
            Pen pen = new Pen(color, lineWeight);
            graphics.DrawLine(pen, points[0].X, points[0].Y, points[1].X, points[1].Y);
            graphics.DrawLine(pen, points[0].X, points[0].Y, points[2].X, points[2].Y);
            graphics.DrawLine(pen, points[1].X, points[1].Y, points[2].X, points[2].Y);
        }

        public void Clear (Color c) {
            graphics.Clear(c);
        }

        public void Dispose () {
            Image.Dispose();
            graphics.Dispose();
        }
    }
}
