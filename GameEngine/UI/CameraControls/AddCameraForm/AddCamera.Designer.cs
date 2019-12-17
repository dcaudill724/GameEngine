namespace GameEngine {
    partial class AddCamera {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.CameraListBox = new System.Windows.Forms.ListBox();
            this.AddCameraButton = new System.Windows.Forms.Button();
            this.XTextBox = new System.Windows.Forms.TextBox();
            this.YTextBox = new System.Windows.Forms.TextBox();
            this.ZTextBox = new System.Windows.Forms.TextBox();
            this.PositionLabel = new System.Windows.Forms.Label();
            this.XLabel = new System.Windows.Forms.Label();
            this.YLabel = new System.Windows.Forms.Label();
            this.ZLabel = new System.Windows.Forms.Label();
            this.ZLabel2 = new System.Windows.Forms.Label();
            this.YLabel2 = new System.Windows.Forms.Label();
            this.XLabel2 = new System.Windows.Forms.Label();
            this.DirectionLabel = new System.Windows.Forms.Label();
            this.ZTextBox2 = new System.Windows.Forms.TextBox();
            this.YTextBox2 = new System.Windows.Forms.TextBox();
            this.XTextBox2 = new System.Windows.Forms.TextBox();
            this.RadiansLabel1 = new System.Windows.Forms.Label();
            this.DegreesLabel1 = new System.Windows.Forms.Label();
            this.RadiansTextBox1 = new System.Windows.Forms.TextBox();
            this.DegreesTextBox1 = new System.Windows.Forms.TextBox();
            this.DegreesTextBox2 = new System.Windows.Forms.TextBox();
            this.RadiansTextBox2 = new System.Windows.Forms.TextBox();
            this.DegreesLabel2 = new System.Windows.Forms.Label();
            this.RadiansLabel2 = new System.Windows.Forms.Label();
            this.HFOVGroupBox = new System.Windows.Forms.GroupBox();
            this.VFOVGroupBox = new System.Windows.Forms.GroupBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SensitivityLabel = new System.Windows.Forms.Label();
            this.SensitivityTextBox = new System.Windows.Forms.TextBox();
            this.CameraFieldsGroupBox = new System.Windows.Forms.GroupBox();
            this.CameraFieldsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.HFOVGroupBox.SuspendLayout();
            this.VFOVGroupBox.SuspendLayout();
            this.CameraFieldsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CameraListBox
            // 
            this.CameraListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CameraListBox.FormattingEnabled = true;
            this.CameraListBox.Items.AddRange(new object[] {
            "Ray Tracing"});
            this.CameraListBox.Location = new System.Drawing.Point(12, 12);
            this.CameraListBox.Name = "CameraListBox";
            this.CameraListBox.Size = new System.Drawing.Size(129, 264);
            this.CameraListBox.TabIndex = 0;
            this.CameraListBox.SelectedIndexChanged += new System.EventHandler(this.CameraListBox_SelectedIndexChanged);
            // 
            // AddCameraButton
            // 
            this.AddCameraButton.Location = new System.Drawing.Point(148, 228);
            this.AddCameraButton.Name = "AddCameraButton";
            this.AddCameraButton.Size = new System.Drawing.Size(264, 48);
            this.AddCameraButton.TabIndex = 1;
            this.AddCameraButton.Text = "Add Camera";
            this.AddCameraButton.UseVisualStyleBackColor = true;
            this.AddCameraButton.Click += new System.EventHandler(this.AddCameraButton_Click);
            // 
            // XTextBox
            // 
            this.XTextBox.Location = new System.Drawing.Point(215, 38);
            this.XTextBox.Name = "XTextBox";
            this.XTextBox.Size = new System.Drawing.Size(26, 20);
            this.XTextBox.TabIndex = 2;
            this.XTextBox.Text = "0.0";
            // 
            // YTextBox
            // 
            this.YTextBox.Location = new System.Drawing.Point(264, 38);
            this.YTextBox.Name = "YTextBox";
            this.YTextBox.Size = new System.Drawing.Size(26, 20);
            this.YTextBox.TabIndex = 3;
            this.YTextBox.Text = "0.0";
            // 
            // ZTextBox
            // 
            this.ZTextBox.Location = new System.Drawing.Point(313, 38);
            this.ZTextBox.Name = "ZTextBox";
            this.ZTextBox.Size = new System.Drawing.Size(26, 20);
            this.ZTextBox.TabIndex = 4;
            this.ZTextBox.Text = "0.0";
            // 
            // PositionLabel
            // 
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Location = new System.Drawing.Point(145, 41);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(47, 13);
            this.PositionLabel.TabIndex = 5;
            this.PositionLabel.Text = "Position:";
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(195, 41);
            this.XLabel.Margin = new System.Windows.Forms.Padding(0);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(17, 13);
            this.XLabel.TabIndex = 6;
            this.XLabel.Text = "X:";
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.Location = new System.Drawing.Point(244, 41);
            this.YLabel.Margin = new System.Windows.Forms.Padding(0);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(17, 13);
            this.YLabel.TabIndex = 7;
            this.YLabel.Text = "Y:";
            // 
            // ZLabel
            // 
            this.ZLabel.AutoSize = true;
            this.ZLabel.Location = new System.Drawing.Point(293, 41);
            this.ZLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ZLabel.Name = "ZLabel";
            this.ZLabel.Size = new System.Drawing.Size(17, 13);
            this.ZLabel.TabIndex = 8;
            this.ZLabel.Text = "Z:";
            // 
            // ZLabel2
            // 
            this.ZLabel2.AutoSize = true;
            this.ZLabel2.Location = new System.Drawing.Point(293, 67);
            this.ZLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.ZLabel2.Name = "ZLabel2";
            this.ZLabel2.Size = new System.Drawing.Size(17, 13);
            this.ZLabel2.TabIndex = 15;
            this.ZLabel2.Text = "Z:";
            // 
            // YLabel2
            // 
            this.YLabel2.AutoSize = true;
            this.YLabel2.Location = new System.Drawing.Point(244, 67);
            this.YLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.YLabel2.Name = "YLabel2";
            this.YLabel2.Size = new System.Drawing.Size(17, 13);
            this.YLabel2.TabIndex = 14;
            this.YLabel2.Text = "Y:";
            // 
            // XLabel2
            // 
            this.XLabel2.AutoSize = true;
            this.XLabel2.Location = new System.Drawing.Point(195, 67);
            this.XLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.XLabel2.Name = "XLabel2";
            this.XLabel2.Size = new System.Drawing.Size(17, 13);
            this.XLabel2.TabIndex = 13;
            this.XLabel2.Text = "X:";
            // 
            // DirectionLabel
            // 
            this.DirectionLabel.AutoSize = true;
            this.DirectionLabel.Location = new System.Drawing.Point(145, 67);
            this.DirectionLabel.Name = "DirectionLabel";
            this.DirectionLabel.Size = new System.Drawing.Size(52, 13);
            this.DirectionLabel.TabIndex = 12;
            this.DirectionLabel.Text = "Direction:";
            // 
            // ZTextBox2
            // 
            this.ZTextBox2.Location = new System.Drawing.Point(313, 64);
            this.ZTextBox2.Name = "ZTextBox2";
            this.ZTextBox2.Size = new System.Drawing.Size(26, 20);
            this.ZTextBox2.TabIndex = 11;
            this.ZTextBox2.Text = "0.0";
            // 
            // YTextBox2
            // 
            this.YTextBox2.Location = new System.Drawing.Point(264, 64);
            this.YTextBox2.Name = "YTextBox2";
            this.YTextBox2.Size = new System.Drawing.Size(26, 20);
            this.YTextBox2.TabIndex = 10;
            this.YTextBox2.Text = "0.0";
            // 
            // XTextBox2
            // 
            this.XTextBox2.Location = new System.Drawing.Point(215, 64);
            this.XTextBox2.Name = "XTextBox2";
            this.XTextBox2.Size = new System.Drawing.Size(26, 20);
            this.XTextBox2.TabIndex = 9;
            this.XTextBox2.Text = "1.0";
            // 
            // RadiansLabel1
            // 
            this.RadiansLabel1.AutoSize = true;
            this.RadiansLabel1.Location = new System.Drawing.Point(9, 22);
            this.RadiansLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.RadiansLabel1.Name = "RadiansLabel1";
            this.RadiansLabel1.Size = new System.Drawing.Size(49, 13);
            this.RadiansLabel1.TabIndex = 17;
            this.RadiansLabel1.Text = "Radians:";
            // 
            // DegreesLabel1
            // 
            this.DegreesLabel1.AutoSize = true;
            this.DegreesLabel1.Location = new System.Drawing.Point(136, 22);
            this.DegreesLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.DegreesLabel1.Name = "DegreesLabel1";
            this.DegreesLabel1.Size = new System.Drawing.Size(50, 13);
            this.DegreesLabel1.TabIndex = 18;
            this.DegreesLabel1.Text = "Degrees:";
            // 
            // RadiansTextBox1
            // 
            this.RadiansTextBox1.Location = new System.Drawing.Point(58, 19);
            this.RadiansTextBox1.Name = "RadiansTextBox1";
            this.RadiansTextBox1.Size = new System.Drawing.Size(75, 20);
            this.RadiansTextBox1.TabIndex = 19;
            this.RadiansTextBox1.Text = "1.22173";
            this.RadiansTextBox1.TextChanged += new System.EventHandler(this.RadiansTextBox1_TextChanged);
            // 
            // DegreesTextBox1
            // 
            this.DegreesTextBox1.Location = new System.Drawing.Point(189, 19);
            this.DegreesTextBox1.Name = "DegreesTextBox1";
            this.DegreesTextBox1.Size = new System.Drawing.Size(69, 20);
            this.DegreesTextBox1.TabIndex = 20;
            this.DegreesTextBox1.Text = "70.0";
            this.DegreesTextBox1.TextChanged += new System.EventHandler(this.DegreesTextBox1_TextChanged);
            // 
            // DegreesTextBox2
            // 
            this.DegreesTextBox2.Location = new System.Drawing.Point(189, 19);
            this.DegreesTextBox2.Name = "DegreesTextBox2";
            this.DegreesTextBox2.Size = new System.Drawing.Size(69, 20);
            this.DegreesTextBox2.TabIndex = 25;
            this.DegreesTextBox2.Text = "70.0";
            this.DegreesTextBox2.TextChanged += new System.EventHandler(this.DegreesTextBox2_TextChanged);
            // 
            // RadiansTextBox2
            // 
            this.RadiansTextBox2.Location = new System.Drawing.Point(58, 19);
            this.RadiansTextBox2.Name = "RadiansTextBox2";
            this.RadiansTextBox2.Size = new System.Drawing.Size(75, 20);
            this.RadiansTextBox2.TabIndex = 24;
            this.RadiansTextBox2.Text = "1.22173";
            this.RadiansTextBox2.TextChanged += new System.EventHandler(this.RadiansTextBox2_TextChanged);
            // 
            // DegreesLabel2
            // 
            this.DegreesLabel2.AutoSize = true;
            this.DegreesLabel2.Location = new System.Drawing.Point(136, 22);
            this.DegreesLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.DegreesLabel2.Name = "DegreesLabel2";
            this.DegreesLabel2.Size = new System.Drawing.Size(50, 13);
            this.DegreesLabel2.TabIndex = 23;
            this.DegreesLabel2.Text = "Degrees:";
            // 
            // RadiansLabel2
            // 
            this.RadiansLabel2.AutoSize = true;
            this.RadiansLabel2.Location = new System.Drawing.Point(9, 22);
            this.RadiansLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.RadiansLabel2.Name = "RadiansLabel2";
            this.RadiansLabel2.Size = new System.Drawing.Size(49, 13);
            this.RadiansLabel2.TabIndex = 22;
            this.RadiansLabel2.Text = "Radians:";
            // 
            // HFOVGroupBox
            // 
            this.HFOVGroupBox.Controls.Add(this.DegreesLabel1);
            this.HFOVGroupBox.Controls.Add(this.RadiansLabel1);
            this.HFOVGroupBox.Controls.Add(this.RadiansTextBox1);
            this.HFOVGroupBox.Controls.Add(this.DegreesTextBox1);
            this.HFOVGroupBox.Location = new System.Drawing.Point(148, 116);
            this.HFOVGroupBox.Name = "HFOVGroupBox";
            this.HFOVGroupBox.Size = new System.Drawing.Size(264, 50);
            this.HFOVGroupBox.TabIndex = 26;
            this.HFOVGroupBox.TabStop = false;
            this.HFOVGroupBox.Text = "Horizontal FOV";
            // 
            // VFOVGroupBox
            // 
            this.VFOVGroupBox.Controls.Add(this.RadiansTextBox2);
            this.VFOVGroupBox.Controls.Add(this.RadiansLabel2);
            this.VFOVGroupBox.Controls.Add(this.DegreesTextBox2);
            this.VFOVGroupBox.Controls.Add(this.DegreesLabel2);
            this.VFOVGroupBox.Location = new System.Drawing.Point(148, 172);
            this.VFOVGroupBox.Name = "VFOVGroupBox";
            this.VFOVGroupBox.Size = new System.Drawing.Size(264, 50);
            this.VFOVGroupBox.TabIndex = 27;
            this.VFOVGroupBox.TabStop = false;
            this.VFOVGroupBox.Text = "Vertical FOV";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(146, 15);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 28;
            this.NameLabel.Text = "Name:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(187, 12);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(152, 20);
            this.NameTextBox.TabIndex = 29;
            this.NameTextBox.Text = "Ray tracing Camera";
            // 
            // SensitivityLabel
            // 
            this.SensitivityLabel.AutoSize = true;
            this.SensitivityLabel.Location = new System.Drawing.Point(146, 93);
            this.SensitivityLabel.Margin = new System.Windows.Forms.Padding(0);
            this.SensitivityLabel.Name = "SensitivityLabel";
            this.SensitivityLabel.Size = new System.Drawing.Size(57, 13);
            this.SensitivityLabel.TabIndex = 30;
            this.SensitivityLabel.Text = "Sensitivity:";
            // 
            // SensitivityTextBox
            // 
            this.SensitivityTextBox.Location = new System.Drawing.Point(206, 90);
            this.SensitivityTextBox.Name = "SensitivityTextBox";
            this.SensitivityTextBox.Size = new System.Drawing.Size(55, 20);
            this.SensitivityTextBox.TabIndex = 31;
            this.SensitivityTextBox.Text = "1.0";
            // 
            // CameraFieldsGroupBox
            // 
            this.CameraFieldsGroupBox.Controls.Add(this.CameraFieldsFlowLayoutPanel);
            this.CameraFieldsGroupBox.Location = new System.Drawing.Point(418, 12);
            this.CameraFieldsGroupBox.Name = "CameraFieldsGroupBox";
            this.CameraFieldsGroupBox.Size = new System.Drawing.Size(238, 264);
            this.CameraFieldsGroupBox.TabIndex = 32;
            this.CameraFieldsGroupBox.TabStop = false;
            this.CameraFieldsGroupBox.Text = "Camera Specific Fields";
            // 
            // CameraFieldsFlowLayoutPanel
            // 
            this.CameraFieldsFlowLayoutPanel.AutoScroll = true;
            this.CameraFieldsFlowLayoutPanel.Location = new System.Drawing.Point(7, 19);
            this.CameraFieldsFlowLayoutPanel.Name = "CameraFieldsFlowLayoutPanel";
            this.CameraFieldsFlowLayoutPanel.Size = new System.Drawing.Size(225, 239);
            this.CameraFieldsFlowLayoutPanel.TabIndex = 0;
            // 
            // AddCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 285);
            this.Controls.Add(this.CameraFieldsGroupBox);
            this.Controls.Add(this.SensitivityTextBox);
            this.Controls.Add(this.SensitivityLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.VFOVGroupBox);
            this.Controls.Add(this.HFOVGroupBox);
            this.Controls.Add(this.ZLabel2);
            this.Controls.Add(this.YLabel2);
            this.Controls.Add(this.XLabel2);
            this.Controls.Add(this.DirectionLabel);
            this.Controls.Add(this.ZTextBox2);
            this.Controls.Add(this.YTextBox2);
            this.Controls.Add(this.XTextBox2);
            this.Controls.Add(this.ZLabel);
            this.Controls.Add(this.YLabel);
            this.Controls.Add(this.XLabel);
            this.Controls.Add(this.PositionLabel);
            this.Controls.Add(this.ZTextBox);
            this.Controls.Add(this.YTextBox);
            this.Controls.Add(this.XTextBox);
            this.Controls.Add(this.AddCameraButton);
            this.Controls.Add(this.CameraListBox);
            this.Name = "AddCamera";
            this.Text = "AddCamera";
            this.HFOVGroupBox.ResumeLayout(false);
            this.HFOVGroupBox.PerformLayout();
            this.VFOVGroupBox.ResumeLayout(false);
            this.VFOVGroupBox.PerformLayout();
            this.CameraFieldsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox CameraListBox;
        private System.Windows.Forms.Button AddCameraButton;
        private System.Windows.Forms.TextBox XTextBox;
        private System.Windows.Forms.TextBox YTextBox;
        private System.Windows.Forms.TextBox ZTextBox;
        private System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.Label YLabel;
        private System.Windows.Forms.Label ZLabel;
        private System.Windows.Forms.Label ZLabel2;
        private System.Windows.Forms.Label YLabel2;
        private System.Windows.Forms.Label XLabel2;
        private System.Windows.Forms.Label DirectionLabel;
        private System.Windows.Forms.TextBox ZTextBox2;
        private System.Windows.Forms.TextBox YTextBox2;
        private System.Windows.Forms.TextBox XTextBox2;
        private System.Windows.Forms.Label RadiansLabel1;
        private System.Windows.Forms.Label DegreesLabel1;
        private System.Windows.Forms.TextBox RadiansTextBox1;
        private System.Windows.Forms.TextBox DegreesTextBox1;
        private System.Windows.Forms.TextBox DegreesTextBox2;
        private System.Windows.Forms.TextBox RadiansTextBox2;
        private System.Windows.Forms.Label DegreesLabel2;
        private System.Windows.Forms.Label RadiansLabel2;
        private System.Windows.Forms.GroupBox HFOVGroupBox;
        private System.Windows.Forms.GroupBox VFOVGroupBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label SensitivityLabel;
        private System.Windows.Forms.TextBox SensitivityTextBox;
        private System.Windows.Forms.GroupBox CameraFieldsGroupBox;
        private System.Windows.Forms.FlowLayoutPanel CameraFieldsFlowLayoutPanel;
    }
}