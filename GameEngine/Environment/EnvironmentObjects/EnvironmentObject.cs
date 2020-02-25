using System.Drawing;
using System.Numerics;

namespace GameEngine {
    public abstract class EnvironmentObject : MessageReceiver {
        public Mesh Mesh;
        public Vector3 Position;

        public abstract void Update (Vector3 direction);
        public abstract float RayCollision (Ray r);
        public abstract Color GetColor ();
        public abstract Vector3 GetSupportPoint (Vector3 direction);
        public abstract Vector3 GetCenter ();
    }
}
