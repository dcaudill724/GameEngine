using System.Drawing;
using System.Numerics;

namespace GameEngine {
    public class GraphicsTriangle {
        public GraphicsVector3[] Points;
        public TextureVector[] TexturePoints;
        public Vector3 Normal;
        public Color Color;

        #region Constructors

        public GraphicsTriangle (GraphicsVector3 point1, GraphicsVector3 point2, GraphicsVector3 point3, Color color) {
            Points = new GraphicsVector3[3];
            TexturePoints = new TextureVector[3];
            Points[0] = point1;
            Points[1] = point2;
            Points[2] = point3;
            generateNormal();
            Color = color;
        }

        public GraphicsTriangle (GraphicsVector3 point1, GraphicsVector3 point2, GraphicsVector3 point3, Vector3 normal, Color color) {
            Points = new GraphicsVector3[3];
            TexturePoints = new TextureVector[3];
            Points[0] = point1;
            Points[1] = point2;
            Points[2] = point3;
            Normal = normal;
            Color = color;
        }

        public GraphicsTriangle (GraphicsVector3[] points, Color color) {
            Points = points;
            TexturePoints = new TextureVector[3];
            generateNormal();
            Color = color;
        }

        public GraphicsTriangle(Triangle triangle) {
            Points = new GraphicsVector3[3];
            TexturePoints = new TextureVector[3];
            for (int i = 0; i < 3; ++i) {
                Points[i] = new GraphicsVector3(triangle.Points[i]);
                TexturePoints[i] = new TextureVector();
            }
            Normal = triangle.Normal;
            Color = triangle.Color;
        }

        public GraphicsTriangle (GraphicsVector3 point1, GraphicsVector3 point2, GraphicsVector3 point3, TextureVector texturePoint1, TextureVector texturePoint2, TextureVector texturePoint3, Color color) {
            Points = new GraphicsVector3[3];
            Points[0] = point1;
            Points[1] = point2;
            Points[2] = point3;
            TexturePoints = new TextureVector[3];
            TexturePoints[0] = texturePoint1;
            TexturePoints[1] = texturePoint2;
            TexturePoints[2] = texturePoint3;
            generateNormal();
            Color = color;
        }

        public GraphicsTriangle (GraphicsVector3 point1, GraphicsVector3 point2, GraphicsVector3 point3, TextureVector texturePoint1, TextureVector texturePoint2, TextureVector texturePoint3, Vector3 normal, Color color) {
            Points = new GraphicsVector3[3];
            Points[0] = point1;
            Points[1] = point2;
            Points[2] = point3;
            TexturePoints = new TextureVector[3];
            TexturePoints[0] = texturePoint1;
            TexturePoints[1] = texturePoint2;
            TexturePoints[2] = texturePoint3;
            Normal = normal;
            Color = color;
        }

        public GraphicsTriangle (GraphicsVector3[] points, TextureVector[] texturePoints, Color color) {
            Points = points;
            TexturePoints = texturePoints;
            generateNormal();
            Color = color;
        }

        public GraphicsTriangle (GraphicsVector3[] points, TextureVector[] texturePoints, Vector3 normal, Color color) {
            Points = points;
            Normal = normal;
            TexturePoints = texturePoints;
            Color = color;
        }

        public GraphicsTriangle (Triangle triangle, TextureVector[] texturePoints) {
            Points = new GraphicsVector3[3];
            TexturePoints = texturePoints;
            for (int i = 0; i < 3; ++i) {
                Points[i] = new GraphicsVector3(triangle.Points[i]);
            }
            Normal = triangle.Normal;
            Color = triangle.Color;
        }

        public GraphicsTriangle () {
            Points = new GraphicsVector3[3];
            TexturePoints = new TextureVector[3];
            Normal = new Vector3(0, 0, 0);
            Color = Color.Black;
        }

        #endregion

        private void generateNormal () {
            Normal = GraphicsVector3.Cross(Points[1] - Points[0], Points[2] - Points[0]).Value;
            Normal = Vector3.Normalize(Normal);
        }

        public GraphicsTriangle Copy () {
            GraphicsVector3[] newPoints = new GraphicsVector3[3];
            TextureVector[] newTexturePoints = new TextureVector[3];

            for (int i = 0; i < 3; ++i) {
                newPoints[i] = new GraphicsVector3(Points[i]);
                newTexturePoints[i] = new TextureVector(TexturePoints[i]);
            }

            return new GraphicsTriangle(newPoints, newTexturePoints, Normal, Color);
        }

        public void TransformMatrix4x4 (Matrix4x4 matrix) {
            for (int i = 0; i < 3; ++i) {
                Points[i] = GraphicsVector3.Transform(Points[i], matrix);
            }
        }

        public void Update(Vector3 direction) {
            foreach (GraphicsVector3 v in Points) {
                v.Value += direction;
            }
        }
    }
}
