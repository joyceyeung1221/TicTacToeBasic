using System;
using System.Collections.Generic;

namespace TicTacToeTDD
{
    public class PlayerTurn
    {
        private IIO _io;
        private Board _board;
        private bool _isValid;
        public PlayerTurn(IIO io, Board board)
        {
            _io = io;
            _board = board;
        }

        public Marker[,] Complete(Marker marker, GameBoard gameBoard)
        {
            var playerMove = GetPlayerMove(marker, gameBoard);
            gameBoard.PlaceMarker(marker, playerMove);
            return gameBoard.Board;
        }

        private int[] GetPlayerMove(Marker marker, GameBoard gameBoard)
        {
            int[] playerCoordinate;
            do
            {
                SetDefaultValidIndicator();
                playerCoordinate = GetBoardCoordinateFromUser(marker);
                if (!gameBoard.IsPlaceTaken(playerCoordinate))
                {
                    _isValid = true;
                }
                else
                {
                    _io.Output("Oh no, a piece is already at this place! Try again...");
                }
            } while (_isValid==false);
            return playerCoordinate;
        }

        private int[] GetBoardCoordinateFromUser(Marker marker)
        {
            int[] playerCoordinate;
            do
            {
                playerCoordinate = RecordPlayerCoordinate(marker);
            } while (!_board.IsValidLocation(playerCoordinate));
            return playerCoordinate;
        }

        private int[] RecordPlayerCoordinate(Marker marker)
        {
            List<int> coordinate;
            do
            {
                SetDefaultValidIndicator();
                _io.Output($"{marker.Role} enter a coord x,y to place your X or enter 'q' to give up: ");
                string userInput = _io.RecordInput();
                coordinate = ConvertToCoordinate(userInput);
                if (IsACoordinate(coordinate) && _board.IsValidLocation(coordinate.ToArray()))
                {
                    _isValid = true;
                }
                else
                {
                    _io.Output($"{userInput} is not in correct format = int, int");
                }
            } while (_isValid == false);
            return coordinate.ToArray();
        }

        private bool IsACoordinate(List<int> coordinate)
        {
            return coordinate.Count == 2 && !coordinate.Exists(value => value < 0);
        }

        private List<int> ConvertToCoordinate(string input)
        {
            var coordinate = new List<int>();
            var splitInput = input.Split(',');
            foreach (string value in splitInput)
            {
                if (Int32.TryParse(value, out int num))
                {
                    coordinate.Add(num);
                }
                else
                {
                    coordinate.Add(-1);
                }
            }
            return coordinate;
        }

        private void SetDefaultValidIndicator()
        {
            _isValid = false;
        }
    }
}
