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
        public string CurrentPlayer { get; set; }

        public GameBoard()
        {
            Board = new Dictionary<int, string>();
            for(int i = 1; i<10; i++)
            {
                Board[i] = null;
            }
            CurrentPlayer = "X";
        }
    }
}
