using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace TicTacToe
{
    class EasyAI
    {
        public EasyAI()
        {

        }

        public int DoMove(Tile[] tiles)
        {
            for(int i = 0; i < tiles.Length; i++)
            {
                if (!tiles[i].occupied)
                {
                    return tiles[i].number;
                }
            } return -1;
        }
    }
}
