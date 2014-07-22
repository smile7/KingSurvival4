namespace KingSurvival4
{
    using System;

    /// <summary>
    /// The class which writes the messages from the console and prints the board
    /// </summary>
    public class ConsoleWriter : IWriter
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Prints the whole board on the console
        /// </summary>
        /// <param name="board">The board</param>
        public void RenderBoard(string[,] board)
        {
            Console.WriteLine("   KING SURVIVAL GAME");
            Console.WriteLine("    0 1 2 3 4 5 6 7");
            Console.WriteLine("   -----------------");
            int startRow = 3;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                Console.SetCursorPosition(0, startRow + row);
                Console.Write(row + " | ");
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col] + " ");
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("   -----------------");
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
