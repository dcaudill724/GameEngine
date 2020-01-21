namespace GameEngine {
    partial class Form1 {
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
            this.CameraViewPictureBox = new System.Windows.Forms.PictureBox();
            this.CameraViewPanel = new System.Windows.Forms.Panel();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainEnvironmentControl = new GameEngine.EnvironmentControl();
            ((System.ComponentModel.ISupportInitialize)(this.CameraViewPictureBox)).BeginInit();
            this.CameraViewPanel.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // CameraViewPictureBox
            // 
            this.CameraViewPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraViewPictureBox.BackColor = System.Drawing.Color.Black;
            this.CameraViewPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CameraViewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CameraViewPictureBox.Location = new System.Drawing.Point(0, 0);
            this.CameraViewPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.CameraViewPictureBox.Name = "CameraViewPictureBox";
            this.CameraViewPictureBox.Size = new System.Drawing.Size(632, 321);
            this.CameraViewPictureBox.TabIndex = 0;
            this.CameraViewPictureBox.TabStop = false;
            this.CameraViewPictureBox.Click += new System.EventHandler(this.CameraView_Click);
            // 
            // CameraViewPanel
            // 
            this.CameraViewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraViewPanel.BackColor = System.Drawing.Color.DimGray;
            this.CameraViewPanel.Controls.Add(this.CameraViewPictureBox);
            this.CameraViewPanel.Location = new System.Drawing.Point(9, 29);
            this.CameraViewPanel.Margin = new System.Windows.Forms.Padding(0, 5, 3, 3);
            this.CameraViewPanel.Name = "CameraViewPanel";
            this.CameraViewPanel.Size = new System.Drawing.Size(632, 321);
            this.CameraViewPanel.TabIndex = 3;
            this.CameraViewPanel.SizeChanged += new System.EventHandler(this.CameraViewPanel_SizeChanged);
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.DimGray;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(843, 24);
            this.MenuStrip.TabIndex = 4;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // MainEnvironmentControl
            // 
            this.MainEnvironmentControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainEnvironmentControl.BackColor = System.Drawing.Color.DimGray;
            this.MainEnvironmentControl.Location = new System.Drawing.Point(649, 29);
            this.MainEnvironmentControl.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.MainEnvironmentControl.Name = "MainEnvironmentControl";
            this.MainEnvironmentControl.Size = new System.Drawing.Size(185, 324);
            this.MainEnvironmentControl.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(843, 450);
            this.Controls.Add(this.CameraViewPanel);
            this.Controls.Add(this.MainEnvironmentControl);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CameraViewPictureBox)).EndInit();
            this.CameraViewPanel.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CameraViewPictureBox;
        private EnvironmentControl MainEnvironmentControl;
        private System.Windows.Forms.Panel CameraViewPanel;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    }
}

