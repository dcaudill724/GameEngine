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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraListItem));
            this.CameraNameTextBox = new System.Windows.Forms.TextBox();
            this.DeleteButton = new System.Windows.Forms.PictureBox();
            this.SettingsButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).BeginInit();
            this.SuspendLayout();
            // 
            // CameraNameTextBox
            // 
            this.CameraNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraNameTextBox.BackColor = System.Drawing.Color.Gray;
            this.CameraNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CameraNameTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CameraNameTextBox.Location = new System.Drawing.Point(4, 9);
            this.CameraNameTextBox.Name = "CameraNameTextBox";
            this.CameraNameTextBox.ReadOnly = true;
            this.CameraNameTextBox.Size = new System.Drawing.Size(114, 13);
            this.CameraNameTextBox.TabIndex = 0;
            this.CameraNameTextBox.Click += new System.EventHandler(this.SetActive);
            this.CameraNameTextBox.DoubleClick += new System.EventHandler(this.CameraNameTextBox_DoubleClick);
            this.CameraNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CameraNameTextBox_KeyDown);
            this.CameraNameTextBox.Leave += new System.EventHandler(this.CameraNameTextBox_Leave);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteButton.BackgroundImage")));
            this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteButton.Location = new System.Drawing.Point(161, 8);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(15, 15);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.TabStop = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SettingsButton.BackgroundImage")));
            this.SettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SettingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SettingsButton.Location = new System.Drawing.Point(143, 8);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(15, 15);
            this.SettingsButton.TabIndex = 2;
            this.SettingsButton.TabStop = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // CameraListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CameraNameTextBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CameraListItem";
            this.Size = new System.Drawing.Size(179, 30);
            this.Load += new System.EventHandler(this.CameraListItem_Load);
            this.Click += new System.EventHandler(this.SetActive);
            ((System.ComponentModel.ISupportInitialize)(this.DeleteButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CameraNameTextBox;
        private System.Windows.Forms.PictureBox DeleteButton;
        private System.Windows.Forms.PictureBox SettingsButton;
    }
}
