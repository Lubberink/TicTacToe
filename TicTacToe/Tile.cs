using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Tile
    {
        public int number { get; set; }
        public bool occupied;
        public Board.Player occupiedBy { get; set; }

        public Tile(int number)
        {
            this.number = number;
            this.occupied = false;
        }
    }
}
