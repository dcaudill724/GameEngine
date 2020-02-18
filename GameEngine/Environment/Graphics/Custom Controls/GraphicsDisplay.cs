using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Timers;
using System.Windows.Forms;

namespace GameEngine {
    public partial class GraphicsDisplay : Control {
        //as of right now the timer updates the display at 1000fps but I want it to be invalidated when a frame is done drawing

        private Camera activeCamera;
        private Rectangle displayBounds;
        private float xRatio;
        private float yRatio;
        private Dictionary<GraphicsInstructions, Action<Graphics, object[]>> drawingMethods;
        private Frame currentFrame;

        public Frame CurrentFrame {
            get { return currentFrame; }
            set {
                currentFrame = value;
                Ready = false;
            }
        }
        public bool Ready;

        public GraphicsDisplay () {
            InitializeComponent();
            DoubleBuffered = true;

            System.Timers.Timer temp = new System.Timers.Timer(1);
            temp.Elapsed += update;
            temp.AutoReset = true;
            temp.Enabled = true;
            temp.Start();

            drawingMethods = new Dictionary<GraphicsInstructions, Action<Graphics, object[]>>();
            drawingMethods.Add(GraphicsInstructions.DrawLine, (Graphics graphics, object[] parameters) => drawLine(graphics, (Line)parameters[0], (Color)parameters[1], (int)parameters[2]));
            drawingMethods.Add(GraphicsInstructions.DrawTriangle, (Graphics graphics, object[] parameters) => drawTrangle(graphics, (GraphicsTriangle)parameters[0], (Color)parameters[1], (int)parameters[2]));
            drawingMethods.Add(GraphicsInstructions.FillTriangle, (Graphics graphics, object[] parameters) => fillTriangle(graphics, (GraphicsTriangle)parameters[0], (Color)parameters[1], (float)parameters[2]));

            Ready = true;
        }

        private void update(object source, ElapsedEventArgs e) {
            Invalidate();
        }

        protected override void OnPaint (PaintEventArgs pe) {
            base.OnPaint(pe);

            pe.Graphics.FillRectangle(new SolidBrush(Color.Black), displayBounds);

            if (activeCamera != null && currentFrame != null) {
                foreach (GraphicsInstruction i in currentFrame.Instructions) {
                    drawingMethods[i.Instruction](pe.Graphics, i.Parameters);
                }
            }

            Ready = true;
        }

        public void SetActiveCamera(Camera camera) {
            activeCamera = camera;

            float viewAspectRatio = (float)Height / (float)Width;
            float aspectRatio = camera.FrameHeight / camera.FrameWidth;

            if (aspectRatio > viewAspectRatio) {
                displayBounds.Height = Height;
                displayBounds.Width = (int)(Height * (1 / aspectRatio));
            } else if (aspectRatio < viewAspectRatio) {
                displayBounds.Width = Width;
                displayBounds.Height = (int)(Width * (aspectRatio));
            } else {
                displayBounds.Width = Width;
                displayBounds.Height = Height;
            }
            displayBounds.Location = new Point((Width / 2) - (displayBounds.Width / 2), (Height / 2) - (displayBounds.Height / 2));

            xRatio = (float)displayBounds.Width / camera.FrameWidth;
            yRatio = (float)displayBounds.Height / camera.FrameHeight;
        }


        #region Drawing Methods
        private void convertToDisplaySpace(ref Line line) {
            line.X1 = (int)(line.X1 * xRatio + displayBounds.X);
            line.Y1 = (int)(line.Y1 * yRatio + displayBounds.Y);
            line.X2 = (int)(line.X2 * xRatio + displayBounds.X);
            line.Y2 = (int)(line.Y2 * yRatio + displayBounds.Y);
        }

        private void drawLine (Graphics graphics, Line line, Color c, int lineWeight) {
            convertToDisplaySpace(ref line);
            graphics.DrawLine(new Pen(c, lineWeight), line.X1, line.Y1, line.X2, line.Y2);
        }

