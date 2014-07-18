namespace KingSurvival4
{
    using System;
    public class ConsoleRenderer
    {
        public void Render(string[,] board)
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
