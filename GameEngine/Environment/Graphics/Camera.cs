using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine {
    interface Camera {
        void Update(SynchronizedCollection<EnvironmentObject> objects, int mouseXDif, int mouseYDif);
        Bitmap GetFrame();
    }
}
