﻿/*
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
    internal class GameBoard
    {
        public Dictionary<int, string> Board { get; set; }
        public string GamePlayer { get; set; }

        public GameBoard()
        {
            InitializeGameBoard();
        }

        public void InitializeGameBoard()
        {
            Board = new Dictionary<int, string>();
            for(int i = 1; i<10; i++)
            {
                Board[i] = null;
            }
            GamePlayer = "X";
        }
    }
}
