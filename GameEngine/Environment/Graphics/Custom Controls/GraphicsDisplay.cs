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
            drawingMethods.Add(GraphicsInstructions.DrawTriangle, (Graphics graphics, object[] parameters) => drawTrangle(graphics, (Vector3[])parameters[0], (Color)parameters[1], (int)parameters[2]));

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

        private void drawTrangle(Graphics graphics, Vector3[] points, Color c, int lineWeight) {
            Line l1 = new Line((int)points[0].X, (int)points[0].Y, (int)points[1].X, (int)points[1].Y);
            Line l2 = new Line((int)points[0].X, (int)points[0].Y, (int)points[2].X, (int)points[2].Y);
            Line l3 = new Line((int)points[1].X, (int)points[1].Y, (int)points[2].X, (int)points[2].Y);
            drawLine(graphics, l1, c, lineWeight);
            drawLine(graphics, l2, c, lineWeight);
            drawLine(graphics, l3, c, lineWeight);
        }


        #endregion
    }
}
