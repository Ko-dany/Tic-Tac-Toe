/*
 * Program: PROG 2370
 * Purpose: Assignment 1
 * Revision History:
 *      created by Dahyun Ko, Sep/20/2023
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManagement
{
    internal interface IGameManager
    {
        void InitializeBoard();

        string GetCurrentPlayer();

        void SwitchCurrentPlayer();

        bool SelectedSlotIsValid(int selectedCell);

        void StoreSlotData(int selectedCell, string player);
        string GetGameResult();
    }
}
