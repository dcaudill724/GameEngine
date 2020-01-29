using System;
using System.Windows.Forms;

namespace GameEngine {
    public partial class EnvironmentControl : UserControl {
        public EnvironmentControl () {
            InitializeComponent();
        }

        private void NewCameraButton_Click (object sender, EventArgs e) {
            Form addCamera = new AddCamera(this);
            addCamera.Show();
        }

        public void AddCamera(Camera c) {
            Environment.Cameras.Add(c);
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
                Environment.ActiveCamera = null;
            }
        }

        private void EnvironmentControl_Resize (object sender, EventArgs e) {
            //CamerasGroupBox.Height = Convert.ToInt32(Parent.Height * 0.5);
            //EnvironmentObjectsGroupBox.Height = Convert.ToInt32(Parent.Height * 0.5);
        }

        private void AddObjectButton_Click (object sender, EventArgs e) {
            AddObject newAddObject = new AddObject();
            newAddObject.Show();
        }

        public void SetCameraViewSize(Camera camera) {
            ((Parent as Form1).Controls["CameraView"] as GraphicsDisplay).SetActiveCamera(camera);
        }
    }
}
