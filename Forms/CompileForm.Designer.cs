namespace CourseworkFront
{
    partial class CompileForm
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
            this.d1NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.d2NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.d1RadioButton = new System.Windows.Forms.RadioButton();
            this.d2RadioButton = new System.Windows.Forms.RadioButton();
            this.okButton = new System.Windows.Forms.Button();
            this.classificationRadioButton = new System.Windows.Forms.RadioButton();
            this.regressionRadioButton = new System.Windows.Forms.RadioButton();
            this.typeGroupBox = new System.Windows.Forms.GroupBox();
            this.typeDataGroupBox = new System.Windows.Forms.GroupBox();
            this.imageRadioButton = new System.Windows.Forms.RadioButton();
            this.textRadioButton = new System.Windows.Forms.RadioButton();
            this.matrixRadioButton = new System.Windows.Forms.RadioButton();
            this.inputShapeGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.d1NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d2NumericUpDown)).BeginInit();
            this.typeGroupBox.SuspendLayout();
            this.typeDataGroupBox.SuspendLayout();
            this.inputShapeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // d1NumericUpDown
            // 
            this.d1NumericUpDown.Location = new System.Drawing.Point(5, 21);
            this.d1NumericUpDown.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.d1NumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.d1NumericUpDown.Name = "d1NumericUpDown";
            this.d1NumericUpDown.Size = new System.Drawing.Size(63, 20);
            this.d1NumericUpDown.TabIndex = 3;
            // 
            // d2NumericUpDown
            // 
            this.d2NumericUpDown.Location = new System.Drawing.Point(77, 20);
            this.d2NumericUpDown.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.d2NumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.d2NumericUpDown.Name = "d2NumericUpDown";
            this.d2NumericUpDown.Size = new System.Drawing.Size(63, 20);
            this.d2NumericUpDown.TabIndex = 4;
            // 
            // d1RadioButton
            // 
            this.d1RadioButton.AutoSize = true;
            this.d1RadioButton.Enabled = false;
            this.d1RadioButton.Location = new System.Drawing.Point(5, 50);
            this.d1RadioButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.d1RadioButton.Name = "d1RadioButton";
            this.d1RadioButton.Size = new System.Drawing.Size(39, 17);
            this.d1RadioButton.TabIndex = 5;
            this.d1RadioButton.Text = "1D";
            this.d1RadioButton.UseVisualStyleBackColor = true;
            this.d1RadioButton.CheckedChanged += new System.EventHandler(this.D1RadioButton_CheckedChanged);
            // 
            // d2RadioButton
            // 
            this.d2RadioButton.AutoSize = true;
            this.d2RadioButton.Checked = true;
            this.d2RadioButton.Location = new System.Drawing.Point(51, 50);
            this.d2RadioButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.d2RadioButton.Name = "d2RadioButton";
            this.d2RadioButton.Size = new System.Drawing.Size(39, 17);
            this.d2RadioButton.TabIndex = 6;
            this.d2RadioButton.TabStop = true;
            this.d2RadioButton.Text = "2D";
            this.d2RadioButton.UseVisualStyleBackColor = true;
            this.d2RadioButton.CheckedChanged += new System.EventHandler(this.D2RadioButton_CheckedChanged);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(10, 183);
            this.okButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(343, 34);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // classificationRadioButton
            // 
            this.classificationRadioButton.AutoSize = true;
            this.classificationRadioButton.Checked = true;
            this.classificationRadioButton.Location = new System.Drawing.Point(6, 19);
            this.classificationRadioButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.classificationRadioButton.Name = "classificationRadioButton";
            this.classificationRadioButton.Size = new System.Drawing.Size(86, 17);
            this.classificationRadioButton.TabIndex = 8;
            this.classificationRadioButton.TabStop = true;
            this.classificationRadioButton.Text = "Classification";
            this.classificationRadioButton.UseVisualStyleBackColor = true;
            // 
            // regressionRadioButton
            // 
            this.regressionRadioButton.AutoSize = true;
            this.regressionRadioButton.Enabled = false;
            this.regressionRadioButton.Location = new System.Drawing.Point(6, 41);
            this.regressionRadioButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.regressionRadioButton.Name = "regressionRadioButton";
            this.regressionRadioButton.Size = new System.Drawing.Size(78, 17);
            this.regressionRadioButton.TabIndex = 9;
            this.regressionRadioButton.Text = "Regression";
            this.regressionRadioButton.UseVisualStyleBackColor = true;
            // 
            // typeGroupBox
            // 
            this.typeGroupBox.Controls.Add(this.classificationRadioButton);
            this.typeGroupBox.Controls.Add(this.regressionRadioButton);
            this.typeGroupBox.Location = new System.Drawing.Point(10, 13);
            this.typeGroupBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.typeGroupBox.Name = "typeGroupBox";
            this.typeGroupBox.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.typeGroupBox.Size = new System.Drawing.Size(177, 67);
            this.typeGroupBox.TabIndex = 10;
            this.typeGroupBox.TabStop = false;
            this.typeGroupBox.Text = "Type of supervised learning ";
            // 
            // typeDataGroupBox
            // 
            this.typeDataGroupBox.Controls.Add(this.imageRadioButton);
            this.typeDataGroupBox.Controls.Add(this.textRadioButton);
            this.typeDataGroupBox.Controls.Add(this.matrixRadioButton);
            this.typeDataGroupBox.Location = new System.Drawing.Point(209, 13);
            this.typeDataGroupBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.typeDataGroupBox.Name = "typeDataGroupBox";
            this.typeDataGroupBox.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.typeDataGroupBox.Size = new System.Drawing.Size(144, 67);
            this.typeDataGroupBox.TabIndex = 11;
            this.typeDataGroupBox.TabStop = false;
            this.typeDataGroupBox.Text = "Type of data";
            // 
            // imageRadioButton
            // 
            this.imageRadioButton.AutoSize = true;
            this.imageRadioButton.Checked = true;
            this.imageRadioButton.Location = new System.Drawing.Point(9, 41);
            this.imageRadioButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.imageRadioButton.Name = "imageRadioButton";
            this.imageRadioButton.Size = new System.Drawing.Size(54, 17);
            this.imageRadioButton.TabIndex = 17;
            this.imageRadioButton.TabStop = true;
            this.imageRadioButton.Text = "Image";
            this.imageRadioButton.UseVisualStyleBackColor = true;
            // 
            // textRadioButton
            // 
            this.textRadioButton.AutoSize = true;
            this.textRadioButton.Enabled = false;
            this.textRadioButton.Location = new System.Drawing.Point(74, 19);
            this.textRadioButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textRadioButton.Name = "textRadioButton";
            this.textRadioButton.Size = new System.Drawing.Size(46, 17);
            this.textRadioButton.TabIndex = 19;
            this.textRadioButton.Text = "Text";
            this.textRadioButton.UseVisualStyleBackColor = true;
            // 
            // matrixRadioButton
            // 
            this.matrixRadioButton.AutoSize = true;
            this.matrixRadioButton.Enabled = false;
            this.matrixRadioButton.Location = new System.Drawing.Point(9, 19);
            this.matrixRadioButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.matrixRadioButton.Name = "matrixRadioButton";
            this.matrixRadioButton.Size = new System.Drawing.Size(53, 17);
            this.matrixRadioButton.TabIndex = 18;
            this.matrixRadioButton.Text = "Matrix";
            this.matrixRadioButton.UseVisualStyleBackColor = true;
            // 
            // inputShapeGroupBox
            // 
            this.inputShapeGroupBox.Controls.Add(this.d1NumericUpDown);
            this.inputShapeGroupBox.Controls.Add(this.d2NumericUpDown);
            this.inputShapeGroupBox.Controls.Add(this.d1RadioButton);
            this.inputShapeGroupBox.Controls.Add(this.d2RadioButton);
            this.inputShapeGroupBox.Location = new System.Drawing.Point(10, 91);
            this.inputShapeGroupBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.inputShapeGroupBox.Name = "inputShapeGroupBox";
            this.inputShapeGroupBox.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.inputShapeGroupBox.Size = new System.Drawing.Size(177, 78);
            this.inputShapeGroupBox.TabIndex = 12;
            this.inputShapeGroupBox.TabStop = false;
            this.inputShapeGroupBox.Text = "Input shape";
            // 
            // CompileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 229);
            this.Controls.Add(this.inputShapeGroupBox);
            this.Controls.Add(this.typeDataGroupBox);
            this.Controls.Add(this.typeGroupBox);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "CompileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COMPILE";
            this.Load += new System.EventHandler(this.CompileForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.d1NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d2NumericUpDown)).EndInit();
            this.typeGroupBox.ResumeLayout(false);
            this.typeGroupBox.PerformLayout();
            this.typeDataGroupBox.ResumeLayout(false);
            this.typeDataGroupBox.PerformLayout();
            this.inputShapeGroupBox.ResumeLayout(false);
            this.inputShapeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown d1NumericUpDown;
        private System.Windows.Forms.NumericUpDown d2NumericUpDown;
        private System.Windows.Forms.RadioButton d1RadioButton;
        private System.Windows.Forms.RadioButton d2RadioButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.RadioButton classificationRadioButton;
        private System.Windows.Forms.RadioButton regressionRadioButton;
        private System.Windows.Forms.GroupBox typeGroupBox;
        private System.Windows.Forms.GroupBox typeDataGroupBox;
        private System.Windows.Forms.RadioButton imageRadioButton;
        private System.Windows.Forms.RadioButton textRadioButton;
        private System.Windows.Forms.RadioButton matrixRadioButton;
        private System.Windows.Forms.GroupBox inputShapeGroupBox;
    }
}