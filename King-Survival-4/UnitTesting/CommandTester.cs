﻿namespace UnitTesting
{
    using System;
    using KingSurvival.Base;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandTester
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CommandInvalidInputTester()
        {
            var command = new Command("alabala");
            Assert.IsNull(command);
        }

        [TestMethod]
        public void CommandDetermineDirectionMethodDownRightTester()
        {
            var command = new Command("adr");
            var parser = new Parser();
            var position = parser.GetNewPosition(command.NewPositionLetters);
            Assert.AreEqual(position.X, 1);
            Assert.AreEqual(position.Y, 1);
        }

        [TestMethod]
        public void CommandDetermineDirectionMethodDownLeftTester()
        {
            var command = new Command("adl");
            var parser = new Parser();
            var position = parser.GetNewPosition(command.NewPositionLetters);
            Assert.AreEqual(position.X, 1);
            Assert.AreEqual(position.Y, -1);
        }

        [TestMethod]
        public void CommandDetermineDirectionMethodUpLeftTester()
        {
            var command = new Command("kul");
            var parser = new Parser();
            var position = parser.GetNewPosition(command.NewPositionLetters);
            Assert.AreEqual(position.X, -1);
            Assert.AreEqual(position.Y, -1);
        }

        [TestMethod]
        public void CommandDetermineDirectionMethodUpRightTester()
        {
            var command = new Command("kur");
            var parser = new Parser();
            var position = parser.GetNewPosition(command.NewPositionLetters);
            Assert.AreEqual(position.X, -1);
            Assert.AreEqual(position.Y, 1);
        }
    }
}
