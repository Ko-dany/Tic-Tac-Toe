using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManagement
{
    public class GameManager : IGameManager
    {
        int[][] winningConditions = new int[][]
        {
            new int[] {1,2,3},
            new int[] {4,5,6},
            new int[] {7,8,9},
            new int[] {1,4,7},
            new int[] {2,5,8},
            new int[] {3,6,9},
            new int[] {1,5,9},
            new int[] {3,5,7},
        };

        GameBoard _gameBoard = new GameBoard();
        
        public void Initializer()
        {
            _gameBoard = new GameBoard();
        }

        public string GetCurrentPlayer()
        {
            return _gameBoard.CurrentPlayer;
        }

        public void SwitchCurrentPlayer()
        {
            _gameBoard.CurrentPlayer = (_gameBoard.CurrentPlayer == "X" ? "O" : "X");
        }

        public bool SelectedSlotIsValid(int selectedCell)
        {
            return _gameBoard.Board[selectedCell] == null;
            // Returns true if the cell is empty.
        }

        public void StoreSlotData(int selectedCell, string player)
        {
            _gameBoard.Board[selectedCell] = player;
        }

        public string GetGameResult()
        {
            string gameResult = null;

            if (_gameBoard.Board.Values.All(value => value != null)) gameResult = "Draw";

            foreach (int[] condition in winningConditions)
            {
                if (_gameBoard.Board[condition[0]] == "X"
                    && _gameBoard.Board[condition[1]] == "X"
                    && _gameBoard.Board[condition[2]] == "X")
                {
                    gameResult = "X";
                    break;
                }
                else if (_gameBoard.Board[condition[0]] == "O"
                    && _gameBoard.Board[condition[1]] == "O"
                    && _gameBoard.Board[condition[2]] == "O")
                {
                    gameResult = "O";
                    break;
                }
            }
            return gameResult;
            // Returns non-null string if the game is ended(drawn) or there's a winner.
        }
    }
}
