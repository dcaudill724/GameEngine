using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;
using System.Collections.Concurrent;
using System.Threading;

namespace GameEngine {
    class RaytracingCamera : Camera {
        public Vector3 Position;
        public Vector3 Direction;
        private float sensitivity;
        private readonly int resolution;
        private readonly List<List<Ray>> rayLists;
        private readonly int rayListCount;

        public RaytracingCamera (Vector3 Position, Vector3 Direction, float viewWidth, float viewHeight, float sensitivity, int resolution) {
            this.Position = Position;
            this.Direction = Direction;
            this.sensitivity = sensitivity;
            this.resolution = resolution;
            rayListCount = 6;

            //init (arbitrarily) 6 ray lists
            rayLists = new List<List<Ray>>();
            for (int i = 0; i < rayListCount; ++i) {
                rayLists.Add(new List<Ray>());
            }


            float startingHorizontalAngle = -viewWidth / 2;
            float startingVerticalAngle = -viewHeight / 2;

            float horizontalAngleIncrement = viewWidth / resolution;
            float verticalAngleIncrement = viewHeight / resolution;

            for (int i = 0; i < resolution; ++i) {
                float verticalAngle = startingVerticalAngle + (verticalAngleIncrement * i);

                for (int j = 0; j < resolution; ++j) {
                    float horizontalAngle = startingHorizontalAngle + (horizontalAngleIncrement * j);

                    //might be a problem here with Direction being passed by value but probably not
                    Ray newRay = new Ray(Position, Direction, Color.Black);
                    newRay.RotateY(horizontalAngle);
                    newRay.RotateZ(verticalAngle);

                    rayLists[(int)(((i * resolution) + j) / ((resolution * resolution) / (float)rayListCount))].Add(newRay);
                }
            }

            //at this point direction is (1, 0, 0);
            //must rotate the vectors to assume the new direction
            float dirXAngle = (Direction.X) / (float)Math.Sqrt(Math.Pow(Direction.X, 2) + Math.Pow(Direction.Y, 2) + Math.Pow(Direction.Z, 2));
            Console.WriteLine(dirXAngle);
        }

        public Bitmap GetFrame () {
            Bitmap frame = new Bitmap(resolution, resolution);

            //Rays are placed in the list from top to bottom and each row left to right
            int offset = 0;
            foreach (List<Ray> list in rayLists) {
                for (int i = 0; i < list.Count; ++i) {
                    //i / resolution gets the row
                    //i % resolution gets the column
                    Ray temp = list[i];
                    frame.SetPixel(offset % resolution, offset / resolution, temp.RayColor);
                    ++offset;
                }
            }

            return frame;
        }

        public void Update (SynchronizedCollection<EnvironmentObject> objects, int mouseXDif, int mouseYDif) {
            if (mouseXDif != 0 || mouseYDif != 0) {
                updateDirection(mouseXDif, mouseYDif);
            }

            List<Thread> threads = new List<Thread>();

            int counter = 0;

            foreach (List<Ray> rayList in rayLists) {
                List<EnvironmentObject> tempList = new List<EnvironmentObject>();
                foreach (EnvironmentObject e in objects) {
                    tempList.Add(e);
                }
                threads.Add(new Thread(() => castRays(rayList, tempList, ref counter)));
            }

            foreach (Thread t in threads) {
                t.Start();
            }

            while (counter < rayListCount) { }
        }

        private void updateDirection (int mouseXDif, int mouseYDif) {
            //how to multithread this and actually have it be fast
            List<Thread> threads = new List<Thread>();

            float yAxisAngle = mouseXDif * sensitivity;
            float xAxisAngle = mouseYDif * -sensitivity;
            RotateDirY(yAxisAngle);
            TurretRotateDirX(xAxisAngle);

            foreach (List<Ray> list in rayLists) {
                //threads.Add(new Thread(() => {
                    foreach (Ray r in list) {
                        r.RotateY(yAxisAngle);
                        r.TurretRotateX(xAxisAngle);
                    }
                //}));
            }

            foreach (Thread t in threads) {
                t.Priority = ThreadPriority.Highest;
                t.Start();
            }
        }

        private void castRays (List<Ray> rays, List<EnvironmentObject> objects, ref int counter) {
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
            float angleFromZ = (float)Math.Acos(Vector3.Dot(Direction, new Vector3(0, 0, 1)));
            RotateDirY(-angleFromZ);
            RotateDirX(angle);
            RotateDirY(angleFromZ);
        }
    }
}
