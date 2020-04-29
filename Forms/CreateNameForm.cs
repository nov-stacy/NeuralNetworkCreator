using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections.Generic;

namespace CourseworkFront
{
    /// <summary>
    /// Класс для создания формы главного меню приложения (создания или загрузки нейронной сети)
    /// </summary>
    public partial class CreateNameForm : Form
    {
        public CreateNameForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для загрузки формы
        /// </summary>
        private void CreateNameForm_Load(object sender, EventArgs e)
        {
            directoriesPanel.AutoScroll = true;
            CreateNetworksList();
        }

        /// <summary>
        /// Метод для открытия основной формы
        /// </summary>
        private void OpenMainForm(object sender)
        {
            Hide();
            MainForm form = new MainForm();
            if (sender != null) SerializationNetwork.ReadFromFile(((Button)sender).Text, form.BlockTrain);
            form.Closed += (s, args) => Close();
            form.Show();
        }

        /// <summary>
        /// Метод для создания списка уже созданных нейронных сетей
        /// </summary>
        private void CreateNetworksList()
        {
            directoriesPanel.Controls.Clear();
            string[] directories = FileNetwork.GetDirectories();

            // настройки местоположения
            int location = -40, decrease = directories.Length <= 3 ? 2 : 20; 

            foreach (string directory in directories)
            {
                Button button = new Button
                {
                    Width = directoriesPanel.Width - decrease,
                    Height = 40,
                    Location = new Point(0, location += 40),
                    Text = directory
                };
                button.MouseDown += DirectoryButton_Click;
                directoriesPanel.Controls.Add(button);
            }
        }

        /// <summary>
        /// Метод для обработки события нажатия на кнопку ОК (пользователь ввел название новой нейронной сети)
        /// </summary>
        private void OkButton_Click(object sender, EventArgs e)
        {
            string text = inputNameTextBox.Text;
            // проверка на принадлежность правилам для имени нейронной сети
            if (text.Length == 0 || char.IsNumber(text[0]) || !new Regex(@"^[a-zA-Z0-9_]+$").IsMatch(text))
                MessageBox.Show("Error in name. You can use only english latters, numbers or _", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // проверка на то, что данная нейронная сеть уже была создана
            else if (FileNetwork.DirectoryExists(text))
                MessageBox.Show("This neural network is already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // создание нейронной сети
                FileNetwork.CreateDirectory(text);
                Save.NNetwork = new NeuralNetwork(text);
                MessageBox.Show("Network was created successfully", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OpenMainForm(null);
            }
        }

        /// <summary>
        /// Метод, который обрабатывает событие нажатия на кнопку с названием нейронной сети (загрузка или удаление)
        /// </summary>
        private void DirectoryButton_Click(object sender, MouseEventArgs e)
        {
            // проверка принадлежности кнопки, которая была нажата на мыши
            switch (e.Button)
            {
                case MouseButtons.Right:
                    // удаление нейронной сети
                    if (MessageBox.Show("Do you wanna to delete this neural network?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FileNetwork.DeleteDirectory(((Button)sender).Text);
                        CreateNetworksList();
                    }
                    break;
                case MouseButtons.Left:
                    OpenMainForm(sender);
                    break;
            }
        }
    }
}
