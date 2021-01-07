using System;

namespace ds.test.impl
{
    /// <summary>
    /// Базовый интерфейс плагина.
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Название плагина.
        /// </summary>
        string PluginName { get; }
        /// <summary>
        /// Версия плагина.
        /// </summary>
        string Version { get; }
        /// <summary>
        /// Изображение плагина.
        /// </summary>
        System.Drawing.Image Image { get; }
        /// <summary>
        /// Описание плагина.
        /// </summary>
        string Description { get; }
        /// <summary>
        /// Запуск плагина.
        /// </summary>
        int Run(int input1, int input2);
    }
}
