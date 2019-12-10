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
            this.environmentControl = new GameEngine.EnvironmentControl();
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
            this.CameraView.Location = new System.Drawing.Point(0, 0);
            this.CameraView.Margin = new System.Windows.Forms.Padding(0);
            this.CameraView.Name = "CameraView";
            this.CameraView.Size = new System.Drawing.Size(566, 333);
            this.CameraView.TabIndex = 0;
            this.CameraView.TabStop = false;
            this.CameraView.Click += new System.EventHandler(this.CameraView_Click);
            // 
            // environmentControl
            // 
            this.environmentControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.environmentControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.environmentControl.Location = new System.Drawing.Point(569, 0);
            this.environmentControl.Name = "environmentControl";
            this.environmentControl.Size = new System.Drawing.Size(232, 333);
            this.environmentControl.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.environmentControl);
            this.Controls.Add(this.CameraView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CameraView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox CameraView;
        private EnvironmentControl environmentControl;
    }
}

