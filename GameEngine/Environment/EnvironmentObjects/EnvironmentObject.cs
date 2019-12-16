using System.Drawing;

namespace GameEngine {
    public interface EnvironmentObject {
        float RayCollision (Ray r);
        Color GetColor ();
    }
}
