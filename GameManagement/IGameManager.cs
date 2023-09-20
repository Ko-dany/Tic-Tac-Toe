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

        string GetCurrentPlayer();
        // Returns current player

        void SwitchCurrentPlayer();

        bool SelectedSlotIsValid(int selectedCell);
        // Check if the selected cell is available.
        // Returns true if it's available.

        void StoreSlotData(int selectedCell, string player);
        // Store the cell data.

        string GetGameResult();
        // Check
        // 1. if the game eneded (if all cells are occupied)
        // 2. if there is a winner (even though the game has not ended)
        // Returns the result ("Winner" or "Tie")
    }
}
