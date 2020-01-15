using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameEngine {
    class GraphicsHandler {
        public Bitmap Frame;

        public GraphicsHandler () {
        }

        public void Update(Camera activeCamera, List<EnvironmentObject> objects, int mouseXDif, int mouseYDif) {
            activeCamera.Update(objects, mouseXDif, mouseYDif);
            if (Frame != null) {
                Frame.Dispose();
            }
            Frame = activeCamera.GetFrame();
            //cameraView.Refresh();
        }
    }
}
