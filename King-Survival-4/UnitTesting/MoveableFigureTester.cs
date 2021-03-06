﻿namespace UnitTesting
{
    using System;
    using KingSurvival.Base;
    using KingSurvival.Base.GameObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MoveableFigureTester
    {
        [TestMethod]
        public void MoveableFigureMoveMethodTester()
        {
            var firstFigure = new MoveableFigure(new King(new Position(0, 0)));
            firstFigure.MoveFigure(new Position(1, 0));
            var secondFigure = new MoveableFigure(new King(new Position(1, 0)));
            Assert.AreEqual(firstFigure.Position.X, secondFigure.Position.X);
            Assert.AreEqual(firstFigure.Position.Y, secondFigure.Position.Y);
        }
    }
}
