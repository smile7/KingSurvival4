using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival4;

namespace UnitTesting
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void BoardInstanceFieldFillingTest()
        {
            Board board = Board.Instance;

            string[,] matrix = { 
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

                if(!areEqual)
                {
                    break;
                }
            }

            Assert.IsTrue(areEqual);
        }
    }
}
