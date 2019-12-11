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
            this.HFOVGroupBox.SuspendLayout();
            this.VFOVGroupBox.SuspendLayout();
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
            this.CameraListBox.Size = new System.Drawing.Size(181, 251);
            this.CameraListBox.TabIndex = 0;
            // 
            // AddCameraButton
            // 
            this.AddCameraButton.Location = new System.Drawing.Point(199, 211);
            this.AddCameraButton.Name = "AddCameraButton";
            this.AddCameraButton.Size = new System.Drawing.Size(264, 52);
            this.AddCameraButton.TabIndex = 1;
            this.AddCameraButton.Text = "Add Camera";
            this.AddCameraButton.UseVisualStyleBackColor = true;
            this.AddCameraButton.Click += new System.EventHandler(this.AddCameraButton_Click);
            // 
            // XTextBox
            // 
            this.XTextBox.Location = new System.Drawing.Point(266, 47);
            this.XTextBox.Name = "XTextBox";
            this.XTextBox.Size = new System.Drawing.Size(26, 20);
            this.XTextBox.TabIndex = 2;
            this.XTextBox.Text = "0.0";
            // 
            // YTextBox
            // 
            this.YTextBox.Location = new System.Drawing.Point(315, 47);
            this.YTextBox.Name = "YTextBox";
            this.YTextBox.Size = new System.Drawing.Size(26, 20);
            this.YTextBox.TabIndex = 3;
            this.YTextBox.Text = "0.0";
            // 
            // ZTextBox
            // 
            this.ZTextBox.Location = new System.Drawing.Point(364, 47);
            this.ZTextBox.Name = "ZTextBox";
            this.ZTextBox.Size = new System.Drawing.Size(26, 20);
            this.ZTextBox.TabIndex = 4;
            this.ZTextBox.Text = "0.0";
            // 
            // PositionLabel
            // 
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Location = new System.Drawing.Point(196, 50);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(47, 13);
            this.PositionLabel.TabIndex = 5;
            this.PositionLabel.Text = "Position:";
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(246, 50);
            this.XLabel.Margin = new System.Windows.Forms.Padding(0);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(17, 13);
            this.XLabel.TabIndex = 6;
            this.XLabel.Text = "X:";
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.Location = new System.Drawing.Point(295, 50);
            this.YLabel.Margin = new System.Windows.Forms.Padding(0);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(17, 13);
            this.YLabel.TabIndex = 7;
            this.YLabel.Text = "Y:";
            // 
            // ZLabel
            // 
            this.ZLabel.AutoSize = true;
            this.ZLabel.Location = new System.Drawing.Point(344, 50);
            this.ZLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ZLabel.Name = "ZLabel";
            this.ZLabel.Size = new System.Drawing.Size(17, 13);
            this.ZLabel.TabIndex = 8;
            this.ZLabel.Text = "Z:";
            // 
            // ZLabel2
            // 
            this.ZLabel2.AutoSize = true;
            this.ZLabel2.Location = new System.Drawing.Point(344, 76);
            this.ZLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.ZLabel2.Name = "ZLabel2";
            this.ZLabel2.Size = new System.Drawing.Size(17, 13);
            this.ZLabel2.TabIndex = 15;
            this.ZLabel2.Text = "Z:";
            // 
            // YLabel2
            // 
            this.YLabel2.AutoSize = true;
            this.YLabel2.Location = new System.Drawing.Point(295, 76);
            this.YLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.YLabel2.Name = "YLabel2";
            this.YLabel2.Size = new System.Drawing.Size(17, 13);
            this.YLabel2.TabIndex = 14;
            this.YLabel2.Text = "Y:";
            // 
            // XLabel2
            // 
            this.XLabel2.AutoSize = true;
            this.XLabel2.Location = new System.Drawing.Point(246, 76);
            this.XLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.XLabel2.Name = "XLabel2";
            this.XLabel2.Size = new System.Drawing.Size(17, 13);
            this.XLabel2.TabIndex = 13;
            this.XLabel2.Text = "X:";
            // 
            // DirectionLabel
            // 
            this.DirectionLabel.AutoSize = true;
            this.DirectionLabel.Location = new System.Drawing.Point(196, 76);
            this.DirectionLabel.Name = "DirectionLabel";
            this.DirectionLabel.Size = new System.Drawing.Size(52, 13);
            this.DirectionLabel.TabIndex = 12;
            this.DirectionLabel.Text = "Direction:";
            // 
            // ZTextBox2
            // 
            this.ZTextBox2.Location = new System.Drawing.Point(364, 73);
            this.ZTextBox2.Name = "ZTextBox2";
            this.ZTextBox2.Size = new System.Drawing.Size(26, 20);
            this.ZTextBox2.TabIndex = 11;
            this.ZTextBox2.Text = "0.0";
            // 
            // YTextBox2
            // 
            this.YTextBox2.Location = new System.Drawing.Point(315, 73);
            this.YTextBox2.Name = "YTextBox2";
            this.YTextBox2.Size = new System.Drawing.Size(26, 20);
            this.YTextBox2.TabIndex = 10;
            this.YTextBox2.Text = "0.0";
            // 
            // XTextBox2
            // 
            this.XTextBox2.Location = new System.Drawing.Point(266, 73);
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
            this.HFOVGroupBox.Location = new System.Drawing.Point(199, 99);
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
            this.VFOVGroupBox.Location = new System.Drawing.Point(199, 155);
            this.VFOVGroupBox.Name = "VFOVGroupBox";
            this.VFOVGroupBox.Size = new System.Drawing.Size(264, 50);
            this.VFOVGroupBox.TabIndex = 27;
            this.VFOVGroupBox.TabStop = false;
            this.VFOVGroupBox.Text = "Vertical FOV";
            // 
            // AddCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 278);
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
    }
}