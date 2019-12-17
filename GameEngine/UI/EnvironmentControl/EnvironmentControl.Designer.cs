﻿namespace GameEngine {
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
            this.EnvironmentGroupBox = new System.Windows.Forms.GroupBox();
            this.CamerasGroupBox = new System.Windows.Forms.GroupBox();
            this.AddCameraButton = new System.Windows.Forms.Button();
            this.CameraListFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.EnvironmentControlPanel = new System.Windows.Forms.Panel();
            this.CamerasGroupBox.SuspendLayout();
            this.EnvironmentControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnvironmentGroupBox
            // 
            this.EnvironmentGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EnvironmentGroupBox.Location = new System.Drawing.Point(3, 3);
            this.EnvironmentGroupBox.Name = "EnvironmentGroupBox";
            this.EnvironmentGroupBox.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.EnvironmentGroupBox.Size = new System.Drawing.Size(171, 454);
            this.EnvironmentGroupBox.TabIndex = 0;
            this.EnvironmentGroupBox.TabStop = false;
            this.EnvironmentGroupBox.Text = "Environment";
            // 
            // CamerasGroupBox
            // 
            this.CamerasGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CamerasGroupBox.Controls.Add(this.AddCameraButton);
            this.CamerasGroupBox.Controls.Add(this.CameraListFlowPanel);
            this.CamerasGroupBox.Location = new System.Drawing.Point(3, 3);
            this.CamerasGroupBox.Name = "CamerasGroupBox";
            this.CamerasGroupBox.Size = new System.Drawing.Size(163, 201);
            this.CamerasGroupBox.TabIndex = 0;
            this.CamerasGroupBox.TabStop = false;
            this.CamerasGroupBox.Text = "Cameras";
            // 
            // AddCameraButton
            // 
            this.AddCameraButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddCameraButton.Location = new System.Drawing.Point(7, 172);
            this.AddCameraButton.Name = "AddCameraButton";
            this.AddCameraButton.Size = new System.Drawing.Size(152, 23);
            this.AddCameraButton.TabIndex = 1;
            this.AddCameraButton.Text = "Add Camera";
            this.AddCameraButton.UseVisualStyleBackColor = true;
            this.AddCameraButton.Click += new System.EventHandler(this.AddCameraButton_Click);
            // 
            // CameraListFlowPanel
            // 
            this.CameraListFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraListFlowPanel.AutoScroll = true;
            this.CameraListFlowPanel.Location = new System.Drawing.Point(6, 20);
            this.CameraListFlowPanel.Name = "CameraListFlowPanel";
            this.CameraListFlowPanel.Size = new System.Drawing.Size(151, 147);
            this.CameraListFlowPanel.TabIndex = 0;
            this.CameraListFlowPanel.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.CameraListFlowPanel_ControlRemoved);
            // 
            // EnvironmentControlPanel
            // 
            this.EnvironmentControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EnvironmentControlPanel.AutoScroll = true;
            this.EnvironmentControlPanel.Controls.Add(this.CamerasGroupBox);
            this.EnvironmentControlPanel.Location = new System.Drawing.Point(4, 20);
            this.EnvironmentControlPanel.Margin = new System.Windows.Forms.Padding(1);
            this.EnvironmentControlPanel.Name = "EnvironmentControlPanel";
            this.EnvironmentControlPanel.Size = new System.Drawing.Size(169, 434);
            this.EnvironmentControlPanel.TabIndex = 1;
            // 
            // EnvironmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EnvironmentControlPanel);
            this.Controls.Add(this.EnvironmentGroupBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EnvironmentControl";
            this.Size = new System.Drawing.Size(177, 460);
            this.CamerasGroupBox.ResumeLayout(false);
            this.EnvironmentControlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox EnvironmentGroupBox;
        private System.Windows.Forms.GroupBox CamerasGroupBox;
        private System.Windows.Forms.Panel EnvironmentControlPanel;
        private System.Windows.Forms.FlowLayoutPanel CameraListFlowPanel;
        private System.Windows.Forms.Button AddCameraButton;
    }
}
