namespace UnitTesting
{
    using System;
    using KingSurvival4;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandTester
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CommandInvalidInputTester()
        {
            var command = new Command("alabala");
        }

        [TestMethod]
        public void CommandValidInputTester()
        {
            var command = new Command("kur");
            Assert.AreEqual(command.Input, "KUR");
        }

        [TestMethod]
        public void CommandDetermineDirectionMethodDownRightTester()
        {
            var command = new Command("adr");
            var position = command.DetermineNewPosition();
            Assert.AreEqual(position.X, 1);
            Assert.AreEqual(position.Y, 1);
        }

        [TestMethod]
        public void CommandDetermineDirectionMethodDownLeftTester()
        {
            var command = new Command("adl");
            var position = command.DetermineNewPosition();
            Assert.AreEqual(position.X, 1);
            Assert.AreEqual(position.Y, -1);
        }

        [TestMethod]
        public void CommandDetermineDirectionMethodUpLeftTester()
        {
            var command = new Command("kul");
            var position = command.DetermineNewPosition();
            Assert.AreEqual(position.X, -1);
            Assert.AreEqual(position.Y, -1);
        }

        [TestMethod]
        public void CommandDetermineDirectionMethodUpRightTester()
        {
            var command = new Command("kur");
            var position = command.DetermineNewPosition();
            Assert.AreEqual(position.X, -1);
            Assert.AreEqual(position.Y, 1);
        }
    }
}
