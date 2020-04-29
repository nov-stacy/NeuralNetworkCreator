using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CourseworkFront
{
    /// <summary>
    /// Класс для работы с бэкендом (localhost сервером) приложения
    /// </summary>
    class Client
    {
        /// <summary>
        /// Путь до сервера
        /// </summary>
        private static readonly string url = "http://127.0.0.1:5000";

        /// <summary>
        /// Отправка запроса к серверу и получения ответа
        /// </summary>
        /// <param name="typeEvent">Тип запроса (компиляция, тренировка)</param>
        /// <param name="paramsDict">Параметры запросы</param>
        /// <returns></returns>
        private static string Request(string typeEvent, Dictionary<string, object> paramsDict=null)
        {
            // обработка параметров
            string paramsString = "?";
            if (paramsDict != null)
                foreach (string name in paramsDict.Keys) paramsString += string.Format("{0}={1}&", name, paramsDict[name]);
            paramsString = paramsString.Remove(paramsString.Length - 1);

            // отправка запроса
            WebRequest request = WebRequest.Create(url + "/" + typeEvent + paramsString);
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                // получение результатов
                WebResponse response = request.GetResponse();
                string responseFromServer;
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    responseFromServer = reader.ReadToEnd();
                }
                response.Close();
                return responseFromServer;
            }
            catch (WebException) // ошибка при запросе
            {
                return "";
            }
        }

        /// <summary>
        /// Запрос на открытие csv файла и получение первых данных
        /// </summary>
        /// <param name="dataPath">Путь до файла, который отправляется</param>
        /// <returns>Ссылка на изображение</returns>
        public static string OpenCSV(string dataPath)
        {
            return Request("open", new Dictionary<string, object> { { "data", dataPath } });
        }

        /// <summary>
        /// Запрос на комплиляцию нейронной сети (проверка ее корректности)
        /// </summary>
        /// <param name="json">Строка в формате json (данные о нейронной сети)</param>
        /// <returns>Текст с основными данными по параметрам нейронной сети</returns>
        public static string GetCompile(string json)
        {
            string key = Environment.UserName + "/" + Save.NNetwork.Name;
            return Request(key + "/compile", new Dictionary<string, object> { { "network", json } });
        }

        /// <summary>
        /// Запрос на обучение нейронной сети
        /// </summary>
        /// <param name="json">Строка в формате json (данные о нейронной сети)</param>
        /// <param name="dataPath">Путь до файла с данными</param>
        /// <param name="target">Значение, которое необходимо находить</param>
        /// <param name="epochs">Количество эпох обучение</param>
        /// <param name="trainRate">Доля данных, на которых надо обучаться (остальное на валидацию)</param>
        /// <param name="batchSize">Размер батча</param>
        /// <returns>Ссылка на сгенерированный код</returns>
        public static string StartTrain(string json, string dataPath, string target, int epochs, float trainRate, int batchSize)
        {
            string key = Environment.UserName + "/" + Save.NNetwork.Name;
            return Request(key + "/start_train", new Dictionary<string, object> {
                { "network", json },
                { "data", dataPath }, 
                { "target", target }, 
                { "epochs", epochs }, 
                { "rate", trainRate.ToString().Replace(',', '.') },
                { "batch_size", batchSize }
            });
        }

        /// <summary>
        /// Запрос на получение результатов метрик во время обучения
        /// </summary>
        /// <param name="name">Название метрики</param>
        /// <returns>Ссылка на график или если обучение закончилось - ссылка на веса</returns>
        public static string GetMetrics(string name)
        {
            string key = Environment.UserName + "/" + Save.NNetwork.Name;
            return Request(key + "/get_" + name);
        }

        /// <summary>
        /// Запрос на окончание тренировки нейронной сети
        /// </summary>
        public static void CloseTrain()
        {
            Request(Environment.UserName + "/" + Save.NNetwork.Name + "/close_train");
        }
    }
}
