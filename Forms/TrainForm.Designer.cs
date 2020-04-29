namespace CourseworkFront
{
    partial class TrainForm
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
            this.filePanel = new System.Windows.Forms.Panel();
            this.fileLabel = new System.Windows.Forms.Label();
            this.openFilebutton = new System.Windows.Forms.Button();
            this.epochLabel = new System.Windows.Forms.Label();
            this.epochNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.targetLabel = new System.Windows.Forms.Label();
            this.targetBox = new System.Windows.Forms.ComboBox();
            this.trainRateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.batchLabel = new System.Windows.Forms.Label();
            this.batchNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.filePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epochNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainRateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // filePanel
            // 
            this.filePanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.filePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filePanel.Controls.Add(this.fileLabel);
            this.filePanel.Location = new System.Drawing.Point(12, 14);
            this.filePanel.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(296, 22);
            this.filePanel.TabIndex = 3;
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(1, 3);
            this.fileLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(0, 13);
            this.fileLabel.TabIndex = 0;
            // 
            // openFilebutton
            // 
            this.openFilebutton.Location = new System.Drawing.Point(318, 14);
            this.openFilebutton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.openFilebutton.Name = "openFilebutton";
            this.openFilebutton.Size = new System.Drawing.Size(72, 23);
            this.openFilebutton.TabIndex = 4;
            this.openFilebutton.Text = "OPEN FILE";
            this.openFilebutton.UseVisualStyleBackColor = true;
            this.openFilebutton.Click += new System.EventHandler(this.OpenFilebutton_Click);
            // 
            // epochLabel
            // 
            this.epochLabel.AutoSize = true;
            this.epochLabel.Location = new System.Drawing.Point(171, 256);
            this.epochLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.epochLabel.Name = "epochLabel";
            this.epochLabel.Size = new System.Drawing.Size(97, 13);
            this.epochLabel.TabIndex = 5;
            this.epochLabel.Text = "Number of epochs:";
            // 
            // epochNumericUpDown
            // 
            this.epochNumericUpDown.Location = new System.Drawing.Point(268, 255);
            this.epochNumericUpDown.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.epochNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.epochNumericUpDown.Name = "epochNumericUpDown";
            this.epochNumericUpDown.Size = new System.Drawing.Size(53, 20);
            this.epochNumericUpDown.TabIndex = 6;
            this.epochNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 311);
            this.okButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(595, 32);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // targetLabel
            // 
            this.targetLabel.AutoSize = true;
            this.targetLabel.Location = new System.Drawing.Point(417, 256);
            this.targetLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.targetLabel.Name = "targetLabel";
            this.targetLabel.Size = new System.Drawing.Size(41, 13);
            this.targetLabel.TabIndex = 10;
            this.targetLabel.Text = "Target:";
            // 
            // targetBox
            // 
            this.targetBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetBox.FormattingEnabled = true;
            this.targetBox.Location = new System.Drawing.Point(468, 255);
            this.targetBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.targetBox.Name = "targetBox";
            this.targetBox.Size = new System.Drawing.Size(138, 21);
            this.targetBox.TabIndex = 11;
            // 
            // trainRateNumericUpDown
            // 
            this.trainRateNumericUpDown.DecimalPlaces = 2;
            this.trainRateNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.trainRateNumericUpDown.Location = new System.Drawing.Point(93, 255);
            this.trainRateNumericUpDown.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.trainRateNumericUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            this.trainRateNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.trainRateNumericUpDown.Name = "trainRateNumericUpDown";
            this.trainRateNumericUpDown.Size = new System.Drawing.Size(53, 20);
            this.trainRateNumericUpDown.TabIndex = 13;
            this.trainRateNumericUpDown.Value = new decimal(new int[] {
            75,
            0,
            0,
            131072});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 256);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Train data rate:";
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(12, 46);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.webBrowser.MinimumSize = new System.Drawing.Size(6, 7);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(591, 199);
            this.webBrowser.TabIndex = 14;
            // 
            // batchLabel
            // 
            this.batchLabel.AutoSize = true;
            this.batchLabel.Location = new System.Drawing.Point(171, 284);
            this.batchLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.batchLabel.Name = "batchLabel";
            this.batchLabel.Size = new System.Drawing.Size(59, 13);
            this.batchLabel.TabIndex = 15;
            this.batchLabel.Text = "Batch size:";
            // 
            // batchNumericUpDown
            // 
            this.batchNumericUpDown.Location = new System.Drawing.Point(268, 283);
            this.batchNumericUpDown.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.batchNumericUpDown.Name = "batchNumericUpDown";
            this.batchNumericUpDown.Size = new System.Drawing.Size(53, 20);
            this.batchNumericUpDown.TabIndex = 16;
            // 
            // TrainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 354);
            this.Controls.Add(this.batchNumericUpDown);
            this.Controls.Add(this.batchLabel);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.trainRateNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.targetBox);
            this.Controls.Add(this.targetLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.epochNumericUpDown);
            this.Controls.Add(this.epochLabel);
            this.Controls.Add(this.openFilebutton);
            this.Controls.Add(this.filePanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRAIN";
            this.filePanel.ResumeLayout(false);
            this.filePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epochNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainRateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.Button openFilebutton;
        private System.Windows.Forms.Label epochLabel;
        private System.Windows.Forms.NumericUpDown epochNumericUpDown;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label targetLabel;
        private System.Windows.Forms.ComboBox targetBox;
        private System.Windows.Forms.NumericUpDown trainRateNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Label batchLabel;
        private System.Windows.Forms.NumericUpDown batchNumericUpDown;
    }
}