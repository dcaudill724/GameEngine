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
        private Dictionary<Camera, CameraListItem> cameraList;

        public EnvironmentControl () {
            cameraList = new Dictionary<Camera, CameraListItem>();
            InitializeComponent();
        }

        private void NewObjectButton_Click (object sender, EventArgs e) {

        }

        private void NewCameraButton_Click (object sender, EventArgs e) {
            Form addCamera = new AddCamera(this);
            addCamera.Show();
        }

        public void AddCamera(Camera c) {
            CameraListItem item = new CameraListItem(c);
            cameraList.Add(c, item);
            CameraListBox.Controls.Add(item);
            Console.WriteLine(CameraListBox.Items.Count);
            Environment.AddNewCamera(c);
        }

        private void CameraListBox_ControlAdded (object sender, ControlEventArgs e) {
            foreach (Control c in CameraListBox.Controls) {
                c.Width = CameraListBox.Width;
            }
        }
    }
}
