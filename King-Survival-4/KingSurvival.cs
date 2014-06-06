namespace KingSurvival
{
	using System;

	public class KingSurvival
	{
		private readonly int[,] board;

		private readonly int[] pawnRows = { 0, 0, 0, 0 };

		private readonly int[] pawnCols = { 0, 2, 4, 6 };

		////with + are marked the white cells
		private readonly int whiteCell = '+';

		////with - are arked the black cells
		private readonly int blackCell = '-';

		private readonly int[] deltaRows = { -1, +1, +1, -1 }; ////UR, DR, DL, UL

		private readonly int[] deltaCols = { +1, +1, -1, -1 };

		private int kingRow = 7;

		private int kingColumn = 3;

		public KingSurvival()
		{
			this.board = new int[8, 8];
			this.FillTheBoard();
		}

		public static void Main()
		{
			KingSurvival game = new KingSurvival();
			int kingMovesCount = 0;
			bool isKingsTurn = true;
			while (true) ////while the game ends
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

		public void FillTheBoard()
		{
			for (int row = 0; row < this.board.GetLength(0); row++)
			{
				for (int colum = 0; colum < this.board.GetLength(1); colum++)
				{
					if ((row + colum) % 2 == 0)
					{
						this.board[row, colum] = this.whiteCell;
					}
					else
					{
						this.board[row, colum] = this.blackCell;
					}
				}
			}

            this.board[this.pawnRows[0], this.pawnCols[0]] = 'A';

            this.board[this.pawnRows[1], this.pawnCols[1]] = 'B';

            this.board[this.pawnRows[2], this.pawnCols[2]] = 'C';

            this.board[this.pawnRows[3], this.pawnCols[3]] = 'D';

            this.board[this.kingRow, this.kingColumn] = 'K';
		}

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
            int kingNewColum = this.kingColumn + this.deltaCols[indexOfChange];
            if (this.IsCellWhiteOrBlack(kingNewRow, kingNewColum))
			{
                this.board[this.kingRow, this.kingColumn] = this.board[kingNewRow, kingNewColum];
                this.board[kingNewRow, kingNewColum] = 'K';
                this.kingRow = kingNewRow;
                this.kingColumn = kingNewColum;
				return true;
			}

			return false;
		}

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

		public bool HasKingWon()
		{
            if (this.kingRow == 0) ////check if king is on the first row
			{
				return true;
			}

			for (int i = 0; i < this.board.GetLength(0); i += 2) //// check if all powns are on the last row
			{
				if (this.board[this.board.GetLength(1) - 1, i] == this.whiteCell || this.board[this.board.GetLength(1) - 1, i] == this.blackCell)
				{
					return false;
				}
			}

			return true;
		}

		public bool HasKingLost()
		{
            if (!this.IsCellWhiteOrBlack(this.kingRow + 1, this.kingColumn + 1) && !this.IsCellWhiteOrBlack(this.kingRow + 1, this.kingColumn - 1) &&
                !this.IsCellWhiteOrBlack(this.kingRow - 1, this.kingColumn + 1) && !this.IsCellWhiteOrBlack(this.kingRow - 1, this.kingColumn - 1))
			{
				return true;
			}

			return false;
		}

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

		private bool IsPositionInsideBoard(int row, int colum)
		{
			if (row < 0 || row > this.board.GetLength(0) - 1 || colum < 0 || colum > this.board.GetLength(1) - 1)
			{
				return false;
			}

			return true;
		}

		private bool IsCellWhiteOrBlack(int row, int colum)
		{
			if (this.IsPositionInsideBoard(row, colum))
			{
				if (this.board[row, colum] == this.whiteCell || this.board[row, colum] == this.blackCell)
				{
					return true;
				}
			}

			return false;
		}
	}
}
