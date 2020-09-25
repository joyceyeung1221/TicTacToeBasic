using System;
namespace TicTacToeTDD
{
    public class Marker
    {
        private char _symbol;
        public string Role;
        public Marker(char symbol, string role)
        {
            _symbol = symbol;
            Role = role;
            
        }

        public char GetSymbol()
        {
            return _symbol;
        }
    }
}
