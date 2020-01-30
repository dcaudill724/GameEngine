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

            projectionMatrix = Matrix4x4.CreatePerspectiveFieldOfView((float)(Math.PI / 3), FrameWidth / FrameHeight, 0.1f, 1000.0f);

            frame = new Frame((int)FrameWidth, (int)FrameHeight);
        }

        public override Frame GetFrame () {
            frame.Clear();

            Matrix4x4 viewMatrix = Matrix4x4.CreateLookAt(Position, Position + Direction, new Vector3(0, 1, 0));

            Vector3 lightDirection = new Vector3(-1f, 0f, 0f);

            foreach (EnvironmentObject e in Environment.EnvironmentObjects) {
                List<Triangle> triangles = e.Mesh.Triangles;
                for (int i = 0; i < triangles.Count; ++i) {
                    Triangle t = triangles[i]; //Current triangle

                    if (Vector3.Dot(t.Normal, t.Points[0] - Position) < 0.0f) { 
                        Vector3[] projectedPoints = new Vector3[3]; //Stores projected points

                        //Converts the points from 3D space to 2D space
                        for (int j = 0; j < 3; ++j) {
                            Vector3 point = Vector3.Transform(t.Points[j], viewMatrix);

                            projectedPoints[j] = ConvertToScreenSpace(point, FrameWidth, FrameHeight);
                        }

                        float brightness = Vector3.Dot(t.Normal, lightDirection);
                        //brightness isn't working bro
                        Console.WriteLine(brightness);

                        frame.FillTriangle(projectedPoints, e.GetColor(), 1);
                    }
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

        public override void Update (List<EnvironmentObject> objects, int mouseXDif, int mouseYDif, Vector3 direction) {
            Position += direction;
            if (mouseXDif != 0 || mouseYDif != 0) {
                updateDirection(-mouseXDif, mouseYDif, direction);
            }
        }

        private void updateDirection (int mouseXDif, int mouseYDif, Vector3 direction) {
            float yAxisAngle = (mouseXDif / 100f) * sensitivity;
            float xAxisAngle = (mouseYDif / 100f) * -sensitivity;
            Direction = VectorMath.RotateVector3Y(Direction, yAxisAngle);
            Direction = VectorMath.TurretRotateVector3X(Direction, xAxisAngle, AngleFromZ);
            AngleFromZ += xAxisAngle;
        }

        public override void Dispose () {
            
        }
    }
}
