using System;
using Xunit;

namespace TicTacToeTDD.Test
{
    public class BoardTest
    { 
    
        Board board = new Board(3,3);

        [Fact]
        public void ShouldReturnTrue_WhenCoordinatesIsWithinRange()
        {
            var actual = board.IsValidLocation(new int[] { 1, 1 });
            var expected = true;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        public void ShouldReturnFalse_WhenCoordinatesIsOutOfRange(int row, int col)
        {
            var actual = board.IsValidLocation(new int[] { row, col });
            var expected = false;
            Assert.Equal(expected, actual);
        }
    }
}
