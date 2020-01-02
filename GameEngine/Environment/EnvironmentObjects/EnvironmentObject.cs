using System.Drawing;
using System.Numerics;

namespace GameEngine {
    public abstract class EnvironmentObject {
        public Mesh Mesh;
        public Vector3 Position;

        public abstract float RayCollision (Ray r);
        public abstract Color GetColor ();
        public abstract Vector3 GetSupportPoint (Vector3 direction);
        public abstract Vector3 GetCenter ();
    }
}
