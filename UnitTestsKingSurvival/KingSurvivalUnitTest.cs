using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival4;
using System.IO;

namespace UnitTestsKingSurvival
{
    [TestClass]
    public class KingSurvivalUnitTest
    {

        [TestMethod]
        public void KingWinsIn7TurnsPlusTestingllegalTurns()
        {
            //using (StringReader input1 = new StringReader("dhfrtjj\nadr\nkdr\nkul\nadl\nadr\nkur\n\bdl\nadl\nkur\nbdr\nkul\nbdl\nkur\ncdl\nkur\nddr\nkur\n\n"))
            //{
            using (StreamReader input1 = new StreamReader(@"..\..\..\test1.txt"))
            {
                Console.SetIn(input1);
                using (StringWriter output1 = new StringWriter())
                {
                    Console.SetOut(output1);
                    KingSurvivalEngine testEngine1 = new KingSurvivalConsoleEngine(new ConsoleReader(), new ConsoleRenderer());
                    testEngine1.Start();
                    string outputStr1 = output1.ToString();
                    outputStr1 = outputStr1.Substring(0, outputStr1.Length - 2);
                    int index1 = outputStr1.LastIndexOf("\n");
                    string toCompare1 = outputStr1.Substring(index1 + 1);

                    Assert.AreEqual("King won in 7 turns", toCompare1, "King had to win but it didn't.");
                }
            }
        }



        [TestMethod]
        public void KingWinsIn7Turns()
        {
            //using (StringReader input = new StringReader("kul\nadl\nadr\nkur\nadl\nkur\nbdr\nkul\nbdl\nkur\ncdl\nkur\nddr\nkur\n\n"))
            //{
            using (StreamReader input = new StreamReader(@"..\..\..\test2.txt"))
            {
                Console.SetIn(input);
                using (StringWriter output = new StringWriter())
                {
                    Console.SetOut(output);
                    KingSurvivalEngine testEngine = new KingSurvivalConsoleEngine(new ConsoleReader(), new ConsoleRenderer());
                    testEngine.Start();
                    string outputStr = output.ToString();
                    outputStr = outputStr.Substring(0, outputStr.Length - 2);
                    int index = outputStr.LastIndexOf("\n");
                    string toCompare = outputStr.Substring(index + 1);
                    Assert.AreEqual("King won in 7 turns", toCompare, "When playing based on the zero test scenario, King didn't win.");
                }
            }

        }



        [TestMethod]
        public void KingLosesIn12Turns()
        {
            //using (StringReader input = new StringReader("kul\nadl\nadr\nkur\nadl\nkur\nbdr\nkul\nbdl\nkur\ncdl\nkur\nddr\nkur\n\n"))
            //{
            using (StreamReader input = new StreamReader(@"..\..\..\test3.txt"))
            {
                Console.SetIn(input);
                using (StringWriter output = new StringWriter())
                {
                    Console.SetOut(output);
                    KingSurvivalEngine testEngine = new KingSurvivalConsoleEngine(new ConsoleReader(), new ConsoleRenderer());
                    testEngine.Start();
                    string outputStr = output.ToString();
                    outputStr = outputStr.Substring(0, outputStr.Length - 2);
                    int index = outputStr.LastIndexOf("\n");
                    string toCompare = outputStr.Substring(index + 1);
                    Assert.AreEqual("King lost in 12 turns", toCompare, "When playing based on the zero test scenario, King didn't win.");
                }
            }

        }

    }
}
