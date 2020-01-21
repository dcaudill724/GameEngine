using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using System.Threading;

namespace GameEngine {
    class ProjectionCamera : Camera {
        private Matrix4x4 projectionMatrix;
        private Frame frame;

        public ProjectionCamera () {
            Name = "Projection Camera";
            Position = new Vector3(0, 0, 0);
            Direction = new Vector3(1, 0, 0);
            HorizontalFOV = 70 * ((float)Math.PI / 180);
            VerticalFOV = 70 * ((float)Math.PI / 180);
            sensitivity = 1;
            AngleFromZ = (float)Math.PI / 2;
            FrameHeight = 1080;
            FrameWidth = 1920;
        }

        public ProjectionCamera (string Name, Vector3 Position, Vector3 Direction, float viewWidth, float viewHeight, float sensitivity, int horizontalRes, int verticalRes) {
            this.Name = Name;
            this.Position = Position;
            this.Direction = Direction;
            HorizontalFOV = viewWidth;
            VerticalFOV = viewHeight;
            this.sensitivity = sensitivity;
            AngleFromZ = (float)Math.PI / 2;
            FrameWidth = horizontalRes;
            FrameHeight = verticalRes;

            projectionMatrix = Matrix4x4.CreatePerspectiveFieldOfView((float)(Math.PI / 2), FrameWidth / FrameHeight, 0.1f, 1000.0f);

            frame = new Frame(FrameWidth, FrameHeight);
        }

        public override Frame GetFrame () {

            Matrix4x4 viewMatrix = Matrix4x4.CreateLookAt(Position, Position + Direction, new Vector3(0, 1, 0));

            foreach (EnvironmentObject e in Environment.EnvironmentObjects) {
                List<Triangle> triangles = e.Mesh.Triangles;
                for (int i = 0; i < triangles.Count; ++i) {
                    Vector3[] projectedPoints = new Vector3[3];
                    Triangle t = triangles[i];

                    for (int j = 0; j < 3; ++j) {
                        Vector3 point = Vector3.Transform(t.Points[j], viewMatrix);

                        projectedPoints[j] = ConvertToScreenSpace(point, FrameWidth, FrameHeight);
                    }

                   frame.DrawTriangle(projectedPoints, Color.White, 2);
                }
            }

            return frame;
        }

        private Vector3 ConvertToScreenSpace(Vector3 vec, float frameWidth, float frameHeight) {
            Vector3 newVec = Vector3.Transform(vec, projectionMatrix);
            float w = vec.X * projectionMatrix.M14 + vec.Y * projectionMatrix.M24 + vec.Z * projectionMatrix.M34 + projectionMatrix.M44;
            newVec /= w;
            newVec.X += 1.0f;
            newVec.Y += 1.0f;
            newVec.X *= (0.5f * frameWidth);
            newVec.Y *= (0.5f * frameHeight);
            return newVec;
        }

        public override void Update (List<EnvironmentObject> objects, int mouseXDif, int mouseYDif) {
            if (mouseXDif != 0 || mouseYDif != 0) {
                updateDirection(-mouseXDif, mouseYDif);
            }
        }

        private void updateDirection (int mouseXDif, int mouseYDif) {
            float yAxisAngle = (mouseXDif / 100f) * sensitivity;
            float xAxisAngle = (mouseYDif / 100f) * -sensitivity;
            Direction = VectorMath.RotateVector3Y(Direction, yAxisAngle);
            Direction = VectorMath.TurretRotateVector3X(Direction, xAxisAngle, AngleFromZ);
            AngleFromZ += xAxisAngle;
        }

        public override void Dispose () {
            frame.Dispose();
        }
    }
}
