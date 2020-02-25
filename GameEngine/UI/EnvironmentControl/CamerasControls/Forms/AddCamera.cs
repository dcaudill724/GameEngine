using System;
using System.Numerics;
using System.Windows.Forms;
using System.Reflection;

namespace GameEngine {
    public partial class AddCamera : Form {
        private EnvironmentControl environmentControl;
        private Camera cameraBuffer = null;

        public AddCamera (EnvironmentControl environmentControl) {
            this.environmentControl = environmentControl;
            InitializeComponent();
            CameraListBox.SetSelected(0, true);
        }

        #region EventMethods

        private void RadiansTextBox1_TextChanged (object sender, EventArgs e) {
            if (!RadiansTextBox1.Focused) {
                return;
            }
            try {
                double value = Convert.ToDouble(RadiansTextBox1.Text);
                value = value % (Math.PI * 2);
                value = value * (180 / Math.PI);
                DegreesTextBox1.Text = Convert.ToString(value);
            } catch {
                DegreesTextBox1.Text = "0";
            }
        }

        private void RadiansTextBox2_TextChanged (object sender, EventArgs e) {
            if (!RadiansTextBox2.Focused) {
                return;
            }
            try {
                double value = Convert.ToDouble(RadiansTextBox2.Text);
                value %= (Math.PI * 2);
                value *= (180 / Math.PI);
                DegreesTextBox2.Text = Convert.ToString(value);
            } catch {
                DegreesTextBox2.Text = "0";
            }
        }

        private void DegreesTextBox1_TextChanged (object sender, EventArgs e) {
            if (!DegreesTextBox1.Focused) {
                return;
            }
            try {
                double value = Convert.ToDouble(DegreesTextBox1.Text);
                value = value % 360;
                value = value * (Math.PI / 180);
                RadiansTextBox1.Text = Convert.ToString(value);
            } catch {
                RadiansTextBox1.Text = "0";
            }
        }

        private void DegreesTextBox2_TextChanged (object sender, EventArgs e) {
            if (!DegreesTextBox2.Focused) {
                return;
            }
            try {
                double value = Convert.ToDouble(DegreesTextBox2.Text);
                value = value % 360;
                value = value * (Math.PI / 180);
                RadiansTextBox2.Text = Convert.ToString(value);
            } catch {
                RadiansTextBox2.Text = "0";
            }
        }

        private void AddCameraButton_Click (object sender, EventArgs e) {
            string cameraType = CameraListBox.SelectedItem.ToString();

            cameraBuffer = null;

            string name = NameTextBox.Text;
            Vector3 position = new Vector3(float.Parse(XTextBox.Text), float.Parse(YTextBox.Text), float.Parse(ZTextBox.Text));
            Vector3 direction = Vector3.Normalize(new Vector3(float.Parse(XTextBox2.Text), float.Parse(YTextBox2.Text), float.Parse(ZTextBox2.Text)));
            float horizontalWidth = float.Parse(RadiansTextBox1.Text);
            float verticalWidth = float.Parse(RadiansTextBox2.Text);
            float sensitivity = float.Parse(SensitivityTextBox.Text);
            int horizontalResolution = Convert.ToInt32(HorizontalResolutionTextBox.Text);
            int verticalResolution = Convert.ToInt32(VerticalResolutionTextBox.Text);

            object[] fieldValues = new object[CameraFieldsFlowLayoutPanel.Controls.Count];

            for (int i = 0; i < fieldValues.Length; ++i) {
                fieldValues[i] = CameraFieldsFlowLayoutPanel.Controls[i].Controls["FieldValueTextBox"].Text;
            }

            switch (cameraType) {
                case "Ray Tracing":
                    cameraBuffer = new RaytracingCamera(name, position, direction, horizontalWidth, verticalWidth, sensitivity, horizontalResolution, verticalResolution, Convert.ToInt32(fieldValues[0]), Convert.ToInt32(fieldValues[1]));
                    break;
                case "Projection":
                    cameraBuffer = new ProjectionCamera(name, position, direction, horizontalWidth, verticalWidth, sensitivity, horizontalResolution, verticalResolution);
                    break;
            }
            if (cameraBuffer != null) {
                environmentControl.AddCamera(cameraBuffer);
                Close();
            } else {
                MessageBox.Show("Invalid Camera Type", "Invalid", MessageBoxButtons.OK);
            }
        }

        private void CameraListBox_SelectedIndexChanged (object sender, EventArgs e) {
            CameraFieldsFlowLayoutPanel.Controls.Clear();

            switch (CameraListBox.SelectedItem) {
                case "Ray Tracing":
                    cameraBuffer = new RaytracingCamera();
                    break;
                case "Projection":
                    cameraBuffer = new ProjectionCamera();
                    break;
            }



            FieldInfo[] list = cameraBuffer.GetType().GetFields();

            int offset = list.Length - 9; //Camera has 9 fields

            NameTextBox.Text = Convert.ToString(list[offset].GetValue(cameraBuffer));

            Vector3 tempPos = (Vector3)list[offset + 1].GetValue(cameraBuffer);
            XTextBox.Text = Convert.ToString(tempPos.X);
            YTextBox.Text = Convert.ToString(tempPos.Y);
            ZTextBox.Text = Convert.ToString(tempPos.Z);

            Vector3 tempDir = (Vector3)list[offset + 2].GetValue(cameraBuffer);
            XTextBox2.Text = Convert.ToString(tempDir.X);
            YTextBox2.Text = Convert.ToString(tempDir.Y);
            ZTextBox2.Text = Convert.ToString(tempDir.Z);

            SensitivityTextBox.Text = Convert.ToString(list[offset + 3].GetValue(cameraBuffer));

            RadiansTextBox1.Text = Convert.ToString(list[offset + 4].GetValue(cameraBuffer));
            RadiansTextBox2.Text = Convert.ToString(list[offset + 5].GetValue(cameraBuffer));

            HorizontalResolutionTextBox.Text = Convert.ToString(list[offset + 7].GetValue(cameraBuffer));
            VerticalResolutionTextBox.Text = Convert.ToString(list[offset + 8].GetValue(cameraBuffer));

            for (int i = 0; i < offset; ++i) {
                FieldDisplay fd = new FieldDisplay(list[i], cameraBuffer, CameraFieldsFlowLayoutPanel);
                CameraFieldsFlowLayoutPanel.Controls.Add(fd);
            }

            cameraBuffer.Dispose();
        }

        #endregion
    }
}
