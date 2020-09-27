using System;
using System.Collections.Generic;

namespace TicTacToeTDD
{
    public class GameMaster
    {
        private IIO _io;
        private List<Marker> _markerList = new List<Marker>();
        private GameBoard _gameBoard;
        private Marker _currentMarker;
        private PlayerTurn _playerTurn;
        private bool _isGameConcluded;

        public GameMaster(IIO io)
        {
            _io = io;
        }

        public void SetupGame(Board board)
        {
            _markerList.Add(new Marker('X', "Player 1"));
            _markerList.Add(new Marker('O', "Player 2"));
            _gameBoard = new GameBoard(board.Row, board.Column);
            _currentMarker = _markerList[0];
            _playerTurn = new PlayerTurn(_io, board);
            _isGameConcluded = false;
        }

        public void Run()
        {
            do
            {
                ProcessRound();

            } while (!_isGameConcluded);
        }

        private void ProcessRound()
        {
            var gameStatus = _playerTurn.Resolve(_currentMarker, _gameBoard);
            if(_playerTurn.EndGame == true)
            {
                AnnouncePlayerGiveUp();
                _isGameConcluded = true;
                return;
            }
            if(WinningValidator.HasWinner(gameStatus))
            {
                AnnounceWinner();
                _isGameConcluded = true;
            } else if (WinningValidator.IsADraw(gameStatus))
            {
                AnnounceDraw();
                _isGameConcluded = true;
            }
            else
            {
                ConfirmMove();
                SwitchPlayer();
            }
            _io.Output(_gameBoard.PresentBoard());

        }

        private void AnnouncePlayerGiveUp()
        {
            _io.Output("You have resigned from the game.");

        }

        private void SwitchPlayer()
        {
            var index = _markerList.IndexOf(_currentMarker);
            var nextMarkerIndex = (index + 1 < _markerList.Count) ? index + 1 : 0;
            _currentMarker = _markerList[nextMarkerIndex];
        }

        private void AnnounceWinner()
        {
            _io.Output("Move accepted, well done you've won the game!");
        }

        private void AnnounceDraw()
        {
            _io.Output("Move accepted, it is a draw!");
        }
        private void ConfirmMove()
        {
            _io.Output("Move accepted, here's the current board:");

        }
    }
}