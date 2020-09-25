using System;
using System.Collections.Generic;

namespace TicTacToeTDD
{
    public class GameMaster
    {
        private IIO _io;
        private List<Marker> _listOfMarkers = new List<Marker>();
        private GameBoard _gameBoard;
        private Marker _currentMarker;
        private PlayerTurn _playerTurn;

        public GameMaster(IIO io)
        {
            _io = io;
        }

        public void SetupGame(Board board)
        {
            _listOfMarkers.Add(new Marker('X', "Player 1"));
            _listOfMarkers.Add(new Marker('O', "Player 2"));
            _gameBoard = new GameBoard(board.Row, board.Column);
            _currentMarker = _listOfMarkers[0];
            _playerTurn = new PlayerTurn(_io, board);
        }

        public void Run()
        {
            _playerTurn.Complete(_currentMarker, _gameBoard);
        }

        private void SwitchPlayer()
        {
            var index = _listOfMarkers.IndexOf(_currentMarker);
            var nextMarkerIndex = (index + 1 < _listOfMarkers.Count) ? index + 1 : 0;
            _currentMarker = _listOfMarkers[nextMarkerIndex];
        }

        //public string CompleteTurn(Marker player)
        //{
        //    RecordUserCoordinate();
        //    ValidateInput();
        //    CallOutError();

        //}
    }
}