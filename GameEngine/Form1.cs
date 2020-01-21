using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GameEngine {
    public partial class Form1 : Form {
        public Form1 () {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load (object sender, EventArgs e) {
            System.Windows.Forms.Timer fpsTimer = new System.Windows.Forms.Timer();
            fpsTimer.Interval = 500;
            fpsTimer.Tick += new EventHandler(UpdateFpsLabel);
            fpsTimer.Enabled = true;


            Label fpsLabel = new Label {
                Location = new Point(3, 3),
                Name = "FpsLabel",
                ForeColor = Color.Red
            };

            CameraViewPictureBox.Controls.Add(fpsLabel);
            Thread environmentThread = new Thread(() => Environment.Start(CameraViewPictureBox));
            environmentThread.Start();
        }

        private void CameraView_Click (object sender, EventArgs e) {
            string button = (e as MouseEventArgs).Button.ToString();
            if (button == "Left") {
                Environment.EnableCameraMode();
            } else if (button == "Right") {
                Environment.DisableCameraMode();
            }
        }

        public void SetCameraViewSize (Camera camera) {
            float viewAspectRatio = (float)CameraViewPanel.Height / (float)CameraViewPanel.Width;
            float aspectRatio = camera.FrameHeight / camera.FrameWidth;
            if (aspectRatio > viewAspectRatio) {
                CameraViewPictureBox.Height = CameraViewPanel.Height;
                CameraViewPictureBox.Width = (int)(CameraViewPanel.Height * (1 / aspectRatio));
            } else if (aspectRatio < viewAspectRatio) {
                CameraViewPictureBox.Width = CameraViewPanel.Width;
                CameraViewPictureBox.Height = (int)(CameraViewPanel.Width * (aspectRatio));
            } else {
                CameraViewPictureBox.Width = CameraViewPanel.Width;
                CameraViewPictureBox.Height = CameraViewPanel.Height;
            }

            CameraViewPictureBox.Location = new Point((CameraViewPanel.Width / 2) - (CameraViewPictureBox.Width / 2), (CameraViewPanel.Height / 2) - (CameraViewPictureBox.Height / 2));
        }

        private void CameraViewPanel_SizeChanged (object sender, EventArgs e) {
            if (Environment.ActiveCamera != null) {
                SetCameraViewSize(Environment.ActiveCamera);
            }
        }

        private void UpdateFpsLabel (object sender, EventArgs e) {
            CameraViewPictureBox.Controls["FpsLabel"].Text = "Fps: " + Environment.FPS;
        }
    }
}
