namespace UnitTesting
{
    using System;
    using KingSurvival4;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FigureGetterTests
    {
        [TestMethod]
        public void GetFigureMethodTesterForKing()
        {
            var figure = FigureGetter.GetFigure(new Position(0, 0), 'K', 'K');
            Assert.IsTrue(figure is King);
        }

        [TestMethod]
        public void GetFigureMethodTesterForPawn()
        {
            var figure = FigureGetter.GetFigure(new Position(0, 0), 'A', 'P');
            Assert.IsTrue(figure is Pawn);
        }
    }
}
