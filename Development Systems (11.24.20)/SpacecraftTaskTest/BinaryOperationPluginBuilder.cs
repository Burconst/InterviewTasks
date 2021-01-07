using System;

namespace SpacecraftTaskTest
{
    internal sealed class BinaryOperationPluginBuilder
    {
        string _pluginName;
        string _version;
        System.Drawing.Image _image;
        string _description;
        Func<int, int, int> _operation;

        public BinaryOperationPluginBuilder PluginName(string pluginName)
        {
            _pluginName = pluginName;
            return this;
        }

        public BinaryOperationPluginBuilder Version(string version)
        {
            _version = version;
            return this;
        }

        public BinaryOperationPluginBuilder Image(System.Drawing.Image image)
        {
            _image = image;
            return this;
        }

        public BinaryOperationPluginBuilder Description(string description)
        {
            _description = description;
            return this;
        }

        public BinaryOperationPluginBuilder Operation(Func<int, int, int> operation)
        {
            _operation = operation;
            return this;
        }

        public ds.test.impl.IPlugin Build() 
        {
            return new BinaryOperationPlugin(_pluginName, _version, _image, _description, _operation); 
        }


    }
}