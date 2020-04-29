using System.Drawing;

namespace CourseworkFront
{
    /// <summary>
    /// Класс для определения поведения программы при соединении пользователем слоев и выбора слоя, с которого начинается нейронная сеть
    /// </summary>
    static class SelectLayer
    {
        /// <summary>
        /// Цвет текста при выборе слоя для соединения
        /// </summary>
        private static readonly Color COLOR_NOT_SELECTED = SystemColors.ControlText;
        /// <summary>
        /// Цвет дефолтного текста
        /// </summary>
        private static readonly Color COLOR_SELECTED = SystemColors.MenuHighlight;
        /// <summary>
        /// Цвет фона при выборе первого слоя нейронной сети
        /// </summary>
        private static readonly Color COLOR_NOT_SELECTED_FIRST = SystemColors.GradientActiveCaption;
        /// <summary>
        /// Цвет дефолтного текста
        /// </summary>
        private static readonly Color COLOR_SELECTED_FIRST = SystemColors.ControlDark;

        /// <summary>
        /// Слой, который был выбран первым для соединения
        /// </summary>
        private static Component selectedLayer = null;

        /// <summary>
        /// Метод для добавления нового соединения между двумя слоями
        /// </summary>
        /// <param name="selectedLayer2">Вторая компонента, которая участвует в соединении</param>
        private static void AddConnection(Component selectedLayer2)
        {
            // проверка на то, что соединения между слоями еще не было
            foreach (Connection connection in Save.NNetwork.Connections)
                if ((connection.ComponentFirst == selectedLayer && connection.ComponentSecond == selectedLayer2) || (connection.ComponentSecond == selectedLayer && connection.ComponentFirst == selectedLayer2)) return;

            // добавление соединения
            Save.NNetwork.Connections.Add(new Connection(selectedLayer, selectedLayer2));
            selectedLayer.Layer.NextLayer = selectedLayer2.Layer;
            // отрисовка соединений после изменения
            LayersControls.DrawLines(selectedLayer.Parent, Save.NNetwork.Connections);
        }

        /// <summary>
        /// Проверка на то, что слой был выбран для соединения
        /// </summary>
        /// <param name="control">Компонента, к которой привязан слой</param>
        /// <returns>Выбрал ли пользователь слой</returns>
        public static bool IsSelect(Component component)
        {
            return component.ForeColor == COLOR_SELECTED;
        }

        /// <summary>
        /// Метод, который вызывается, когда пользователь выбрал слой для соединения
        /// </summary>
        /// <param name="sender">Компонента, которую выбрал пользователь</param>
        public static void Select(Component component)
        {
            // проверка на то, что слой был уже выбран (пользователь отменил выбор)
            if (!IsSelect(component))
            {
                component.ForeColor = COLOR_SELECTED;
                // проверка на то, является ли выбранный слой первым или вторым
                if (selectedLayer == null)
                {
                    selectedLayer = component;
                    return;
                }
                AddConnection(component);
            }
            component.ForeColor = COLOR_NOT_SELECTED;
            ClearSelect();
        }

        /// <summary>
        /// Метод для очистки выбора пользователя
        /// </summary>
        public static void ClearSelect()
        {
            selectedLayer.ForeColor = COLOR_NOT_SELECTED;
            selectedLayer = null;
        }

        /// <summary>
        /// Метод для выбора первого слоя в нейронной сети
        /// </summary>
        /// <param name="component">Компонента, которую выбрал пользователь</param>
        public static void SelectFirst(Component component)
        {
            Layer firstLayer = Save.NNetwork.Layers.Find(layer => layer.Component == component);

            // если первый слой был уже выбран ранее
            if (Save.NNetwork.FirstLayer != null)
                Save.NNetwork.FirstLayer.Component.BackColor = COLOR_NOT_SELECTED_FIRST;

            Save.NNetwork.FirstLayer = firstLayer;
            Save.NNetwork.FirstLayer.Component.BackColor = COLOR_SELECTED_FIRST;
        }
    }
}
