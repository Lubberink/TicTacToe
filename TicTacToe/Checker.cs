using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Checker
    {
        private int length;
        private int width;

        private List<TileRow> horizontalFields;
        public Checker(int length, int width)
        {
            this.length = length;
            this.width = width;

            this.horizontalFields = new List<TileRow>();
            DetermineHorizontalPositions();
        }

        public void DetermineHorizontalPositions()
        {
            for (int i = 0; i < length; i++)
            {
                TileRow tileRow = new TileRow();

                for(int j = 1; j <= width; j++)
                {
                    tileRow.addTile((i * 3)+j);
                }

                horizontalFields.Add(tileRow);
            }
        }

        public bool[] CheckIfWOn(Tile[] tiles, Board.Player player)
        {
            bool[] result = new bool[4];
            result[0] = CheckIfWonHorizontal(tiles, player);
            result[1] = CheckIfWonVertical(tiles, player);
            result[2] = CheckIfWonDiagonal(tiles, player);
            result[3] = CheckIfTie(tiles);

            return result;
        }

        public bool CheckIfWOnOne(Tile[] tiles, Board.Player player)
        {
            bool[] result = new bool[4];
            result[0] = CheckIfWonHorizontal(tiles, player);
            result[1] = CheckIfWonVertical(tiles, player);
            result[2] = CheckIfWonDiagonal(tiles, player);

            foreach(bool answer in result)
            {
                if (answer)
                {
                    return answer;
                }
            }

            return false;
        }

        public bool CheckIfLost(Tile[] tiles, Board.Player player)
        {
            player = SwitchPlayer(player);
            return CheckIfWOnOne(tiles, player);
        }

        public bool CheckIfTie(Tile[] tiles)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (!tiles[i].occupied)
                {
                    return false;
                }
            } return true;
        }

        public bool CheckIfWonHorizontal(Tile[] tiles, Board.Player player)
        {
            bool won = true;
            for (int y = 0; y < length; y++)
            {
                won = true;
                for (int x = 0; x < width; x++)
                {
                    if (tiles[(y * width) + x].occupiedBy != player)
                    {
                        won = false;
                    }
                }
                if (won)
                {
                    // Console.WriteLine("Won horizontal: " + won);
                    return won;
                }
            }
            // Console.WriteLine("Won horizontal: " + won);
            return won;
        }

        public bool CheckIfWonVertical(Tile[] tiles, Board.Player player)
        {
            bool won = true;
            for (int x = 0; x < width; x++)
            {
                won = true;
                for (int y = 0; y < length; y++)
                {
                    if (tiles[(x + (y*3))].occupiedBy != player)
                    {
                        won = false;
                    }
                } if(won)
                {
                    // Console.WriteLine("Won vertical: " + won);
                    return won;
                }
            }
           //  Console.WriteLine("Won vertical: " + won);
            return won;
        }

        public bool CheckIfWonDiagonal(Tile[] tiles, Board.Player player)
        {
            bool won = true;

            for (int y = 1; y <= length; y++)
            {
                if (tiles[2 * y].occupiedBy != player)
                {
                    won = false;
                } 
            }
            if (won)
            {
                // Console.WriteLine("Won diagonal: " + won);
                return won;
            }
            won = true;
            for (int y = 0; y < length; y++)
            {
                if (tiles[4 * y].occupiedBy != player)
                {
                    won = false;
                }
            }
            // Console.WriteLine("Won diagonal: " + won);
            return won;
        }
        private Board.Player SwitchPlayer(Board.Player player)
        {
            if (player == Board.Player.X)
            {
                return Board.Player.O;
            }
            return Board.Player.X;
        }
    }
}
