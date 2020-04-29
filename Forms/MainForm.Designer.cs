namespace CourseworkFront
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.informationBox = new System.Windows.Forms.GroupBox();
            this.informationPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layersBox = new System.Windows.Forms.GroupBox();
            this.maxPooling2DButton = new System.Windows.Forms.Button();
            this.maxPolling1DButton = new System.Windows.Forms.Button();
            this.conv2DButton = new System.Windows.Forms.Button();
            this.conv1DButton = new System.Windows.Forms.Button();
            this.flattenButton = new System.Windows.Forms.Button();
            this.dropoutButton = new System.Windows.Forms.Button();
            this.denseButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.compileSettingsBox = new System.Windows.Forms.GroupBox();
            this.metricsLabel = new System.Windows.Forms.Label();
            this.metricsBox = new System.Windows.Forms.ComboBox();
            this.lossLabel = new System.Windows.Forms.Label();
            this.lossBox = new System.Windows.Forms.ComboBox();
            this.optimizerLabel = new System.Windows.Forms.Label();
            this.optimizerBox = new System.Windows.Forms.ComboBox();
            this.firstLayerRadioButton = new System.Windows.Forms.RadioButton();
            this.connectionRadioButton = new System.Windows.Forms.RadioButton();
            this.compileButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.informationBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.layersBox.SuspendLayout();
            this.compileSettingsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // informationBox
            // 
            this.informationBox.Controls.Add(this.informationPanel);
            this.informationBox.Location = new System.Drawing.Point(950, 29);
            this.informationBox.Margin = new System.Windows.Forms.Padding(1);
            this.informationBox.Name = "informationBox";
            this.informationBox.Padding = new System.Windows.Forms.Padding(1);
            this.informationBox.Size = new System.Drawing.Size(324, 610);
            this.informationBox.TabIndex = 0;
            this.informationBox.TabStop = false;
            this.informationBox.Text = "Neural network information";
            // 
            // informationPanel
            // 
            this.informationPanel.AutoScroll = true;
            this.informationPanel.Location = new System.Drawing.Point(19, 29);
            this.informationPanel.Margin = new System.Windows.Forms.Padding(1);
            this.informationPanel.Name = "informationPanel";
            this.informationPanel.Size = new System.Drawing.Size(290, 563);
            this.informationPanel.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectToolStripMenuItem,
            this.saveAllToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openProjectToolStripMenuItem.Text = "Open project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.OpenProjectToolStripMenuItem_Click);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveAllToolStripMenuItem.Text = "Save project";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.SaveAllToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // layersBox
            // 
            this.layersBox.BackColor = System.Drawing.SystemColors.Control;
            this.layersBox.Controls.Add(this.maxPooling2DButton);
            this.layersBox.Controls.Add(this.maxPolling1DButton);
            this.layersBox.Controls.Add(this.conv2DButton);
            this.layersBox.Controls.Add(this.conv1DButton);
            this.layersBox.Controls.Add(this.flattenButton);
            this.layersBox.Controls.Add(this.dropoutButton);
            this.layersBox.Controls.Add(this.denseButton);
            this.layersBox.Location = new System.Drawing.Point(4, 29);
            this.layersBox.Margin = new System.Windows.Forms.Padding(1);
            this.layersBox.Name = "layersBox";
            this.layersBox.Padding = new System.Windows.Forms.Padding(1);
            this.layersBox.Size = new System.Drawing.Size(169, 278);
            this.layersBox.TabIndex = 2;
            this.layersBox.TabStop = false;
            this.layersBox.Text = "Layers";
            // 
            // maxPooling2DButton
            // 
            this.maxPooling2DButton.Location = new System.Drawing.Point(8, 237);
            this.maxPooling2DButton.Margin = new System.Windows.Forms.Padding(1);
            this.maxPooling2DButton.Name = "maxPooling2DButton";
            this.maxPooling2DButton.Size = new System.Drawing.Size(152, 28);
            this.maxPooling2DButton.TabIndex = 6;
            this.maxPooling2DButton.Text = "MaxPooling 2D";
            this.maxPooling2DButton.UseVisualStyleBackColor = true;
            this.maxPooling2DButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LayerButton_MouseDown);
            // 
            // maxPolling1DButton
            // 
            this.maxPolling1DButton.Location = new System.Drawing.Point(8, 201);
            this.maxPolling1DButton.Margin = new System.Windows.Forms.Padding(1);
            this.maxPolling1DButton.Name = "maxPolling1DButton";
            this.maxPolling1DButton.Size = new System.Drawing.Size(152, 28);
            this.maxPolling1DButton.TabIndex = 5;
            this.maxPolling1DButton.Text = "MaxPooling 1D";
            this.maxPolling1DButton.UseVisualStyleBackColor = true;
            this.maxPolling1DButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LayerButton_MouseDown);
            // 
            // conv2DButton
            // 
            this.conv2DButton.Location = new System.Drawing.Point(8, 164);
            this.conv2DButton.Margin = new System.Windows.Forms.Padding(1);
            this.conv2DButton.Name = "conv2DButton";
            this.conv2DButton.Size = new System.Drawing.Size(152, 28);
            this.conv2DButton.TabIndex = 4;
            this.conv2DButton.Text = "Conv 2D";
            this.conv2DButton.UseVisualStyleBackColor = true;
            this.conv2DButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LayerButton_MouseDown);
            // 
            // conv1DButton
            // 
            this.conv1DButton.Location = new System.Drawing.Point(8, 127);
            this.conv1DButton.Margin = new System.Windows.Forms.Padding(1);
            this.conv1DButton.Name = "conv1DButton";
            this.conv1DButton.Size = new System.Drawing.Size(152, 28);
            this.conv1DButton.TabIndex = 3;
            this.conv1DButton.Text = "Conv 1D";
            this.conv1DButton.UseVisualStyleBackColor = true;
            this.conv1DButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LayerButton_MouseDown);
            // 
            // flattenButton
            // 
            this.flattenButton.Location = new System.Drawing.Point(8, 90);
            this.flattenButton.Margin = new System.Windows.Forms.Padding(1);
            this.flattenButton.Name = "flattenButton";
            this.flattenButton.Size = new System.Drawing.Size(152, 28);
            this.flattenButton.TabIndex = 2;
            this.flattenButton.Text = "Flatten";
            this.flattenButton.UseVisualStyleBackColor = true;
            this.flattenButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LayerButton_MouseDown);
            // 
            // dropoutButton
            // 
            this.dropoutButton.Location = new System.Drawing.Point(8, 53);
            this.dropoutButton.Margin = new System.Windows.Forms.Padding(1);
            this.dropoutButton.Name = "dropoutButton";
            this.dropoutButton.Size = new System.Drawing.Size(152, 28);
            this.dropoutButton.TabIndex = 1;
            this.dropoutButton.Text = "Dropout";
            this.dropoutButton.UseVisualStyleBackColor = true;
            this.dropoutButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LayerButton_MouseDown);
            // 
            // denseButton
            // 
            this.denseButton.Location = new System.Drawing.Point(8, 15);
            this.denseButton.Margin = new System.Windows.Forms.Padding(1);
            this.denseButton.Name = "denseButton";
            this.denseButton.Size = new System.Drawing.Size(152, 28);
            this.denseButton.TabIndex = 0;
            this.denseButton.Text = "Dense";
            this.denseButton.UseVisualStyleBackColor = true;
            this.denseButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LayerButton_MouseDown);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mainPanel.Location = new System.Drawing.Point(180, 36);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(756, 603);
            this.mainPanel.TabIndex = 3;
            this.mainPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainPanel_DragDrop);
            this.mainPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainPanel_DragEnter);
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            this.mainPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseClick);
            // 
            // compileSettingsBox
            // 
            this.compileSettingsBox.Controls.Add(this.metricsLabel);
            this.compileSettingsBox.Controls.Add(this.metricsBox);
            this.compileSettingsBox.Controls.Add(this.lossLabel);
            this.compileSettingsBox.Controls.Add(this.lossBox);
            this.compileSettingsBox.Controls.Add(this.optimizerLabel);
            this.compileSettingsBox.Controls.Add(this.optimizerBox);
            this.compileSettingsBox.Location = new System.Drawing.Point(4, 313);
            this.compileSettingsBox.Margin = new System.Windows.Forms.Padding(1);
            this.compileSettingsBox.Name = "compileSettingsBox";
            this.compileSettingsBox.Padding = new System.Windows.Forms.Padding(1);
            this.compileSettingsBox.Size = new System.Drawing.Size(169, 160);
            this.compileSettingsBox.TabIndex = 4;
            this.compileSettingsBox.TabStop = false;
            this.compileSettingsBox.Text = "Compile Settings";
            // 
            // metricsLabel
            // 
            this.metricsLabel.AutoSize = true;
            this.metricsLabel.Location = new System.Drawing.Point(2, 105);
            this.metricsLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.metricsLabel.Name = "metricsLabel";
            this.metricsLabel.Size = new System.Drawing.Size(35, 13);
            this.metricsLabel.TabIndex = 5;
            this.metricsLabel.Text = "metric";
            // 
            // metricsBox
            // 
            this.metricsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.metricsBox.FormattingEnabled = true;
            this.metricsBox.Location = new System.Drawing.Point(4, 119);
            this.metricsBox.Margin = new System.Windows.Forms.Padding(1);
            this.metricsBox.Name = "metricsBox";
            this.metricsBox.Size = new System.Drawing.Size(157, 21);
            this.metricsBox.TabIndex = 4;
            this.metricsBox.SelectedIndexChanged += new System.EventHandler(this.ParamsBox_SelectedIndexChanged);
            // 
            // lossLabel
            // 
            this.lossLabel.AutoSize = true;
            this.lossLabel.Location = new System.Drawing.Point(2, 63);
            this.lossLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lossLabel.Name = "lossLabel";
            this.lossLabel.Size = new System.Drawing.Size(25, 13);
            this.lossLabel.TabIndex = 3;
            this.lossLabel.Text = "loss";
            // 
            // lossBox
            // 
            this.lossBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lossBox.FormattingEnabled = true;
            this.lossBox.Location = new System.Drawing.Point(4, 78);
            this.lossBox.Margin = new System.Windows.Forms.Padding(1);
            this.lossBox.Name = "lossBox";
            this.lossBox.Size = new System.Drawing.Size(157, 21);
            this.lossBox.TabIndex = 2;
            this.lossBox.SelectedIndexChanged += new System.EventHandler(this.ParamsBox_SelectedIndexChanged);
            // 
            // optimizerLabel
            // 
            this.optimizerLabel.AutoSize = true;
            this.optimizerLabel.Location = new System.Drawing.Point(2, 22);
            this.optimizerLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.optimizerLabel.Name = "optimizerLabel";
            this.optimizerLabel.Size = new System.Drawing.Size(48, 13);
            this.optimizerLabel.TabIndex = 1;
            this.optimizerLabel.Text = "optimizer";
            // 
            // optimizerBox
            // 
            this.optimizerBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optimizerBox.FormattingEnabled = true;
            this.optimizerBox.Location = new System.Drawing.Point(4, 36);
            this.optimizerBox.Margin = new System.Windows.Forms.Padding(1);
            this.optimizerBox.Name = "optimizerBox";
            this.optimizerBox.Size = new System.Drawing.Size(157, 21);
            this.optimizerBox.TabIndex = 0;
            this.optimizerBox.SelectedIndexChanged += new System.EventHandler(this.ParamsBox_SelectedIndexChanged);
            // 
            // firstLayerRadioButton
            // 
            this.firstLayerRadioButton.AutoSize = true;
            this.firstLayerRadioButton.Location = new System.Drawing.Point(8, 480);
            this.firstLayerRadioButton.Margin = new System.Windows.Forms.Padding(1);
            this.firstLayerRadioButton.Name = "firstLayerRadioButton";
            this.firstLayerRadioButton.Size = new System.Drawing.Size(98, 17);
            this.firstLayerRadioButton.TabIndex = 5;
            this.firstLayerRadioButton.TabStop = true;
            this.firstLayerRadioButton.Text = "First layer mode";
            this.firstLayerRadioButton.UseVisualStyleBackColor = true;
            // 
            // connectionRadioButton
            // 
            this.connectionRadioButton.AutoSize = true;
            this.connectionRadioButton.Checked = true;
            this.connectionRadioButton.Location = new System.Drawing.Point(8, 503);
            this.connectionRadioButton.Margin = new System.Windows.Forms.Padding(1);
            this.connectionRadioButton.Name = "connectionRadioButton";
            this.connectionRadioButton.Size = new System.Drawing.Size(108, 17);
            this.connectionRadioButton.TabIndex = 6;
            this.connectionRadioButton.TabStop = true;
            this.connectionRadioButton.Text = "Connection mode";
            this.connectionRadioButton.UseVisualStyleBackColor = true;
            // 
            // compileButton
            // 
            this.compileButton.Location = new System.Drawing.Point(4, 531);
            this.compileButton.Margin = new System.Windows.Forms.Padding(1);
            this.compileButton.Name = "compileButton";
            this.compileButton.Size = new System.Drawing.Size(170, 30);
            this.compileButton.TabIndex = 7;
            this.compileButton.Text = "Compile";
            this.compileButton.UseVisualStyleBackColor = true;
            this.compileButton.Click += new System.EventHandler(this.CompileButton_Click);
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(4, 573);
            this.startButton.Margin = new System.Windows.Forms.Padding(1);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(169, 33);
            this.startButton.TabIndex = 8;
            this.startButton.Text = "GO";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 650);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.compileButton);
            this.Controls.Add(this.connectionRadioButton);
            this.Controls.Add(this.firstLayerRadioButton);
            this.Controls.Add(this.compileSettingsBox);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.layersBox);
            this.Controls.Add(this.informationBox);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "MainForm";
            this.Text = "Application for create neural network";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closing);
            this.Shown += new System.EventHandler(this.MainForm_Load);
            this.informationBox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.layersBox.ResumeLayout(false);
            this.compileSettingsBox.ResumeLayout(false);
            this.compileSettingsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox informationBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.GroupBox layersBox;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox compileSettingsBox;
        private System.Windows.Forms.Label metricsLabel;
        private System.Windows.Forms.ComboBox metricsBox;
        private System.Windows.Forms.Label lossLabel;
        private System.Windows.Forms.ComboBox lossBox;
        private System.Windows.Forms.Label optimizerLabel;
        private System.Windows.Forms.ComboBox optimizerBox;
        private System.Windows.Forms.Button flattenButton;
        private System.Windows.Forms.Button dropoutButton;
        private System.Windows.Forms.Button denseButton;
        private System.Windows.Forms.Button conv1DButton;
        private System.Windows.Forms.Button maxPooling2DButton;
        private System.Windows.Forms.Button maxPolling1DButton;
        private System.Windows.Forms.Button conv2DButton;
        private System.Windows.Forms.RadioButton firstLayerRadioButton;
        private System.Windows.Forms.RadioButton connectionRadioButton;
        private System.Windows.Forms.Button compileButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Panel informationPanel;
    }
}

