namespace KingSurvival
{
	using System;
	public class KingSurvival
	{
		private readonly int[,] board;

		private readonly int[] pawnRows = { 0, 0, 0, 0 };

		private readonly int[] pawnCols = { 0, 2, 4, 6 };

		private int kingRow = 7;

		private int kingColumn = 3;

		//with + are marked the white cells
		private readonly int whiteCell = '+';

		//with - are arked the black cells
		private readonly int blackCell = '-';

		private readonly int[] deltaRows = { -1, +1, +1, -1 }; //UR, DR, DL, UL

		private readonly int[] deltaCols = { +1, +1, -1, -1 };

		public KingSurvival()
		{
			board = new int[8, 8];
			FillTheBoard();
		}

		public void FillTheBoard()
		{
			for (int row = 0; row < board.GetLength(0); row++)
			{
				for (int colum = 0; colum < board.GetLength(1); colum++)
				{
					if ((row + colum) % 2 == 0)
					{
						board[row, colum] = whiteCell;
					}
					else
					{
						board[row, colum] = blackCell;
					}
				}
			}

			board[pawnRows[0], pawnCols[0]] = 'A';

			board[pawnRows[1], pawnCols[1]] = 'B';

			board[pawnRows[2], pawnCols[2]] = 'C';

			board[pawnRows[3], pawnCols[3]] = 'D';

			board[kingRow, kingColumn] = 'K';
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
				case "kur": { indexOfChange = 0; }
					break;
				case "kdr": { indexOfChange = 1; }
					break;
				case "kdl": { indexOfChange = 2; }
					break;
				case "kul": { indexOfChange = 3; }
					break;
				default:
					return false;
			}

			int kingNewRow = kingRow + deltaRows[indexOfChange];
			int kingNewColum = kingColumn + deltaCols[indexOfChange];
			if (IsCellWhiteOrBlack(kingNewRow, kingNewColum))
			{
				board[kingRow, kingColumn] = board[kingNewRow, kingNewColum];
				board[kingNewRow, kingNewColum] = 'K';
				kingRow = kingNewRow;
				kingColumn = kingNewColum;
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
					{ indexOfChange = 1; }
					break;
				case "adl":
				case "bdl":
				case "cdl":
				case "ddl":
					{ indexOfChange = 2; }
					break;
				default:
					return false;
			}

			int pawnIndex = -1;
			switch (command[0])
			{
				case 'a':
				case 'A':
					{ pawnIndex = 0; }
					break;
				case 'b':
				case 'B':
					{ pawnIndex = 1; }
					break;
				case 'c':
				case 'C':
					{ pawnIndex = 2; }
					break;
				case 'd':
				case 'D':
					{ pawnIndex = 3; }
					break;
			}

			int pawnNewRow = pawnRows[pawnIndex] + deltaRows[indexOfChange];
			int pawnNewColum = pawnCols[pawnIndex] + deltaCols[indexOfChange];
			if (IsCellWhiteOrBlack(pawnNewRow, pawnNewColum))
			{
				board[pawnRows[pawnIndex], pawnCols[pawnIndex]] = board[pawnNewRow, pawnNewColum];
				board[pawnNewRow, pawnNewColum] = command.ToUpper()[0];
				pawnRows[pawnIndex] = pawnNewRow;
				pawnCols[pawnIndex] = pawnNewColum;
				return true;
			}

			return false;
		}

		public bool HasKingWon()
		{
			if (kingRow == 0) //check if king is on the first row
			{
				return true;
			}

			for (int i = 0; i < board.GetLength(0); i += 2) // check if all powns are on the last row
			{
				if (board[board.GetLength(1) - 1, i] == whiteCell || board[board.GetLength(1) - 1, i] == blackCell)
				{
					return false;
				}
			}

			return true;
		}

		private bool IsPositionInsideBoard(int row, int colum)
		{
			if (row < 0 || row > board.GetLength(0) - 1 || colum < 0 || colum > board.GetLength(1) - 1)
			{
				return false;
			}

			return true;
		}

		private bool IsCellWhiteOrBlack(int row, int colum)
		{
			if (IsPositionInsideBoard(row, colum))
			{
				if (board[row, colum] == whiteCell || board[row, colum] == blackCell)
				{
					return true;
				}
			}

			return false;
		}

		public bool HasKingLost()
		{
			if (!IsCellWhiteOrBlack(kingRow + 1, kingColumn + 1) && !IsCellWhiteOrBlack(kingRow + 1, kingColumn - 1) &&
				!IsCellWhiteOrBlack(kingRow - 1, kingColumn + 1) && !IsCellWhiteOrBlack(kingRow - 1, kingColumn - 1))
			{
				return true;
			}

			return false;
		}
		public void PrintBoard()
		{
			for (int row = 0; row < board.GetLength(0); row++)
			{
				for (int col = 0; col < board.GetLength(1); col++)
				{
					int cell = board[row, col];
					char toPrint = (char)cell;
					Console.Write(toPrint + " ");
				}

				Console.WriteLine();
			}
		}
		public static void Main()
		{
			KingSurvival game = new KingSurvival();
			int kingMovesCount = 0;
			bool isKingsTurn = true;
			while (true) //while the game ends
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
	}
}
