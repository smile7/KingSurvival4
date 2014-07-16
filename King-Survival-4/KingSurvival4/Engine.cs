namespace KingSurvival4
{
    using System;
    using System.Collections.Generic;
    public class Engine
    {
        public static Dictionary<string, Figure> dictionary = new Dictionary<string, Figure>();

        public Engine()
        {
        }

        public void Start()
        {
            var board = Board.Instance;
            FillBoard();
            RenderBoard();
        }

        private void FillBoard()
        {
            const string WhiteCell = "+";
            const string BlackCell = "-";

            for (int row = 0; row < Board.Field.GetLength(0); row++)
            {
                for (int col = 0; col < Board.Field.GetLength(1); col++)
                {
                    //dictionary.Add((row + ' ' + col).ToString(), 

                    if ((row + col) % 2 == 0)
                    {
                        Board.Field[row, col] = WhiteCell;
                    }
                    else
                    {
                        Board.Field[row, col] = BlackCell;
                    }
                }
            }

           var firstPawn = FigureGetter.GetFigure(new Position(0, 0), 'A', 'P');
           var secondPawn = FigureGetter.GetFigure(new Position(0, 2), 'B', 'P');
           var thirdPawn = FigureGetter.GetFigure(new Position(0, 4), 'C', 'P');
           var fourthPawn =   FigureGetter.GetFigure(new Position(0, 6), 'D', 'P');
           var king = FigureGetter.GetFigure(new Position(7, 3), 'K', 'K');

           Board.Field[firstPawn.Position.X, firstPawn.Position.Y] = firstPawn.Name.ToString();
           Board.Field[secondPawn.Position.X, secondPawn.Position.Y] = secondPawn.Name.ToString();
           Board.Field[thirdPawn.Position.X, thirdPawn.Position.Y] = thirdPawn.Name.ToString();
           Board.Field[fourthPawn.Position.X, fourthPawn.Position.Y] = fourthPawn.Name.ToString();
           Board.Field[king.Position.X, king.Position.Y] = king.Name.ToString();
            
        }

        private void RenderBoard()
        {
            Console.WriteLine();

            for (int row = 0; row < Board.Field.GetLength(0); row++)
            {
                for (int col = 0; col < Board.Field.GetLength(1); col++)
                {
                    Console.Write(Board.Field[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
