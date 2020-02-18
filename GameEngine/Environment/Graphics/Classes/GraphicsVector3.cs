using System.Numerics;

namespace GameEngine {
    public class GraphicsVector3 {
        public Vector3 Value;
        public float W;

        public GraphicsVector3() {
            Value = new Vector3(0, 0, 0);
            W = 1;
        }

        public GraphicsVector3(Vector3 vector) {
            Value = vector;
            W = 1;
        }

        public GraphicsVector3(Vector3 vector, float w) {
            Value = vector;
            W = w;
        }

        public GraphicsVector3(GraphicsVector3 original) {
            Value = original.Value;
            W = original.W;
        }

        public static GraphicsVector3 Cross(GraphicsVector3 vec1, GraphicsVector3 vec2) {
            return new GraphicsVector3(Vector3.Cross(vec1.Value, vec2.Value));
        }

        public static float Dot(GraphicsVector3 vec1, GraphicsVector3 vec2) {
            return Vector3.Dot(vec1.Value, vec2.Value);
        }

        public static float Dot(Vector3 vec1, GraphicsVector3 vec2) {
            return Vector3.Dot(vec1, vec2.Value);
        }

        public static GraphicsVector3 Transform(GraphicsVector3 vec1, Matrix4x4 matrix) {
            GraphicsVector3 v = new GraphicsVector3(Vector3.Transform(vec1.Value, matrix));
            v.Value += new Vector3(vec1.W * matrix.M14, vec1.W * matrix.M24, vec1.W * matrix.M34);
            v.W = vec1.Value.X * matrix.M14 + vec1.Value.Y * matrix.M24 + vec1.Value.Z * matrix.M34 + vec1.Value.Z * matrix.M44;
            return v;
        }

        public static GraphicsVector3 operator- (GraphicsVector3 vec1, GraphicsVector3 vec2) {
            return new GraphicsVector3(vec1.Value - vec2.Value, vec1.W);
        }

        public static GraphicsVector3 operator- (Vector3 vec1, GraphicsVector3 vec2) {
            return new GraphicsVector3(vec1 - vec2.Value, vec2.W);
        }

        public static GraphicsVector3 operator - (GraphicsVector3 vec1, Vector3 vec2) {
            return new GraphicsVector3(vec1.Value - vec2, vec1.W);
        }
    }
}
