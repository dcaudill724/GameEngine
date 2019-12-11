namespace GameEngine {
    partial class CameraListItem {
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
            this.CameraNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CameraNameLabel
            // 
            this.CameraNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CameraNameLabel.Location = new System.Drawing.Point(3, 8);
            this.CameraNameLabel.Name = "CameraNameLabel";
            this.CameraNameLabel.Size = new System.Drawing.Size(43, 13);
            this.CameraNameLabel.TabIndex = 0;
            this.CameraNameLabel.Text = "Camera";
            // 
            // CameraListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.CameraNameLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CameraListItem";
            this.Size = new System.Drawing.Size(186, 28);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label CameraNameLabel;
    }
}
