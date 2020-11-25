using System.Collections.Generic;
using System.Linq;

namespace ds.test.impl
{
    /// <summary>
    /// Статический класс для управления текущим набором плагинов.
    /// </summary>
    public static class Plugins
    {
        private static readonly List<IPlugin> _plugins = new List<IPlugin>();
        /// <summary>
        /// Количество добавленных плагинов.
        /// </summary>
        public static int PluginsCount => _plugins.Count;
        
        /// <summary>
        /// Названия добавленных плагинов.
        /// </summary>
        public static string[] GetPluginNames 
        {
            get 
            {
                return (from plugin in _plugins select plugin.PluginName).ToArray<string>();
            }
        }
        /// <summary>
        /// Получение плагина по названию.
        /// </summary>
        /// <param name="pluginName">Название плагина.</param>
        /// <returns></returns>
        public static IPlugin GetPlugin(string pluginName) => _plugins.Find(p => p.PluginName == pluginName);
        /// <summary>
        /// Добавить плагин.
        /// </summary>
        public static void Add(IPlugin plugin) => _plugins.Add(plugin);
        /// <summary>
        /// Добавить набор плагинов.
        /// </summary>
        public static void Add(IEnumerable<IPlugin> plugins) => _plugins.AddRange(plugins);
        /// <summary>
        /// Удалить плагин.
        /// </summary>
        public static bool Remove(IPlugin plugin) => _plugins.Remove(plugin);
        /// <summary>
        /// Удалить набор плагинов.
        /// </summary>
        public static bool Remove(IEnumerable<IPlugin> plugins)
        {
            bool isAllRemoved = true;
            foreach(var plugin in plugins) 
            {
                isAllRemoved &= Remove(plugin);
            }
            return isAllRemoved;
        }
        /// <summary>
        /// Удалить плагин по имени.
        /// </summary>
        /// <param name="pluginName">Навание плагина.</param>
        /// <returns></returns>
        public static bool Remove(string pluginName) => Remove(_plugins.Find(p => p.PluginName == pluginName));
        /// <summary>
        /// Удалить плагины по именам.
        /// </summary>
        /// <param name="pluginNames">Названия плагинов.</param>
        /// <returns></returns>
        public static bool Remove(IEnumerable<string> pluginNames)
        {
            bool isAllRemoved = true;
            foreach(var plugin in pluginNames) 
            {
                isAllRemoved &= Remove(plugin);
            }
            return isAllRemoved;
        }
        /// <summary>
        /// Очистить набор плагинов.
        /// </summary>
        public static void Clear() => _plugins.Clear();

    }
}