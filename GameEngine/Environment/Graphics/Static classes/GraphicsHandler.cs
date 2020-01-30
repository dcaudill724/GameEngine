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
            Vector3 tempCameraMoveDirection = new Vector3(); //Change this stuff to a input manager and message system
            if (Keyboard.IsKeyDown(Key.W)) {
                tempCameraMoveDirection.X += 0.0001f;
            }
            if (Keyboard.IsKeyDown(Key.S)) {
                tempCameraMoveDirection.X -= 0.0001f;
            }
            if (Keyboard.IsKeyDown(Key.LeftShift)) {
                tempCameraMoveDirection.Y += 0.0001f;
            }
            if (Keyboard.IsKeyDown(Key.Space)) {
                tempCameraMoveDirection.Y -= 0.0001f;
            }
            if (Keyboard.IsKeyDown(Key.D)) {
                tempCameraMoveDirection.Z += 0.0001f;
            }
            if (Keyboard.IsKeyDown(Key.A)) {
                tempCameraMoveDirection.Z -= 0.0001f;
            }

            activeCamera.Update(objects, mouseXDif, mouseYDif, tempCameraMoveDirection);
            Frame temp = activeCamera.GetFrame();
            if (cameraView.Ready) {
                cameraView.CurrentFrame = temp.Copy();
            }
        }
    }
}
