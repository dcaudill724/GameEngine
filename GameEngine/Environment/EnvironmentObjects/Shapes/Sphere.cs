using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace GameEngine {
    class Sphere : EnvironmentObject {
        private float radius;
        private Color color;

        #region Init Functions

        public Sphere(int x, int y, int z, float radius, Color color, int resolution) {
            Position = new Vector3(x, y, z);
            this.radius = radius;
            this.color = color;
            generateMesh(resolution);
        }
        public Sphere(Vector3 position, float radius, Color color, int resolution) {
            this.Position = position;
            this.radius = radius;
            this.color = color;
            generateMesh(resolution);
        }

        private void generateMesh(int resolution) {
            Vector3[] points = new Vector3[8];
            points[0] = new Vector3(1, 1, 1);
            points[1] = new Vector3(1, 1, -1);
            points[2] = new Vector3(1, -1, 1);
            points[3] = new Vector3(1, -1, -1);
            points[4] = new Vector3(-1, 1, 1);
            points[5] = new Vector3(-1, 1, -1);
            points[6] = new Vector3(-1, -1, 1);
            points[7] = new Vector3(-1, -1, -1);

            //faces are generated in a clockwise manner
            Vector3[,] faces = {
                { points[1], points[0], points[2], points[3] }, //right common X
                { points[4], points[0], points[1], points[5] }, //top common y
                { points[0], points[4], points[6], points[2] }, //back common z
                { points[4], points[5], points[7], points[6] }, //left common x
                { points[7], points[6], points[2], points[3] },  //bottom common y
                { points[5], points[1], points[3], points[7] } //front common z
            };

            //generate the newly divided squares
            Vector3[,] newFacePoints = new Vector3[resolution, resolution];

            for (int i = 0; i < faces.GetLength(0); ++i) {
                
                Vector3 horizontalIncrement = (faces[i, 1] - faces[i, 0]) / (resolution - 1);
                Vector3 verticalIncrement = (faces[i, 3] - faces[i, 0]) / (resolution - 1);

                for (int j = 0; j < resolution; ++j) { //vertical
                    Vector3 tempVerticalPoint = j * verticalIncrement;

                    for (int k = 0; k < resolution; k++) { //horizontal
                        Vector3 tempHorizontalPoint = k * horizontalIncrement;

                        newFacePoints[k, j] = (Vector3.Normalize(faces[i, 0] + tempVerticalPoint + tempHorizontalPoint) * radius) + Position;
                    }
                }
            }

            List<Triangle> meshTriangles = new List<Triangle>();

            //for each point, generate both the triangles in the square that it (the point) is in the top left of
            for (int j = 0; j < resolution - 1; ++j) { //vertical
                for (int k = 0; k < resolution - 1; ++k) { //horizontal
                    meshTriangles.Add(new Triangle(newFacePoints[k, j], newFacePoints[k + 1, j], newFacePoints[k, j + 1], color));
                    meshTriangles.Add(new Triangle(newFacePoints[k, j + 1], newFacePoints[k + 1, j], newFacePoints[k + 1, j + 1], color));
                }
            }

            Mesh = new Mesh(meshTriangles);
        }

        #endregion

        #region EnvironmentObject Functions

        public override void Update (Vector3 direction) {
            Position += direction;
            Mesh.Update(direction);
            return;
        }
        public override float RayCollision (Ray r) {
            Vector3 oc = Vector3.Subtract(r.Position, Position);
            float a = Vector3.Dot(r.Direction, r.Direction);
            float b = 2.0f * Vector3.Dot(oc, r.Direction);
            float c = Vector3.Dot(oc, oc) - radius * radius;
            float discriminant = b * b - 4 * a * c;
            if (discriminant < 0) {
                return -1.0f;
            } else {
                float numerator = -b - (float)Math.Sqrt(discriminant);
                if (numerator > 0.0) {
                    return numerator / (2.0f * a);
                }
                numerator = -b + (float)Math.Sqrt(discriminant);
                if (numerator > 0.0) {
                    return numerator / (2.0f * a);
                } else {
                    return -1.0f;
                }
            }
        }

        public override Color GetColor() {
            return color;
        }

        public override Vector3 GetSupportPoint(Vector3 direction) {
            Vector3 relativePoint = Vector3.Normalize(direction) * radius;
            Vector3 supportPoint = relativePoint + Position;
            return supportPoint;
        }

        public override Vector3 GetCenter() {
            return Position;
        }

        #endregion
    }
}
