using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using static GameController;
using static MainMenu;

public abstract class TicTacToeSolver
{
    protected readonly int WinValue = 50;
    protected readonly int LoseValue = -50;
    protected readonly int DrawValue = 2;
    abstract public int GetNextMove(Player[] ticTacToeSpaces, Player AI_player, GameMode gamemode);

    public static bool IsTerminal(Player[] board, out Player winningPlayer)
    {
        Assert.AreEqual(board.Length, 9);

        //check rows
        HashSet<Player> line = new HashSet<Player>();
        for (int i = 0; i < 9; i += 3)
        {
            line.Add(board[i]);
            line.Add(board[i + 1]);
            line.Add(board[i + 2]);

            if (line.All(x => x == Player.XPlayer) || line.All(x => x == Player.OPlayer))
            {
                winningPlayer = line.ElementAt(0);
                return true;
            }
            line.Clear();
        }

        //check cols
        line.Clear();
        for (int i = 0; i < 3; i++)
        {
            line.Add(board[i]);
            line.Add(board[i + 3]);
            line.Add(board[i + 6]);

            if (line.All(x => x == Player.XPlayer) || line.All(x => x == Player.OPlayer))
            {
                winningPlayer = line.ElementAt(0);
                return true;
            }
            line.Clear();
        }

        //check diagonals
        if ((board[0] == board[4] && board[4] == board[8] && board[4] != Player.None) ||
            (board[2] == board[4] && board[4] == board[6] && board[4] != Player.None))
        {
            winningPlayer = board[4];
            return true;
        }

        //check any available moves
        if (!board.Any(x => x == Player.None))
        {
            winningPlayer = Player.None;
            return true;
        }

        winningPlayer = Player.None;
        return false;
    }

    public static bool IsTerminal(Player[] board, out Player winningPlayer, GameMode gamemode)
    {
        if (gamemode == GameMode.GameMode3x3)
        {
            return IsTerminal(board, out winningPlayer);
        }
        else if (gamemode == GameMode.GameMode5x5)
        {
            Assert.AreEqual(board.Length, 25);
            
            HashSet<Player> line = new HashSet<Player>();
            // check horizontal
            for (int horizontalIndex = 0; horizontalIndex < 5; horizontalIndex++)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        line.Add(board[5 * horizontalIndex + i + j]);
                    }

                    if (line.All(x => x == Player.XPlayer) || line.All(x => x == Player.OPlayer))
                    {
                        winningPlayer = line.ElementAt(0);
                        return true;
                    }
                    line.Clear();
                }
            }

            line.Clear();

            for (int verticalIndex = 0; verticalIndex < 5; verticalIndex++)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        line.Add(board[verticalIndex + (i + j) * 5]);
                    }

                    if (line.All(x => x == Player.XPlayer) || line.All(x => x == Player.OPlayer))
                    {
                        winningPlayer = line.ElementAt(0);
                        return true;
                    }
                    line.Clear();
                }
            }

            //check diagonals
            if ((board[0] == board[6] && board[6] == board[12] && board[12] == board[18] && board[12] != Player.None) ||
                (board[6] == board[12] && board[12] == board[18] && board[18] == board[24] && board[12] != Player.None) ||
                (board[20] == board[16] && board[16] == board[12] && board[12] == board[8] && board[12] != Player.None) ||
                (board[16] == board[12] && board[12] == board[8] && board[8] == board[4] && board[12] != Player.None))
            {
                winningPlayer = board[12];
                return true;
            }

            if ((board[1] == board[7] && board[7] == board[13] && board[13] == board[19] && board[7] != Player.None) ||
                (board[15] == board[11] && board[11] == board[7] && board[7] == board[3] && board[7] != Player.None))
            {
                winningPlayer = board[7];
                return true;
            }
                
            if ((board[5] == board[11] && board[11] == board[17] && board[17] == board[23] && board[17] != Player.None) ||
                (board[21] == board[17] && board[17] == board[13] && board[13] == board[9] && board[17] != Player.None))
            {
                winningPlayer = board[17];
                return true;
            }

            //check any available moves
            if (!board.Any(x => x == Player.None))
            {
                winningPlayer = Player.None;
                return true;
            }

            winningPlayer = Player.None;
            return false;
        }
        else if (gamemode == GameMode.GameMode7x7)
        {
            throw new NotImplementedException();
        }

        throw new NotImplementedException();
    }
}
