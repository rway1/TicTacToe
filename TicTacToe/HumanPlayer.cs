using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.MyInterfaces;

namespace TicTacToe
{
    class HumanPlayer : IPlayer
    {
        private static int numberOfPlayers = 1;

        private int playerNumber;

        public int PlayerNumber
        {
            get { return playerNumber; }
        }

        public HumanPlayer()
        {
            playerNumber = numberOfPlayers++;
        }

        public int GetNextMove()
        {
            Console.Write(string.Format("Player{0}'s turn: ", playerNumber));
            if (!int.TryParse(Console.ReadLine(), out int result))
                throw new PlayerMoveException();
            return result;
        }

        public void RegisterPreviousMove()
        {
            throw new NotImplementedException();
        }
    }
}
