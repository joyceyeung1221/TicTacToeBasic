using System;
namespace TicTacToeTDD
{
    public class Board
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Board(int rows, int columns)
        {
            Row = rows;
            Column = columns;
        }

        public bool IsValidLocation(int[] coordinate)
        {
            var row = coordinate[0];
            var col = coordinate[1];
            return this.isXWithInBoundary(row) && this.isYWithInBoundary(col);
        }

        private bool isXWithInBoundary(int num)
        {
            return num > 0 && num <= Row;
        }

        private bool isYWithInBoundary(int num)
        {
            return num > 0 && num <= Column;
        }
    }
}