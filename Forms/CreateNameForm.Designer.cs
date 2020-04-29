namespace CourseworkFront
{
    partial class CreateNameForm
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
            this.helloLabel = new System.Windows.Forms.Label();
            this.pleaseLabel = new System.Windows.Forms.Label();
            this.inputNameTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.directoriesPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // helloLabel
            // 
            this.helloLabel.AutoSize = true;
            this.helloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.helloLabel.Location = new System.Drawing.Point(96, 7);
            this.helloLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.helloLabel.Name = "helloLabel";
            this.helloLabel.Size = new System.Drawing.Size(103, 31);
            this.helloLabel.TabIndex = 2;
            this.helloLabel.Text = "HELLO";
            // 
            // pleaseLabel
            // 
            this.pleaseLabel.AutoSize = true;
            this.pleaseLabel.Location = new System.Drawing.Point(4, 46);
            this.pleaseLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pleaseLabel.Name = "pleaseLabel";
            this.pleaseLabel.Size = new System.Drawing.Size(268, 13);
            this.pleaseLabel.TabIndex = 3;
            this.pleaseLabel.Text = "Please, input your neural network`s name or select exist";
            // 
            // inputNameTextBox
            // 
            this.inputNameTextBox.Location = new System.Drawing.Point(7, 64);
            this.inputNameTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.inputNameTextBox.Name = "inputNameTextBox";
            this.inputNameTextBox.Size = new System.Drawing.Size(242, 20);
            this.inputNameTextBox.TabIndex = 4;
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.SystemColors.Control;
            this.okButton.Location = new System.Drawing.Point(257, 64);
            this.okButton.Margin = new System.Windows.Forms.Padding(1);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(46, 20);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // directoriesPanel
            // 
            this.directoriesPanel.Location = new System.Drawing.Point(6, 87);
            this.directoriesPanel.Margin = new System.Windows.Forms.Padding(1);
            this.directoriesPanel.Name = "directoriesPanel";
            this.directoriesPanel.Size = new System.Drawing.Size(299, 135);
            this.directoriesPanel.TabIndex = 6;
            // 
            // CreateNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 235);
            this.Controls.Add(this.directoriesPanel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.inputNameTextBox);
            this.Controls.Add(this.pleaseLabel);
            this.Controls.Add(this.helloLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "CreateNameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create neural network";
            this.Load += new System.EventHandler(this.CreateNameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label helloLabel;
        private System.Windows.Forms.Label pleaseLabel;
        private System.Windows.Forms.TextBox inputNameTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel directoriesPanel;
    }
}