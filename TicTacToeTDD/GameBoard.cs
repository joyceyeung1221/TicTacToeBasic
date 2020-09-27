using System;
using System.Linq;

namespace TicTacToeTDD
{
    public class GameBoard
    {
        public Marker[,] Board;
        const char emptySlotSymbol = '.';

        public GameBoard(int row, int col)
        {
            Board = new Marker[row, col];

        }

        public void PlaceMarker(Marker marker, int[] coordinate)
        {
            Board[coordinate[0] - 1, coordinate[1] - 1] = marker;
        }


        public bool IsPlaceTaken(int[] coordinate)
        {
            return Board[coordinate[0] - 1, coordinate[1] - 1] != null;
        }

        public string PresentBoard()
        {
            int rowLength = Board.GetLength(0);
            int colLength = Board.GetLength(1);
            string output = "";

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    var symbol = getMarkerSymbol(Board[i, j]);
                    output += string.Format("{0} ", symbol);
                }
                output += "\n";
            }
            return output;

        }

        private char getMarkerSymbol(Marker marker)
        {
            if (marker != null)
            {
                return marker.GetSymbol();
            }
            return emptySlotSymbol;
        }
    }
}
