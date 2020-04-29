using System;
using System.Windows.Forms;

namespace CourseworkFront
{
    /// <summary>
    /// Класс для создания формы компиляции (выбора количество входных слоев)
    /// </summary>
    public partial class CompileForm : Form
    {
        public CompileForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для получения типа  обучения (классификация или регрессия)
        /// </summary>
        private string GetSupervisedType()
        {
            if (classificationRadioButton.Checked) return "classification";
            if (regressionRadioButton.Checked) return "regression";
            return null;
        }

        /// <summary>
        /// Получение вида данных
        /// </summary>
        private string GetDataType()
        {
            if (matrixRadioButton.Checked) return "matrix";
            if (textRadioButton.Checked) return "text";
            if (imageRadioButton.Checked) return "image";
            return null;
        }

        /// <summary>
        /// Метод для загрузки формы
        /// </summary>
        private void CompileForm_Load(object sender, EventArgs e)
        {
            if (Save.NNetwork.InputShape[1] != 0)
            {
                d2NumericUpDown.Enabled = true;
                d2RadioButton.Checked = true;
                d2NumericUpDown.Value = Save.NNetwork.InputShape[1];
            }
            d1NumericUpDown.Value = Save.NNetwork.InputShape[0];
        }

        /// <summary>
        /// Метод для обработки события выбора 1D входящие данные
        /// </summary>
        private void D1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // отключение 2D набора
            d2NumericUpDown.Value = 0;
            d2NumericUpDown.Enabled = false;
        }

        /// <summary>
        /// Метод для обработки события выбора 2D входящие данные
        /// </summary>
        private void D2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            d2NumericUpDown.Enabled = true; // включение 2D набора
        }

        /// <summary>
        /// Метод для обработки события нажатия на кнопки компиляции
        /// </summary>
        private void OkButton_Click(object sender, EventArgs e)
        {
            Save.NNetwork.InputShape[0] = (int)d1NumericUpDown.Value;
            Save.NNetwork.InputShape[1] = (int)d2NumericUpDown.Value;
            Save.NNetwork.TypeData = GetDataType();
            Save.NNetwork.TypeSupervised = GetSupervisedType();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
