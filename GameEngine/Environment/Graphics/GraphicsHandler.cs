using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameEngine {
    class GraphicsHandler {
        private PictureBox cameraView;

        public GraphicsHandler (PictureBox cameraView) {
            this.cameraView = cameraView;
        }

        public void Update(Camera activeCamera, List<EnvironmentObject> objects, int mouseXDif, int mouseYDif) {
            activeCamera.Update(objects, mouseXDif, mouseYDif);
            Frame temp = activeCamera.GetFrame();
            cameraView.BackgroundImage = temp.Image;
            //cameraView.Invalidate();
            cameraView.Update();
        }
    }
}
