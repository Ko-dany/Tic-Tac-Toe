using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManagement
{
    internal interface IGameManager
    {
        void Initializer();
        // Initialize the game.

        char GetCurrentPlayer();
        // Returns current player

        void SwitchCurrentPlayer();

        bool CheckTheSelectedCell(int selectedCell);
        // Check if the selected cell is available.
        // Returns true if it's available.

        void StoreCellData(int selectedCell, char player);
        // Store the cell data.

        string GetGameResult();
        // Check
        // 1. if the game eneded (if all cells are occupied)
        // 2. if there is a winner (even though the game has not ended)
        // Returns the result ("Winner" or "Tie")
    }
}
