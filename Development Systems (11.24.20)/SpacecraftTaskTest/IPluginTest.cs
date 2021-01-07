using NUnit.Framework;

namespace SpacecraftTaskTest
{
    [TestFixture]
    public class IPluginTest
    {

        [Test]
        public void MultiplicationPlugin_AreEqual()
        {
            var plugin = new BinaryOperationPluginBuilder()
                            .Operation((x, y) => x*y)
                            .Build();
            Assert.AreEqual(9, plugin.Run(3,3));
            Assert.AreEqual(-500, plugin.Run(10,-50));
        }

        [Test]
        public void PowPlugin_AreEqual()
        {
            var plugin = new BinaryOperationPluginBuilder()
                            .Operation((x, y) => (int)System.Math.Pow(x, y))
                            .Build();
            Assert.AreEqual(9, plugin.Run(3,2));
            Assert.AreEqual(0, plugin.Run(10,-2));
        }

        [Test]
        public void MinPlugin_AreEqual()
        {
            var plugin = new BinaryOperationPluginBuilder()
                            .Operation((x, y) => System.Math.Min(x, y))
                            .Build();
            Assert.AreEqual(2, plugin.Run(3,2));
            Assert.AreEqual(-2, plugin.Run(10,-2));
        }


    }
}