using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static GameController;
using static MainMenu;

public class AlphaBetaPruningTranspositionSolver : AlphaBetaPruningSolver
{
    private TranspositionTable m_transpositionTable;
    protected new int m_maxDepthIterations = 5; 


    public AlphaBetaPruningTranspositionSolver(int boardSize)
    {
        m_transpositionTable = new TranspositionTable(boardSize);
    }

    public AlphaBetaPruningTranspositionSolver(int boardSize, int maxDepth)
    {
        m_transpositionTable = new TranspositionTable(boardSize);
        m_maxDepthIterations = maxDepth;
    }

    protected override double alphabeta(Player[] board, int depth, bool isMaximizing, Player AI_player, double alpha, double beta)
    {
        double precalculatedScore = m_transpositionTable.GetTransposition(board);
        if (precalculatedScore != -1)
        {
            return precalculatedScore;
        }

        if (IsTerminal(board, out Player winner, m_gamemode))
        {
            return CalculateValue(winner, AI_player, depth);
        }

        if (depth >= m_maxDepthIterations)
        {
            return 0;
        }

        if (isMaximizing)
        {
            double bestVal = double.NegativeInfinity;

            int[] indexes = new int[m_fieldSize];
            List<Player[]> availableMoves = GetAvailableMoves(board, AI_player, ref indexes);

            foreach (Player[] currentBoard in availableMoves)
            {
                double value = alphabeta(currentBoard, depth + 1, false, AI_player, alpha, beta);

                //if (value != 0)
                {
                    m_transpositionTable.AddTransposotion(currentBoard, value);
                }

                bestVal = Math.Max(bestVal, value);
                alpha = Math.Max(bestVal, alpha);
                if (beta <= alpha)
                {
                    break;
                }
            }

            return bestVal;
        }
        else
        {
            double bestVal = double.PositiveInfinity;

            int[] indexes = new int[m_fieldSize];
            List<Player[]> availableMoves = GetAvailableMoves(board, (AI_player == Player.XPlayer) ? Player.OPlayer : Player.XPlayer, ref indexes);

            foreach (Player[] currentBoard in availableMoves)
            {
                double value = alphabeta(currentBoard, depth + 1, true, AI_player, alpha, beta);

                //if (value != 0)
                {
                    m_transpositionTable.AddTransposotion(currentBoard, value);
                }

                bestVal = Math.Min(bestVal, value);
                beta = Math.Min(beta, bestVal);
                if (alpha >= beta)
                {
                    break;
                }
            }

            return bestVal;
        }
    }
}
