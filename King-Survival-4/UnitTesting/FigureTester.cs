namespace UnitTesting
{
    using System;

    using KingSurvival.Base;
    using KingSurvival.Base.FigureExtensions;
    using KingSurvival.Base.GameObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FigureTester
    {
        [TestMethod]
        public void FigureSaveMementoTester()
        {
            FigureMemento memento = new FigureMemento(new Position(1, 2), 'A', "Pawn");
            Pawn pawn = new Pawn(new Position(1, 2), 'A');
            var figureMemento = pawn.SaveMemento();

            Assert.IsTrue(figureMemento is FigureMemento);
            Assert.AreEqual(memento.Position.X, figureMemento.Position.X);
            Assert.AreEqual(memento.Position.Y, figureMemento.Position.Y);
            Assert.AreEqual(memento.Name, figureMemento.Name);
            Assert.AreEqual(memento.Symbol, figureMemento.Symbol);
        }

        [TestMethod]
        public void FigureCloneMethodTester()
        {
            King originalFigure = new King(new Position(3, 4));
            var cloned = originalFigure.Clone();
            Assert.AreNotEqual(originalFigure, cloned);
        }
    }
}
