﻿namespace KingSurvival.Console
{
    using System;
    using System.Collections.Generic;

    using KingSurvival.Base;
    using KingSurvival.Base.Exceptions;
    using KingSurvival.Base.GameObjects;
    using KingSurvival.Console.InputOutputEngines;
    using KingSurvival.Validations;
    using KingSurvival.Base.FigureExtensions;

    /// <summary>
    /// The main class Engine for the console application; implementing the FACADE pattern
    /// </summary>
    public class KingSurvivalConsoleEngine : KingSurvivalEngine
    {
        /// <summary>
        /// Private figures for the console implementation of the game
        /// </summary>
        private readonly Figure firstPawn = FigureGetter.GetFigure(new Position(0, 0), 'A', "Pawn");
        private readonly Figure secondPawn = FigureGetter.GetFigure(new Position(0, 2), 'B', "Pawn");
        private readonly Figure thirdPawn = FigureGetter.GetFigure(new Position(0, 4), 'C', "Pawn");
        private readonly Figure fourthPawn = FigureGetter.GetFigure(new Position(0, 6), 'D', "Pawn");
        private readonly Figure king = FigureGetter.GetFigure(new Position(7, 3), 'K', "King");

        /// <summary>
        /// Field for the board
        /// </summary>
        private readonly Board board;

        /// <summary>
        /// This varialble saves the state of the figure's old position
        /// </summary>
        private readonly FigureMemory oldPosition = new FigureMemory();

        private bool isGameInProgress = true;
        private int countTurns = 0;
        private bool kingsTurn = true;

        /// <summary>
        /// Constructor for the console application. 
        /// Here the figures for the console implementation are 
        /// added to the list of figures in the base class.
        /// </summary>
        public KingSurvivalConsoleEngine()
            : base(new ConsoleReader(), new ConsoleWriter())
        {
            this.board = Board.Instance;
            this.Figures = new List<Figure>();
            AddFiguresToList();
        }

        /// <summary>
        /// Implementation of the abstract method GameBegins from the base class.
        /// While the game is in progress, the figures' turns are played.
        /// </summary>
        protected override void GameBegins()
        {
            foreach (var figure in this.Figures)
            {
                this.board.Notify(figure);
            }

            while (this.isGameInProgress)
            {
                this.RenderBoard(Board.Field);

                PlayFigureTurn();
            }

            this.GameEnds();
        }

        /// <summary>
        /// Implementation of the abstract method GameEnds from the base class for a console application.
        /// Here the board is rendered one more time and a final message is displayed.
        /// </summary>
        protected override void GameEnds()
        {
            this.RenderBoard(Board.Field);

            if (EngineValidator.HasKingWon(this.Figures))
            {
                this.WriteMessage(ConsoleMessages.KingWonMessage(this.countTurns));
            }
            else
            {
                this.WriteMessage(ConsoleMessages.KingLostMessage(this.countTurns));
            }
        }

        /// <summary>
        /// Adds the figures to the list of figures in the parent class
        /// </summary>
        private void AddFiguresToList()
        {
            this.Figures.Add(this.firstPawn);
            this.Figures.Add(this.secondPawn);
            this.Figures.Add(this.thirdPawn);
            this.Figures.Add(this.fourthPawn);
            this.Figures.Add(this.king);
        }

        /// <summary>
        /// Executes the commands for the player whose turn it is
        /// </summary>
        private void PlayFigureTurn()
        {
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

                    if (EngineValidator.HasGameEnded(this.Figures))
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

        /// <summary>
        /// Changes the position of a figure if it is valid
        /// </summary>
        /// <param name="figure">The figure that wants to move</param>
        /// <param name="oldPosition">The memory which saves the previous state of the figure</param>
        /// <param name="newPosition">The new position where we want to move the figure</param>
        private void ChangeFigurePosition(Figure figure, FigureMemory oldPosition, Position newPosition)
        {
            if (EngineValidator.IsMoveValid(figure, newPosition))
            {
                var clonedFigure = figure.Clone() as Figure;
                oldPosition.Memento = clonedFigure.SaveMemento();

                MoveableFigure changeFigurePosition = new MoveableFigure(figure);
                changeFigurePosition.MoveFigure(newPosition);

                this.board.Notify(figure, oldPosition.Memento.Position);
            }
        }
    }
}
