using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameController;
using System.Linq;

public class MiniMaxSolver : TicTacToeSolver
{
    private readonly int WinValue = 10;
    private readonly int LoseValue = -10;
    private readonly int DrawValue = 2;

    public override int GetNextMove(Player[] ticTacToeSpaces, Player AI_player)
    {
        int[] indexes = new int[9];
        List<Player[]> availableMoves = GetAvailableMoves(ticTacToeSpaces, AI_player, ref indexes);

        double bestValue = -1;
        int move = -1;
        for (int i = 0; i < availableMoves.Count(); i++)
        {
            double value = minimax(availableMoves[i], 0, false, AI_player);
            if (value > bestValue)
            {
                bestValue = value;
                move = indexes[i];
            }
        }

        return move;
    }

    private double minimax(Player[] board, int depth, bool isMaximizing, Player AI_player)
    {
        if (IsTerminal(board, out Player winner))
        {
           return CalculateValue(winner, AI_player);
        }

        if (isMaximizing)
        {
            double bestVal = double.NegativeInfinity;

            int[] indexes = new int[9];
            List<Player[]> availableMoves = GetAvailableMoves(board, AI_player, ref indexes);

            foreach (Player[] currentBoard in availableMoves)
            {
                double value = minimax(currentBoard, depth + 1, false, AI_player);
                bestVal = Math.Max(bestVal, value);
            }

            return bestVal;
        }
        else
        {
            double bestVal = double.PositiveInfinity;

            int[] indexes = new int[9];
            List<Player[]> availableMoves = GetAvailableMoves(board, (AI_player == Player.XPlayer) ? Player.OPlayer : Player.XPlayer, ref indexes);

            foreach (Player[] currentBoard in availableMoves)
            {
                double value = minimax(currentBoard, depth + 1, true, AI_player);
                bestVal = Math.Min(bestVal, value);
            }

            return bestVal;
        }
    }

    private List<Player[]> GetAvailableMoves(Player[] board, Player AI_player, ref int[] choosenIndex)
    {
        List<Player[]> moves = new List<Player[]>();
        int currentSuccessMove = 0;

        for (int i = 0; i < 9; i++)
        {
            if (board[i] == Player.None)
            {
                Player[] movesElement = new Player[9];
                board.CopyTo(movesElement, 0);
                movesElement[i] = AI_player;
                moves.Add(movesElement);

                choosenIndex[currentSuccessMove] = i;
                currentSuccessMove++;
            }
        }

        return moves;
    }

    private int CalculateValue(Player winner, Player AI_player)
    {
        if (winner == AI_player)
        {
            return WinValue;
        }
        else if (winner == Player.None)
        {
            return DrawValue;
        }
        else
        {
            return LoseValue;
        }
    }
}
