using System.Collections.Generic;

namespace GameEngine {
    public class Mesh {
        public List<Triangle> Triangles;
        public List<GraphicsTriangle> GraphicsTriangles;

        public Mesh () {
            Triangles = new List<Triangle>();
            GraphicsTriangles = new List<GraphicsTriangle>();
        }

        public Mesh(List<Triangle> triangles) {
            Triangles = triangles;
            GraphicsTriangles = new List<GraphicsTriangle>();
            foreach (Triangle t in triangles) {
                GraphicsTriangles.Add(new GraphicsTriangle(t));
            }
        }

        public void AddTriangle(Triangle triangle) {
            Triangles.Add(triangle);
            GraphicsTriangles.Add(new GraphicsTriangle(triangle));
        }
    }
}
