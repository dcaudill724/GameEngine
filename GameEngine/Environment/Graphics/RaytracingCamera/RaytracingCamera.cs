using System;
using System.Collections.Generic;
using System.Numerics;
using System.Drawing;
using System.Threading;

namespace GameEngine {
    class RaytracingCamera : Camera {
        public int PyramidResolution;
        public int ViewDistance;
        private readonly RayPyramid[,] rayPyramids;

        public RaytracingCamera() {
            Name = "Raytracing Camera";
            Position = new Vector3(0, 0, 0);
            Direction = new Vector3(1, 0, 0);
            HorizontalFOV = 70 * ((float)Math.PI / 180);
            VerticalFOV = 70 * ((float)Math.PI / 180);
            sensitivity = 1;
            FrameWidth = 100;
            FrameHeight = 100;
            PyramidResolution = 10;
            ViewDistance = 500;
            AngleFromZ = (float)Math.PI / 2;
        }

        public RaytracingCamera (string Name, Vector3 Position, Vector3 Direction, float viewWidth, float viewHeight, float sensitivity, int horizontalResolution, int verticalResolution, int pyramidResolution, int viewDistance) {
            this.Name = Name;
            this.Position = Position;
            this.Direction = Direction;
            HorizontalFOV = viewWidth;
            VerticalFOV = viewHeight;
            this.sensitivity = sensitivity;
            FrameWidth = horizontalResolution;
            FrameHeight = verticalResolution;
            PyramidResolution = pyramidResolution;
            ViewDistance = viewDistance;
            rayPyramids = new RayPyramid[pyramidResolution, pyramidResolution];


            //Start at the top left of the field of view
            float startingHorizontalAngle = -viewWidth / 2;
            float startingVerticalAngle = -viewHeight / 2;

            float pyramidHorizontalAngleIncrement = viewWidth / (pyramidResolution + 1);
            float pyramidVerticalAngleIncrement = viewHeight / (pyramidResolution + 1);

            //first we need to initialize all the ray pyramids
            for (int i = 0; i < pyramidResolution; ++i) {
                float verticalAngle = startingVerticalAngle + (pyramidVerticalAngleIncrement * i);
                float nextVerticalAngle = startingVerticalAngle + (pyramidVerticalAngleIncrement * (i + 1));

                for (int j = 0; j < pyramidResolution; ++j) {
                    float horizontalAngle = startingHorizontalAngle + (pyramidHorizontalAngleIncrement * j);
                    float nextHorizontalAngle = startingHorizontalAngle + (pyramidHorizontalAngleIncrement * (j + 1));

                    Vector3 point1 = Vector3.Multiply(ViewDistance, Direction);
                    //point1 = VectorMath.RotateVector3Z(point1, verticalAngle);
                    //point1 = VectorMath.RotateVector3Y(point1, horizontalAngle);

                    Vector3 point2 = Vector3.Multiply(ViewDistance, Direction);
                    //point2 = VectorMath.RotateVector3Z(point2, verticalAngle);
                    //point2 = VectorMath.RotateVector3Y(point2, nextHorizontalAngle);

                    Vector3 point3 = Vector3.Multiply(ViewDistance, Direction);
                    //point3 = VectorMath.RotateVector3Z(point3, nextVerticalAngle);
                    //point3 = VectorMath.RotateVector3Y(point3, horizontalAngle);

                    Vector3 point4 = Vector3.Multiply(ViewDistance, Direction);
                    //point4 = VectorMath.RotateVector3Z(point4, nextVerticalAngle);
                    //point4 = VectorMath.RotateVector3Y(point4, nextHorizontalAngle);

                    rayPyramids[j, i] = new RayPyramid(Position, point1, point2, point3, point4);

                }
            }

            float horizontalAngleIncrement = viewWidth / FrameWidth;
            float verticalAngleIncrement = viewHeight / FrameHeight;

            for (int i = 0; i < FrameHeight; ++i) {
                float verticalAngle = startingVerticalAngle + (verticalAngleIncrement * i);

                for (int j = 0; j < FrameWidth; ++j) {
                    float horizontalAngle = startingHorizontalAngle + (horizontalAngleIncrement * j);

                    Ray newRay = new Ray(Position, Direction, Color.Black);
                    newRay.RotateZ(verticalAngle);
                    newRay.RotateY(horizontalAngle);

                    int rayPyramidHorizontalIndex = (int)(j / (FrameWidth / pyramidResolution));
                    int rayPyramidVerticalIndex = (int)(i / (FrameHeight / pyramidResolution));

                    rayPyramids[rayPyramidHorizontalIndex, rayPyramidVerticalIndex].RayList.Add(newRay);
                }
            }

            AngleFromZ = (float)Math.PI/2;


            //at this point direction is (1, 0, 0);
            //must rotate the vectors to assume the new direction
            //float dirXAngle = (Direction.X) / (float)Math.Sqrt(Math.Pow(Direction.X, 2) + Math.Pow(Direction.Y, 2) + Math.Pow(Direction.Z, 2));
        }

