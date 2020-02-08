using System.Drawing;
using System.Numerics;

namespace GameEngine {
    public class Triangle {
        public Vector3[] Points;
        public Vector3 Normal;
        public Color Color;

        public Triangle (Vector3 point1, Vector3 point2, Vector3 point3, Color color) {
            Points = new Vector3[3];
            Points[0] = point1;
            Points[1] = point2;
            Points[2] = point3;
            generateNormal();
            Color = color;
        }

        public Triangle (Vector3 point1, Vector3 point2, Vector3 point3, Vector3 normal, Color color) {
            Points = new Vector3[3];
            Points[0] = point1;
            Points[1] = point2;
            Points[2] = point3;
            Normal = normal;
            Color = color;
        }

        public Triangle (Vector3[] points, Color color) {
            Points = points;
            generateNormal();
            Color = color;
        }

        public Triangle() {
            Points = new Vector3[3];
            Normal = new Vector3(0, 0, 0);
            Color = Color.Black;
        }

        private void generateNormal() {
            Normal = Vector3.Cross(Points[1] - Points[0], Points[2] - Points[0]);
            Normal = Vector3.Normalize(Normal);
        }
        
        public Triangle Copy() {
            return new Triangle(Points[0], Points[1], Points[2], Normal, Color);
        }

        public void TransformMatrix4x4(Matrix4x4 matrix) {
            for (int i = 0; i < 3; ++i) {
                Points[i] = Vector3.Transform(Points[i], matrix);
            }
        }
    }
}
