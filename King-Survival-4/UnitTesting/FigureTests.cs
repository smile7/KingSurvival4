using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival4;

namespace UnitTesting
{
    [TestClass]
    public class FigureTests
    {
        [TestMethod]
        public void FigureSaveMementoTester()
        {
            Memento memento = new Memento(new Position(1, 2), 'A', 'P');
            Pawn pawn = new Pawn(new Position(1, 2), 'A');
            var figureMemento = pawn.SaveMemento();
            
            Assert.AreEqual(memento.Position.X, figureMemento.Position.X);
            Assert.AreEqual(memento.Position.Y, figureMemento.Position.Y);
            Assert.AreEqual(memento.Name, figureMemento.Name);
            Assert.AreEqual(memento.Symbol, figureMemento.Symbol);

        }
    }
}
