using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameEngine {
    static class Environment {
        private static GraphicsHandler graphicsHandler;
        private static SynchronizedCollection<EnvironmentObject> environmentObjects;
        private static List<Camera> cameras;
        private static Camera activeCamera;
        private static bool cameraMode;
        private static Point mousePoint;
        

        public static void Start() {
            initGraphics();
            initEnvironment();
            Thread graphicsThread = new Thread(new ThreadStart(updateGraphics));
            graphicsThread.Start();
        }

        #region init functions
        private static void initGraphics() {
            graphicsHandler = new GraphicsHandler();
            cameraMode = false;
            cameras = new List<Camera>();
            activeCamera = new RaytracingCamera(new Vector3(0, 0, 0), new Vector3(0, 1, 0), (float)(Math.PI / 2), 0.95f, 0.01f, 100);
            cameras.Add(activeCamera);
        }

        private static void initEnvironment() {
            environmentObjects = new SynchronizedCollection<EnvironmentObject>();
            environmentObjects.Add(new Sphere(100, 0, 0, 10, Color.Red));
        }
        #endregion

        private static void updateGraphics() {
            while (true) {
                if (cameraMode) {
                    int x = Cursor.Position.X - mousePoint.X;
                    int y = Cursor.Position.Y - mousePoint.Y;
                    Cursor.Position = mousePoint;
                    graphicsHandler.Update(activeCamera, environmentObjects, x, y);
                } else {
                    graphicsHandler.Update(activeCamera, environmentObjects, 0, 0);
                }
            }
        }

        public static void EnableCameraMode() {
            Cursor.Hide();
            mousePoint = Cursor.Position;
            cameraMode = true;
        }

        public static void DisableCameraMode() {
            Cursor.Show();
            cameraMode = false;
        }
    }
}
