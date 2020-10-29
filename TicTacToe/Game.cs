using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        public Game()
        {
            Board board = new Board(3, 3);

            Console.WriteLine("You will play as 'X'");
            Console.WriteLine("Select your AI please: 1 = easy, 2 = medium, 3 = hard");
            string choice = Console.ReadLine();
            if(Convert.ToInt32(choice) == 1)
            {
                Console.WriteLine("Easy AI joined the game");
            }
            board.doMove(1, Board.Player.X);
            board.doMove(9, Board.Player.O);
            // EasyAI easyAI = new EasyAI();
            // BacktrackingAI hardAI = new BacktrackingAI();
            MiniMaxAI miniMaxAI = new MiniMaxAI();
            board.PrintActualState();
            for (int i = 0; i < 10; i++)
            {
                // string move = Console.ReadLine();
                board.doMove(Convert.ToInt32(2), Board.Player.X);
                board.PrintActualState();

                board.doMove(miniMaxAI.DoMove(board.GetTiles(), Board.Player.O), Board.Player.O);
                board.PrintActualState();
            }
        }
    }
}
