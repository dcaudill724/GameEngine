using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace GameEngine {
    public class Frame {
        public int FrameWidth;
        public int FrameHeight;
        public List<GraphicsInstruction> Instructions;

        public Frame(int frameWidth, int frameHeight) {
            FrameWidth = frameWidth;
            FrameHeight = frameHeight;
            Instructions = new List<GraphicsInstruction>();
        }

        public Frame(Frame original) {
            FrameWidth = original.FrameWidth;
            FrameHeight = original.FrameHeight;
            Instructions = new List<GraphicsInstruction>(original.Instructions);
        }

        public void DrawLine(int x1, int y1, int x2, int y2, Color c, int lineWeight) {
            Line l = new Line(x1, y1, x2, y2);
            Instructions.Add(new GraphicsInstruction(GraphicsInstructions.DrawLine, l, c, lineWeight));
        }

        public void DrawTriangle(Vector3[] points, Color c, int lineWeight) {
            Instructions.Add(new GraphicsInstruction(GraphicsInstructions.DrawTriangle, points, c, lineWeight));
        }

        public void Clear() {
            Instructions.Clear();
        }

        public Frame Copy() {
            return new Frame(this);
        }
    }
}
