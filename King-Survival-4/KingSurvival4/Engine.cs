namespace KingSurvival4
{
    using System;
    using System.Collections.Generic;
    public class Engine
    {
        public static Dictionary<string, Figure> dictionary = new Dictionary<string, Figure>();

        Figure firstPawn = FigureGetter.GetFigure(new Position(0, 0), 'A', 'P');
        Figure secondPawn = FigureGetter.GetFigure(new Position(0, 2), 'B', 'P');
        Figure thirdPawn = FigureGetter.GetFigure(new Position(0, 4), 'C', 'P');
        Figure fourthPawn = FigureGetter.GetFigure(new Position(0, 6), 'D', 'P');
        Figure king = FigureGetter.GetFigure(new Position(7, 3), 'K', 'K');

        public Engine()
        {
        }

        public void Start()
        {
            var board = Board.Instance;
            bool kingsTurn = true;
            while (true)
            {
                // TODO check Kings win -> cw end message break;
                //Check kings lost -> cw end message break;

                Console.Clear();
                FillBoard();
                RenderBoard();
                if (kingsTurn)
                {
                    do
                    {
                        Console.Write("King's turn: ");
                        var command = new CommandProxy();
                        try
                        {
                            command.Input = Console.ReadLine();
                            int[] initial = command.DetermineDirection();
                            string kingSymbol = command.realCommand.FigureLetter;
                            if (kingSymbol != "K")
                            {
                                throw new ArgumentOutOfRangeException();
                            }
                            if (IsMoveValid(king, initial))
                            {
                                MoveKing changeKingsPosition = new MoveKing();
                                changeKingsPosition.Move(king, initial);
                            }
                            kingsTurn = false;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Illegal move. Please try again.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Your move is outside the board. Please try again.");
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("You can't step over a Pawn. Please enter new command.");
                        }
                    } while (kingsTurn);
                }
                else
                {
                    do
                    {
                        Console.Write("Pawn's turn: ");
                        var command = new CommandProxy();

                        try
                        {
                            command.Input = Console.ReadLine();
                            int[] initial = command.DetermineDirection();
                            Figure chosenPawn = firstPawn;
                            string pawnSymbol = command.realCommand.FigureLetter;
                            switch (pawnSymbol)
                            {
                                case "A": chosenPawn = firstPawn; break;
                                case "B": chosenPawn = secondPawn; break;
                                case "C": chosenPawn = thirdPawn; break;
                                case "D": chosenPawn = fourthPawn; break;
                                default: throw new ArgumentOutOfRangeException();
                            }

                            if (IsMoveValid(chosenPawn, initial))
                            {
                                MovePawn changePawnsPOsition = new MovePawn();
                                changePawnsPOsition.Move(chosenPawn, initial);
                            }
                            kingsTurn = true;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Illegal move. Please try again.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Your move is outside the board. Please try again.");
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("You can't step over another figure. Please enter new command.");
                        }
                    } while (!kingsTurn);
                }
            }
        }

        private bool IsMoveValid(Figure figure, int[] direction)
        {
            int newX = figure.Position.X + direction[0];
            int newY = figure.Position.Y + direction[1];
            if (newX >= 8 || newX < 0 || newY >= 8 || newY < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (Board.field[newX, newY] != "+")
            {
                throw new InvalidOperationException();
            }

            return true;
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


            Board.Field[firstPawn.Position.X, firstPawn.Position.Y] = firstPawn.Name.ToString();
            Board.Field[secondPawn.Position.X, secondPawn.Position.Y] = secondPawn.Name.ToString();
            Board.Field[thirdPawn.Position.X, thirdPawn.Position.Y] = thirdPawn.Name.ToString();
            Board.Field[fourthPawn.Position.X, fourthPawn.Position.Y] = fourthPawn.Name.ToString();
            Board.Field[king.Position.X, king.Position.Y] = king.Name.ToString();

        }

        private void RenderBoard()
        {
            Console.WriteLine("   KING SURVIVAL GAME");
            Console.WriteLine("    0 1 2 3 4 5 6 7");
            Console.WriteLine("   -----------------");
            int startRow = 3;

            for (int row = 0; row < Board.Field.GetLength(0); row++)
            {
                Console.SetCursorPosition(0, startRow + row);
                Console.Write(row + " | ");
                for (int col = 0; col < Board.Field.GetLength(1); col++)
                {
                    Console.Write(Board.Field[row, col] + " ");
                }

                Console.WriteLine("|");
            }
            Console.WriteLine("   -----------------");
        }
    }
}
