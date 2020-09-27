using System;
using Xunit;

namespace TicTacToeTDD.Test
{
    public class GameBoardTest
    {
        Marker marker1 = new Marker('X',"Player 1");
        Marker marker2 = new Marker('O',"Player 2");
        int row = 3;
        int col = 3;

        [Fact]
        public void ShouldReturnFalseWhenPlaceIsNotTaken()
        {
            var coordinate = new int[] { row, col };
            GameBoard gameBoard = new GameBoard(row, col);
            var result = gameBoard.IsPlaceTaken(coordinate);
            var expected = false;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(3, 1, true)]
        public void ShouldReturnTrueWhenAMarkerIsPlaced(int row, int col, bool expected)
        {
            var coordinate = new int[] { row, col };
            GameBoard gameBoard = new GameBoard(row, col);
            gameBoard.PlaceMarker(marker1, coordinate);

            var result = gameBoard.IsPlaceTaken(coordinate);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldPrintDots_WhenSlotsAreEmpty()
        {
            GameBoard gameBoard = new GameBoard(row, col);

            var result = gameBoard.PresentBoard();
            var expected = ". . . \n. . . \n. . . \n";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldPrintPlayerSymbol_WhereSlotsAreTaken()
        {
            GameBoard gameBoard = new GameBoard(row, col);
            gameBoard.PlaceMarker(marker1, new int[] { 1, 1 });
            gameBoard.PlaceMarker(marker2, new int[] { 3, 3 });

            var result = gameBoard.PresentBoard();
            var expected = "X . . \n. . . \n. . O \n";

            Assert.Equal(expected, result);
        }
    }
}