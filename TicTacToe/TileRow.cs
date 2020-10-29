using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TileRow
    {
        private ArrayList tileRow;

        public TileRow()
        {
            tileRow = new ArrayList();
        }

        public void addTile(int tileNumber)
        {
            tileRow.Add(tileNumber);
        }

        public int GetTileRowCount()
        {
            return tileRow.Count;
        }

        public ArrayList GetTileRow()
        {
            return tileRow;
        }
    }
}
