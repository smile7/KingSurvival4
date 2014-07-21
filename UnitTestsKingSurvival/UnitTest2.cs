using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using KingSurvival4;

namespace UnitTestsKingSurvival
{
    [TestClass]
    public class UnitTest2
    {


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
