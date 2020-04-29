using System;
using System.Collections.Generic;


namespace CourseworkFront
{
    /// <summary>
    /// Класс, описывающий настройки нейронной сети (типы и значения параметров)
    /// </summary>
    class NeuralNetworkParams
    {
        /// <summary>
        /// Список метрик, которые могут быть в нейронной сети
        /// </summary>
        public static readonly string[] METRICS = { 
            "accuracy", "binary_accuracy", "categorical_accuracy", "cosine_proximity", "mae", "mse", 
            "sparse_categorical_accuracy", "sparse_top_k_categorical_accuracy", "top_k_categorical_accuracy"
        };

        /// <summary>
        /// Список оптимизационных функций, которые могут быть в нейронной сети
        /// </summary>
        public static readonly string[] OPTIMIZER = { 
            "adadelta", "adagrad", "adam", "adamax", "nadam", "rmsprop", "sgd" 
        };

        /// <summary>
        /// Список функий потерь, которые могут быть в нейронной сети
        /// </summary>
        public static readonly string[] LOSSES = {
            "binary_crossentropy", "categorical_crossentropy", "categorical_hinge", "cosine_proximity", 
            "hinge", "huber_loss", "kullback_leibler_divergence", "logcosh", "mean_absolute_error", 
            "mean_absolute_percentage_error", "mean_squared_error", "mean_squared_logarithmic_error", 
            "poisson", "sparse_categorical_crossentropy", "squared_hinge"
        };

        /// <summary>
        /// Список функций активации для слоев
        /// </summary>
        public static readonly string[] ACTIVATIONS = {
            "elu", "exponential", "hard_sigmoid", "linear", "relu", "selu", "sigmoid", "softmax", "softplus", 
            "softsign", "tanh"
        };

        /// <summary>
        /// Функция для создания слоя
        /// </summary>
        /// <param name="name">названия слоя</param>
        /// <returns>объект слоя</returns>
        public static Layer GetLayer(string name, EventHandler eventHandler)
        {
            switch (name.ToLower())
            {
                case "dense":
                    return new Dense(eventHandler);
                case "dropout":
                    return new Dropout(eventHandler);
                case "flatten":
                    return new Flatten(eventHandler);
                case "conv1d": case "conv 1d":
                    return new Conv1D(eventHandler);
                case "conv2d": case "conv 2d":
                    return new Conv2D(eventHandler);
                case "maxpooling1d": case "maxpooling 1d":
                    return new MaxPooling1D(eventHandler);
                case "maxpooling2d": case "maxpooling 2d":
                    return new MaxPooling2D(eventHandler);
            }

            throw new ArgumentException(string.Format("{0} is not a layer", name)); // на вход был подан неверный слой
        }
    }

    /// <summary>
    /// Класс, описывающий сущность нейронной сети
    /// </summary>
    class NeuralNetwork
    {
        /// <summary>
        /// Имя нейронной сети
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Тип данных (матрица, изображение, звук и т.п.)
        /// </summary>
        public string TypeData { get; set; } = null;

        /// <summary>
        /// Тип обучения (регрессия или классификация)
        /// </summary>
        public string TypeSupervised { get; set; } = null;

        /// <summary>
        /// Размерность входных данных
        /// </summary>
        public int[] InputShape { get; } = new int[2] { 0, 0 };

        /// <summary>
        /// Ссылка на первый слой нейронной сети
        /// </summary>
        public Layer FirstLayer { get; set; } = null;

        /// <summary>
        /// Список всех соединений между слоями
        /// </summary>
        public List<Connection> Connections { get; } = new List<Connection>();

        /// <summary>
        /// Список слоев нейронной сети
        /// </summary>
        public List<Layer> Layers { get; } = new List<Layer>();

        /// <summary>
        /// Параметры нейронной сети
        /// </summary>
        public Dictionary<string, string> Params { get; } = new Dictionary<string, string>
        {
            { "optimizer", "" },
            { "loss", "" },
            { "metrics", "" }
        };

        public NeuralNetwork(string name) { Name = name; }

        /// <summary>
        /// Добавление слоя в нейронную сеть
        /// </summary>
        /// <param name="name">Название слоя</param>
        /// <returns>Ссылка на слой</returns>
        public Layer AddLayer(string name, EventHandler eventHandler)
        {
            Layers.Add(NeuralNetworkParams.GetLayer(name, eventHandler));
            return Layers[Layers.Count - 1];
        }

        /// <summary>
        /// Удаление слоя из нейронной сети
        /// </summary>
        /// <param name="layer">Ссылка на слой</param>
        public void DeleteLayer(Layer layer)
        {
            // нахождение всех соединений, которые cвязаны с удаляемым слоем
            List<Connection> deleted = new List<Connection>();
            foreach (Connection connection in Connections)
                if (connection.ComponentFirst.Layer == layer || connection.ComponentSecond.Layer == layer) 
                    deleted.Add(connection);

            // удаление соединений
            foreach (Connection connection in deleted)
            {
                connection.ComponentFirst.Layer.NextLayer = null;
                Connections.Remove(connection);
            }

            // проверка на то, что слой был первым
            if (layer == FirstLayer) FirstLayer = null;
            Layers.Remove(layer);
        }

        /// <summary>
        /// Метод для добавления параметров нейронной сети
        /// </summary>
        public void AddParams(string optimizer, string loss, string metrics)
        {
            Params["optimizer"] = optimizer;
            Params["loss"] = loss;
            Params["metrics"] =  metrics;
        }

        /// <summary>
        /// Метод компиляции нейронной сети (проверка на ее корректность)
        /// </summary>
        /// <returns>Полный путь до результатов компиляции</returns>
        public string Compile()
        {
            string json = ConvertJson.NetworkToJson(this);
            if (json == "") return "";
            return Client.GetCompile(json);
        }
    }

    /// <summary>
    /// Класс для сохранения нейронной сети
    /// </summary>
    static class Save 
    {
        /// <summary>
        /// Ссылка на нейронную сеть
        /// </summary>
        public static NeuralNetwork NNetwork { get; set; } = new NeuralNetwork("TEST");
    }
}
