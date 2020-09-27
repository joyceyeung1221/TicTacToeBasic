using System;

namespace TicTacToeTDD
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(3, 3);
            IIO io = new InputOutput();
            GameMaster gameMaster = new GameMaster(io);
            gameMaster.SetupGame(board);
            gameMaster.Run();
        }
    }
}
