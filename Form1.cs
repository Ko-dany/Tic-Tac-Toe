﻿using System;
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

        /************ Decalre global variables ************/
        private List<PictureBox> slotsList = new List<PictureBox>();
        private GameManager _gameManager;
        private string currentPlayer;
        /**************************************************/

        /************ Set helper methods ************/
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
            lblGameStatus.Text = $"Player {currentPlayer}'s turn!";
        }
        /**************************************************/


        private void frmMain_Load(object sender, EventArgs e)
        {
            slotsList.Add(picSlot1);
            slotsList.Add(picSlot2);
            slotsList.Add(picSlot3);
            slotsList.Add(picSlot4);
            slotsList.Add(picSlot5);
            slotsList.Add(picSlot6);
            slotsList.Add(picSlot7);
            slotsList.Add(picSlot8);
            slotsList.Add(picSlot9);

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

                    if (_gameManager.GetGameResult() == "X" || _gameManager.GetGameResult() == "O")
                    {
                        MessageBox.Show($"Player \"{_gameManager.GetGameResult()}\" won.");
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
                {
                    MessageBox.Show("The selected slot is not valid.");
                }
            }
        }
    }
}
