using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Board
    {
        private int length;
        private int width;
        private int totalLength;
        private int turn;
        private Tile[] tiles;

        private ArrayList winningPositions;

        public Board(int length, int width)
        {
            this.length = length;
            this.width = width;
            this.totalLength = length * width;
            this.tiles = new Tile[totalLength];

            winningPositions = new ArrayList();
            winningPositions.Add(123);
            winningPositions.Add(456);
            winningPositions.Add(789);
            createTiles();
        }

        public enum Player
        {
            E,
            O,
            X
        }

        public enum Result
        {
            LOST,
            TIE,
            WON,
            PLAYING
        }

        public void PrintActualState()
        {
            for(int i = 0; i < this.totalLength; i++)
            {
                if (tiles[i].occupied)
                {
                    Console.Write(tiles[i].occupiedBy);
                } else
                {
                    Console.Write(" ");
                }
                if (tiles[i].number % 3 == 0)
                {
                    Console.WriteLine();
                } else
                {
                    Console.Write("|");
                }
            }
        }

        public bool doMove(int fieldNumber, Player player)
        {
            if (checkIfMoveIsAllowed(fieldNumber))
            {
                tiles[fieldNumber - 1].occupiedBy = player;
                tiles[fieldNumber - 1].occupied = true;
                Console.WriteLine(checkGameEnd(player));
                return true;
            }

            Console.WriteLine("Move is not allowed!");
            return false;
        }

        private bool checkIfMoveIsAllowed(int fieldNumber)
        {
            if (tiles[fieldNumber - 1].occupied)
            {
                return false;
            } return true;
        }

        public Result checkGameEnd(Player player)
        {
            Checker checker = new Checker(length, width);
            bool[] result = checker.CheckIfWOn(tiles, player);

            for(int i = 0; i < result.Length -1; i++)
            {
                if (result[i])
                {
                    return Result.WON;
                }
            }

            if (result[result.Length-1])
            {
                return Result.TIE;
            }

            return Result.PLAYING;
        }

        private void createTiles()
        {
            for (int i = 0; i < this.totalLength; i++)
            {
                this.tiles[i] = new Tile(i+1);
            }
        }
        public Tile[] GetTiles()
        {
            return tiles;
        }
    }
}
