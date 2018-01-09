using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.MyInterfaces;

namespace TicTacToe
{
    class ComputerPlayer : IPlayer
    {
        private static int numberOfPlayers = 1;

        private int playerNumber;
        private IStradegy m_stradegy;

        public int PlayerNumber
        {
            get { return playerNumber; }
        }

        public ComputerPlayer(IStradegy stradegy)
        {
            m_stradegy = stradegy;
            playerNumber = numberOfPlayers++;
        }

        public int GetNextMove()
        {
            return m_stradegy.GetBestMove();
        }

        public void RegisterPreviousMove()
        {
            throw new NotImplementedException();
        }
    }
}
