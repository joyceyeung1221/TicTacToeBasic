using System;
using Xunit;
using Moq;
namespace TicTacToeTDD.Test
{
    public class PlayerTurnTest
    {
        public PlayerTurnTest()
        {
        }

        [Fact]
        public void ShouldReturnUpdatedBoard_WhenUserEnterCoordinate()
        {
            var player = new Marker('X',"Player 1");
            var gameBoard = new GameBoard(3, 3);
            var mockio = new Mock<IIO>();
            mockio.Setup(x => x.RecordInput()).Returns("1,1");
            var playerTurn = new PlayerTurn(mockio.Object, new Board(3, 3));
            var actual = playerTurn.Complete(player, gameBoard);
            var expected = new Marker[,] { { player, null, null }, { null, null, null }, { null, null, null } };

            Assert.Equal(expected, actual);
        }
    }
}
