using System;

namespace TicTacToe
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Game game = new Game();
            game.AddPlayer(new HumanPlayer());
            game.AddPlayer(new HumanPlayer());
            game.StartGame();
        }
    }
}
