using System;
using System.Collections.Generic;
using System.Numerics;
using System.Drawing;
using System.Threading;

namespace GameEngine {
    class RaytracingCamera : Camera {
        public readonly int Resolution;
        private readonly List<Ray> RayList;
        private float angleFromZ;

        public RaytracingCamera() {
            Name = "Raytracing Camera";
            Position = new Vector3(0, 0, 0);
            Direction = new Vector3(1, 0, 0);
            HorizontalFOV = 70 * ((float)Math.PI / 180);
            VerticalFOV = 70 * ((float)Math.PI / 180);
            sensitivity = 1;
            Resolution = 100;
        }

        public RaytracingCamera (string Name, Vector3 Position, Vector3 Direction, float viewWidth, float viewHeight, float sensitivity, int resolution) {
            this.Name = Name;
            this.Position = Position;
            this.Direction = Direction;
            HorizontalFOV = viewWidth;
            VerticalFOV = viewHeight;
            this.sensitivity = sensitivity;
            Resolution = resolution;
            RayList = new List<Ray>();


            float startingHorizontalAngle = -viewWidth / 2;
            float startingVerticalAngle = -viewHeight / 2;

            float horizontalAngleIncrement = viewWidth / resolution;
            float verticalAngleIncrement = viewHeight / resolution;

            for (int i = 0; i < resolution; ++i) {
                float verticalAngle = startingVerticalAngle + (verticalAngleIncrement * i);

                for (int j = 0; j < resolution; ++j) {
                    float horizontalAngle = startingHorizontalAngle + (horizontalAngleIncrement * j);

                    Ray newRay = new Ray(Position, Direction, Color.Black);
                    newRay.RotateZ(verticalAngle);
                    newRay.RotateY(horizontalAngle);

                    RayList.Add(newRay);
                }
            }

            angleFromZ = (float)Math.PI/2;

            //at this point direction is (1, 0, 0);
            //must rotate the vectors to assume the new direction
            float dirXAngle = (Direction.X) / (float)Math.Sqrt(Math.Pow(Direction.X, 2) + Math.Pow(Direction.Y, 2) + Math.Pow(Direction.Z, 2));
        }

        public override Bitmap GetFrame () {
            Bitmap frame = new Bitmap(Resolution, Resolution);

            //Rays are placed in the list from top to bottom and each row left to right
            for (int i = 0; i < RayList.Count; ++i) {
                //i / resolution gets the row
                //i % resolution gets the column
                Ray temp = RayList[i];
                frame.SetPixel(i % Resolution, i / Resolution, temp.RayColor);
            }

            return frame;
        }

        public override void Update (SynchronizedCollection<EnvironmentObject> objects, int mouseXDif, int mouseYDif) {
            if (mouseXDif != 0 || mouseYDif != 0) {
                updateDirection(mouseXDif, mouseYDif);
            }

            castRays(RayList, objects, 0);
        }

        private void updateDirection (int mouseXDif, int mouseYDif) {
            //how to multithread this and actually have it be fast
            List<Thread> threads = new List<Thread>();

            float yAxisAngle = (mouseXDif / 100f) * sensitivity;
            float xAxisAngle = (mouseYDif / 100f) * -sensitivity;
            RotateDirY(yAxisAngle);
            TurretRotateDirX(xAxisAngle);

            angleFromZ += xAxisAngle;

            foreach (Ray r in RayList) {
                r.RotateY(yAxisAngle);
                r.TurretRotateX(xAxisAngle, angleFromZ);
            }
        }

        private void castRays (List<Ray> rays, SynchronizedCollection<EnvironmentObject> objects, int counter) {
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
            ++counter;
        }

        public void RotateDirX (float angle) {
            float y = (float)(Direction.Y * Math.Cos(angle) - Direction.Z * Math.Sin(angle));
            float z = (float)(Direction.Y * Math.Sin(angle) + Direction.Z * Math.Cos(angle));
            Direction = new Vector3(Direction.X, y, z);
        }

        public void RotateDirY (float angle) {
            float x = (float)(Direction.X * Math.Cos(angle) + Direction.Z * Math.Sin(angle));
            float z = (float)(-Direction.X * Math.Sin(angle) + Direction.Z * Math.Cos(angle));
            Direction = new Vector3(x, Direction.Y, z);
        }

        public void RotateDirZ (float angle) {
            float x = (float)(Direction.X * Math.Cos(angle) - Direction.Y * Math.Sin(angle));
            float y = (float)(Direction.X * Math.Sin(angle) + Direction.Y * Math.Cos(angle));
            Direction = new Vector3(x, y, Direction.Z);
        }

        public void TurretRotateDirX (float angle) {
            RotateDirY(-angleFromZ);
            RotateDirX(angle);
            RotateDirY(angleFromZ);
        }
    }
}