using System;
using System.Windows.Forms;

namespace GameEngine {
    public partial class EditCamera : Form {
        private Camera camera;

        public EditCamera (Camera camera) {
            this.camera = camera;
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
        }

        private void OkButton_Click (object sender, EventArgs e) {
            Close();
        }
    }
}
