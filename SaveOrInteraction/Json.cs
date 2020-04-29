using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CourseworkFront
{
    /// <summary>
    /// Класс для реализации слоя, который будет конвертироваться в json
    /// </summary>
    class JsonLayer
    {
        public JsonLayer(string type, Dictionary<string, object> layerParams) 
        { 
            this.type = type; 
            this.layerParams = layerParams; 
        }

        /// <summary>
        /// Тип слоя
        /// </summary>
        public string type;

        /// <summary>
        /// Параметры слоя
        /// </summary>
        [JsonProperty("params")]
        public Dictionary<string, object> layerParams;
    }

    /// <summary>
    /// Класс для реализации нейронной сети, которая будет конвертироваться в json
    /// </summary>
    class JsonNeuralNetwork
    {
        public JsonNeuralNetwork(List<JsonLayer> layers, Dictionary<string, string> nParams, string typeSupervised, string typeData) 
        { 
            this.layers = layers;
            this.typeSupervised = typeSupervised;
            this.typeData = typeData;
            neuralNetworkParams = nParams; 
        }

        /// <summary>
        /// Параметры нейронной сети
        /// </summary>
        [JsonProperty("params")]
        public Dictionary<string, string> neuralNetworkParams;
        
        /// <summary>
        /// Список слоев, из которых состоит нейронная сеть
        /// </summary>
        public List<JsonLayer> layers;

        [JsonProperty("data_type")]
        public string typeData;

        [JsonProperty("type")]
        public string typeSupervised;
    }

    /// <summary>
    /// Класс для реализации конвертации нейронной сети в json формат
    /// </summary>
    class ConvertJson
    {
        /// <summary>
        /// Метод для изменения параметров первого слоя (добавление параметра input_shape, который пользователь вводит позже)
        /// </summary>
        /// <param name="firstLayer">Ссылка на первый слой</param>
        /// <returns>Список новых параметров первого слоя</returns>
        private static Dictionary<string, object> GetParamsFirstLayer(Layer firstLayer)
        {
            // копия словаря с параметрами, чтобы не изменять исходные
            Dictionary<string, object> firstLayerParams = firstLayer.GetParams().ToDictionary(entry => entry.Key, entry => entry.Value);
            // добавление input_shape как списка
            firstLayerParams.Add("input_shape", Save.NNetwork.InputShape[1] == 0 ? new int[] { Save.NNetwork.InputShape[0] } : Save.NNetwork.InputShape);

            return firstLayerParams;
        }

        /// <summary>
        /// Метод для конвертации нейронной сети в json
        /// </summary>
        /// <param name="nnetwork">ссылка на нейронную сеть</param>
        /// <returns>Полный путь на файл json</returns>
        public static string NetworkToJson(NeuralNetwork nnetwork)
        {
            if (nnetwork.FirstLayer == null) return ""; // проверка на наличие слоев
            if (nnetwork.TypeSupervised == null || nnetwork.TypeData == null) return "";

            // создание списка слоев и работа с первым, так как необходимо добавить ему параметр
            Layer layer = nnetwork.FirstLayer;
            List<JsonLayer> layers = new List<JsonLayer>
            {
                new JsonLayer(layer.Type, GetParamsFirstLayer(layer))
            };
            layer = layer.NextLayer;

            // добавление всех слоев нейронной сети через соединения
            while (layer != null && layer.NextLayer != nnetwork.FirstLayer)
            {
                layers.Add(new JsonLayer(layer.Type, layer.GetParams()));
                layer = layer.NextLayer;
            }

            // проверка на то, что все слои участвуют в нейронной сети
            if (layers.Count != nnetwork.Layers.Count) return "";

            // конвертация в json
            string filename = FileNetwork.GetFile(nnetwork.Name, FileNetwork.JSON_FILE, true);
            string json = JsonConvert.SerializeObject(new JsonNeuralNetwork(layers, nnetwork.Params, nnetwork.TypeSupervised, nnetwork.TypeData));
            FileNetwork.WriteToFile(filename, json);
            return json;
        }
    }
}
