using System.Collections.Generic;
using System.Numerics;
using System.Windows.Input;

namespace GameEngine {
    class GraphicsHandler {
        private GraphicsDisplay cameraView;

        public GraphicsHandler (GraphicsDisplay cameraView) {
            this.cameraView = cameraView;
        }

        public void Update(Camera activeCamera, List<EnvironmentObject> objects, int mouseXDif, int mouseYDif) {
            Vector3 tempCameraMoveDirection = new Vector3();

            activeCamera.Update(objects, mouseXDif, mouseYDif, tempCameraMoveDirection);
            Frame temp = activeCamera.GetFrame();
            if (cameraView.Ready) {
                cameraView.CurrentFrame = temp.Copy();
            }
        }
    }
}
