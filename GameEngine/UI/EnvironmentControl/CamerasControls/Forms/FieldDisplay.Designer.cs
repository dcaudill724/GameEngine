namespace GameEngine {
    partial class FieldDisplay {
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
            this.FieldNameLabel = new System.Windows.Forms.Label();
            this.FieldValueTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FieldNameLabel
            // 
            this.FieldNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FieldNameLabel.AutoSize = true;
            this.FieldNameLabel.Location = new System.Drawing.Point(3, 9);
            this.FieldNameLabel.Name = "FieldNameLabel";
            this.FieldNameLabel.Size = new System.Drawing.Size(56, 13);
            this.FieldNameLabel.TabIndex = 0;
            this.FieldNameLabel.Text = "Undefined";
            // 
            // FieldValueTextBox
            // 
            this.FieldValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FieldValueTextBox.Location = new System.Drawing.Point(65, 6);
            this.FieldValueTextBox.Name = "FieldValueTextBox";
            this.FieldValueTextBox.Size = new System.Drawing.Size(180, 20);
            this.FieldValueTextBox.TabIndex = 1;
            // 
            // FieldDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.FieldValueTextBox);
            this.Controls.Add(this.FieldNameLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FieldDisplay";
            this.Size = new System.Drawing.Size(248, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FieldNameLabel;
        private System.Windows.Forms.TextBox FieldValueTextBox;
    }
}
