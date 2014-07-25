namespace UnitTesting
{
    using System;
    using KingSurvival.Base;
    using KingSurvival.Base.GameObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FigureGetterTester
    {
        [TestMethod]
        public void GetFigureMethodTesterForKing()
        {
            var figure = FigureGetter.GetFigure(new Position(0, 0), 'K', "King");
            Assert.IsTrue(figure is King);
        }

        [TestMethod]
        public void GetFigureMethodTesterForPawn()
        {
            var figure = FigureGetter.GetFigure(new Position(0, 0), 'A', "Pawn");
            Assert.IsTrue(figure is Pawn);
        }
    }
}
