using System.Collections.Generic;

namespace GameEngine {
    class GraphicsHandler {
        private GraphicsDisplay cameraView;

        public GraphicsHandler (GraphicsDisplay cameraView) {
            this.cameraView = cameraView;
        }

        public void Update(Camera activeCamera, List<EnvironmentObject> objects, int mouseXDif, int mouseYDif) {
            activeCamera.Update(objects, mouseXDif, mouseYDif);
            Frame temp = activeCamera.GetFrame();
            if (cameraView.Ready) {
                cameraView.CurrentFrame = temp.Copy();
            }
        }
    }
}
