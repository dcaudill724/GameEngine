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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.CamerasPage = new System.Windows.Forms.TabPage();
            this.NewCameraButton = new System.Windows.Forms.Button();
            this.ObjectPage = new System.Windows.Forms.TabPage();
            this.newObjectButton = new System.Windows.Forms.Button();
            this.CameraListBox = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.CamerasPage.SuspendLayout();
            this.ObjectPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.CamerasPage);
            this.tabControl1.Controls.Add(this.ObjectPage);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(183, 460);
            this.tabControl1.TabIndex = 0;
            // 
            // CamerasPage
            // 
            this.CamerasPage.Controls.Add(this.CameraListBox);
            this.CamerasPage.Controls.Add(this.NewCameraButton);
            this.CamerasPage.Location = new System.Drawing.Point(4, 22);
            this.CamerasPage.Name = "CamerasPage";
            this.CamerasPage.Padding = new System.Windows.Forms.Padding(3);
            this.CamerasPage.Size = new System.Drawing.Size(175, 434);
            this.CamerasPage.TabIndex = 1;
            this.CamerasPage.Text = "Cameras";
            this.CamerasPage.UseVisualStyleBackColor = true;
            // 
            // NewCameraButton
            // 
            this.NewCameraButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewCameraButton.Location = new System.Drawing.Point(6, 6);
            this.NewCameraButton.Name = "NewCameraButton";
            this.NewCameraButton.Size = new System.Drawing.Size(163, 23);
            this.NewCameraButton.TabIndex = 0;
            this.NewCameraButton.Text = "Add New Camera";
            this.NewCameraButton.UseVisualStyleBackColor = true;
            this.NewCameraButton.Click += new System.EventHandler(this.NewCameraButton_Click);
            // 
            // ObjectPage
            // 
            this.ObjectPage.Controls.Add(this.newObjectButton);
            this.ObjectPage.Location = new System.Drawing.Point(4, 22);
            this.ObjectPage.Name = "ObjectPage";
            this.ObjectPage.Padding = new System.Windows.Forms.Padding(3);
            this.ObjectPage.Size = new System.Drawing.Size(157, 434);
            this.ObjectPage.TabIndex = 2;
            this.ObjectPage.Text = "Environment Objects";
            this.ObjectPage.UseVisualStyleBackColor = true;
            // 
            // newObjectButton
            // 
            this.newObjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newObjectButton.Location = new System.Drawing.Point(6, 6);
            this.newObjectButton.Name = "newObjectButton";
            this.newObjectButton.Size = new System.Drawing.Size(163, 23);
            this.newObjectButton.TabIndex = 0;
            this.newObjectButton.Text = "Add New Object";
            this.newObjectButton.UseVisualStyleBackColor = true;
            this.newObjectButton.Click += new System.EventHandler(this.NewObjectButton_Click);
            // 
            // CameraListBox
            // 
            this.CameraListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraListBox.FormattingEnabled = true;
            this.CameraListBox.Location = new System.Drawing.Point(7, 36);
            this.CameraListBox.Name = "CameraListBox";
            this.CameraListBox.Size = new System.Drawing.Size(162, 394);
            this.CameraListBox.TabIndex = 1;
            this.CameraListBox.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.CameraListBox_ControlAdded);
            // 
            // EnvironmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EnvironmentControl";
            this.Size = new System.Drawing.Size(183, 460);
            this.tabControl1.ResumeLayout(false);
            this.CamerasPage.ResumeLayout(false);
            this.ObjectPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage CamerasPage;
        private System.Windows.Forms.TabPage ObjectPage;
        private System.Windows.Forms.Button NewCameraButton;
        private System.Windows.Forms.Button newObjectButton;
        private System.Windows.Forms.ListBox CameraListBox;
    }
}
