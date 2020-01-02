using System;
using System.Windows.Forms;
using System.Reflection;
using System.Numerics;

namespace GameEngine {
    public partial class EditCamera : Form {
        private Camera camera;
        private CameraListItem parent;

        public EditCamera (Camera camera, CameraListItem parent) {
            this.camera = camera;
            this.parent = parent;
            InitializeComponent();
        }

        private void EditCamera_Load (object sender, EventArgs e) {
            NameTextBox.Text = camera.Name;
            XTextBox.Text = Convert.ToString(camera.Position.X);
            YTextBox.Text = Convert.ToString(camera.Position.Y);
            ZTextBox.Text = Convert.ToString(camera.Position.Z);
            XTextBox2.Text = Convert.ToString(camera.Direction.X);
            YTextBox2.Text = Convert.ToString(camera.Direction.Y);
            ZTextBox2.Text = Convert.ToString(camera.Direction.Z);
            RadiansTextBox1.Text = Convert.ToString(camera.HorizontalFOV);
            DegreesTextBox1.Text = Convert.ToString(camera.HorizontalFOV * 180 / Math.PI);
            RadiansTextBox2.Text = Convert.ToString(camera.VerticalFOV);
            DegreesTextBox2.Text = Convert.ToString(camera.VerticalFOV * 180 / Math.PI);

            FieldInfo[] list = camera.GetType().GetFields();

            for (int i = 0; i < list.GetLength(0) - 6; ++i) {
                FieldDisplay fd = new FieldDisplay(list[i], camera, CameraFieldsFlowLayoutPanel);
                CameraFieldsFlowLayoutPanel.Controls.Add(fd);
            }
        }

        private void ApplyButton_Click (object sender, EventArgs e) {
            string name = NameTextBox.Text;
            Vector3 position = new Vector3(float.Parse(XTextBox.Text), float.Parse(YTextBox.Text), float.Parse(ZTextBox.Text));
            Vector3 direction = Vector3.Normalize(new Vector3(float.Parse(XTextBox2.Text), float.Parse(YTextBox2.Text), float.Parse(ZTextBox2.Text)));
            float horizontalWidth = float.Parse(RadiansTextBox1.Text);
            float verticalWidth = float.Parse(RadiansTextBox2.Text);
            float sensitivity = float.Parse(SensitivityTextBox.Text);

            Console.WriteLine(camera.GetType().ToString());

            switch (camera.GetType().ToString()) {
                case "GameEngine.RaytracingCamera":
                    object[] fieldValues = new object[CameraFieldsFlowLayoutPanel.Controls.Count];

                    for (int i = 0; i < fieldValues.Length; ++i) {
                        fieldValues[i] = CameraFieldsFlowLayoutPanel.Controls[i].Controls["FieldValueTextBox"].Text;
                    }

                    Console.WriteLine(Convert.ToInt32(fieldValues[0]));

                    RaytracingCamera temp = new RaytracingCamera(name, position, direction, horizontalWidth, verticalWidth, sensitivity, Convert.ToInt32(fieldValues[0]), Convert.ToInt32(fieldValues[1]), Convert.ToInt32(fieldValues[2]));

                    int index = Environment.Cameras.IndexOf(camera);

                    Environment.Cameras[index] = temp;
                    parent.UpdateCamera(temp);

                    camera = temp;
                    break;
            }
            Environment.SetActiveCamera(camera);
            Close();
        }
    }
}
