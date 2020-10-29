using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Sources;
using System.Xml;

namespace TicTacToe
{
    class MiniMaxAI
    {

        public enum Points
        {
            WON = 1,
            LOST = -1,
            TIE = 0
        }
        public int DoMove(Tile[] tile, Board.Player player)
        {
            List<Node> nodes = new List<Node>();
            AddNodes(tile, nodes, player);
            List<int> scores = new List<int>();
            int moveToDO = 0;
            int highestScore = -999;
            foreach(Node n in nodes)
            {
                int score = Minimax(n, 1, true);
                scores.Add(score);
                if(score > highestScore)
                {
                    moveToDO = n.getMove();
                }
            }
            foreach(int i in scores)
            {
                Console.WriteLine(i);
            }
            return moveToDO;
        }

        private int Minimax(Node node, int depth, bool maximizingPlayer)
        {
            // SetNewMoveOnBoard(node, GetRightPlayer(maximizingPlayer));
            if (depth == 0 || CheckIfOver())
            {
                int score = CalculateScore(node);
                return score;
            }

            if (maximizingPlayer)
            {
                int maxEval = -999;
                foreach(Node child in node.getChildren())
                {
                    CalculateChildren(child, node, GetRightPlayer(maximizingPlayer));
                    int score = Minimax(child, depth - 1, false);
                    maxEval = MaxValue(maxEval, score);
                }
                return maxEval;
            } else
            {
                int minEval = 999;
                foreach (Node child in node.getChildren())
                {
                    CalculateChildren(child, node, GetRightPlayer(maximizingPlayer));
                    int score = Minimax(child, depth - 1, true);
                    minEval = MinValue(minEval, score);
                }
                return minEval;
            }
        }

        private int MaxValue(int eval, int score)
        {
            if(score > eval)
            {
                return score;
            } return eval;
        }

        private int MinValue(int eval, int score)
        {
            if (score < eval)
            {
                return score;
            }
            return eval;
        }

        private int CalculateScore(Node node)
        {
            Checker checker = new Checker(3, 3);
            bool won = checker.CheckIfWOnOne(node.getBoard(), Board.Player.O);
            bool lost = checker.CheckIfLost(node.getBoard(), Board.Player.O);
            bool tie = checker.CheckIfTie(node.getBoard());
            if (won)
            {
               return (int) Points.WON;
            }
            if(lost)
            {
                return (int)Points.LOST;
            }
            if (tie)
            {
                return (int)Points.LOST;
            } else
            {
                return 0;
            }
        }

        private bool CheckIfOver()
        {
            return false;
        }

        private void AddNodes(Tile[] tiles, List<Node> nodes, Board.Player player)
        {
            List<int> availableMoves = new List<int>();
            foreach (Tile t in tiles)
            {
                if (!t.occupied)
                {
                    availableMoves.Add(t.number);
                    Node n = new Node(t.number);
                    n.setMoveDoneBy(player);
                    n.setBoard(CopyTiles(tiles));
                    nodes.Add(n);
                }
            }
            AddChildren(nodes, availableMoves, SwitchPlayer(player));
        }

        private void AddChildren(List<Node> nodes, List<int> availableMoves, Board.Player player)
        {
            foreach (Node n in nodes)
            {
                foreach (int i in availableMoves)
                {
                    if (n.getMove() != i)
                    {
                        Node child = new Node(i);
                        child.setDepth(1);
                        child.setBoard(CopyTiles(n.getBoard()));
                        child.setMoveDoneBy(player);
                        n.addChild(child);
                    }
                }
            }
        }

        private void CalculateChildren(Node child, Node parent, Board.Player player)
        {
            Tile[] newBoard = child.getBoard();
            child.setDepth(parent.getDepth() + 1);
      
            List<int> availableMoves = new List<int>();
            foreach (Node n in parent.getChildren())
            {
                if (n.getMove() != child.getMove())
                {
                    Node c = new Node(n.getMove());
                    c.setBoard(CopyTiles(newBoard));
                    child.addChild(c);
                }
            }
        }

        public Tile[] CopyTiles(Tile[] tiles)
        {
            Tile[] newTiles = new Tile[9];
            for (int i = 0; i < 9; i++)
            {
                bool occupied = tiles[i].occupied;
                Board.Player occupiedBy = tiles[i].occupiedBy;

                Tile tile = new Tile(i + 1);
                tile.occupied = occupied;
                tile.occupiedBy = occupiedBy;

                newTiles[i] = tile;
            } return newTiles;
        }

        private void SetNewMoveOnBoard(Node node, Board.Player player)
        {
            int move = node.getMove();
            Tile[] board = node.getBoard();
            board[move - 1].occupied = true;
            board[move - 1].occupiedBy = player;
        }

        private Board.Player GetRightPlayer(bool maximizingPlayer)
        {
            if(maximizingPlayer)
            {
                return Board.Player.O;
            } return Board.Player.X;
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
