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
    protected readonly int WinValue = 100;
    protected readonly int LoseValue = -100;
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

            return IsTerminal5x5(board, out winningPlayer);

        }
        else if (gamemode == GameMode.GameMode7x7)
        {
            Assert.AreEqual(board.Length, 49);

            return IsTerminal7x7(board, out winningPlayer);
        }

        throw new NotImplementedException();
    }

    private static bool IsTerminal5x5(Player[] board, out Player winningPlayer)
    {
        // check horizontal
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (IsSame(board, (i * 5) + j, (i * 5) + j + 1, (i * 5) + j + 2, (i * 5) + j + 3))
                {
                    winningPlayer = board[(i * 5) + j];
                    return true;
                }
            }
        }

        // check vertical
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (IsSame(board, 5 * j + i, 5 * (j + 1) + i, 5 * (j + 2) + i, 5 * (j + 3) + i))
                {
                    winningPlayer = board[5 * j + i];
                    return true;
                }
            }
        }


        // check diagonals
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

    private static bool IsTerminal7x7(Player[] board, out Player winningPlayer)
    {
        // check horizontal
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (IsSame(board, (i * 7) + j, (i * 7) + j + 1, (i * 7) + j + 2, (i * 7) + j + 3, (i * 7) + j + 4))
                {
                    winningPlayer = board[(i * 7) + j];
                    return true;
                }
            }
        }

        // check vertical
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (IsSame(board, 7 * j + i, 7 * (j + 1) + i, 7 * (j + 2) + i, 7 * (j + 3) + i, 7 * (j + 4) + i))
                {
                    winningPlayer = board[7 * j + i];
                    return true;
                }
            }
        }

        // check diagonal
        if (IsSame(board, 2, 10, 18, 26, 34) || IsSame(board, 4, 10, 16, 22, 28))
        {
            winningPlayer = board[10];
            return true;
        }
        else if (IsSame(board, 1, 9, 17, 25, 33) || IsSame(board, 5, 11, 17, 23, 29))
        {
            winningPlayer = board[17];
            return true;
        }
        else if (IsSame(board, 9, 17, 25, 33, 41) || IsSame(board, 11, 17, 23, 29, 35))
        {
            winningPlayer = board[17];
            return true;
        }
        else if (IsSame(board, 0, 8, 16, 24, 32) || IsSame(board, 8, 16, 24, 32, 40) || IsSame(board, 16, 24, 32, 40, 48))
        {
            winningPlayer = board[24];
            return true;
        }
        else if (IsSame(board, 6, 12, 18, 24, 30) || IsSame(board, 12, 18, 24, 30, 36) || IsSame(board, 18, 24, 30, 36, 42))
        {
            winningPlayer = board[24];
            return true;
        }
        else if (IsSame(board, 13, 19, 25, 31, 37) || IsSame(board, 19, 25, 31, 37, 43))
        {
            winningPlayer = board[25];
            return true;
        }
        else if (IsSame(board, 20, 26, 32, 38, 44))
        {
            winningPlayer = board[20];
            return true;
        }
        else if (IsSame(board, 7, 15, 23, 31, 39) || IsSame(board, 15, 23, 31, 39, 47))
        {
            winningPlayer = board[15];
            return true;
        }
        else if (IsSame(board, 14, 22, 30, 38, 46))
        {
            winningPlayer = board[14];
            return true;
        }

        winningPlayer = Player.None;
        return false;
    }

    private static bool IsSame(Player[] board, int a, int b, int c, int d)
    {
        return board[a] == board[b] && board[b] == board[c] && board[c] == board[d] && board[a] != Player.None;
    }

    private static bool IsSame(Player[] board, int a, int b, int c, int d, int e)
    {
        return board[a] == board[b] && board[b] == board[c] && board[c] == board[d] && board[d] == board[e] && board[a] != Player.None;
    }
}
