using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace CourseworkFront
{
    /// <summary>
    /// Класс для определения поведения программы при сохранении нейронной сети
    /// </summary>
    class SerializationNetwork
    {
        /// <summary>
        /// Метод для конвертации списка слоев в список словарей
        /// </summary>
        private static List<Dictionary<string, object>> LayersToDict()
        {
            List<Dictionary<string, object>> layers = new List<Dictionary<string, object>>();
            foreach (Layer layer in Save.NNetwork.Layers)
            {
                Dictionary<string, object> dictLayer = new Dictionary<string, object>
                {
                    { "Type", layer.Type },
                    { "Params", layer.GetParams() },
                    { "NextLayer", Save.NNetwork.Layers.FindIndex(l => l ==layer.NextLayer) },
                    { "Location.X", layer.Component.Location.X },
                    { "Location.Y", layer.Component.Location.Y }
                };
                layers.Add(dictLayer);
            }
            return layers;
        }

        /// <summary>
        /// Метод для конвертации списка соединений в список словарей
        /// </summary>
        /// <returns></returns>
        private static List<Dictionary<string, object>> ConnectionsToDict()
        {
            List<Dictionary<string, object>> connections = new List<Dictionary<string, object>>();
            foreach (Connection connection in Save.NNetwork.Connections)
            {
                Dictionary<string, object> dictConnections = new Dictionary<string, object>
                {
                    { "First", Save.NNetwork.Layers.FindIndex(l => l == connection.ComponentFirst.Layer) },
                    { "Second", Save.NNetwork.Layers.FindIndex(l => l == connection.ComponentSecond.Layer) }
                }; ;
                connections.Add(dictConnections);
            }
            return connections;
        }

        /// <summary>
        /// Метод для конвертации нейронной сети в JSON формат
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, object> NetworkToDict()
        {
            return new Dictionary<string, object>
            {
                { "InputShape", new List<int>(Save.NNetwork.InputShape) },
                { "FirstLayer", Save.NNetwork.Layers.FindIndex(l => l == Save.NNetwork.FirstLayer) },
                { "Params", Save.NNetwork.Params },
                { "Layers", LayersToDict() },
                { "Connections", ConnectionsToDict() }
            };
        }

        /// <summary>
        /// Метод для конвертации списка словарей в список слоев
        /// </summary>
        private static void DictToLayers(List<Dictionary<string, object>> dictionary, EventHandler eventHandler)
        {
            // определение параметров каждого слоя
            foreach (Dictionary<string, object> dictLayer in dictionary)
            {
                Layer layer = Save.NNetwork.AddLayer((string)dictLayer["Type"], eventHandler);
                layer.SetParams(((JObject)dictLayer["Params"]).ToObject<Dictionary<string, object>>());
                layer.Component.Location = new Point((int)(long)dictLayer["Location.X"], (int)(long)dictLayer["Location.Y"]);
            }

            // определение следующего слоя для каждого
            for (int index = 0; index < Save.NNetwork.Layers.Count; index++)
            {
                int indexNext = (int)(long)dictionary[index]["NextLayer"];
                if (indexNext != -1) Save.NNetwork.Layers[index].NextLayer = Save.NNetwork.Layers[indexNext];
            }
        }
                
        /// <summary>
        /// Метод для конвертации списка словарей в список соединений
        /// </summary>
        private static void DictToConnection(List<Dictionary<string, object>> dictionary)
        {
            foreach (Dictionary<string, object> connection in dictionary)
                Save.NNetwork.Connections.Add(new Connection(Save.NNetwork.Layers[(int)(long)connection["First"]].Component, Save.NNetwork.Layers[(int)(long)connection["Second"]].Component));
        }

        /// <summary>
        /// Метод для конвертации словаря в нейронну сеть
        /// </summary>
        /// <param name="name">Название нейронной сети</param>
        private static void DictToNetwork(string name, Dictionary<string, object> dictionary, EventHandler eventHandler)
        {
            // определение названия нейронной сети
            Save.NNetwork = new NeuralNetwork(name);

            // определение входных данных
            Save.NNetwork.InputShape[0] = ((JArray)dictionary["InputShape"]).ToObject<List<int>>()[0];
            Save.NNetwork.InputShape[1] = ((JArray)dictionary["InputShape"]).ToObject<List<int>>()[1];

            // определение параметров нейронной сети
            Dictionary<string, object> paramsN = ((JObject)dictionary["Params"]).ToObject<Dictionary<string, object>>();
            foreach (string key in paramsN.Keys) Save.NNetwork.Params[key] = (string)paramsN[key];

            // определение слоев и соединений нейронных сетей
            DictToLayers(((JArray)dictionary["Layers"]).ToObject<List<Dictionary<string, object>>>(), eventHandler);
            DictToConnection(((JArray)dictionary["Connections"]).ToObject<List<Dictionary<string, object>>>());

            // определение первого слоя нейронной сети
            int index = (int)(long)dictionary["FirstLayer"];
            if (index != -1) SelectLayer.SelectFirst(Save.NNetwork.Layers[index].Component);
        }

        /// <summary>
        /// Метод для сохранения нейронной сети в файл
        /// </summary>
        public static void WriteToFile()
        {
            string filename = FileNetwork.GetFile(Save.NNetwork.Name, FileNetwork.SAVE_FILE, true);
            string bin = JsonConvert.SerializeObject(NetworkToDict());
            FileNetwork.WriteToFile(filename, bin);
        }

        /// <summary>
        /// Метод для получения нейронной сети из файла
        /// </summary>
        /// <param name="name">Название нейронной сети</param>
        public static void ReadFromFile(string name, EventHandler eventHandler)
        {
            string filename = FileNetwork.GetFile(name, FileNetwork.SAVE_FILE);
            string bin = FileNetwork.ReadFromFile(filename);
            DictToNetwork(name, JsonConvert.DeserializeObject<Dictionary<string, object>>(bin), eventHandler);
        }
    }
}
