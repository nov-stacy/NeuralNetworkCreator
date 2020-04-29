using System;
using System.Drawing;
using System.Windows.Forms;

namespace CourseworkFront
{
    /// <summary>
    /// Класс для создания основного меню, с которым будет работать пользователь
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Запрет на тренировку нейронной сети
        /// </summary>
        public void BlockTrain(object sender, EventArgs e)
        {
            // запрет на тренировку нейронной сети
            startButton.Enabled = false;
            informationPanel.Controls.Clear();
        }

        /// <summary>
        /// Метод для загрузки формы
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // на весь экран
            WindowState = FormWindowState.Maximized;

            // добавление пунктов выбора в настройках
            optimizerBox.DropDownStyle = ComboBoxStyle.DropDownList;
            optimizerBox.Items.AddRange(NeuralNetworkParams.OPTIMIZER);
            metricsBox.Items.AddRange(NeuralNetworkParams.METRICS);
            lossBox.Items.AddRange(NeuralNetworkParams.LOSSES);

            // добавление возможности работать со слоями
            mainPanel.AllowDrop = true;

            // добавление возможности скролить панель
            mainPanel.AutoScroll = true;

            // установление названия нейронной сети в качестве заголовка
            Text = Save.NNetwork.Name;

            // добавление слоев на панель
            foreach (Layer layer in Save.NNetwork.Layers) AddControl(layer.Component);

            // установление параметров
            string[] paramsN = new string[] { Save.NNetwork.Params["optimizer"], Save.NNetwork.Params["metrics"], Save.NNetwork.Params["loss"] };
            optimizerBox.SelectedItem = paramsN[0] == "" ? NeuralNetworkParams.OPTIMIZER[0] : paramsN[0];
            metricsBox.SelectedItem = paramsN[1] == "" ? NeuralNetworkParams.METRICS[0] : paramsN[1];
            lossBox.SelectedItem = paramsN[2] == "" ? NeuralNetworkParams.LOSSES[0] : paramsN[2];

