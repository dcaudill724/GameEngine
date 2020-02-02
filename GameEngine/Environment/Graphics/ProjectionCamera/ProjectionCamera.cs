﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using System.Threading;

namespace GameEngine {
    class ProjectionCamera : Camera {
        private Matrix4x4 projectionMatrix;
        private Frame frame;

        #region Constructors

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

        #endregion

        public override Frame GetFrame () {
            frame.Clear();

            Matrix4x4 viewMatrix = Matrix4x4.CreateLookAt(Position, Position + Direction, new Vector3(0, 1, 0));

            Vector3 lightDirection = Vector3.Normalize(new Vector3(-0.75f, -1f, -0.5f));

            foreach (EnvironmentObject e in Environment.EnvironmentObjects) {
                List<Triangle> triangles = e.Mesh.Triangles;
                for (int i = 0; i < triangles.Count; ++i) {
                    Triangle t = triangles[i]; //Current triangle

                    if (Vector3.Dot(t.Normal, t.Points[0] - Position) < 0.0f) {
                        Triangle projected = t.Copy();

                        //Convert from world space to view space (Still 3D)
                        projected.TransformMatrix4x4(viewMatrix);

                        //Clip the triangle while adding it to the list of triangles to raster
                        List<Triangle> trianglesToRaster = new List<Triangle>(ClipTriangleAgainstPlane(new Vector3(0f, 0f, 2.1f), new Vector3(0f, 0f, 1f), projected));

                        //List<Triangle> trianglesToRaster = new List<Triangle>() { projected };
                        foreach (Triangle tri in trianglesToRaster) {
                            //Converts the clipped triangle from 3D space to 2D space
                            Triangle clipped = tri.Copy();

                            float brightness = Vector3.Dot(clipped.Normal, lightDirection);
                            if (brightness < 0) {
                                brightness = 0;
                            }

                            frame.FillTriangle(ConvertToScreenSpace(clipped.Copy(), FrameWidth, FrameHeight), e.GetColor(), brightness);
                            frame.DrawTriangle(ConvertToScreenSpace(clipped.Copy(), FrameWidth, FrameHeight), Color.White, 2);
                        }
                    }
                }
            }

            return frame;
        }

        private Triangle ConvertToScreenSpace (Triangle triangle, float frameWidth, float frameHeight) {
            Vector3[] newPoints = new Vector3[3];
            for (int i = 0; i < 3; ++i) {
                Vector3 newPoint = Vector3.Transform(triangle.Points[i], projectionMatrix);
                float w = triangle.Points[i].X * projectionMatrix.M14 + triangle.Points[i].Y * projectionMatrix.M24 + triangle.Points[i].Z * projectionMatrix.M34 + projectionMatrix.M44;
                newPoint /= w;
                newPoint.X += 1.0f;
                newPoint.Y += 1.0f;
                newPoint.X *= (0.5f * frameWidth);
                newPoint.Y *= (0.5f * frameHeight);
                newPoints[i] = newPoint;
            }
            return new Triangle(newPoints);
        }

        #region Clipping Functions

        private Vector3 LinePlaneIntersection (Vector3 planePosition, Vector3 planeNormal, Vector3 lineStart, Vector3 lineEnd) {
            planeNormal = Vector3.Normalize(planeNormal);
            float planeDot = Vector3.Dot(planeNormal, planePosition);
            float ad = Vector3.Dot(lineStart, planeNormal);
            float bd = Vector3.Dot(lineEnd, planeNormal);
            float t = (-planeDot - ad) / (bd - ad);
            Vector3 lineToIntersect = (lineEnd - lineStart) * t;
            return lineStart + lineToIntersect;
        }

        private Triangle[] ClipTriangleAgainstPlane (Vector3 planePosition, Vector3 planeNormal, Triangle triangle) {
            planeNormal = Vector3.Normalize(planeNormal);

            List<Vector3> insidePoints = new List<Vector3>();
            List<Vector3> outsidePoints = new List<Vector3>();

            float[] distances = new float[3];
            for (int i = 0; i < 3; ++i) {
                distances[i] = GetShortestDistanceToPlane(triangle.Points[i], planePosition, planeNormal);
            }

            for (int i = 0; i < 3; ++i) {
                if (distances[i] >= 0) {
                    insidePoints.Add(triangle.Points[i]);
                } else {
                    outsidePoints.Add(triangle.Points[i]);
                }
            }

            if (insidePoints.Count == 0) {
                return new Triangle[] { };
            }

            if (insidePoints.Count == 3) {
                return new Triangle[] { triangle };
            }

            if (insidePoints.Count == 1 && outsidePoints.Count == 2) {
                Vector3 p1 = insidePoints[0];

                Vector3 p2 = LinePlaneIntersection(planePosition, planeNormal, p1, outsidePoints[0]);
                Vector3 p3 = LinePlaneIntersection(planePosition, planeNormal, p1, outsidePoints[1]);

                return new Triangle[] { new Triangle(p1, p2, p3, triangle.Normal) };
            }

            if (insidePoints.Count == 2 && outsidePoints.Count == 1) {
                Vector3 t1p1 = insidePoints[0];
                Vector3 t1p2 = insidePoints[1];
                Vector3 t1p3 = LinePlaneIntersection(planePosition, planeNormal, t1p1, outsidePoints[0]);

                Vector3 t2p1 = insidePoints[1];
                Vector3 t2p2 = t1p3;
                Vector3 t2p3 = LinePlaneIntersection(planePosition, planeNormal, t2p1, outsidePoints[0]);

                return new Triangle[] { new Triangle(t1p1, t1p3, t1p2, triangle.Normal), new Triangle(t2p1, t2p2, t2p3, triangle.Normal) };
            }
            return null; //To satisfy the compliers :(
        }

        private float GetShortestDistanceToPlane(Vector3 point, Vector3 planePosition, Vector3 planeNormal) {
            return planeNormal.X * -point.X + planeNormal.Y * -point.Y + planeNormal.Z * -point.Z - Vector3.Dot(planeNormal, planePosition);
        }

        #endregion

        #region Update Functions

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

        #endregion
        public override void Dispose () {
            
        }
    }
}