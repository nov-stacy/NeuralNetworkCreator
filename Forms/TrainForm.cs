using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CourseworkFront
{
    /// <summary>
    /// Класс для создания формы выбора тренировочного датасета и настроек тренировки нейронной сети
    /// </summary>
    public partial class TrainForm : Form
    {
        public TrainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Чтение из файла csv
        /// </summary>
        /// <param name="filePath">Путь до файла</param>
        private DataTable ReadCSV(string filePath)
        {
            DataTable dt = new DataTable();

            File.ReadLines(filePath).Take(1)
                .SelectMany(x => x.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                .ToList()
                .ForEach(x => dt.Columns.Add(x.Trim()));

            return dt;
        }

        /// <summary>
        /// Метод для обработки нажатия на кнопку выбора датасета
        /// </summary>
        private void OpenFilebutton_Click(object sender, System.EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "csv files (*.csv)|*.csv";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Open dataset";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileLabel.Text = openFileDialog.FileName;
                    webBrowser.DocumentText = Client.OpenCSV(fileLabel.Text);
                    targetBox.Items.Clear();
                    var columns = ReadCSV(fileLabel.Text).Columns;
                    if (columns.Count >= 100)
                        targetBox.DropDownStyle = ComboBoxStyle.DropDown;
                    else
                    {
                        foreach (DataColumn column in columns) targetBox.Items.Add(column.ColumnName);
                        targetBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                }
            }
        }

        /// <summary>
        /// Метод для обработки нажатия на кнопку обучения
        /// </summary>
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (fileLabel.Text == "")
                MessageBox.Show("There is some errors", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string json = FileNetwork.ReadFromFile(FileNetwork.GetFile(Save.NNetwork.Name, "model.json"));
                string result = Client.StartTrain(json, fileLabel.Text, targetBox.Text, (int)epochNumericUpDown.Value, (float)trainRateNumericUpDown.Value, (int)batchNumericUpDown.Value);
                if (result.Contains(".py"))
                {
                    string path = FileNetwork.Copy(Save.NNetwork.Name, result);
                    if (path != "")
                        MessageBox.Show("Program has been generated. Results has been saved to " + FileNetwork.GetFullPath(path), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Training has been started", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                    MessageBox.Show("There is some errors in neural network", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
