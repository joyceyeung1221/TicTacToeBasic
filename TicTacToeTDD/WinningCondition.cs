using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeTDD
{
    public class WinningCondition
    {

        public static bool IsMet(Marker[,] board)
        {
            return IsAnyRowOccupiedByOnePlayer(board) || IsAnyColumnOccupiedByOnePlayer(board) || IsAnyDiagonalLineOccupidedByOnePlayer(board);
        }

        static bool IsAnyRowOccupiedByOnePlayer(Marker[,] board)
        {
            for(int r = 0; r < board.GetLength(0); r++)
            {
                var row = new List<Marker>();
                for(int c = 0; c< board.GetLength(1); c++)
                {
                    row.Add(board[r, c]);
                }
                if (AllFieldsContainsTheSamePlayer(row))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsAnyColumnOccupiedByOnePlayer(Marker[,] board)
        {
            for (int c = 0; c < board.GetLength(1); c++)
            {
                var column = new List<Marker>();
                for (int r = 0; r < board.GetLength(0); r++)
                {
                    column.Add(board[r, c]);
                }
                if (AllFieldsContainsTheSamePlayer(column))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsAnyDiagonalLineOccupidedByOnePlayer(Marker[,] board)
        {
            var diagonalLine = GetLineFromTopLeftToBottomRight(board);
            if (AllFieldsContainsTheSamePlayer(diagonalLine))
            {
                return true;
            }
            else
            {
                diagonalLine = GetLineFromTopRightToBottomLeft(board);
                return AllFieldsContainsTheSamePlayer(diagonalLine);
            }
        }

        private static List<Marker> GetLineFromTopLeftToBottomRight(Marker[,] board)
        {
            var connectedFields = new List<Marker>();
            for(int i = 0; i <board.GetLength(0); i++)
            {
                connectedFields.Add(board[i, i]);
            }
            return connectedFields;
        }

        private static List<Marker> GetLineFromTopRightToBottomLeft(Marker[,] board)
        {
            var connectedFields = new List<Marker>();
            var r = 0;
            for (int c = board.GetLength(0)-1; c >=0; c--)
            {
                connectedFields.Add(board[r, c]);
                r++;
            }
            return connectedFields;
        }

        private static bool AllFieldsContainsTheSamePlayer(List<Marker> line)
        {
            var filteredRow = line.Distinct();
            return filteredRow.Count() == 1 && filteredRow.First() != null;
        }
    }
}
