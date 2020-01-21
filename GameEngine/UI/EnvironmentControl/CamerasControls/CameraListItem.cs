using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameEngine {
    public partial class CameraListItem : UserControl {
        private Camera camera;

        public CameraListItem (Camera camera, Control Parent) {
            this.camera = camera;
            InitializeComponent();
            CameraNameTextBox.Text = camera.Name;
            Width = Parent.Width;
        }

        private void CameraNameTextBox_DoubleClick (object sender, EventArgs e) {
            CameraNameTextBox.ReadOnly = false;
            CameraNameTextBox.SelectAll();
        }

        private void CameraNameTextBox_Leave (object sender, EventArgs e) {
            CameraNameTextBox.DeselectAll();
            CameraNameTextBox.ReadOnly = true;
            camera.Name = CameraNameTextBox.Text;
        }

        private void CameraNameTextBox_KeyDown (object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                CameraNameTextBox.DeselectAll();
                CameraNameTextBox.ReadOnly = true;
                camera.Name = CameraNameTextBox.Text;
            }
        }

        private void SetActive (object sender, EventArgs e) {
            Environment.ActiveCamera = camera;
            
            CameraNameTextBox.BackColor = Color.White;
            BackColor = Color.White;

            foreach (CameraListItem cli in Parent.Controls) {
                if (cli != this) {
                    cli.SetNotActive();
                }
            }

            (Parent.Parent.Parent.Parent as EnvironmentControl).SetCameraViewSize(camera);
        }

        public void SetActive() {
            SetActive(null, null);
        }

        public void SetNotActive () {
            BackColor = Color.Gray;
            CameraNameTextBox.BackColor = Color.Gray;
        }

        public void UpdateCamera(Camera c) {
            camera = c;
        }

        private void SettingsButton_Click (object sender, EventArgs e) {
            SetActive();
            EditCamera newEditCamera = new EditCamera(camera, this);
            newEditCamera.Show();
        }

        private void DeleteButton_Click (object sender, EventArgs e) {
            Environment.Cameras.Remove(camera);
            camera.Dispose();
            Parent.Controls.Remove(this);
        }
    }
}
