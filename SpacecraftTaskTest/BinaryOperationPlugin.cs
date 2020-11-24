
using System.Drawing;

namespace SpacecraftTaskTest
{
    internal class BinaryOperationPlugin : ds.test.impl.IPlugin
    {
        private readonly System.Func<int, int, int> _operation;

        public string PluginName { get; }

        public string Version { get; }

        public Image Image { get; }

        public string Description { get; }

        public BinaryOperationPlugin(string pluginName, string version, Image image, string description, System.Func<int, int, int> operation) 
        {
            PluginName = pluginName;
            Version = version;
            Image = image;
            Description = description;
            _operation = operation;
        }

        public int Run(int input1, int input2) => _operation(input1,input2);
    }
}