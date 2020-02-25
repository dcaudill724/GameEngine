using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace GameEngine {
    public static class InputManager {
        private static List<Key> previousKeyboardState;
        private static readonly byte[] distinctVirtualKeys = Enumerable
            .Range(0, 256)
            .Select(KeyInterop.KeyFromVirtualKey)
            .Where(item => item != Key.None)
            .Distinct()
            .Select(item => (byte)KeyInterop.VirtualKeyFromKey(item))
            .ToArray();

        public static void Init() {
            previousKeyboardState = new List<Key>();
        }

        public static void ReportInput() {
            reportKeyboardState();
        }

        private static void reportKeyboardState() {
            byte[] keyboardStateBuffer = new byte[256];
            GetKeyboardState(keyboardStateBuffer);

            List<Key> keysPressed = new List<Key>();

            for (int i = 0; i < distinctVirtualKeys.Length; ++i) {
                byte virtualKey = distinctVirtualKeys[i];
                if ((keyboardStateBuffer[virtualKey] & 0x80) != 0) {
                    keysPressed.Add(KeyInterop.KeyFromVirtualKey(virtualKey));
                }
            }

            //must report keyUp or keyDown

            //reports keyDown
            foreach (Key k in keysPressed) {
                if (!previousKeyboardState.Contains(k)) {
                    Message keyDown = new Message(MessageType.KeyDown, k);
                    MessageManager.SendMessage(keyDown);
                }
            }

            //reports keyUp 
            foreach (Key k in previousKeyboardState) {
                if (!keysPressed.Contains(k)) {
                    Message keyUp = new Message(MessageType.KeyUp, k);
                    MessageManager.SendMessage(keyUp);
                }
            }

            previousKeyboardState = new List<Key>(keysPressed);
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetKeyboardState (byte[] lpKeyState);
    }
}
