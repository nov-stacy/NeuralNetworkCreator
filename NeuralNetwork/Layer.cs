using System.Collections.Generic;
using System;

namespace CourseworkFront
{
    /// <summary>
    /// Класс, описывающий слой нейронной сети
    /// </summary>
    abstract class Layer
    {
        /// <summary>
        /// Тип слоя
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Ссылка на следующий слой, который идет после этого в соединении
        /// </summary>
        public Layer NextLayer { get; set; }

        /// <summary>
        /// Ссылка на компоненту управления, с которым связан слой
        /// </summary>
        public Component Component { get; private set; }

        public Layer(string type) { Type = type; }

        /// <summary>
        /// Метод для инициализации компоненты
        /// </summary>
        /// <param name="component">Ссылка на компоненту управления</param>
        protected void CreateComponent(Component component) { Component = component; }

        /// <summary>
        /// Метод для получения параметров слоя
        /// </summary>
        /// <returns>Словрь слоев</returns>
        public abstract Dictionary<string, object> GetParams();

        /// <summary>
        /// Метод для установления параметров
        /// </summary>
        /// <param name="dictionary">Словарь параметров</param>
        public abstract void SetParams(Dictionary<string, object> dictionary);
    }

    /// <summary>
    /// Класс, описывающий Dense слой
    /// </summary>
    class Dense : Layer
    {
        public Dense(EventHandler eventHandler) : base("Dense") { CreateComponent(new DenseForm(this, eventHandler)); }
        
        /// <summary>
        /// Получение параметров: количество нейронов и вид активации
        /// </summary>
        public override Dictionary<string, object> GetParams()
        {
            return new Dictionary<string, object>
            {
                { "units", (int)((DenseForm)Component).NeuronsCount.Value },
                { "activation", ((DenseForm)Component).Activation.Text }
            };
        }

        /// <summary>
        /// Установление параметров: количество нейронов и вид активации
        /// </summary>
        public override void SetParams(Dictionary<string, object> dictionary)
        {
            ((DenseForm)Component).NeuronsCount.Value = (int)(long)dictionary["units"];
            ((DenseForm)Component).Activation.Text = (string)dictionary["activation"];
        }
    }

    /// <summary>
    /// Класс, описывающий Dropout слой
    /// </summary>
    class Dropout : Layer
    {
        public Dropout(EventHandler eventHandler) : base("Dropout") { CreateComponent(new DropoutForm(this, eventHandler)); }

        /// <summary>
        /// Получение параметров: вероятность удаления нейронов
        /// </summary>
        public override Dictionary<string, object> GetParams()
        {
            return new Dictionary<string, object>
            {
                { "rate", ((DropoutForm)Component).Rate.Value }
            };
        }

        /// <summary>
        /// Установление параметров: вероятность удаления нейронов
        /// </summary>
        public override void SetParams(Dictionary<string, object> dictionary)
        {
            ((DropoutForm)Component).Rate.Value = (decimal)(double)dictionary["rate"];
        }
    }

    /// <summary>
    /// Класс, описывающий Flatten слой
    /// </summary>
    class Flatten : Layer
    {
        public Flatten(EventHandler eventHandler) : base("Flatten") { CreateComponent(new FlattenForm(this, eventHandler)); }

        /// <summary>
        /// Получение параметров
        /// </summary>
        /// <returns>Пустой словарь так как нет параметров</returns>
        public override Dictionary<string, object> GetParams()
        {
            return new Dictionary<string, object>();
        }

        /// <summary>
        /// Установление параметров
        /// </summary>
        public override void SetParams(Dictionary<string, object> dictionary){}
    }

    /// <summary>
    /// Класс, описывающий Conv1D слой
    /// </summary>
    class Conv1D : Layer
    {
        public Conv1D(EventHandler eventHandler) : base("Conv1D") { CreateComponent(new Conv1DForm(this, eventHandler)); }

        /// <summary>
        /// Получение параметров: количество выходных фильтров, вид активации и длину окна свертки
        /// </summary>
        public override Dictionary<string, object> GetParams()
        {
            return new Dictionary<string, object>
            {
                { "filters", (int)((Conv1DForm)Component).Filters.Value },
                { "activation", ((Conv1DForm)Component).Activation.Text },
                { "kernel_size", (int)((Conv1DForm)Component).KernelSize.Value }
            };
        }

