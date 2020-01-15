using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine {
    static class BitmapDrawing {
        public static void DrawLine(Graphics graphics, float x1, float y1, float x2, float y2, Color color, int weight) {
            graphics.DrawLine(new Pen(color, weight), x1, y1, x2, y2);
        }

        private static void drawLine (Graphics graphics, float x1, float y1, float x2, float y2, Color color, int weight) {
            graphics.DrawLine(new Pen(color, weight), x1, y1, x2, y2);
        }

        public static void DrawTriangle(Graphics graphics, Vector3 pt1, Vector3 pt2, Vector3 pt3, Color color, int lineWeight) {
            drawLine(graphics, pt1.X, pt1.Y, pt2.X, pt2.Y, color, lineWeight);
            drawLine(graphics, pt1.X, pt1.Y, pt3.X, pt3.Y, color, lineWeight);
            drawLine(graphics, pt2.X, pt2.Y, pt3.X, pt3.Y, color, lineWeight);
        }

        public static void DrawTriangle (Graphics graphics, Vector3[] points, Color color, int lineWeight) {
            drawLine(graphics, points[0].X, points[0].Y, points[1].X, points[1].Y, color, lineWeight);
            drawLine(graphics, points[0].X, points[0].Y, points[2].X, points[2].Y, color, lineWeight);
            drawLine(graphics, points[1].X, points[1].Y, points[2].X, points[2].Y, color, lineWeight);
        }

        public static void ClearFrame(Graphics graphics, Color color) {
            graphics.Clear(color);
        }
    }
}
