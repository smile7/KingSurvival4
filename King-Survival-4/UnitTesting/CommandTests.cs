using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival4;

namespace UnitTesting
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
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
            var position = command.DetermineDirection();
            Assert.AreEqual(position.X, 1);
            Assert.AreEqual(position.Y, 1);
        }

        [TestMethod]
        public void CommandDetermineDirectionMethodDownLeftTester()
        {
            var command = new Command("adl");
            var position = command.DetermineDirection();
            Assert.AreEqual(position.X, 1);
            Assert.AreEqual(position.Y, -1);
        }

        [TestMethod]
        public void CommandDetermineDirectionMethodUpLeftTester()
        {
            var command = new Command("kul");
            var position = command.DetermineDirection();
            Assert.AreEqual(position.X, -1);
            Assert.AreEqual(position.Y, -1);
        }

        [TestMethod]
        public void CommandDetermineDirectionMethodUpRightTester()
        {
            var command = new Command("kur");
            var position = command.DetermineDirection();
            Assert.AreEqual(position.X, -1);
            Assert.AreEqual(position.Y, 1);
        }
    }
}