        #region Update Functions

        public override Frame GetFrame () {
            throw new NotImplementedException();
            /*Bitmap frame = new Bitmap((int)FrameWidth, (int)FrameHeight);

            int internalPyramidResolution = (int)(FrameHeight / PyramidResolution);
            //need to fix all this nonsense to work with horizontal and vertical resolutions

            for (int i = 0; i < rayPyramids.GetLength(0); ++i) {
                int startingFrameX = i * internalPyramidResolution;

                for (int j = 0; j < rayPyramids.GetLength(1); ++j) {
                    Color[] rayColors = rayPyramids[i, j].GetRayColors();
                    int startingFrameY = j * internalPyramidResolution;

                    for (int k = 0; k < rayColors.Length; ++k) {
                        int frameX = startingFrameX + (k % internalPyramidResolution);
                        int frameY = startingFrameY + (k / internalPyramidResolution);
                        
                        frame.SetPixel(frameX, frameY, rayColors[k]);
                    }
                }
            }

            return frame;*/
        }

        public override void Update (List<EnvironmentObject> objects, int mouseXDif, int mouseYDif, Vector3 direction) {
            if (mouseXDif != 0 || mouseYDif != 0) {
                updateDirection(mouseXDif, mouseYDif);
            }
            foreach (RayPyramid rp in rayPyramids) {
                foreach (EnvironmentObject e in Environment.EnvironmentObjects) {
                    if (GJKCollision.CheckCollision(rp, e)) {
                        castRays(rp.RayList, objects);
                    } else {
                        rp.SetColor(Color.Black);
                    }
                }
            }
        }

        private void updateDirection (int mouseXDif, int mouseYDif) {
            //how to multithread this and actually have it be fast

            float yAxisAngle = (mouseXDif / 100f) * sensitivity;
            float xAxisAngle = (mouseYDif / 100f) * -sensitivity;
            //Direction = VectorMath.RotateVector3Y(Direction, yAxisAngle);
            //Direction = VectorMath.TurretRotateVector3X(Direction, xAxisAngle, AngleFromZ);

            AngleFromZ += xAxisAngle;

            foreach (RayPyramid rp in rayPyramids) {
                rp.RotateY(yAxisAngle);
                rp.TurretRotateX(xAxisAngle, AngleFromZ);

                foreach (Ray r in rp.RayList) {
                    r.RotateY(yAxisAngle);
                    r.TurretRotateX(xAxisAngle, AngleFromZ);
                }
            }
        }

        private void castRays (List<Ray> rays, List<EnvironmentObject> objects) {
            foreach (EnvironmentObject e in objects) {
                foreach (Ray r in rays) {
                    float minDist = float.PositiveInfinity;
                    EnvironmentObject closestObject = null;

                    float collisionDist = e.RayCollision(r);
                    if (collisionDist > 0 && collisionDist < minDist) {
                        minDist = collisionDist;
                        closestObject = e;
                    }

                    if (closestObject != null) {
                        r.RayColor = closestObject.GetColor();
                    } else {
                        r.RayColor = Color.Black;
                    }
                }
            }
        }

        public override void Dispose () {
            throw new NotImplementedException();
        }

        #endregion
    }
}