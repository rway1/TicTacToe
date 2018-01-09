using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.MyInterfaces
{
    interface IPlayer
    {
        void RegisterPreviousMove();
        int GetNextMove();
    }
}
