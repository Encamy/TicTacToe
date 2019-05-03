using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static GameController;

public abstract class TicTacToeSolver
{
    abstract public int GetNextMove(Player[] ticTacToeSpaces, Player AI_player);

    public static bool IsTerminal(Player[] board, out Player winningPlayer)
    {
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
}
