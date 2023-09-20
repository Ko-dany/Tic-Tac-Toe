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
        
        public void InitializeBoard()
            // Set up a new GameBoard.
        {
            _gameBoard = new GameBoard();
        }

        public string GetCurrentPlayer()
            // Get the current player from the gameboard.
        {
            return _gameBoard.GamePlayer;
        }

        public void SwitchCurrentPlayer()
            // Swtich the current player on the gameboard.
        {
            _gameBoard.GamePlayer = _gameBoard.GamePlayer == "X" ? "O" : "X";
        }

        public bool SelectedSlotIsValid(int selectedCell)
            // Check if the selected slot is already occupied and return "true" if it's empty.
        {
            return _gameBoard.Board[selectedCell] == null;
        }

        public void StoreSlotData(int selectedCell, string player)
            // Store which player took which slot to the gameboard.
        {
            _gameBoard.Board[selectedCell] = player;
        }

        public string GetGameResult()
            // Check the game result.
            // Return "X" | "O" if there's a winner, "Draw" if the game ended with no winner.
            // Otherwise return null.
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
        }
    }
}
