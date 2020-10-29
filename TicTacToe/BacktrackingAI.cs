using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class BacktrackingAI
    {
        int totalLength;
        Tile[] newTiles;
        List<int> availableMoves;
        List<int> movesDone;

        Board.Player turn;

        Checker checker;
        public BacktrackingAI()
        {
        }

        public int DoMove(Tile[] tiles)
        {
            newTiles = new Tile[tiles.Length];
            availableMoves = new List<int>();
            totalLength = tiles.Length;
            CopyTiles(tiles);
            checker = new Checker(3, 3);
            turn = Board.Player.O;

            movesDone = new List<int>();

            for(int i = 0; i < availableMoves.Count; i++)
            {
                movesDone.Add(availableMoves[i]);
                availableMoves.Remove(availableMoves[i]);
                if (FindSolution(newTiles, movesDone[movesDone.Count-1], turn, movesDone ,availableMoves))
                {
                    return movesDone[movesDone.Count - 1];
                }
                movesDone.Remove(availableMoves[i]);
                availableMoves.Add(availableMoves[i]);
            } return -1;
        }

        private bool FindSolution(Tile[] tiles, int move, Board.Player player, List<int> movesDone, List<int> availableMoves)
        {
            tiles[move - 1].occupied = true;
            tiles[move - 1].occupiedBy = player;

            if (checkIfIWin(tiles))
            {
                return true;
            } if (checkIfOpponentWins(tiles))
            {
                return false;
            } 
            for(int i = 0; i < availableMoves.Count; i++)
            {
                turnPlayer();
                movesDone.Add(availableMoves[i]);
                availableMoves.Remove(availableMoves[i]);
                if (FindSolution(tiles, movesDone[movesDone.Count - 1], turn, movesDone, availableMoves))
                {
                    return true;
                }
                else
                {
                    movesDone.Remove(availableMoves[i]);
                    availableMoves.Add(availableMoves[i]);
                }
            }
            return true;
        }

        private void turnPlayer()
        {
            if(turn == Board.Player.O)
            {
                turn = Board.Player.X;
            } else
            {
                turn = Board.Player.O;
            }
        }

        private bool checkIfOpponentWins(Tile[] tiles)
        {
            return checkIfWin(tiles, Board.Player.X);
        }

        private bool checkIfIWin(Tile[] tiles)
        {
            return checkIfWin(tiles, Board.Player.O);
        }

        private bool checkIfWin(Tile[] tiles, Board.Player player)
        {
            bool[] result = checker.CheckIfWOn(tiles, player);
            for (int i = 0; i < result.Length - 1; i++)
            {
                if (result[i])
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTiles(Tile[] tiles)
        {
            for (int i = 0; i < this.totalLength; i++)
            {
                bool occupied = tiles[i].occupied;
                Board.Player occupiedBy = tiles[i].occupiedBy;

                Tile tile = new Tile(i + 1);
                tile.occupied = occupied;
                tile.occupiedBy = occupiedBy;

                this.newTiles[i] = tile;

                if (!occupied)
                {
                    availableMoves.Add(tiles[i].number);
                }
            }
        }
    }
}