        private void drawTrangle(Graphics graphics, GraphicsTriangle triangle, Color c, int lineWeight) {
            Line l1 = new Line((int)triangle.Points[0].Value.X, (int)triangle.Points[0].Value.Y, (int)triangle.Points[1].Value.X, (int)triangle.Points[1].Value.Y);
            Line l2 = new Line((int)triangle.Points[0].Value.X, (int)triangle.Points[0].Value.Y, (int)triangle.Points[2].Value.X, (int)triangle.Points[2].Value.Y);
            Line l3 = new Line((int)triangle.Points[1].Value.X, (int)triangle.Points[1].Value.Y, (int)triangle.Points[2].Value.X, (int)triangle.Points[2].Value.Y);
            drawLine(graphics, l1, c, lineWeight);
            drawLine(graphics, l2, c, lineWeight);
            drawLine(graphics, l3, c, lineWeight);
        }

        private void fillTriangle(Graphics graphics, GraphicsTriangle triangle, Color c, float brightness) {
            c = Color.FromArgb((int)(c.R * brightness), (int)(c.G * brightness), (int)(c.B * brightness));
            Array.Sort(triangle.Points, delegate (GraphicsVector3 vec1, GraphicsVector3 vec2) { return vec1.Value.Y.CompareTo(vec2.Value.Y); });
            if (triangle.Points[1].Value.Y == triangle.Points[2].Value.Y) {
                fillFlatBottomTriangle(graphics, triangle.Points, c);
            }
            else if (triangle.Points[0].Value.Y == triangle.Points[1].Value.Y) {
                fillFlatTopTriangle(graphics, triangle.Points, c);
            } else {
                GraphicsVector3 v4 = new GraphicsVector3(new Vector3((int)(triangle.Points[0].Value.X + (triangle.Points[1].Value.Y - triangle.Points[0].Value.Y) / (triangle.Points[2].Value.Y - triangle.Points[0].Value.Y) * (triangle.Points[2].Value.X - triangle.Points[0].Value.X)), triangle.Points[1].Value.Y, 1));
                fillFlatBottomTriangle(graphics, new GraphicsVector3[] { triangle.Points[0], triangle.Points[1], v4 }, c);
                fillFlatTopTriangle(graphics, new GraphicsVector3[] { triangle.Points[1], v4, triangle.Points[2] }, c);
            }
        }

        private void fillFlatTopTriangle(Graphics graphics, GraphicsVector3[] points, Color c) {
            float invslope1 = (points[2].Value.X - points[0].Value.X) / (points[2].Value.Y - points[0].Value.Y);
            float invslope2 = (points[2].Value.X - points[1].Value.X) / (points[2].Value.Y - points[1].Value.Y);

            float curx1 = points[2].Value.X;
            float curx2 = points[2].Value.X;

            for (float scanlineY = points[2].Value.Y; scanlineY > points[0].Value.Y; scanlineY--) {
                Line line = new Line((int)curx1, (int)scanlineY, (int)curx2, (int)scanlineY);
                drawLine(graphics, line, c, 1);
                curx1 -= invslope1;
                curx2 -= invslope2;
            }
        }

        private void fillFlatBottomTriangle(Graphics graphics, GraphicsVector3[] points, Color c) {
            //issues here with weird artifacts
            float invslope1 = (points[1].Value.X - points[0].Value.X) / (points[1].Value.Y - points[0].Value.Y);
            float invslope2 = (points[2].Value.X - points[0].Value.X) / (points[2].Value.Y - points[0].Value.Y);

            float curx1 = points[0].Value.X;
            float curx2 = points[0].Value.X;

            for (float scanlineY = points[0].Value.Y; scanlineY <= points[1].Value.Y; scanlineY++) {
                Line line = new Line((int)curx1, (int)scanlineY, (int)curx2, (int)scanlineY);
                drawLine(graphics, line, c, 1);
                curx1 += invslope1;
                curx2 += invslope2;
            }
        }


        #endregion
    }
}
