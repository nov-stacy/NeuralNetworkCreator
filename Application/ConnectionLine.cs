using System;
using System.Collections.Generic;
using System.Drawing;

namespace CourseworkFront
{
    /// <summary>
    /// Класс, описывающий соединение между слоями, как нарисованную линию
    /// </summary>
    class ConnectionLine
    {
        /// <summary>
        /// Метод для получения уравнения kx+b, описывающего соединение
        /// </summary>
        /// <returns>Список параметров уравнения {k, b}</returns>
        private static float[] MakeLine(Connection connection)
        {
            Point[] points = GetLocation(connection);
            float k = (points[0].Y - points[1].Y) / (float)(points[0].X - points[1].X);
            float b = points[0].Y - k * points[0].X;
            return new float[2] { k, b };
        }

        /// <summary>
        /// Получение координаты соединения
        /// </summary>
        /// <param name="point">Координаты компоненты</param>
        /// <param name="size">Размер компоненты</param>
        private static Point GeneratePoint(Point point, Size size)
        {
            int x = point.X + size.Width / 2;
            int y = point.Y + size.Height / 2;
            return new Point(x, y);
        }

        /// <summary>
        /// Проверка на то, принадлежит ли точка соединению
        /// </summary>
        /// <param name="point">Ссылка на точку</param>
        private static bool IsOnLine(Connection connection, Point point)
        {
            float[] ParamsLine = MakeLine(connection); // получение уравнения соединения
            float Y1 = ParamsLine[0] * point.X + ParamsLine[1];
            if (Math.Abs(point.Y - Y1) <= 5) return true;
            return false;
        }

        /// <summary>
        /// Получение расположения соединения на поле
        /// </summary>
        /// <returns>Список координат</returns>
        public static Point[] GetLocation(Connection connection)
        {
            return new Point[2]{
                GeneratePoint(connection.ComponentFirst.Location, connection.ComponentFirst.Size),
                GeneratePoint(connection.ComponentSecond.Location, connection.ComponentSecond.Size),
            };
        }

        /// <summary>
        /// Получение соединения, к прямой которого принадлежит точка
        /// </summary>
        /// <param name="connections">Список соединений</param>
        /// <param name="point">Точка</param>
        public static Connection IsIntersection(List<Connection> connections, Point point)
        {
            foreach (Connection connection in connections)
                if (IsOnLine(connection, point)) return connection;
            return null;
        }
    }
}
