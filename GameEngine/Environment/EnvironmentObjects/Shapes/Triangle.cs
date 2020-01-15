using System.Numerics;

namespace GameEngine {
    public class Triangle {
        public Vector3[] Points;
        public Vector3 Normal;

        public Triangle (Vector3 point1, Vector3 point2, Vector3 point3) {
            Points = new Vector3[3];
            Points[0] = point1;
            Points[1] = point2;
            Points[2] = point3;
            generateNormal();
        }

        public Triangle (Vector3 point1, Vector3 point2, Vector3 point3, Vector3 normal) {
            Points = new Vector3[3];
            Points[0] = point1;
            Points[1] = point2;
            Points[2] = point3;
            Normal = normal;
        }

        private void generateNormal() {
            Normal = Vector3.Cross(Points[1] - Points[0], Points[2] - Points[0]);
        }
        
        public Triangle Copy() {
            return new Triangle(Points[0], Points[1], Points[2]);
        }
    }
}
