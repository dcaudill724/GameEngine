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
            this.CameraView = new System.Windows.Forms.PictureBox();
            this.MainEnvironmentControl = new GameEngine.EnvironmentControl();
            this.FpsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CameraView)).BeginInit();
            this.SuspendLayout();
            // 
            // CameraView
            // 
            this.CameraView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraView.BackColor = System.Drawing.Color.Black;
            this.CameraView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CameraView.Location = new System.Drawing.Point(9, 9);
            this.CameraView.Margin = new System.Windows.Forms.Padding(0);
            this.CameraView.Name = "CameraView";
            this.CameraView.Size = new System.Drawing.Size(630, 324);
            this.CameraView.TabIndex = 0;
            this.CameraView.TabStop = false;
            this.CameraView.Click += new System.EventHandler(this.CameraView_Click);
            // 
            // MainEnvironmentControl
            // 
            this.MainEnvironmentControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainEnvironmentControl.BackColor = System.Drawing.Color.DimGray;
            this.MainEnvironmentControl.Location = new System.Drawing.Point(649, 9);
            this.MainEnvironmentControl.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.MainEnvironmentControl.Name = "MainEnvironmentControl";
            this.MainEnvironmentControl.Size = new System.Drawing.Size(185, 324);
            this.MainEnvironmentControl.TabIndex = 1;
            // 
            // FpsLabel
            // 
            this.FpsLabel.AutoSize = true;
            this.FpsLabel.Location = new System.Drawing.Point(13, 13);
            this.FpsLabel.Name = "FpsLabel";
            this.FpsLabel.Size = new System.Drawing.Size(35, 13);
            this.FpsLabel.TabIndex = 2;
            this.FpsLabel.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(843, 450);
            this.Controls.Add(this.FpsLabel);
            this.Controls.Add(this.MainEnvironmentControl);
            this.Controls.Add(this.CameraView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CameraView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CameraView;
        private EnvironmentControl MainEnvironmentControl;
        private System.Windows.Forms.Label FpsLabel;
    }
}

