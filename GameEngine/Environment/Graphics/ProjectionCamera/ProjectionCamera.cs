using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace GameEngine {
    class ProjectionCamera : Camera {
        public int HorizontalRes;
        public int VerticalRes;
        private float[,] projectionMatrix;
        private Bitmap frame;

        public ProjectionCamera () {
            Name = "Projection Camera";
            Position = new Vector3(0, 0, 0);
            Direction = new Vector3(1, 0, 0);
            HorizontalFOV = 70 * ((float)Math.PI / 180);
            VerticalFOV = 70 * ((float)Math.PI / 180);
            sensitivity = 1;
            AngleFromZ = (float)Math.PI / 2;
            VerticalRes = 500;
            HorizontalRes = 500;

            float fNear = 0.1f;
            float fFar = 1000.0f;
            float fAspectRatio = VerticalRes / HorizontalRes;
            float fHFovRad = 1.0f / (float)Math.Tan(HorizontalFOV);
            float fVFovRad = 1.0f / (float)Math.Tan(VerticalFOV);

            projectionMatrix = new float[4, 4];
            projectionMatrix[0, 0] = fAspectRatio * fHFovRad;
            projectionMatrix[1, 1] = fVFovRad;
            projectionMatrix[2, 2] = fFar / (fFar - fNear);
            projectionMatrix[3, 2] = (-fFar * fNear) / (fFar - fNear);
            projectionMatrix[2, 3] = 1.0f;
            projectionMatrix[3, 3] = 0.0f;
        }

        public ProjectionCamera (string Name, Vector3 Position, Vector3 Direction, float viewWidth, float viewHeight, float sensitivity, int horizontalRes, int verticalRes) {
            this.Name = Name;
            this.Position = Position;
            this.Direction = Direction;
            HorizontalFOV = viewWidth;
            VerticalFOV = viewHeight;
            this.sensitivity = sensitivity;
            AngleFromZ = (float)Math.PI / 2;
            this.HorizontalRes = horizontalRes;
            this.VerticalRes = verticalRes;

            float fNear = 0.1f;
            float fFar = 1000.0f;
            float fAspectRatio = (float)VerticalRes / (float)HorizontalRes;
            float fFovRad = 1.0f / (float)Math.Tan(Math.PI / 4);
            //float fHFovRad = 1.0f / (float)Math.Tan(HorizontalFOV);
            //float fVFovRad = 1.0f / (float)Math.Tan(VerticalFOV);

            projectionMatrix = new float[4, 4];
            projectionMatrix[0, 0] = fAspectRatio * fFovRad;
            projectionMatrix[1, 1] = fFovRad;
            projectionMatrix[2, 2] = fFar / (fFar - fNear);
            projectionMatrix[3, 2] = (-fFar * fNear) / (fFar - fNear);
            projectionMatrix[2, 3] = 1.0f;
            projectionMatrix[3, 3] = 0.0f;

            frame = new Bitmap(HorizontalRes, VerticalRes);
        }

        public override Bitmap GetFrame () {
            for (int i = 0; i < frame.Width; ++i) {
                for (int j = 0; j < frame.Height; ++j) {
                    frame.SetPixel(i, j, Color.Black);
                }
            }

            foreach (EnvironmentObject e in Environment.EnvironmentObjects) {
                List<Triangle> triangles = e.Mesh.Triangles;;
                for (int i = 0; i < triangles.Count; ++i) {
                    Vector3[] projectedPoints = new Vector3[3];
                    for (int j = 0; j < 3; ++j) {
                        Vector3 tempPoint = triangles[i].Points[j];

                        tempPoint.Z += e.Position.Z;

                        tempPoint = VectorMath.MultiplyProjectionMatrix(tempPoint, projectionMatrix);

                        tempPoint.X += 1.0f;
                        tempPoint.Y += 1.0f;
                        tempPoint.X *= 0.5f * HorizontalRes;
                        tempPoint.Y *= 0.5f * VerticalRes;
                        
                        projectedPoints[j] = tempPoint;
                    }
                    BitmapDrawing.DrawTriangle(frame, projectedPoints[0], projectedPoints[1], projectedPoints[2], Color.White, 2);
                }
            }

            return frame;
        }

        public override void Update (List<EnvironmentObject> objects, int mouseXDif, int mouseYDif) {
            if (mouseXDif != 0 || mouseYDif != 0) {
                updateDirection(mouseXDif, mouseYDif);
            }
        }

        private void updateDirection (int mouseXDif, int mouseYDif) {
            //how to multithread this and actually have it be fast
            
            float yAxisAngle = (mouseXDif / 100f) * sensitivity;
            float xAxisAngle = (mouseYDif / 100f) * -sensitivity;
            Direction = VectorMath.RotateVector3Y(Direction, yAxisAngle);
            Direction = VectorMath.TurretRotateVector3X(Direction, xAxisAngle, AngleFromZ);

            AngleFromZ += xAxisAngle;
        }
    }
}
