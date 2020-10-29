using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace TicTacToe
{
    class Node
    {
        private int move;
        private List<Node> children;
        private int depth;
        private Tile[] board;
        public Board.Player moveDoneBy { set; get; }

        public Node(int move)
        {
            this.children = new List<Node>();
            this.move = move;
        }

        public int getMove()
        {
            return move;
        }
        public void setMove(int move)
        {
            this.move = move;
        }

        public int getDepth()
        {
            return depth;
        }

        public void setDepth(int depth)
        {
            this.depth = depth;
        }

        public void addChild(Node child)
        {
            children.Add(child);
        }

        public List<Node> getChildren()
        {
            return children;
        }

        public Tile[] getBoard()
        {
            return board;
        }

        public void setBoard(Tile[] board)
        {
            this.board = board;
        }

        public void setMoveDoneBy(Board.Player moveDoneBy)
        {
            this.moveDoneBy = moveDoneBy;
        }

        public Board.Player getMoveDoneBy()
        {
            return moveDoneBy;
        }
    }
}
