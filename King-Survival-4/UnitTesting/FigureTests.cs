namespace UnitTesting
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival4;

    [TestClass]
    public class FigureTests
    {
        [TestMethod]
        public void FigureSaveMementoTester()
        {
            Memento memento = new Memento(new Position(1, 2), 'A', 'P');
            Pawn pawn = new Pawn(new Position(1, 2), 'A');
            var figureMemento = pawn.SaveMemento();

            Assert.IsTrue(figureMemento is Memento);
            Assert.AreEqual(memento.Position.X, figureMemento.Position.X);
            Assert.AreEqual(memento.Position.Y, figureMemento.Position.Y);
            Assert.AreEqual(memento.Name, figureMemento.Name);
            Assert.AreEqual(memento.Symbol, figureMemento.Symbol);

        }

        [TestMethod]
        public void FigureCloneMethodTester()
        {
            King originalFigure = new King(new Position(3,4));
            var cloned = originalFigure.Clone();
            Assert.AreNotEqual(originalFigure, cloned);
        }
    }
}
