using System;
using System.Windows.Forms;

namespace GameEngine {
    public partial class EnvironmentControl : UserControl {
        public EnvironmentControl () {
            InitializeComponent();
        }

        private void NewObjectButton_Click (object sender, EventArgs e) {

        }

        private void NewCameraButton_Click (object sender, EventArgs e) {
            Form addCamera = new AddCamera(this);
            addCamera.Show();
        }

        public void AddCamera(Camera c) {
            Environment.AddCamera(c);
            CameraListItem newCamera = new CameraListItem(c, CameraListFlowPanel);
            CameraListFlowPanel.Controls.Add(newCamera);
            newCamera.SetActive();
        }

        private void AddCameraButton_Click (object sender, EventArgs e) {
            AddCamera newCameraForm = new AddCamera(this);
            newCameraForm.Show();
        }

        private void CameraListFlowPanel_ControlRemoved (object sender, ControlEventArgs e) {
            if (CameraListFlowPanel.Controls.Count > 0) {
                (CameraListFlowPanel.Controls[0] as CameraListItem).SetActive();
            } else {
                Environment.SetActiveCamera(null);
            }
        }
    }
}
