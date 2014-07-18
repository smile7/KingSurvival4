namespace KingSurvival4
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private ConsoleRenderer renderer;

        public const int MinRowIndex = 0;
        public const int MaxRowIndex = 8;
        public const int MinColumnIndex = 0;
        public const int MaxColumnIndex = 8;

        protected Figure firstPawn = FigureGetter.GetFigure(new Position(0, 0), 'A', 'P');
        protected Figure secondPawn = FigureGetter.GetFigure(new Position(0, 2), 'B', 'P');
        protected Figure thirdPawn = FigureGetter.GetFigure(new Position(0, 4), 'C', 'P');
        protected Figure fourthPawn = FigureGetter.GetFigure(new Position(0, 6), 'D', 'P');
        protected Figure king = FigureGetter.GetFigure(new Position(7, 3), 'K', 'K');

        public Engine()
        {
            this.renderer = new ConsoleRenderer();
        }

        public void Start()
        {
            var board = Board.Instance;
            bool kingsTurn = true;
            while (true)
            {
                // TODO check Kings win -> cw end message break;
                //Check kings lost -> cw end message break;

                this.renderer.Clear();
                this.FillBoard();
                this.renderer.Render(Board.Field);
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

                            if (this.IsMoveValid(this.king, initial))
                            {
                                MoveKing changeKingsPosition = new MoveKing();
                                changeKingsPosition.Move(this.king, initial);
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
                    } 
                    while (kingsTurn);
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
                            Figure chosenPawn = this.firstPawn;
                            string pawnSymbol = command.realCommand.FigureLetter;
                            switch (pawnSymbol)
                            {
                                case "A": chosenPawn = this.firstPawn;
                                    break;
                                case "B": chosenPawn = this.secondPawn;
                                    break;
                                case "C": chosenPawn = this.thirdPawn;
                                    break;
                                case "D": chosenPawn = this.fourthPawn;
                                    break;
                                default: throw new ArgumentOutOfRangeException();
                            }

                            if (this.IsMoveValid(chosenPawn, initial))
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
                    } 
                    while (!kingsTurn);
                }
            }
        }

        private bool IsMoveValid(Figure figure, int[] direction)
        {
            int newX = figure.Position.X + direction[0];
            int newY = figure.Position.Y + direction[1];

            if (newX >= MaxColumnIndex || newX < MinColumnIndex || newY >= MaxRowIndex || newY < MinRowIndex)
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

            Board.Field[this.firstPawn.Position.X, this.firstPawn.Position.Y] = this.firstPawn.Name.ToString();
            Board.Field[this.secondPawn.Position.X, this.secondPawn.Position.Y] = this.secondPawn.Name.ToString();
            Board.Field[this.thirdPawn.Position.X, this.thirdPawn.Position.Y] = this.thirdPawn.Name.ToString();
            Board.Field[this.fourthPawn.Position.X, this.fourthPawn.Position.Y] = this.fourthPawn.Name.ToString();
            Board.Field[this.king.Position.X, this.king.Position.Y] = this.king.Name.ToString();
        }

        //private void RenderBoard()
        //{
        //    Console.WriteLine("   KING SURVIVAL GAME");
        //    Console.WriteLine("    0 1 2 3 4 5 6 7");
        //    Console.WriteLine("   -----------------");
        //    int startRow = 3;

        //    for (int row = 0; row < Board.Field.GetLength(0); row++)
        //    {
        //        Console.SetCursorPosition(0, startRow + row);
        //        Console.Write(row + " | ");
        //        for (int col = 0; col < Board.Field.GetLength(1); col++)
        //        {
        //            Console.Write(Board.Field[row, col] + " ");
        //        }

        //        Console.WriteLine("|");
        //    }

        //    Console.WriteLine("   -----------------");
        //}
    }
}
