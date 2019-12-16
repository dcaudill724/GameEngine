﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameEngine {
    public partial class AddCamera : Form {
        private EnvironmentControl environmentControl;

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
            Camera c = null;
            switch (cameraType) {
                case "Ray Tracing":
                    string name = NameTextBox.Text;
                    Vector3 position = new Vector3(float.Parse(XTextBox.Text), float.Parse(YTextBox.Text), float.Parse(ZTextBox.Text));
                    Vector3 direction = Vector3.Normalize(new Vector3(float.Parse(XTextBox2.Text), float.Parse(YTextBox2.Text), float.Parse(ZTextBox2.Text)));
                    float horizontalWidth = float.Parse(RadiansTextBox1.Text);
                    float verticalWidth = float.Parse(RadiansTextBox2.Text);
                    float sensitivity = float.Parse(SensitivityTextBox.Text);
                    //need to add resolution
                    c = new RaytracingCamera(name, position, direction, horizontalWidth, verticalWidth, sensitivity, 200);
                    break;
            }
            if (c != null) {
                environmentControl.AddCamera(c);
                Close();
            } else {
                MessageBox.Show("Invalid Camera Type", "Invalid", MessageBoxButtons.OK);
            }
        }
        #endregion

        private void CameraListBox_SelectedIndexChanged (object sender, EventArgs e) {
            
        }
    }
}
