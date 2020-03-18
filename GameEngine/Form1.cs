using System;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace GameEngine {
    public partial class Form1 : Form {
        public Form1 () {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load (object sender, EventArgs e) {
            IKeyboardMouseEvents globalHook = Hook.GlobalEvents();
            InputManager.Init(ref globalHook);

            Thread environmentThread = new Thread(() => Environment.Start(CameraView));
            environmentThread.Start();
        }

        private void Form1_SizeChanged (object sender, EventArgs e) {
            if (Environment.ActiveCamera != null) {
                CameraView.SetActiveCamera(Environment.ActiveCamera);
            }
        }

        private void CameraView_Click_1 (object sender, EventArgs e) {
            if ((e as System.Windows.Forms.MouseEventArgs).Button == MouseButtons.Right) {
                Select();
                Focus();
                Environment.ToggleCameraMode();
            }
        }
    }
}
