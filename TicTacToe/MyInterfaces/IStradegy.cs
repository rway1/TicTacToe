using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.MyInterfaces
{
    interface IStradegy
    {
        int RegisterPreviousMove();
        int GetBestMove();
    }
}
