using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.MyInterfaces
{
    interface IPlayer
    {
        int PlayerNumber { get; }
        void RegisterPreviousMove();
        int GetNextMove();
    }
}
