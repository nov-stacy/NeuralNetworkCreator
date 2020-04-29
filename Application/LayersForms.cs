using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace CourseworkFront
{
    /// <summary>
    /// Класс для описания компоненты управления, с которой взаимодействует пользователь, чтобы изменить настройки слоя
    /// </summary>
    class Component : Panel
    {
        public Component(Size size)
        {
            // добавление стилей
            BackColor = SystemColors.GradientActiveCaption;
            BorderStyle = BorderStyle.FixedSingle;
            Size = size;
            ControlExtension.Draggable(this, true); // добавление возможности перемещения
        }

        /// <summary>
        /// Ссылка на слой, к которому прикреплена компонента
        /// </summary>
        public Layer Layer { get; set; }
    }

    /// <summary>
    /// Форма для слоя Dense
    /// </summary>
    class DenseForm : Component
    {
        /// <summary>
        /// Ссылка на компоненту, в которую пользователь вносит количество слоев
        /// </summary>
        public NumericUpDown NeuronsCount { get; private set; }

        /// <summary>
        /// Ссылка на компоненту, в которую пользователь вносит вид активации слоя
        /// </summary>
        public ComboBox Activation { get; private set; }

        public DenseForm(Layer layer, EventHandler eventHandler) : base(new Size(120, 125))
        {
            List<Control> controls = new List<Control>
            {
                LayersControls.GetLabel("DENSE", new Point(10, 5)),
                LayersControls.GetLabel("neurons count", new Point(10, 25)),
                LayersControls.GetIntNumericUpDown(new Point(10, 45), new Size(100, 45), eventHandler),
                LayersControls.GetLabel("activation", new Point(10, 70)),
                LayersControls.GetComboBox(NeuralNetworkParams.ACTIVATIONS, new Point(10, 90), eventHandler)
            };
            Controls.AddRange(controls.ToArray());
            NeuronsCount = (NumericUpDown)controls[2];
            Activation = (ComboBox)controls[4];
            Layer = layer;
        }
    }

    /// <summary>
    /// Форма для слоя Dropout
    /// </summary>
    class DropoutForm : Component
    {
        /// <summary>
        /// Ссылка на компоненту, в которую пользователь вносит вероятность выбывания нейрона
        /// </summary>
        public NumericUpDown Rate { get; private set; }

        public DropoutForm(Layer layer, EventHandler eventHandler) : base(new Size(120, 80))
        {
            List<Control> controls = new List<Control>
            {
                LayersControls.GetLabel("DROPOUT", new Point(10, 5)),
                LayersControls.GetLabel("rate", new Point(10, 25)),
                LayersControls.GetFloatNumericUpDown(new Point(10, 45), new Size(100, 45), eventHandler)
            };
            Controls.AddRange(controls.ToArray());
            Rate = (NumericUpDown)controls[2];
            Layer = layer;
        }
    }

    /// <summary>
    /// Форма для слоя Flatten
    /// </summary>
    class FlattenForm : Component
    {
        public FlattenForm(Layer layer, EventHandler eventHandler) : base(new Size(120, 80))
        {
            List<Control> controls = new List<Control>
            {
                LayersControls.GetLabel("FLATTEN", new Point(10, 5)),
            };
            Controls.AddRange(controls.ToArray());
            Layer = layer;
        }
    }

    /// <summary>
    /// Форма для слоя Conv1D
    /// </summary>
    class Conv1DForm : Component
    {
        /// <summary>
        /// Ссылка на компоненту, в которую пользователь вносит количество выходных фильтров
        /// </summary>
        public NumericUpDown Filters { get; private set; }

        /// <summary>
        /// Ссылка на компоненту, в которую пользователь вносит вид активации слоя
        /// </summary>
        public ComboBox Activation { get; private set; }

        /// <summary>
        /// Ссылка на компоненту, в которую пользователь вносит длину окна свертки
        /// </summary>
        public NumericUpDown KernelSize { get; private set; }

        public Conv1DForm(Layer layer, EventHandler eventHandler) : base(new Size(120, 170))
        {
            List<Control> controls = new List<Control>
            {
                LayersControls.GetLabel("CONV 1D", new Point(10, 5)),
                LayersControls.GetLabel("filters", new Point(10, 25)),
                LayersControls.GetIntNumericUpDown(new Point(10, 45), new Size(100, 45), eventHandler),
                LayersControls.GetLabel("kernel size", new Point(10, 70)),
                LayersControls.GetIntNumericUpDown(new Point(10, 90), new Size(100, 45), eventHandler),
                LayersControls.GetLabel("activation", new Point(10, 115)),
                LayersControls.GetComboBox(NeuralNetworkParams.ACTIVATIONS, new Point(10, 135), eventHandler)
            };
            Controls.AddRange(controls.ToArray());
            Filters = (NumericUpDown)controls[2];
            Activation = (ComboBox)controls[6];
            KernelSize = (NumericUpDown)controls[4];
            Layer = layer;
        }
    }

    /// <summary>
    /// Форма для слоя Conv2D
    /// </summary>
    class Conv2DForm : Component
    {
        /// <summary>
        /// Ссылки на компоненты, в которые пользователь вносит количество выходных фильтров
        /// </summary>
        public NumericUpDown Filters { get; private set; }

        /// <summary>
        /// Ссылка на компоненту, в которую пользователь вносит вид активации слоя
        /// </summary>
        public ComboBox Activation { get; private set; }

        /// <summary>
        /// Ссылки на компоненты, в которые пользователь вносит длину окна свертки
        /// </summary>
        public NumericUpDown[] KernelSize { get; private set; } = new NumericUpDown[2];

        public Conv2DForm(Layer layer, EventHandler eventHandler) : base(new Size(120, 170))
        {
            List<Control> controls = new List<Control>
            {
                LayersControls.GetLabel("CONV 2D", new Point(10, 5)),
                LayersControls.GetLabel("filters", new Point(10, 25)),
                LayersControls.GetIntNumericUpDown(new Point(10, 45), new Size(100, 45), eventHandler),
                LayersControls.GetLabel("kernel size", new Point(10, 70)),
                LayersControls.GetIntNumericUpDown(new Point(10, 90), new Size(40, 45), eventHandler),
                LayersControls.GetIntNumericUpDown(new Point(60, 90), new Size(40, 45), eventHandler),
                LayersControls.GetLabel("activation", new Point(10, 115)),
                LayersControls.GetComboBox(NeuralNetworkParams.ACTIVATIONS, new Point(10, 135), eventHandler)
            };
            Controls.AddRange(controls.ToArray());
            Filters = (NumericUpDown)controls[2];
            Activation = (ComboBox)controls[7];
            KernelSize[0] = (NumericUpDown)controls[4];
            KernelSize[1] = (NumericUpDown)controls[5];
            Layer = layer;
        }
    }

    /// <summary>
    /// Форма для слоя MaxPooling1D
    /// </summary>
    class MaxPooling1DForm : Component
    {
        /// <summary>
        /// Ссылка на компоненту, в которую пользователь вносит размер фильтра
        /// </summary>
        public NumericUpDown PoolSize { get; private set; }

        public MaxPooling1DForm(Layer layer, EventHandler eventHandler) : base(new Size(120, 80))
        {
            List<Control> controls = new List<Control>
            {
                LayersControls.GetLabel("MAXPOOLING 1D", new Point(10, 5)),
                LayersControls.GetLabel("pool size", new Point(10, 25)),
                LayersControls.GetIntNumericUpDown(new Point(10, 45), new Size(100, 45), eventHandler)
            };
            Controls.AddRange(controls.ToArray());
            PoolSize = (NumericUpDown)controls[2];
            Layer = layer;
        }
    }

    /// <summary>
    /// Форма для слоя MaxPooling2D
    /// </summary>
    class MaxPooling2DForm : Component
    {
        /// <summary>
        /// Ссылки на компоненты, в которые пользователь вносит размер фильтра
        /// </summary>
        public NumericUpDown[] PoolSize { get; private set; } = new NumericUpDown[2];

        public MaxPooling2DForm(Layer layer, EventHandler eventHandler) : base(new Size(120, 80))
        {
            List<Control> controls = new List<Control>
            {
                LayersControls.GetLabel("MAXPOOLING 2D", new Point(10, 5)),
                LayersControls.GetLabel("pool size", new Point(10, 25)),
                LayersControls.GetIntNumericUpDown(new Point(10, 45), new Size(40, 45), eventHandler),
                LayersControls.GetIntNumericUpDown(new Point(60, 45), new Size(40, 45), eventHandler),
            };
            Controls.AddRange(controls.ToArray());
            PoolSize[0] = (NumericUpDown)controls[2];
            PoolSize[1] = (NumericUpDown)controls[3];
            Layer = layer;
        }
    }
}
