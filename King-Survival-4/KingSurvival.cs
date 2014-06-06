namespace KingSurvival
{
	using System;

    /// <summary>
    /// The main class of the game
    /// </summary>
	public class KingSurvival
	{
        /// <summary>
        /// Field for the main board
        /// </summary>
		private readonly int[,] board;

        /// <summary>
        /// Field for the rows of the pawns
        /// </summary>
		private readonly int[] pawnRows = { 0, 0, 0, 0 };

        /// <summary>
        /// Field for the cols of the pawns
        /// </summary>
		private readonly int[] pawnCols = { 0, 2, 4, 6 };

		/// <summary>
		/// Filed for the white cells (marked with +)
		/// </summary>
		private readonly int whiteCell = '+';

		/// <summary>
		/// Field for the black cells (marked with -)
		/// </summary>
		private readonly int blackCell = '-';

        /// <summary>
        /// The positions stored for the movement on the rows (UR, DR, DL, UL)
        /// </summary>
		private readonly int[] deltaRows = { -1, +1, +1, -1 }; ////UR, DR, DL, UL

        /// <summary>
        /// The positions stored for the movement on the cols (UR, DR, DL, UL)
        /// </summary>
		private readonly int[] deltaCols = { +1, +1, -1, -1 };

        /// <summary>
        /// Field for the initial place of the king on the rows
        /// </summary>
		private int kingRow = 7;

        /// <summary>
        /// Field for the initial place of the king on the cols
        /// </summary>
		private int kingCol = 3;

        /// <summary>
        /// The constructor for the class
        /// </summary>
		public KingSurvival()
		{
			this.board = new int[8, 8];
			this.FillTheBoard();
		}

        /// <summary>
        /// The main method where the game starts
        /// </summary>
		public static void Main()
		{
			KingSurvival game = new KingSurvival();
			int kingMovesCount = 0;
			bool isKingsTurn = true;
			while (true)
			{
				if (game.HasKingWon())
				{
					Console.WriteLine("King won in {0} turns", kingMovesCount);
					break;
				}
				else if (game.HasKingLost())
				{
					Console.WriteLine("King lost in {0} turns", kingMovesCount);
					break;
				}
				else
				{
					Console.WriteLine();
					game.PrintBoard();
					if (isKingsTurn)
					{
						bool kingMoved = false;
						while (!kingMoved)
						{
							Console.Write("King's turn: ");
							string command = Console.ReadLine();
							kingMoved = game.MoveKingIfPossible(command);
							if (!kingMoved)
							{
								Console.WriteLine("Illegal move!");
							}
						}

						isKingsTurn = false;
						kingMovesCount++;
					}
					else
					{
						bool pawnMoved = false;
						while (!pawnMoved)
						{
							Console.Write("Pawns' turn: ");
							string command = Console.ReadLine();
							pawnMoved = game.MovePawnIfPossible(command);
							if (!pawnMoved)
							{
								Console.WriteLine("Illegal move!");
							}
						}

						isKingsTurn = true;
					}
				}
			}
		}

        /// <summary>
        /// Fills the main board with +, - and A,B,C,D,K
        /// </summary>
		public void FillTheBoard()
		{
			for (int row = 0; row < this.board.GetLength(0); row++)
			{
				for (int col = 0; col < this.board.GetLength(1); col++)
				{
					if ((row + col) % 2 == 0)
					{
						this.board[row, col] = this.whiteCell;
					}
					else
					{
						this.board[row, col] = this.blackCell;
					}
				}
			}

            this.board[this.pawnRows[0], this.pawnCols[0]] = 'A';

            this.board[this.pawnRows[1], this.pawnCols[1]] = 'B';

            this.board[this.pawnRows[2], this.pawnCols[2]] = 'C';

            this.board[this.pawnRows[3], this.pawnCols[3]] = 'D';

            this.board[this.kingRow, this.kingCol] = 'K';
		}

        /// <summary>
        /// Checks what is the command given and moves the king to a new cell if possible
        /// </summary>
        /// <param name="command">Input command type string</param>
        /// <returns>Returns true or false depending on whether the cell is white/black</returns>
		public bool MoveKingIfPossible(string command)
		{
			if (command.Length != 3)
			{
				return false;
			}

			string commandToLower = command.ToLower();
			int indexOfChange = -1;
			switch (commandToLower)
			{
				case "kur": 
					{ 
						indexOfChange = 0;
					}

					break;
				case "kdr": 
					{ 
						indexOfChange = 1;
					}

					break;
				case "kdl": 
					{ 
						indexOfChange = 2; 
					}

					break;
				case "kul": 
					{ 
						indexOfChange = 3; 
					}

					break;
				default:
					return false;
			}

            int kingNewRow = this.kingRow + this.deltaRows[indexOfChange];
            int kingNewCol = this.kingCol + this.deltaCols[indexOfChange];
            if (this.IsCellWhiteOrBlack(kingNewRow, kingNewCol))
			{
                this.board[this.kingRow, this.kingCol] = this.board[kingNewRow, kingNewCol];
                this.board[kingNewRow, kingNewCol] = 'K';
                this.kingRow = kingNewRow;
                this.kingCol = kingNewCol;
				return true;
			}

			return false;
		}

        /// <summary>
        /// Checks what is the command given and moves the pawn to a new cell if possible
        /// </summary>
        /// <param name="command">Input command type string</param>
        /// <returns>Returns true or false depending on whether the cell is white/black</returns>
		public bool MovePawnIfPossible(string command)
		{
			if (command.Length != 3)
			{
				return false;
			}

			string commandToLower = command.ToLower();
			int indexOfChange = -1;
			switch (commandToLower)
			{
				case "adr":
				case "bdr":
				case "cdr":
				case "ddr":
					{ 
						indexOfChange = 1; 
					}

					break;
				case "adl":
				case "bdl":
				case "cdl":
				case "ddl":
					{ 
						indexOfChange = 2; 
					}

					break;
				default:
					return false;
			}

			int pawnIndex = -1;
			switch (command[0])
			{
				case 'a':
				case 'A':
					{ 
						pawnIndex = 0; 
					}

					break;
				case 'b':
				case 'B':
					{ 
						pawnIndex = 1; 
					}

					break;
				case 'c':
				case 'C':
					{ 
						pawnIndex = 2; 
					}

					break;
				case 'd':
				case 'D':
					{ 
						pawnIndex = 3; 
					}

					break;
			}

            int pawnNewRow = this.pawnRows[pawnIndex] + this.deltaRows[indexOfChange];
            int pawnNewColum = this.pawnCols[pawnIndex] + this.deltaCols[indexOfChange];
            if (this.IsCellWhiteOrBlack(pawnNewRow, pawnNewColum))
			{
                this.board[this.pawnRows[pawnIndex], this.pawnCols[pawnIndex]] = this.board[pawnNewRow, pawnNewColum];
				this.board[pawnNewRow, pawnNewColum] = command.ToUpper()[0];
                this.pawnRows[pawnIndex] = pawnNewRow;
                this.pawnCols[pawnIndex] = pawnNewColum;
				return true;
			}

			return false;
		}

        /// <summary>
        /// Checks if the king is on the first row and if all pawns are on the last row
        /// </summary>
        /// <returns>Returns true or false</returns>
		public bool HasKingWon()
		{
            if (this.kingRow == 0)
			{
				return true;
			}

			for (int i = 0; i < this.board.GetLength(0); i += 2)
			{
				if (this.board[this.board.GetLength(1) - 1, i] == this.whiteCell || this.board[this.board.GetLength(1) - 1, i] == this.blackCell)
				{
					return false;
				}
			}

			return true;
		}

        /// <summary>
        /// Checks if the king has no adjacent cells to move to
        /// </summary>
        /// <returns>Returns true or false</returns>
		public bool HasKingLost()
		{
            if (!this.IsCellWhiteOrBlack(this.kingRow + 1, this.kingCol + 1) && !this.IsCellWhiteOrBlack(this.kingRow + 1, this.kingCol - 1) &&
                !this.IsCellWhiteOrBlack(this.kingRow - 1, this.kingCol + 1) && !this.IsCellWhiteOrBlack(this.kingRow - 1, this.kingCol - 1))
			{
				return true;
			}

			return false;
		}

        /// <summary>
        /// Prints the main board
        /// </summary>
		public void PrintBoard()
		{
			for (int row = 0; row < this.board.GetLength(0); row++)
			{
				for (int col = 0; col < this.board.GetLength(1); col++)
				{
					int cell = this.board[row, col];
					char toPrint = (char)cell;
					Console.Write(toPrint + " ");
				}

				Console.WriteLine();
			}
		}

        /// <summary>
        /// Checks if the cell is inside the board or not
        /// </summary>
        /// <param name="row">Input row type number</param>
        /// <param name="col">Input col type number</param>
        /// <returns>Returns true or false</returns>
		private bool IsPositionInsideBoard(int row, int col)
		{
			if (row < 0 || row > this.board.GetLength(0) - 1 || col < 0 || col > this.board.GetLength(1) - 1)
			{
				return false;
			}

			return true;
		}

        /// <summary>
        /// Checks if the current cell is inside the board and if it is white or black
        /// </summary>
        /// <param name="row">Input row type number</param>
        /// <param name="col">Input col type number</param>
        /// <returns>Returns true or false</returns>
		private bool IsCellWhiteOrBlack(int row, int col)
		{
			if (this.IsPositionInsideBoard(row, col))
			{
				if (this.board[row, col] == this.whiteCell || this.board[row, col] == this.blackCell)
				{
					return true;
				}
			}

			return false;
		}
	}
}
