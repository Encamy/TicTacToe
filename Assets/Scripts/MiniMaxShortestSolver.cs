using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameController;

public class MiniMaxShortestSolver : MiniMaxSolver
{
    protected override int CalculateValue(Player winner, Player AI_player, int depth)
    {
        if (winner == AI_player)
        {
            return WinValue - depth;
        }
        else if (winner == Player.None)
        {
            return DrawValue;
        }
        else
        {
            return LoseValue + depth;
        }
    }
}
