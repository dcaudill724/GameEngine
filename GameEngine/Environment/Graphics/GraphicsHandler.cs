using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameEngine {
    class GraphicsHandler {
        private PictureBox cameraView;

        public GraphicsHandler () {
            cameraView = Application.OpenForms["Form1"].Controls["CameraView"] as PictureBox;
        }

        public void Update(Camera activeCamera, List<EnvironmentObject> objects, int mouseXDif, int mouseYDif) {
            activeCamera.Update(objects, mouseXDif, mouseYDif);
            cameraView.BackgroundImage = resizeImageToScreen(activeCamera.GetFrame());
        }

        private Bitmap resizeImageToScreen(Bitmap image) {
            return new Bitmap(image, new Size(cameraView.Width, cameraView.Height));
        }
    }
}
