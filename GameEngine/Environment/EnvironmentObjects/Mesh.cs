using System.Collections.Generic;

namespace GameEngine {
    public class Mesh {
        public List<Triangle> Triangles;

        public Mesh () { }

        public Mesh(List<Triangle> triangles) {
            this.Triangles = triangles;
        }

        public void AddTriangle(Triangle triangle) {
            Triangles.Add(triangle);
        }
    }
}
