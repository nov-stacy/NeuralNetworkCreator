namespace CourseworkFront
{
    partial class TrainingInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lossPictureBox = new System.Windows.Forms.PictureBox();
            this.accuracyPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lossPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accuracyPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lossPictureBox
            // 
            this.lossPictureBox.Location = new System.Drawing.Point(12, 12);
            this.lossPictureBox.Name = "lossPictureBox";
            this.lossPictureBox.Size = new System.Drawing.Size(617, 497);
            this.lossPictureBox.TabIndex = 0;
            this.lossPictureBox.TabStop = false;
            // 
            // accuracyPictureBox
            // 
            this.accuracyPictureBox.Location = new System.Drawing.Point(642, 12);
            this.accuracyPictureBox.Name = "accuracyPictureBox";
            this.accuracyPictureBox.Size = new System.Drawing.Size(617, 497);
            this.accuracyPictureBox.TabIndex = 1;
            this.accuracyPictureBox.TabStop = false;
            // 
            // TrainingInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 518);
            this.Controls.Add(this.accuracyPictureBox);
            this.Controls.Add(this.lossPictureBox);
            this.Name = "TrainingInfoForm";
            this.Text = "TrainingInfoForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TrainingInfoForm_FormClosed);
            this.Load += new System.EventHandler(this.TrainingInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lossPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accuracyPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox lossPictureBox;
        private System.Windows.Forms.PictureBox accuracyPictureBox;
    }
}