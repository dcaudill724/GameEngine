using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Threading;
using System.Windows.Forms;

namespace GameEngine {
    static class Environment {
        public static List<Camera> Cameras;

        private static GraphicsHandler graphicsHandler;
        public static List<EnvironmentObject> EnvironmentObjects;
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
            Cameras = new List<Camera>();
        }

        private static void initEnvironment() {
            EnvironmentObjects = new List<EnvironmentObject>();
            EnvironmentObjects.Add(new Cube(new Vector3(0, 0, 1.3f), new Vector3(1, 1, 1), Color.White));
            //EnvironmentObjects.Add(new Sphere(0, 0, 20, 10, Color.Red, 40));
        }
        #endregion

        private static void updateGraphics() {
            while (true) {
                int frameCount = FrameCounter.GetFPS();
                if (frameCount != -1) {
                    Console.WriteLine(frameCount);
                }
                if (cameraMode) {
                    int x = Cursor.Position.X - mousePoint.X;
                    int y = Cursor.Position.Y - mousePoint.Y;
                    Cursor.Position = mousePoint;
                    if (activeCamera != null) {
                        graphicsHandler.Update(activeCamera, EnvironmentObjects, x, y);
                    }
                } else {
                    if (activeCamera != null) {
                        graphicsHandler.Update(activeCamera, EnvironmentObjects, 0, 0);
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
        
        public static void AddCamera(Camera c) {
            Cameras.Add(c);
            activeCamera = c;
        }

        public static void SetActiveCamera (Camera c) {
            activeCamera = c;
        }

        public static void SelectCamera (int index) {
            if (index != -1) {
                activeCamera = Cameras[index];
            } else {
                
            }
        }
    }
}
