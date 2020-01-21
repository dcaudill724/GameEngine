using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Threading;
using System.Windows.Forms;

namespace GameEngine {
    static class Environment {
        public static int FPS;
        public static List<Camera> Cameras;
        public static List<EnvironmentObject> EnvironmentObjects;
        public static Camera ActiveCamera;

        private static GraphicsHandler graphicsHandler;
        private static bool cameraMode;
        private static Point mousePoint;


        public static void Start (PictureBox cameraView) {
            initGraphics(cameraView);
            initEnvironment();
            Thread graphicsThread = new Thread(new ThreadStart(updateGraphics));
            graphicsThread.Start();
        }

        #region init functions
        private static void initGraphics(PictureBox cameraView) {
            graphicsHandler = new GraphicsHandler(cameraView);
            cameraMode = false;
            Cameras = new List<Camera>();
        }

        private static void initEnvironment() {
            EnvironmentObjects = new List<EnvironmentObject>();
            EnvironmentObjects.Add(new Cube(new Vector3(10, 0, 0), new Vector3(3, 3, 3), Color.White));
            //EnvironmentObjects.Add(new Sphere(20, 0, 0, 5, Color.Red, 5));
        }
        #endregion

        private static void updateGraphics() {
            while (true) {
                int frameCount = FrameCounter.GetFPS();
                if (frameCount != -1) {
                    FPS = frameCount;
                }
                if (cameraMode) {
                    int x = Cursor.Position.X - mousePoint.X;
                    int y = Cursor.Position.Y - mousePoint.Y;
                    Cursor.Position = mousePoint;
                    if (ActiveCamera != null) {
                        graphicsHandler.Update(ActiveCamera, EnvironmentObjects, x, y);
                    }
                } else {
                    if (ActiveCamera != null) {
                        graphicsHandler.Update(ActiveCamera, EnvironmentObjects, 0, 0);
                    }
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
