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
            CameraListBox.Items.Add(c.Name);
            CameraListBox.SelectedIndex = CameraListBox.Items.Count - 1;
        }

        private void AddCameraButton_Click (object sender, EventArgs e) {
            AddCamera newCameraForm = new AddCamera(this);
            newCameraForm.Show();
        }

        private void ButtonLoad(object sender, EventArgs e) {
            int width = CameraButtonPanel.Width;
            int gapSize = 4;
            int buttonWidth = (width - gapSize * 2) / 4;
            int y = (CameraButtonPanel.Height - AddCameraButton.Height) / 2;

            AddCameraButton.Width = buttonWidth;
            EditCameraButton.Width = buttonWidth;
            RemoveCameraButton.Width = buttonWidth * 2;

            AddCameraButton.Location = new Point(0, y);
            EditCameraButton.Location = new Point(0 + buttonWidth + gapSize, y);
            RemoveCameraButton.Location = new Point(0 + buttonWidth + gapSize + buttonWidth + gapSize, y);
        }

        private void RemoveCameraButton_Click (object sender, EventArgs e) {
            if (CameraListBox.Items.Count > 1) {
                int deleteIndex = CameraListBox.SelectedIndex;
                if (deleteIndex == 0) {
                    CameraListBox.Items.RemoveAt(0);
                    Environment.RemoveCameraAt(0);
                    CameraListBox.SelectedIndex = 0;
                } else {
                    CameraListBox.SelectedIndex = deleteIndex - 1;
                    CameraListBox.Items.RemoveAt(deleteIndex);
                    Environment.RemoveCameraAt(deleteIndex);
                }
            } else if (CameraListBox.Items.Count == 1) {
                CameraListBox.SelectedIndex = -1;
                CameraListBox.Items.RemoveAt(0);
                Environment.RemoveCameraAt(0);
            }
        }

        private void EditCameraButton_Click (object sender, EventArgs e) {
            if (CameraListBox.SelectedIndex != -1) {
                EditCamera newEditCamera = new EditCamera(Environment.Cameras[CameraListBox.SelectedIndex]);
                newEditCamera.Show();
            }
        }

        private void CameraListBox_SelectedIndexChanged (object sender, EventArgs e) {
            if (CameraListBox.SelectedIndex != -1) {
                Environment.SelectCamera(CameraListBox.SelectedIndex);
            }
        }
    }
}
