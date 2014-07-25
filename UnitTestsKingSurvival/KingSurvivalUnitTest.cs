namespace UnitTestsKingSurvival
{
    using System;
    using System.IO;
    using KingSurvival.Base;
    using KingSurvival.Console;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
 
    [TestClass]
    public class KingSurvivalUnitTest
    {
        [TestMethod]
        public void KingWinsIn7TurnsPlusTestingllegalTurns()
        {
            using (StreamReader input = new StreamReader(@"..\..\..\test1.txt"))
            {
                Console.SetIn(input);
                using (StringWriter output = new StringWriter())
                {
                    Console.SetOut(output);
                    KingSurvivalEngine testEngine = new KingSurvivalConsoleEngine();
                    testEngine.Start();
                    string outputStr = output.ToString();
                    outputStr = outputStr.Substring(0, outputStr.Length - 2);
                    int index = outputStr.LastIndexOf("\n");
                    string toCompare = outputStr.Substring(index + 1);
                    Assert.AreEqual("King won in 7 turns", toCompare, "King had to win but it didn't.");
                }
            }
        }
    }
}
