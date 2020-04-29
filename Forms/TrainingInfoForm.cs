using System;
using System.Threading;
using System.Windows.Forms;

namespace CourseworkFront
{
    /// <summary>
    /// Класс для создания формы с выводом результатов тренировки нейронной сети
    /// </summary>
    public partial class TrainingInfoForm : Form
    {
        /// <summary>
        /// Поток, в котором идет отдельный вывод графика по тренировке
        /// </summary>
        private Thread thread_1, thread_2;

        /// <summary>
        /// Проверка на то, закончилось ли обучение
        /// </summary>
        private bool isEnd = false;

        public TrainingInfoForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Получение и вывод графика по loss во время тренировки нейронной сети
        /// </summary>
        private void WriteLoss()
        {
            string lossPath = "";

            while (true)
            {
                string result = Client.GetMetrics("loss");
                if (result.Contains(".zip")) break;
                if (result != "")
                {
                    lossPath = result;
                    lossPictureBox.ImageLocation = result;
                }
                Thread.Sleep(1000);
            }

            // сохранение результатов
            while(!isEnd) Thread.Sleep(500);
            string newPath = FileNetwork.Copy(Save.NNetwork.Name, lossPath);
            if (newPath != "")
                MessageBox.Show("Loss graph has been saved to " + FileNetwork.GetFullPath(newPath), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Получение и вывод графика по accuracy во время тренировки нейронной сети
        /// </summary>
        private void WriteAccuracy()
        {
            string programPath, accuracyPath = "";

            while (true)
            {
                string result = Client.GetMetrics("accuracy");
                if (result.Contains(".zip"))
                {
                    programPath = result;
                    break;
                }
                if (result != "")
                {
                    accuracyPath = result;
                    accuracyPictureBox.ImageLocation = result;
                }
                Thread.Sleep(1000);
            }
            MessageBox.Show("Neural network training has ended", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isEnd = true;

            // сохранение результатов
            string newPath = FileNetwork.Copy(Save.NNetwork.Name, programPath);
            if (newPath != "")
                MessageBox.Show("Weights has been saved to " + FileNetwork.GetFullPath(newPath), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            newPath = FileNetwork.Copy(Save.NNetwork.Name, accuracyPath);
            if (newPath != "")
                MessageBox.Show("Accuracy graph has been saved to " + FileNetwork.GetFullPath(newPath), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Метод для загрузки формы
        /// </summary>
        private void TrainingInfoForm_Load(object sender, EventArgs e)
        {
            // запуск потоков
            thread_1 = new Thread(WriteLoss);
            thread_2 = new Thread(WriteAccuracy);
            thread_1.Start();
            thread_2.Start();
        }

        /// <summary>
        /// Метод закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrainingInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // остановка потоков
            thread_1.Abort();
            thread_2.Abort();
            thread_1.Join();
            thread_2.Join();
            Client.CloseTrain();
        }
    }
}
