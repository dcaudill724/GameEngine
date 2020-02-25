using System.Collections.Generic;
using System.Numerics;

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

        public void Update(Vector3 direction) {
            for (int i = 0; i < Triangles.Count; ++i) {
                Triangles[i].Update(direction);
                GraphicsTriangles[i].Update(direction);
            }
        }
    }
}
