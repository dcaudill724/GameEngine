using System;

namespace GameEngine {
    static class FrameCounter {
        private static DateTime lastTime;
        private static int frameCounter;

        public static void Init() {
            lastTime = DateTime.Now;
            frameCounter = 0;
        }

        public static int GetFPS() {
            if ((DateTime.Now - lastTime).TotalSeconds >= 0.5) {
                int fps = frameCounter * 2;
                frameCounter = 0;
                lastTime = DateTime.Now;
                Console.WriteLine(fps);
                return fps;
            } else {
                ++frameCounter;
                return -1;
            }
        }
    }
}
