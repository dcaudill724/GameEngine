namespace GameEngine {
    partial class AddObject {
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
            this.ObjectTypeListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ObjectTypeListBox
            // 
            this.ObjectTypeListBox.FormattingEnabled = true;
            this.ObjectTypeListBox.Items.AddRange(new object[] {
            "Shape"});
            this.ObjectTypeListBox.Location = new System.Drawing.Point(13, 13);
            this.ObjectTypeListBox.Name = "ObjectTypeListBox";
            this.ObjectTypeListBox.Size = new System.Drawing.Size(120, 186);
            this.ObjectTypeListBox.TabIndex = 0;
            // 
            // AddObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ObjectTypeListBox);
            this.MinimumSize = new System.Drawing.Size(1, 1);
            this.Name = "AddObject";
            this.Text = "AddObject";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ObjectTypeListBox;
    }
}