/*
 * Program: PROG 2370
 * Purpose: Assignment 1
 * Revision History:
 *      created by Dahyun Ko, Sep/20/2023
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameManagement;

namespace DkoAssignment1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /************ Decalre Global Variables ************/

        private List<PictureBox> slotsList;

        private GameManager _gameManager;
        private string currentPlayer;

        /************ Set Helper Methods ************/

        private void InitializeGame()
        {
           foreach(PictureBox slot in slotsList)
            {
                slot.Image = null;
            }
            _gameManager.InitializeBoard();
            currentPlayer = _gameManager.GetCurrentPlayer();
            ShowWhoseTurn();
        }

        private void ShowWhoseTurn()
        {
            lblGameStatus.Text = $"Player {currentPlayer}'s turn.";
        }

        /************ Form Controller Event Handlers ************/

        private void frmMain_Load(object sender, EventArgs e)
        {
            slotsList = new List<PictureBox>
            {
                picSlot1, picSlot2, picSlot3, picSlot4, picSlot5,
                picSlot6, picSlot7, picSlot8, picSlot9
            };

            _gameManager = new GameManager();
            currentPlayer = _gameManager.GetCurrentPlayer();
            ShowWhoseTurn();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedPictureBox)
            {
                int selectedSlot = int.Parse((clickedPictureBox.Name[clickedPictureBox.Name.Length - 1]).ToString());
                // Extract the slot number (1-9) from the name

                if (_gameManager.SelectedSlotIsValid(selectedSlot))
                // If the selected slot is available,
                {
                    if (currentPlayer == "X")
                    {
                        clickedPictureBox.Image = Properties.Resources.player_x;
                    }
                    else
                    {
                        clickedPictureBox.Image = Properties.Resources.player_o;
                    }

                    _gameManager.StoreSlotData(selectedSlot, currentPlayer);
                    // Store the player and the selected slot to the gameboard


                    if (_gameManager.GetGameResult() == "X" || _gameManager.GetGameResult() == "O")
                    // Check game status - if there's winner or it's tie
                    {
                        MessageBox.Show($"Player \"{_gameManager.GetGameResult()}\" wins!");
                        InitializeGame();
                    }
                    else if(_gameManager.GetGameResult() == "Draw")
                    {
                        MessageBox.Show($"{_gameManager.GetGameResult()}!");
                        InitializeGame();
                    }
                    else
                    {
                        _gameManager.SwitchCurrentPlayer();
                        currentPlayer = _gameManager.GetCurrentPlayer();
                        ShowWhoseTurn();
                    }
                }
                else
                // If the selected slot is preoccupied,
                {
                    MessageBox.Show("The selected slot is not valid.");
                }
            }
        }
    }
}
