using System;
using System.Collections.Generic;

namespace TicTacToeTDD
{
    public class PlayerTurn
    {
        private IIO _io;
        private Board _board;
        public bool EndGame = false;
        public PlayerTurn(IIO io, Board board)
        {
            _io = io;
            _board = board;
        }

        public Marker[,] Resolve(Marker marker, GameBoard gameBoard)
        {
            var playerMove = GetPlayerMove(marker, gameBoard);
            if (!EndGame)
            {
                gameBoard.PlaceMarker(marker, playerMove);
            }
            return gameBoard.Board;
        }

        private int[] GetPlayerMove(Marker marker, GameBoard gameBoard)
        {
            int[] playerCoordinate = new int[2];
            bool _isValid = false;
            do
            {
                string playerInput = GetPlayerInput(marker);
                if (playerInput == "q")
                {
                    EndGame = true;
                    return new int[] { -1, -1 };

                }
                var coordinate = ConvertToCoordinate(playerInput);

                if(!IsACoordinate(coordinate) && !_board.IsValidLocation(coordinate.ToArray()))
                {
                    _io.Output($"{playerInput} is not in correct format = int, int or within range");
                    continue;
                }

                playerCoordinate = coordinate.ToArray();

                if (!gameBoard.IsPlaceTaken(playerCoordinate))
                {
                    _isValid = true;
                    continue;
                }

                _io.Output("Oh no, a piece is already at this place! Try again...");

            } while (!_isValid);

            return playerCoordinate;
        }

        private string GetPlayerInput(Marker marker)
        {
            _io.Output($"{marker.Role} enter a coord x,y to place your X or enter 'q' to give up: ");
            return _io.RecordInput();

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
    }
}