            // отрисовка соединений
            LayersControls.DrawLines(mainPanel, Save.NNetwork.Connections);
        }

        /// <summary>
        /// Метод для добавления компоненты слоя на панель
        /// </summary>
        private void AddControl(Component component)
        {
            mainPanel.Controls.Add(component);
            component.MouseClick += LayerPanel_MouseClick;
            component.LocationChanged += LayerPanel_LocationChanged;
            component.MouseDoubleClick += LayerPanel_MouseDoubleClick;
        }

        /// <summary>
        /// Метод генерации диалога для сохранения нейронной сети
        /// </summary>
        private void SaveNeuralNetworkDialog()
        {
            if (MessageBox.Show("Do you want to save neural network?", "Saving", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SerializationNetwork.WriteToFile();
                MessageBox.Show("Neural network was saved successfully", "Saving", MessageBoxButtons.OK);
            }
            else
            {
                if (!FileNetwork.FileExists(Save.NNetwork.Name, FileNetwork.SAVE_FILE)) FileNetwork.DeleteDirectory(Save.NNetwork.Name);
            }
        }

        /// <summary>
        /// Добавление результатов компиляции нейронной сети на главную форму
        /// </summary>
        private void AddResultCompileToInformation(string text)
        {
            int location = -25; // настройки местоположения
            informationPanel.Controls.Clear();

            // обработка файла построчно
            foreach (string line in text.Split('\n'))
            {
                informationPanel.Controls.Add(new Label
                {
                    Text = line,
                    Width = informationPanel.Width,
                    Location = new Point(0, location += 25),
                });
            }
        }

        /// <summary>
        /// Метод для обработки двойного нажатия на слой (пользователь выбрал слой для соединения или пометки как главного)
        /// </summary>
        private void LayerPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (firstLayerRadioButton.Checked)
                        SelectLayer.SelectFirst((Component)sender);
                    else
                        SelectLayer.Select((Component)sender);
                    BlockTrain(sender, e);
                    break;
            }
        }

        /// <summary>
        /// Метод для обработки нажатия на правую кнопку мыши (удаление слоя)
        /// </summary>
        private void LayerPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && MessageBox.Show("Do you wanna to delete this layer?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // проверка на то, был ли выбран данный слой
                if (SelectLayer.IsSelect((Component)sender)) SelectLayer.ClearSelect();
                // удаление слоя из формы и нейронной сети
                Save.NNetwork.DeleteLayer(((Component)sender).Layer);
                mainPanel.Controls.Remove((Component)sender);
                BlockTrain(sender, e);

                // отрисовка всех соединений между слоями
                LayersControls.DrawLines(mainPanel, Save.NNetwork.Connections);
            }
        }

        /// <summary>
        /// Метод для обработки изменения положения слоя в пространстве
        /// </summary>
        private void LayerPanel_LocationChanged(object sender, EventArgs e)
        {
            // отрисовка всех соединений между слоями
            LayersControls.DrawLines(mainPanel, Save.NNetwork.Connections); 
        }
           
        /// <summary>
        /// Метод для обработки захвати кнопки слоя
        /// </summary>
        private void LayerButton_MouseDown(object sender, MouseEventArgs e)
        {
            // отправка информации о том, какой слой был захвачен
            denseButton.DoDragDrop(((Control)sender).Text, DragDropEffects.Copy); 
        }

        /// <summary>
        /// Метод для обработки перетаскивания слоя на панель
        /// </summary>
        private void MainPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        /// <summary>
        /// Метод для обработки добавления слоя на панель
        /// </summary>
        private void MainPanel_DragDrop(object sender, DragEventArgs e)
        {
            // создание слоя
            Layer layer = Save.NNetwork.AddLayer((string)e.Data.GetData(DataFormats.StringFormat), BlockTrain);

            // настройка слоя
            Control control = layer.Component;
            control.Location = new Point(e.X - mainPanel.Location.X, e.Y - mainPanel.Location.Y);
            AddControl((Component)control);

            BlockTrain(sender, e);
        }

        /// <summary>
        /// Метод для обработки удаления соединения между слоями
        /// </summary>
        private void MainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) return;

            // нахождение соединения, на который нажал пользователь
            Connection connection = ConnectionLine.IsIntersection(Save.NNetwork.Connections, new Point(e.X, e.Y));
            if (connection is null) return;

            DialogResult result = MessageBox.Show("Do you wanna to delete this connection?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // удаление соединения
                connection.ComponentFirst.Layer.NextLayer = null;
                Save.NNetwork.Connections.Remove(connection);
                LayersControls.DrawLines(mainPanel, Save.NNetwork.Connections);
                BlockTrain(sender, e);
            }
        }

        /// <summary>
        /// Метод для обработки нажатия на кнопку компиляции
        /// </summary>
        private void CompileButton_Click(object sender, EventArgs e)
        {
            CompileForm compileForm = new CompileForm();
            if (compileForm.ShowDialog() == DialogResult.OK)
            {
                string text = Save.NNetwork.Compile();
                // проверка на ошибку
                if (text != "")
                {
                    MessageBox.Show("Neural network was compiled successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // добавление результатов на главную форму
                    AddResultCompileToInformation(text);
                    startButton.Enabled = true;
                }
                else
                    MessageBox.Show("There is some errors in neural network", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            compileForm.Dispose();
        }

        /// <summary>
        /// Метод обработки изменения в выборе настроек нейронной сети
        /// </summary>
        private void ParamsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BlockTrain(sender, e);
            Save.NNetwork.AddParams(optimizerBox.Text, lossBox.Text, metricsBox.Text);
        }

        /// <summary>
        /// Метод обработки события закрытия главной формы
        /// </summary>
        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (Visible) SaveNeuralNetworkDialog();
        }

        /// <summary>
        /// Метод обработки события сворачивания и других манипуляций с формой
        /// </summary>
        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            // отрисовка соединений
            LayersControls.DrawLines(mainPanel, Save.NNetwork.Connections);
        }

        /// <summary>
        /// Метод обработки события нажатия на кнопку открытия другого проекта
        /// </summary>
        private void OpenProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Form form = new CreateNameForm();
            form.Closed += (s, args) => Close();
            form.Show();
        }

        /// <summary>
        /// Метод обработки события нажатия на кнопку сохранения проекта
        /// </summary>
        private void SaveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveNeuralNetworkDialog();
        }

        /// <summary>
        /// Метод обработки нажатия на кнопку для запуска обучения модели
        /// </summary>
        private void StartButton_Click(object sender, EventArgs e)
        {
            TrainForm trainForm = new TrainForm();
            if (trainForm.ShowDialog() == DialogResult.OK)
            {
                TrainingInfoForm trainingInfoForm = new TrainingInfoForm();
                trainingInfoForm.ShowDialog();
            }
            trainForm.Dispose();
        }
    }
}
