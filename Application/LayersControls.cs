using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace CourseworkFront
{
    /// <summary>
    /// Класс для создания собственных компонентов управления
    /// </summary>
    static class LayersControls
    {
        /// <summary>
        /// Создание поля с названием слоя
        /// </summary>
        /// <param name="text">Название</param>
        /// <param name="location">Местоположение</param>
        /// <returns>Поле</returns>
        public static Label GetLabel(string text, Point location)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Location = location
            };
        }

        /// <summary>
        /// Создание поля с выбором значения
        /// </summary>
        /// <param name="choose">Значения, из которых можно выбрать</param>
        /// <param name="location">Местоположение</param>
        /// <returns></returns>
        public static ComboBox GetComboBox(string[] choose, Point location, EventHandler eventHandler)
        {
            ComboBox comboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Size = new Size(100, 45),
                Location = location
            };
            comboBox.Items.AddRange(choose);
            comboBox.SelectedIndex = 0;
            comboBox.SelectedValueChanged += eventHandler;
            return comboBox;
        }

        /// <summary>
        /// Создание поля с вводом числа
        /// </summary>
        /// <param name="location">Местоположение</param>
        /// <returns>Поле</returns>
        private static NumericUpDown GetNumericUpDown(Point location, Size size, EventHandler eventHandler)
        {
            NumericUpDown numericUpDown = new NumericUpDown
            {
                Size = size == null ? new Size(100, 45) : size,
                Location = location
            };
            numericUpDown.ValueChanged += eventHandler;
            return numericUpDown;
        }

        /// <summary>
        /// Создание поля с вводом целочисленного числа
        /// </summary>
        /// <param name="location">Местоположение</param>
        /// <returns>Поле</returns>
        public static NumericUpDown GetIntNumericUpDown(Point location, Size size, EventHandler eventHandler)
        {
            NumericUpDown numericUpDown = GetNumericUpDown(location, size, eventHandler);
            numericUpDown.Maximum = 1000;
            return numericUpDown;
        }

        /// <summary>
        /// Создание поля с вводом числа в плавающей точкой [0, 1]
        /// </summary>
        /// <param name="location">Местоположение</param>
        /// <returns>Поле</returns>
        public static NumericUpDown GetFloatNumericUpDown(Point location, Size size, EventHandler eventHandler)
        {
            NumericUpDown numericUpDown = GetNumericUpDown(location, size, eventHandler);
            numericUpDown.Maximum = 1;
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Increment = 0.1M;
            return numericUpDown;
        }

        /// <summary>
        /// Метод для отрисовки на линии половины другого цвета, чтобы обозначить в какую сторону идет направление
        /// </summary>
        /// <param name="graphics">Поверхность рисования</param>
        /// <param name="pen">Ручка для рисования</param>
        /// <param name="points">Точки начала и конца линии</param>
        private static void DrawArrow(Graphics graphics, Pen pen, Point[] points)
        {
            // нахождение середины
            Point point = new Point((points[0].X + points[1].X) / 2, (points[0].Y + points[1].Y) / 2);
            // отрисовка
            pen.Color = Color.Blue;
            graphics.DrawLine(pen, points[0], point);
            pen.Color = Color.Black;
        }

        /// <summary>
        /// Метод для отрисовки соединений между слоями
        /// </summary>
        /// <param name="panel">Компонента, на которой необходимо нарисовать</param>
        /// <param name="connections">Список соединений</param>
        public static void DrawLines(Control panel, List<Connection> connections)
        {
            using (Graphics graphics = panel.CreateGraphics())
            {
                graphics.Clear(panel.BackColor); // очистка экрана
                Pen pen = new Pen(Color.Black, 4);

                foreach (Connection connection in connections)
                {
                    Point[] points = ConnectionLine.GetLocation(connection);
                    graphics.DrawLine(pen, points[0], points[1]); // отрисовка линии
                    DrawArrow(graphics, pen, points); // отрисока направления
                }
            }
        }
    }
}
