namespace GameEngine {
    partial class EnvironmentControl {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.CameraGroupBox = new System.Windows.Forms.GroupBox();
            this.CameraButtonPanel = new System.Windows.Forms.Panel();
            this.AddCameraButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.RemoveCameraButton = new System.Windows.Forms.Button();
            this.EditCameraButton = new System.Windows.Forms.Button();
            this.CameraListBox = new System.Windows.Forms.ListBox();
            this.CameraGroupBox.SuspendLayout();
            this.CameraButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CameraGroupBox
            // 
            this.CameraGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraGroupBox.Controls.Add(this.CameraButtonPanel);
            this.CameraGroupBox.Controls.Add(this.CameraListBox);
            this.CameraGroupBox.Location = new System.Drawing.Point(4, 4);
            this.CameraGroupBox.Name = "CameraGroupBox";
            this.CameraGroupBox.Size = new System.Drawing.Size(200, 133);
            this.CameraGroupBox.TabIndex = 0;
            this.CameraGroupBox.TabStop = false;
            this.CameraGroupBox.Text = "Cameras";
            // 
            // CameraButtonPanel
            // 
            this.CameraButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.CameraButtonPanel.Controls.Add(this.AddCameraButton);
            this.CameraButtonPanel.Controls.Add(this.listBox1);
            this.CameraButtonPanel.Controls.Add(this.RemoveCameraButton);
            this.CameraButtonPanel.Controls.Add(this.EditCameraButton);
            this.CameraButtonPanel.Location = new System.Drawing.Point(7, 95);
            this.CameraButtonPanel.Name = "CameraButtonPanel";
            this.CameraButtonPanel.Size = new System.Drawing.Size(187, 32);
            this.CameraButtonPanel.TabIndex = 1;
            // 
            // AddCameraButton
            // 
            this.AddCameraButton.Location = new System.Drawing.Point(1, 4);
            this.AddCameraButton.Name = "AddCameraButton";
            this.AddCameraButton.Size = new System.Drawing.Size(43, 25);
            this.AddCameraButton.TabIndex = 4;
            this.AddCameraButton.Text = "Add";
            this.AddCameraButton.UseVisualStyleBackColor = true;
            this.AddCameraButton.Click += new System.EventHandler(this.AddCameraButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, -75);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(187, 69);
            this.listBox1.TabIndex = 5;
            // 
            // RemoveCameraButton
            // 
            this.RemoveCameraButton.Location = new System.Drawing.Point(108, 3);
            this.RemoveCameraButton.Name = "RemoveCameraButton";
            this.RemoveCameraButton.Size = new System.Drawing.Size(61, 25);
            this.RemoveCameraButton.TabIndex = 3;
            this.RemoveCameraButton.Text = "Remove";
            this.RemoveCameraButton.UseVisualStyleBackColor = true;
            this.RemoveCameraButton.Click += new System.EventHandler(this.RemoveCameraButton_Click);
            // 
            // EditCameraButton
            // 
            this.EditCameraButton.Location = new System.Drawing.Point(50, 4);
            this.EditCameraButton.Name = "EditCameraButton";
            this.EditCameraButton.Size = new System.Drawing.Size(41, 25);
            this.EditCameraButton.TabIndex = 2;
            this.EditCameraButton.Text = "Edit";
            this.EditCameraButton.UseVisualStyleBackColor = true;
            this.EditCameraButton.Click += new System.EventHandler(this.EditCameraButton_Click);
            // 
            // CameraListBox
            // 
            this.CameraListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraListBox.FormattingEnabled = true;
            this.CameraListBox.Location = new System.Drawing.Point(7, 20);
            this.CameraListBox.Name = "CameraListBox";
            this.CameraListBox.Size = new System.Drawing.Size(187, 69);
            this.CameraListBox.TabIndex = 5;
            this.CameraListBox.SelectedIndexChanged += new System.EventHandler(this.CameraListBox_SelectedIndexChanged);
            // 
            // EnvironmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.CameraGroupBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EnvironmentControl";
            this.Size = new System.Drawing.Size(207, 460);
            this.Load += new System.EventHandler(this.ButtonLoad);
            this.CameraGroupBox.ResumeLayout(false);
            this.CameraButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox CameraGroupBox;
        private System.Windows.Forms.Button RemoveCameraButton;
        private System.Windows.Forms.Button EditCameraButton;
        private System.Windows.Forms.Button AddCameraButton;
        private System.Windows.Forms.ListBox CameraListBox;
        private System.Windows.Forms.Panel CameraButtonPanel;
        private System.Windows.Forms.ListBox listBox1;
    }
}
