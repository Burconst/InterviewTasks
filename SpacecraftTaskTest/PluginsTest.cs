using NUnit.Framework;
using ds.test.impl;
using System.Collections.Generic;

namespace SpacecraftTaskTest
{
    [TestFixture]
    public class PluginsTest
    {
        private List<IPlugin> generatePlugins(int count) 
        {
            var plugins = new List<IPlugin>();
            for(int i = 0; i < count; i++) 
            {
                plugins.Add(new BinaryOperationPluginBuilder()
                            .PluginName($"Plugin {i}")
                            .Build());
            }
            return plugins;
        }
        
        [TearDown] public void Cleanup() 
        {
            Plugins.Clear();
        }

        [Test]
        public void Add_AreEqual()
        {
            var plugin = new BinaryOperationPluginBuilder()
                        .Build();
            Plugins.Add(plugin);
            Assert.AreEqual(1, Plugins.PluginsCount);
            Plugins.Add(plugin);
            Assert.AreEqual(2, Plugins.PluginsCount);
            Plugins.Add(new [] { plugin, plugin, plugin });
            Assert.AreEqual(5, Plugins.PluginsCount);
        }

        [Test]
        public void Remove_AreEqual()
        {
            var plugins = generatePlugins(3);
            Plugins.Add(plugins);
            Plugins.Remove(plugins[0]);
            Assert.AreEqual(2, Plugins.PluginsCount);
            
            Plugins.Add(plugins[1]);
            Plugins.Remove(new [] { "Plugin 1", "Plugin 1" });
            Assert.AreEqual(1, Plugins.PluginsCount);
            
            Plugins.Remove("Plugin 2");
            Assert.AreEqual(0, Plugins.PluginsCount);
        }

        [Test]
        public void Clear_AreEqual()
        {
            var plugins = generatePlugins(3);
            Plugins.Add(plugins);
            Plugins.Clear();
            Assert.AreEqual(0, Plugins.PluginsCount);
        }

        [Test]
        public void GetPlugin_AreEqual()
        {
            var plugins = generatePlugins(3);
            Plugins.Add(plugins);
            Assert.AreSame(plugins[1].PluginName, Plugins.GetPlugin("Plugin 1").PluginName);
            Assert.AreSame(null, Plugins.GetPlugin("Plugin 5"));
        }

        [Test]
        public void GetPluginNames_AreEqual()
        {
            var plugins = generatePlugins(3);
            Plugins.Add(plugins);
            var names = Plugins.GetPluginNames;
            Assert.AreEqual(new [] { "Plugin 0", "Plugin 1", "Plugin 2" }, names);
        }

    }
}