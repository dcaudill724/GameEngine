using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace GameEngine {
    class RayPyramid {
        private Vector3[] points;
        public List<Ray> RayList;

        public RayPyramid (Vector3 origin, Vector3 point1, Vector3 point2, Vector3 point3, Vector3 point4) {
            points = new Vector3[5];
            points[0] = origin;
            points[1] = point1;
            points[2] = point2;
            points[3] = point3;
            points[4] = point4;
            RayList = new List<Ray>();
        }

        public Color[] GetRayColors () {
            Color[] temp = new Color[RayList.Count];
            for (int i = 0; i < temp.Length; ++i) {
                temp[i] = RayList[i].RayColor;
            }
            return temp;
        }

        public void SetColor(Color c) {
            foreach (Ray r in RayList) {
                r.RayColor = c;
            }
        } 

        public Vector3 GetSupportingPoint (Vector3 direction) {
            float furthestDistance = float.NegativeInfinity;
            Vector3 furthestVertex = new Vector3(0, 0, 0);

            foreach (Vector3 v in points) {
                float distance = Vector3.Dot(v, direction);
                if (distance > furthestDistance) {
                    furthestDistance = distance;
                    furthestVertex = v;
                }
            }

            return furthestVertex;
        }

        public Vector3 GetCenter () {
            Vector3 sum = new Vector3(0, 0, 0);

            foreach (Vector3 v in points) {
                sum += v;
            }

            return sum / points.Length;
        }

        public void RotateX (float angle) {
            for (int i = 0; i < points.Length; ++i) {
                points[i] = rotateVector3X(points[i], angle);
            }
        }

        public void RotateY (float angle) {
            for (int i = 0; i < points.Length; ++i) {
                points[i] = rotateVector3Y(points[i], angle);
            }
        }
        public void RotateZ (float angle) {
            for (int i = 0; i < points.Length; ++i) {
                points[i] = rotateVector3Z(points[i], angle);
            }
        }
        public void TurretRotateX (float angle, float angleFromZ) {
            for (int i = 0; i < points.Length; ++i) {
                points[i] = turretRotateVector3X(points[i], angle, angleFromZ);
            }
        }

        private Vector3 rotateVector3X (Vector3 vector, float angle) {
            float y = (float)(vector.Y * Math.Cos(angle) - vector.Z * Math.Sin(angle));
            float z = (float)(vector.Y * Math.Sin(angle) + vector.Z * Math.Cos(angle));
            return new Vector3(vector.X, y, z);
        }

        private Vector3 rotateVector3Y (Vector3 vector, float angle) {
            float x = (float)(vector.X * Math.Cos(angle) + vector.Z * Math.Sin(angle));
            float z = (float)(-vector.X * Math.Sin(angle) + vector.Z * Math.Cos(angle));
            return new Vector3(x, vector.Y, z);
        }

        private Vector3 rotateVector3Z (Vector3 vector, float angle) {
            float x = (float)(vector.X * Math.Cos(angle) - vector.Y * Math.Sin(angle));
            float y = (float)(vector.X * Math.Sin(angle) + vector.Y * Math.Cos(angle));
            return new Vector3(x, y, vector.Z);
        }

        private Vector3 turretRotateVector3X (Vector3 vector, float angle, float angleFromZ) {
            vector = rotateVector3Y(vector, -angleFromZ);
            vector = rotateVector3X(vector, angle);
            vector = rotateVector3Y(vector, angleFromZ);
            return vector;
        }
    }
}
