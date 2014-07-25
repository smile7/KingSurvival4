namespace KingSurvival.Console
{
    using System;
    using System.Collections.Generic;
    using KingSurvival.Base;
    using KingSurvival.Base.Exceptions;
    using KingSurvival.Base.GameObjects;
    using KingSurvival.Console.InputOutputEngines;

    /// <summary>
    /// The main class Engine for the console application; implementing the FACADE pattern
    /// </summary>
    public class KingSurvivalConsoleEngine : KingSurvivalEngine
    {
        public const int MinRowIndex = 0;
        public const int MaxRowIndex = 8;
        public const int MinColumnIndex = 0;
        public const int MaxColumnIndex = 8;

        protected readonly Figure firstPawn = FigureGetter.GetFigure(new Position(0, 0), 'A', "Pawn");
        protected readonly Figure secondPawn = FigureGetter.GetFigure(new Position(0, 2), 'B', "Pawn");
        protected readonly Figure thirdPawn = FigureGetter.GetFigure(new Position(0, 4), 'C', "Pawn");
        protected readonly Figure fourthPawn = FigureGetter.GetFigure(new Position(0, 6), 'D', "Pawn");
        protected readonly Figure king = FigureGetter.GetFigure(new Position(7, 3), 'K', "King");

        private readonly Board board;
        private readonly FigureMemory oldPosition = new FigureMemory();
        private readonly bool isGameInProgress = true;

        private int countTurns = 0;
        private bool kingsTurn = true;

        public KingSurvivalConsoleEngine()
            : base(new ConsoleReader(), new ConsoleWriter())
        {
            this.board = Board.Instance;
            this.Figures = new List<Figure>();
            this.Figures.Add(this.firstPawn);
            this.Figures.Add(this.secondPawn);
            this.Figures.Add(this.thirdPawn);
            this.Figures.Add(this.fourthPawn);
            this.Figures.Add(this.king);
        }

        protected override void GameBegins()
        {
            foreach (var figure in this.Figures)
            {
                this.board.Notify(figure);
            }

            bool hasKingWon = false;

            while (this.isGameInProgress)
            {
                this.RenderBoard(Board.Field);

                if (this.kingsTurn)
                {
                    this.WriteMessage(ConsoleMessages.KingsTurnMessage());
                }
                else
                {
                    this.WriteMessage(ConsoleMessages.PawnsTurnMessage());
                }

                do
                {
                    try
                    {
                        Figure currentFigure;
                        var command = new Command(this.GetCommand().ToUpper());
                        var newPosition = Parser.GetNewPosition(command.NewPositionLetters);

                        if (this.kingsTurn)
                        {
                            currentFigure = this.king;
                            this.countTurns++;

                            string kingSymbol = command.FigureLetter;
                            if (kingSymbol != "K")
                            {
                                throw new InvalidOperationException();
                            }
                        }
                        else
                        {
                            string pawnSymbol = command.FigureLetter;
                            switch (pawnSymbol)
                            {
                                case "A":
                                    currentFigure = this.firstPawn;
                                    break;
                                case "B":
                                    currentFigure = this.secondPawn;
                                    break;
                                case "C":
                                    currentFigure = this.thirdPawn;
                                    break;
                                case "D":
                                    currentFigure = this.thirdPawn;
                                    break;
                                default:
                                    throw new InvalidOperationException();
                            }
                        }

                        this.ChangeFigurePosition(currentFigure, this.oldPosition, newPosition);

                        //if (this.kingsTurn)
                        //{
                            
                        //    bool hasWon = this.HasKingWon();
                        //    if (hasWon)
                        //    {
                        //        hasKingWon = true;
                        //        this.isGameInProgress = false;
                        //        break;
                        //    }
                        //}
                        //else
                        //{
                        //    bool hasLost = this.HasKingLost();
                        //    if (hasLost)
                        //    {
                        //        this.isGameInProgress = false;
                        //        break;
                        //    }
                        //}

                        this.kingsTurn = !this.kingsTurn;
                        break;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        this.WriteMessage(ConsoleMessages.InvalidMoveMessage());
                    }
                    catch (IndexOutOfRangeException)
                    {
                        this.WriteMessage(ConsoleMessages.OutsideBoardMoveMessage());
                    }
                    catch (StepOverException)
                    {
                        this.WriteMessage(ConsoleMessages.StepOverFigureMoveMessage());
                    }
                    catch (InvalidOperationException)
                    {
                        this.WriteMessage(ConsoleMessages.WrongFigureCommand());
                    }
                }
                while (true);
            }

            this.GameEnds(hasKingWon);
        }

        protected override void GameEnds(bool hasKingWon)
        {
            this.RenderBoard(Board.Field);

            if (hasKingWon)
            {
                this.WriteMessage(ConsoleMessages.KingWonMessage(this.countTurns));
            }
            else
            {
                this.WriteMessage(ConsoleMessages.KingLostMessage(this.countTurns));
            }
        }

        //TO DO: Make a method which finds out if the game has ended and 
        //after that ask if hasKingWon in order to write the final message in GameEnds


        protected override bool HasKingWon()
        {
            if (this.king.Position.X == 0)
            {
                return true;
            }

            for (int i = 0; i < Board.Field.GetLength(0); i += 2)
            {
                if (Board.Field[Board.Field.GetLength(1) - 1, i] == Board.WhiteCell || Board.Field[Board.Field.GetLength(1) - 1, i] == Board.BlackCell)
                {
                    return false;
                }
            }

            return true;
        }

        private bool ChangeFigurePosition(Figure figure, FigureMemory oldPosition, Position initial)
        {
            if (this.IsMoveValid(figure, initial))
            {
                var clonedFigure = figure.Clone() as Figure;
                oldPosition.Memento = clonedFigure.SaveMemento();

                MoveableFigure changeFigurePosition = new MoveableFigure(figure);
                changeFigurePosition.MoveFigure(initial);

                this.board.Notify(figure, oldPosition.Memento.Position);

                return true;
            }

            return false;
        }

        private bool IsMoveValid(Figure figure, Position newPosition)
        {
            int newX = figure.Position.X + newPosition.X;
            int newY = figure.Position.Y + newPosition.Y;

            if (this.IsPositionInsideBoard(newX, newY))
            {
                if (this.HasSteppedOverAnotherFigure(newX, newY))
                {
                    return true;
                }

                throw new StepOverException();
            }

            throw new IndexOutOfRangeException();
        }

        protected bool HasSteppedOverAnotherFigure(int row, int col)
        {
            if (Board.Field[row, col] == Board.WhiteCell || Board.Field[row, col] == Board.BlackCell)
            {
                return true;
            }

            return false;
        }

        protected bool IsPositionInsideBoard(int row, int col)
        {
            if (col >= MaxColumnIndex || col < MinColumnIndex || row >= MaxRowIndex || row < MinRowIndex)
            {
                return false;
            }

            return true;
        }
    }
}
