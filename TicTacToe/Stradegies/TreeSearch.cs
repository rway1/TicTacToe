using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.MyInterfaces;

namespace TicTacToe.Stradegies
{
    class TreeSearch : IStradegy
    {
        private class Tree
        {
            private class TreeNode<T>
            {
                private List<TreeNode<T>> list;

                public TreeNode()
                {

                }

                public T GetBestMove()
                {
                    return default(T);
                }
            }

        }

        public int GetBestMove(int PreviousPlayersMove)
        {
            throw new NotImplementedException();
        }

        public int RegisterPreviousMove()
        {
            throw new NotImplementedException();
        }

        public int GetBestMove()
        {
            throw new NotImplementedException();
        }
    }
}
