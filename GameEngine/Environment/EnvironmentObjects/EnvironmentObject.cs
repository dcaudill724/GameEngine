using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine {
    interface EnvironmentObject {
        float RayCollision (Ray r);
        Color GetColor ();
    }
}
