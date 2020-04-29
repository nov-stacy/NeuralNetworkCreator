namespace CourseworkFront
{
    /// <summary>
    /// Класс, описывающий соединение между слоями
    /// </summary>
    class Connection
    {
        /// <summary>
        /// Ссылка на слой, из которого исходит соединение
        /// </summary>
        public Component ComponentFirst { get; private set; } = null;

        /// <summary>
        /// Ссылка на слой, в который входит соедиение
        /// </summary>
        public Component ComponentSecond { get; private set; } = null;

        public Connection(Component first, Component second) { ComponentFirst = first; ComponentSecond = second; }
    }
}
