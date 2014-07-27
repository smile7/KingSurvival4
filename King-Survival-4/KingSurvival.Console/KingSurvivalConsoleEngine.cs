namespace KingSurvival.Console
{
    using System;
    using System.Collections.Generic;
    using KingSurvival.Base;
    using KingSurvival.Base.Exceptions;
    using KingSurvival.Base.GameObjects;
    using KingSurvival.Console.InputOutputEngines;
    using KingSurvival.Validations;

    /// <summary>
    /// The main class Engine for the console application; implementing the FACADE pattern
    /// </summary>
    public class KingSurvivalConsoleEngine : KingSurvivalEngine
    {
        private readonly Figure firstPawn = FigureGetter.GetFigure(new Position(0, 0), 'A', "Pawn");
        private readonly Figure secondPawn = FigureGetter.GetFigure(new Position(0, 2), 'B', "Pawn");
        private readonly Figure thirdPawn = FigureGetter.GetFigure(new Position(0, 4), 'C', "Pawn");
        private readonly Figure fourthPawn = FigureGetter.GetFigure(new Position(0, 6), 'D', "Pawn");
        private readonly Figure king = FigureGetter.GetFigure(new Position(7, 3), 'K', "King");

        private readonly Board board;
        private readonly FigureMemory oldPosition = new FigureMemory();

        private bool isGameInProgress = true;
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
                                    currentFigure = this.fourthPawn;
                                    break;
                                default:
                                    throw new InvalidOperationException();
                            }
                        }

                        this.ChangeFigurePosition(currentFigure, this.oldPosition, newPosition);

                        if (EngineValidator.HasGameEnded(this.king))
                        {
                            this.isGameInProgress = false;
                        }

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

            this.GameEnds();
        }

        protected override void GameEnds()
        {
            this.RenderBoard(Board.Field);

            if (this.HasKingWon())
            {
                this.WriteMessage(ConsoleMessages.KingWonMessage(this.countTurns));
            }
            else
            {
                this.WriteMessage(ConsoleMessages.KingLostMessage(this.countTurns));
            }
        }

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
            if (EngineValidator.IsMoveValid(figure, initial))
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
    }
}
