using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManagement
{
    internal class GameBoard
    {
        public Dictionary<int, char?> Board { get; set; }
        public char CurrentPlayer { get; set; }

        public GameBoard()
        {
            CurrentPlayer = 'X';
        }
    }
}
