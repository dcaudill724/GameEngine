using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace GameEngine {
    public abstract class Camera {
        public string Name;
        public Vector3 Position;
        public Vector3 Direction;
        public float sensitivity;
        public float HorizontalFOV;
        public float VerticalFOV;
        public float AngleFromZ;
        public float FrameWidth;
        public float FrameHeight;

        public abstract void Update (List<EnvironmentObject> objects, int mouseXDif, int mouseYDif, Vector3 direction);
        public abstract Frame GetFrame ();

        public abstract void Dispose ();
    }
}
