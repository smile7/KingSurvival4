﻿namespace KingSurvival4
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// FACADE for Facade pattern and Concrete implementation of Bridge pattern
    /// </summary>
    public class KingSurvivalConsoleEngine : KingSurvivalEngine
    {
        public const int MinRowIndex = 0;
        public const int MaxRowIndex = 8;
        public const int MinColumnIndex = 0;
        public const int MaxColumnIndex = 8;


        protected Figure firstPawn = FigureGetter.GetFigure(new Position(0, 0), 'A', 'P');
        protected Figure secondPawn = FigureGetter.GetFigure(new Position(0, 2), 'B', 'P');
        protected Figure thirdPawn = FigureGetter.GetFigure(new Position(0, 4), 'C', 'P');
        protected Figure fourthPawn = FigureGetter.GetFigure(new Position(0, 6), 'D', 'P');
        protected Figure king = FigureGetter.GetFigure(new Position(7, 3), 'K', 'K');

        Board board;
        public KingSurvivalConsoleEngine(ConsoleReader reader, ConsoleRenderer renderer)
            : base(reader, renderer)
        {
            board = Board.Instance;
            this.Figures = new List<Figure>();
            this.Figures.Add(firstPawn);
            this.Figures.Add(secondPawn);
            this.Figures.Add(thirdPawn);
            this.Figures.Add(fourthPawn);
            this.Figures.Add(king);
        }

        public override void Start()
        {
            bool kingsTurn = true;

            ProspectMemory oldPosition = new ProspectMemory();

            while (true)
            {
                // TODO check Kings win -> cw end message break;
                //Check kings lost -> cw end message break;

                foreach (var figure in this.Figures)
                {
                    board.Notify(figure);
                }

                this.RenderBoard(Board.Field);

                if (kingsTurn)
                {
                    do
                    {
                        this.PostMessage("King's turn: ");
                        var command = new CommandProxy();
                        try
                        {
                            command.Input = this.GetCommand();
                            Direction initial = command.DetermineDirection();
                            string kingSymbol = command.realCommand.FigureLetter;

                            if (kingSymbol != "K")
                            {
                                throw new ArgumentOutOfRangeException();
                            }

                            if (this.IsMoveValid(this.king, initial))
                            {
                                var clonedKing = this.king.Clone() as Figure;
                                oldPosition.Memento = clonedKing.SaveMemento();
                                
                                MoveableFigure changeKingsPosition = new MoveableFigure(this.king);
                                changeKingsPosition.MoveFigure(initial);

                                board.Notify(this.king, oldPosition.Memento.Position);
                            }

                            kingsTurn = false;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            this.PostMessage("Illegal move. Please try again.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            this.PostMessage("Your move is outside the board. Please try again.");
                        }
                        catch (InvalidOperationException)
                        {
                            this.PostMessage("You can't step over a Pawn. Please enter new command.");
                        }
                    }
                    while (kingsTurn);
                }
                else
                {
                    do
                    {
                        this.PostMessage("Pawn's turn: ");
                        var command = new CommandProxy();

                        try
                        {
                            command.Input = this.Reader.Read();
                            Direction initial = command.DetermineDirection();
                            Figure chosenPawn = this.firstPawn;
                            string pawnSymbol = command.realCommand.FigureLetter;
                            switch (pawnSymbol)
                            {
                                case "A":
                                    chosenPawn = this.firstPawn;
                                    break;
                                case "B":
                                    chosenPawn = this.secondPawn;
                                    break;
                                case "C":
                                    chosenPawn = this.thirdPawn;
                                    break;
                                case "D":
                                    chosenPawn = this.fourthPawn;
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                            if (this.IsMoveValid(chosenPawn, initial))
                            {
                                var clonedPawn = chosenPawn.Clone() as Figure;
                                oldPosition.Memento = clonedPawn.SaveMemento();

                                MoveableFigure changePawnsPOsition = new MoveableFigure(chosenPawn);
                                changePawnsPOsition.MoveFigure(initial);

                                board.Notify(chosenPawn, oldPosition.Memento.Position);
                            }

                            kingsTurn = true;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            this.PostMessage("Illegal move. Please try again.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            this.PostMessage("Your move is outside the board. Please try again.");
                        }
                        catch (InvalidOperationException)
                        {
                            this.PostMessage("You can't step over another figure. Please enter new command.");
                        }
                    }
                    while (!kingsTurn);
                }
            }
        }

        private bool IsMoveValid(Figure figure, Direction direction)
        {
            int newX = figure.Position.X + direction.X;
            int newY = figure.Position.Y + direction.Y;

            if (newX >= MaxColumnIndex || newX < MinColumnIndex || newY >= MaxRowIndex || newY < MinRowIndex)
            {
                throw new IndexOutOfRangeException();
            }

            if (Board.Field[newX, newY] != "+")
            {
                throw new InvalidOperationException();
            }

            return true;
        }

        public bool HasKingWon()
        {
            if (this.king.Position.Y == 0)
            {
                return true;
            }

            for (int i = 0; i < Board.Field.GetLength(0); i += 2)
            {
                if (Board.Field[Board.Field.GetLength(1) - 1, i] == "+" || Board.Field[Board.Field.GetLength(1) - 1, i] == "-")
                {
                    return false;
                }
            }

            return true;
        }

        public bool HasKingLost()
        {
            if (!this.IsCellWhiteOrBlack(this.king.Position.X + 1, this.king.Position.Y + 1)
                && !this.IsCellWhiteOrBlack(this.king.Position.X + 1, this.king.Position.Y - 1)
                && !this.IsCellWhiteOrBlack(this.king.Position.X - 1, this.king.Position.Y + 1)
                && !this.IsCellWhiteOrBlack(this.king.Position.X - 1, this.king.Position.Y - 1))
            {
                return true;
            }

            return false;
        }
    }
}
