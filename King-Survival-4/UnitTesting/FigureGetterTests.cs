using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival4;

namespace UnitTesting
{
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
