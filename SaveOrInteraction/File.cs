using System.IO;

namespace CourseworkFront
{
    /// <summary>
    /// Класс для работы с файловой системой
    /// </summary>
    class FileNetwork
    {
        /// <summary>
        /// Имя файла, куда сохраняется нейронная сеть
        /// </summary>
        public static readonly string SAVE_FILE = "save.bin";
        /// <summary>
        /// Имя файла, куда загружается нейронная сеть для отправки на сервер
        /// </summary>
        public static readonly string JSON_FILE = "model.json";
        /// <summary>
        /// Путь до главной директории, где хранятся все нейронные сети
        /// </summary>
        private static readonly string MAIN_DIRECTORY = "../Files/";

        /// <summary>
        /// Получение директории, где находится нейронная сеть
        /// </summary>
        /// <param name="name">Название нейронной сети</param>
        /// <returns>Относительный путь до директории</returns>
        private static string GetDirectory(string name)
        {
            if (!Directory.Exists(MAIN_DIRECTORY)) Directory.CreateDirectory(MAIN_DIRECTORY);
            return MAIN_DIRECTORY + name + "/";
        }

        /// <summary>
        /// Создание директории для нейронной сети
        /// </summary>
        /// <param name="name">Название нейронной сети</param>
        public static void CreateDirectory(string name)
        {
            Directory.CreateDirectory(GetDirectory(name));
        }

        /// <summary>
        /// Проверка на сущестование директории для нейронной сети
        /// </summary>
        /// <param name="name">Название нейронной сети</param>
        /// <returns>Наличие папки с названием нейроной сети в главной директории</returns>
        public static bool DirectoryExists(string name)
        {
            return Directory.Exists(GetDirectory(name));
        }

        /// <summary>
        /// Проверка на сущестование файла
        /// </summary>
        /// <param name="name">Название нейронной сети</param>
        /// <param name="fileName">Название файла</param>
        /// <returns>Наличие файла в директории нейронной сети</returns>
        public static bool FileExists(string name, string fileName)
        {
            return File.Exists(GetDirectory(name) + fileName);
        }

        /// <summary>
        /// Создание файла, в котором будет описываться нейронная сеть
        /// </summary>
        /// <param name="name">Название нейронной сети</param>
        /// <param name="fileName">Название файла</param>
        /// <param name="isCreate">Нужно получить путь до файла или создать его</param>
        /// <returns>Путь к файлу json</returns>
        public static string GetFile(string name, string fileName, bool isCreate = false)
        {
            string path = GetDirectory(name) + fileName;
            if (isCreate) using (FileStream SourceStream = File.Create(path)) { }
            return path;
        }

        /// <summary>
        /// Получение списка всех директорий из главной папки (названий всех нейронных сетей)
        /// </summary>
        public static string[] GetDirectories()
        {
            if (!Directory.Exists(MAIN_DIRECTORY)) Directory.CreateDirectory(MAIN_DIRECTORY);
            string[] directories = Directory.GetDirectories(MAIN_DIRECTORY);

            // так как пути были получены вместе с главным, то нужно отредактировать пути
            for (int index = 0; index < directories.Length; index++)
                directories[index] = directories[index].Replace(MAIN_DIRECTORY, "");

            return directories;
        }

        /// <summary>
        /// Удаление директории
        /// </summary>
        /// <param name="name">Название нейронной сети</param>
        public static void DeleteDirectory(string name)
        {
            if (!DirectoryExists(name)) return;
            Directory.Delete(GetDirectory(name), true);
        }

        /// <summary>
        /// Запись в файл
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        /// <param name="text">Строка, которую надо добавить в файл</param>
        public static void WriteToFile(string fileName, string text)
        { 
            using (StreamWriter file = new StreamWriter(fileName))
            {
                file.WriteLine(text.ToString());
            }
        }

        /// <summary>
        /// Чтение из файла
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        /// <returns>Строка, которая была получена после прочтения файла</returns>
        public static string ReadFromFile(string fileName)
        {
            string text = "";
            using (StreamReader file = new StreamReader(fileName))
            {
                text = file.ReadToEnd();
            }
            return text;
        }

        /// <summary>
        /// Получение полного пути к файлу
        /// </summary>
        /// <param name="fileName">Относительный путь к файлу</param>
        public static string GetFullPath(string fileName)
        {
            return Path.GetFullPath(fileName);
        }

        /// <summary>
        /// Копирование файла
        /// </summary>
        /// <param name="name">Название нейронной сети</param>
        /// <param name="path">Полный путь до файла</param>
        /// <returns></returns>
        public static string Copy(string name, string path)
        {
            if (!File.Exists(path)) return "";
            string[] split = path.Split('\\');
            string nameFile = split[split.Length - 1];
            string newPath = GetDirectory(name) + "\\" + nameFile;
            if (File.Exists(newPath)) File.Delete(newPath);
            File.Copy(path, newPath);
            return newPath;
        }
    }
}
