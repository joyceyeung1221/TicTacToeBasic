using System;
using Xunit;

namespace TicTacToeTDD.Test
{
    public class MarkerTest
    {
        [Fact]
        public void ShouldRepresentPlayerWithSymbolX()
        {
            var player = new Marker('X',"Player 1");
            var symbol = player.GetSymbol();
            var expected = 'X';
            Assert.Equal(expected, symbol);
        }

        [Fact]
        public void ShouldRepresentPlayerWithSymbolO()
        {
            var player = new Marker('O', "Player 2");
            var symbol = player.GetSymbol();
            var expected = 'O';
            Assert.Equal(expected, symbol);
        }
    }
}
