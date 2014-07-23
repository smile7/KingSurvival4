namespace UnitTesting
{
    using System;
    using KingSurvival4;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BoardTester
    {
        [TestMethod]
        public void BoardInstanceFieldFillingTest()
        {
            Board board = Board.Instance;

            string[,] matrix = 
            { 
                               { "+", "-", "+", "-", "+", "-", "+", "-" }, 
                               { "-", "+", "-", "+", "-", "+", "-", "+" }, 
                               { "+", "-", "+", "-", "+", "-", "+", "-" }, 
                               { "-", "+", "-", "+", "-", "+", "-", "+" }, 
                               { "+", "-", "+", "-", "+", "-", "+", "-" }, 
                               { "-", "+", "-", "+", "-", "+", "-", "+" }, 
                               { "+", "-", "+", "-", "+", "-", "+", "-" }, 
                               { "-", "+", "-", "+", "-", "+", "-", "+" } 
            };

            bool areEqual = true;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != Board.Field[i, j])
                    {
                        areEqual = false;
                        break;
                    }
                }

                if (!areEqual)
                {
                    break;
                }
            }

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void BoardInstanceNotifyWithFigureTest()
        {
            Board board = Board.Instance;
            board.Notify(new Pawn(new Position(0, 0), 'A'));
            board.Notify(new Pawn(new Position(0, 2), 'B'));
            board.Notify(new Pawn(new Position(0, 4), 'C'));
            board.Notify(new Pawn(new Position(0, 6), 'D'));
            board.Notify(new King(new Position(7, 3)));

            string[,] matrix = 
            { 
                               { "A", "-", "B", "-", "C", "-", "D", "-" }, 
                               { "-", "+", "-", "+", "-", "+", "-", "+" }, 
                               { "+", "-", "+", "-", "+", "-", "+", "-" }, 
                               { "-", "+", "-", "+", "-", "+", "-", "+" }, 
                               { "+", "-", "+", "-", "+", "-", "+", "-" }, 
                               { "-", "+", "-", "+", "-", "+", "-", "+" }, 
                               { "+", "-", "+", "-", "+", "-", "+", "-" }, 
                               { "-", "+", "-", "K", "-", "+", "-", "+" } 
            };

            bool areEqual = true;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != Board.Field[i, j])
                    {
                        areEqual = false;
                        break;
                    }
                }

                if (!areEqual)
                {
                    break;
                }
            }

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void BoardInstanceNotifyWithNewPositionOfFigureTest()
        {
            Board board = Board.Instance;
            board.Notify(new Pawn(new Position(0, 0), 'A'));
            board.Notify(new Pawn(new Position(0, 2), 'B'));
            board.Notify(new Pawn(new Position(0, 4), 'C'));
            board.Notify(new Pawn(new Position(0, 6), 'D'));
            board.Notify(new King(new Position(6, 2)), new Position(7, 3));

            string[,] matrix = 
            { 
                               { "A", "-", "B", "-", "C", "-", "D", "-" }, 
                               { "-", "+", "-", "+", "-", "+", "-", "+" }, 
                               { "+", "-", "+", "-", "+", "-", "+", "-" }, 
                               { "-", "+", "-", "+", "-", "+", "-", "+" }, 
                               { "+", "-", "+", "-", "+", "-", "+", "-" }, 
                               { "-", "+", "-", "+", "-", "+", "-", "+" }, 
                               { "+", "-", "K", "-", "+", "-", "+", "-" }, 
                               { "-", "+", "-", "+", "-", "+", "-", "+" } 
            };

            bool areEqual = true;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != Board.Field[i, j])
                    {
                        areEqual = false;
                        break;
                    }
                }

                if (!areEqual)
                {
                    break;
                }
            }

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void BoardsizeTest()
        {
            Assert.AreEqual(8, Board.Field.GetLength(0), "The main board width is not 8.");
            Assert.AreEqual(8, Board.Field.GetLength(1), "The board height is not 8");
        }
    }
}
