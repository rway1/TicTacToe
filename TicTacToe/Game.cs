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
                        int playerMove = player.GetNextMove() -1;
                        if(board[playerMove] != Move.Empty)
                        {
                            throw new PlayerMoveException();
                        }
                        board[playerMove] = playerMarker;
                        CheckBoardConditions(playerMove);
                    }
                    catch (PlayerMoveException)
                    {
                        isGameOver = true;
                    }
                    if (isGameOver)
                    {
                        Console.Clear();
                        DrawGameBoard();
                        Console.WriteLine($"Player {player.PlayerNumber} wins");
                        Console.ReadKey();
                        break;
                    }
                    playerMarker = Move.O;
                }

            }
        }

        private void CheckBoardConditions(int playerMove)
        {
            CheckBoardConditionsHorizonal(playerMove);
            CheckBoardConditionsVertical(playerMove);
            CheckBoardConditionsDiagonal(playerMove);
        }

        private void CheckBoardConditionsDiagonal(int playerMove)
        {
            if (playerMove % 3 == playerMove /3)
            {
                if (board[0] == board[4] && board[4] == board[8]) isGameOver = true;
            }
            if (playerMove == 4 || playerMove == 2 || playerMove == 6)
            {
                if (board[2] == board[4] && board[4] == board[6]) isGameOver = true;  
            }
        }

        private void CheckBoardConditionsVertical(int playerMove)
        {
            switch (playerMove / 3)
            {
                case 0:
                    if (board[playerMove] == board[playerMove + 3] &&
                        board[playerMove + 3] == board[playerMove + 6])
                        isGameOver = true;
                    break;
                case 1:
                    if (board[playerMove - 3] == board[playerMove] &&
                        board[playerMove] == board[playerMove + 3])
                        isGameOver = true;
                    break;
                case 2:
                    if (board[playerMove - 6] == board[playerMove - 3] &&
                        board[playerMove - 3] == board[playerMove])
                        isGameOver = true;
                    break;
                default:
                    throw new PlayerMoveException();
            }
        }

        private void CheckBoardConditionsHorizonal(int playerMove)
        {
            switch (playerMove %3)
            {
                case 0:
                    if (board[playerMove] == board[playerMove+1] &&
                        board[playerMove+1] == board[playerMove+2])
                        isGameOver = true;
                    break;
                case 1:
                    if (board[playerMove - 1] == board[playerMove] &&
                        board[playerMove] == board[playerMove + 1])
                        isGameOver = true;
                    break;
                case 2:
                    if (board[playerMove - 2] == board[playerMove - 1] &&
                        board[playerMove - 1] == board[playerMove])
                        isGameOver = true;
                    break;
                default:
                    throw new PlayerMoveException();
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
