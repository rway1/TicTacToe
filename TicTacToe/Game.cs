using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.MyInterfaces;

namespace TicTacToe
{
    class Game
    {
        private char MoveToChar(Move move)
        {
            switch (move)
            {
                case Move.X:
                    return 'X';
                case Move.O:
                    return 'O';
                default:
                    return '-';
            }
        }

        private bool isGameOver;

        enum Move
        {
            Empty,
            X,
            O
        }
        private List<IPlayer> players;
        private List<Move> board;

        public Game()
        {
            isGameOver = false;
            players = new List<IPlayer>();
            board = new List<Move>();
            for (int idx = 0; idx < 9; idx++)
            {
                board.Add(Move.Empty);
            }
        }

        public void AddPlayer(IPlayer player)
        {
            players.Add(player);
        }

        public void StartGame()
        {
            while (!isGameOver)
            {
                Move playerMarker = Move.X;
                foreach (var player in players)
                {
                    if (player is HumanPlayer)
                    {
                        Console.Clear();
                        DrawGameBoard();
                    }
                    try
                    {
                        int playerMove = player.GetNextMove();
                        if(board[playerMove-1] != Move.Empty)
                        {
                            throw new PlayerMoveException();
                        }
                        board[playerMove-1] = playerMarker;
                    }
                    catch (PlayerMoveException)
                    {
                        isGameOver = true;
                    }
                    playerMarker = Move.O;
                }

            }
        }

        public void DrawGameBoard()
        {
            for (int x = 0; x < 9; x++)
            {
                Console.Write(MoveToChar(board[x]));
                if (x%3 == 2)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("|");
                }
            }
        }
    }
}