        /// <summary>
        /// Установление параметров: количество выходных фильтров, вид активации и длину окна свертки
        /// </summary>
        public override void SetParams(Dictionary<string, object> dictionary)
        {
            ((Conv1DForm)Component).Filters.Value = (int)(long)dictionary["filters"];
            ((Conv1DForm)Component).Activation.Text = (string)dictionary["activation"];
            ((Conv1DForm)Component).KernelSize.Value = (int)(long)dictionary["kernel_size"];
        }
    }

    /// <summary>
    /// Класс, описывающий Conv2D слой
    /// </summary>
    class Conv2D : Layer
    {
        public Conv2D(EventHandler eventHandler) : base("Conv2D") { CreateComponent(new Conv2DForm(this, eventHandler)); }

        /// <summary>
        /// Получение параметров: количество выходных фильтров, вид активации и длину окна свертки
        /// </summary>
        public override Dictionary<string, object> GetParams()
        {
            return new Dictionary<string, object>
            {
                { "filters", (int)((Conv2DForm)Component).Filters.Value },
                { "activation", ((Conv2DForm)Component).Activation.Text },
                { "kernel_size_1", (int)((Conv2DForm)Component).KernelSize[0].Value },
                { "kernel_size_2", (int)((Conv2DForm)Component).KernelSize[1].Value }
            };
        }

        /// <summary>
        /// Установление параметров: количество выходных фильтров, вид активации и длину окна свертки
        /// </summary>
        public override void SetParams(Dictionary<string, object> dictionary) 
        {
            ((Conv2DForm)Component).Filters.Value = (int)(long)dictionary["filters"];
            ((Conv2DForm)Component).Activation.Text = (string)dictionary["activation"];
            ((Conv2DForm)Component).KernelSize[0].Value = (int)(long)dictionary["kernel_size_1"];
            ((Conv2DForm)Component).KernelSize[1].Value = (int)(long)dictionary["kernel_size_2"];
        }
    }

    /// <summary>
    /// Класс, описывающий MaxPooling1D слой
    /// </summary>
    class MaxPooling1D : Layer
    {
        public MaxPooling1D(EventHandler eventHandler) : base("MaxPooling1D") { CreateComponent(new MaxPooling1DForm(this, eventHandler)); }

        /// <summary>
        /// Получение параметров: размер фильтра
        /// </summary>
        public override Dictionary<string, object> GetParams()
        {
            return new Dictionary<string, object>
            {
                { "pool_size", (int)((MaxPooling1DForm)Component).PoolSize.Value }
            };
        }

        /// <summary>
        /// Установление параметров: размер фильтра
        /// </summary>
        public override void SetParams(Dictionary<string, object> dictionary)
        {
            ((MaxPooling1DForm)Component).PoolSize.Value = (int)(long)dictionary["pool_size"];
        }
    }

    /// <summary>
    /// Класс, описывающий MaxPooling2D слой
    /// </summary>
    class MaxPooling2D : Layer
    {
        public MaxPooling2D(EventHandler eventHandler) : base("MaxPooling2D") { CreateComponent(new MaxPooling2DForm(this, eventHandler)); }

        /// <summary>
        /// Получение параметров: размер фильтра
        /// </summary>
        public override Dictionary<string, object> GetParams()
        {
            return new Dictionary<string, object>
            {
                { "pool_size_1", (int)((MaxPooling2DForm)Component).PoolSize[0].Value },
                { "pool_size_2", (int)((MaxPooling2DForm)Component).PoolSize[1].Value }
            };
        }

        /// <summary>
        /// Установление параметров: размер фильтра
        /// </summary>
        public override void SetParams(Dictionary<string, object> dictionary)
        {
            ((MaxPooling2DForm)Component).PoolSize[0].Value = (int)(long)dictionary["pool_size_1"];
            ((MaxPooling2DForm)Component).PoolSize[1].Value = (int)(long)dictionary["pool_size_2"];
        }
    }
}
