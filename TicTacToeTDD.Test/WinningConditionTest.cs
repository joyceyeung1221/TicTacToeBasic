using System;
using Xunit;
namespace TicTacToeTDD.Test
{
    public class WinningConditionTest
    {
        public WinningConditionTest()
        {
        }

        static Board board = new Board(3, 3);
        static Marker player = new Marker('X', "Player 1");

        [Fact]
        public void ShouldReturnFalseWhenCriteriaIsNotMet()
        {

            var stubGameBoard = new Marker[,]{ {null,null,null },{null,null,null },{null,null,null } };
            var result = WinningCondition.IsMet(stubGameBoard);
            var expected = false;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldReturnFalseWhenRowIsHalfOccupied()
        {
            var stubGameBoard = new Marker[,] { { null, player, player }, { null, null, null }, { player, null, null } };
            var result = WinningCondition.IsMet(stubGameBoard);
            var expected = false;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldReturnTrueWhenFirstRowIsFullyOccupiedByTheSamePlayer()
        {
            
            var stubGameBoard = new Marker[,]{ {player,player,player },{null,null,null },{null,null,null } };
            var result = WinningCondition.IsMet(stubGameBoard);
            var expected = true;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldReturnTrueWhenSecondRowIsFullyOccupiedByTheSamePlayer()
        {

            var stubGameBoard = new Marker[,] { { null, null, null }, { player, player, player }, { null, null, null } };
            var result = WinningCondition.IsMet(stubGameBoard);
            var expected = true;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldReturnTrueWhenThirdRowIsFullyOccupiedByTheSamePlayer()
        {

            var stubGameBoard = new Marker[,] { { null, null, null }, { null, null, null }, { player, player, player } };
            var result = WinningCondition.IsMet(stubGameBoard);
            var expected = true;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldReturnTrueWhenFirstColumnIsFullyOccupiedByTheSamePlayer()
        {

            var stubGameBoard = new Marker[,] { { player, null, null }, { player, null, null }, { player, null, null } };
            var result = WinningCondition.IsMet(stubGameBoard);
            var expected = true;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldReturnTrueWhenMiddleColumnIsFullyOccupiedByTheSamePlayer()
        {

            var stubGameBoard = new Marker[,] { { null, player, null }, { null, player, null }, { null, player, null } };
            var result = WinningCondition.IsMet(stubGameBoard);
            var expected = true;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldReturnTrueWhenLastolumnIsFullyOccupiedByTheSamePlayer()
        {

            var stubGameBoard = new Marker[,] { { null, null, player }, { null, null, player }, { null, null, player } };
            var result = WinningCondition.IsMet(stubGameBoard);
            var expected = true;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldReturnTrueWhenDiagnolLineStartFromTopLeftIsFullyOccupiedByTheSamePlayer()
        {

            var stubGameBoard = new Marker[,] { { player, null, null }, { null, player, null }, { null, null, player } };
            var result = WinningCondition.IsMet(stubGameBoard);
            var expected = true;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldReturnTrueWhenDiagnolLineStartFromTopRightIsFullyOccupiedByTheSamePlayer()
        {

            var stubGameBoard = new Marker[,] { { null, null, player }, { null, player, null }, { player, null, null } };
            var result = WinningCondition.IsMet(stubGameBoard);
            var expected = true;

            Assert.Equal(expected, result);
        }
    }
}
