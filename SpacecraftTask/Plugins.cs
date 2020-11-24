using System.Collections.Generic;
using System.Linq;

namespace ds.test.impl
{
    public static class Plugins
    {
        private static readonly List<IPlugin> _plugins = new List<IPlugin>();

        public static int PluginsCount => _plugins.Count;

        public static string[] GetPluginNames 
        {
            get 
            {
                return (from plugin in _plugins select plugin.PluginName).ToArray<string>();
            }
        }

        public static IPlugin GetPlugin(string pluginName) => _plugins.Find(p => p.PluginName == pluginName);

        public static void Add(IPlugin plugin) => _plugins.Add(plugin);
        public static void Add(IEnumerable<IPlugin> plugins) => _plugins.AddRange(plugins);
        public static bool Remove(IPlugin plugin) => _plugins.Remove(plugin);
        public static bool Remove(IEnumerable<IPlugin> plugins)
        {
            bool isAllRemoved = true;
            foreach(var plugin in plugins) 
            {
                isAllRemoved &= Remove(plugin);
            }
            return isAllRemoved;
        }

        public static bool Remove(string pluginName) => Remove(_plugins.Find(p => p.PluginName == pluginName));
        public static bool Remove(IEnumerable<string> pluginNames)
        {
            bool isAllRemoved = true;
            foreach(var plugin in pluginNames) 
            {
                isAllRemoved &= Remove(plugin);
            }
            return isAllRemoved;
        }

        public static void Clear() => _plugins.Clear();

    }
}