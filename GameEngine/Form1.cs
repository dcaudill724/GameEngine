using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameEngine {
    public partial class Form1 : Form {
        public Form1 () {
            InitializeComponent();
        }

        private void Form1_Load (object sender, EventArgs e) {
            Thread evironmentThread = new Thread(() => Environment.Start());
            evironmentThread.Start();
        }

        private void CameraView_Click (object sender, EventArgs e) {
            string button = (e as MouseEventArgs).Button.ToString();
            if (button == "Left") {
                Environment.EnableCameraMode();
            } else if (button == "Right") {
                Environment.DisableCameraMode();
            }
        }
    }
}
