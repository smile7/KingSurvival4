namespace UnitTestsKingSurvival
{
    using System;

    using KingSurvival.Console.InputOutputEngines;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConsoleMessagesTests
    {
        [TestMethod]
        public void KingsTurnMessageTest()
        {
            Assert.AreEqual("King's turn:", ConsoleMessages.KingsTurnMessage()); 
        }

        [TestMethod]
        public void PawnsTurnMessageTest()
        {
            Assert.AreEqual("Pawn's turn:", ConsoleMessages.PawnsTurnMessage());
        }

        [TestMethod]
        public void KingWonMessageTest()
        {
            Assert.AreEqual("King won in 10 turns", ConsoleMessages.KingWonMessage(10));
        }

        [TestMethod]
        public void KingLostMessageTest()
        {
            Assert.AreEqual("King lost in 15 turns", ConsoleMessages.KingLostMessage(15));
        }
    }
}
