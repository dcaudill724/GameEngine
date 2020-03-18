using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace GameEngine {
    public static class InputManager {

        public static void Init(ref IKeyboardMouseEvents globalHook) {
            globalHook = Hook.GlobalEvents();

            globalHook.KeyDown += reportKeyDown;
            globalHook.KeyUp += reportKeyUp;
        }

        public static void ReportInput() {
        }

        private static void reportKeyDown(object sender, KeyEventArgs e) {
            Message m = new Message(MessageType.KeyDown, e.KeyCode);
            MessageManager.SendMessage(m);
        }

        private static void reportKeyUp(object sender, KeyEventArgs e) {
            Message m = new Message(MessageType.KeyUp, e.KeyCode);
            MessageManager.SendMessage(m);
        }
    }
}
