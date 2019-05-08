using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static GameController;
using static MainMenu;

public class AlphaBetaPruningTranspositionParallelSolver : AlphaBetaPruningTranspositionSolver
{
    private TranspositionTable m_transpositionTable;
    protected new int m_maxDepthIterations = 5;

    public AlphaBetaPruningTranspositionParallelSolver(int boardSize) 
        : base(boardSize)
    {
    }

    public AlphaBetaPruningTranspositionParallelSolver(int boardSize, int maxDepth)
        : base(boardSize, maxDepth)
    {
    }

    public override int GetNextMove(Player[] ticTacToeSpaces, Player AI_player, GameMode gamemode)
    {
        switch (gamemode)
        {
            case GameMode.GameMode3x3:
                m_fieldSize = 9;
                break;
            case GameMode.GameMode5x5:
                m_fieldSize = 25;
                break;
            case GameMode.GameMode7x7:
                throw new NotImplementedException();
        }

        m_gamemode = gamemode;

        int[] indexes = new int[m_fieldSize];
        List<Player[]> availableMoves = GetAvailableMoves(ticTacToeSpaces, AI_player, ref indexes);

        double bestValue = LoseValue * 2;
        int move = -1;

        Parallel.ForEach(availableMoves, (currentMove) => {
            double value = alphabeta(currentMove, 0, false, AI_player, Double.NegativeInfinity, Double.PositiveInfinity);
            if (value > bestValue)
            {
                bestValue = value;
                move = indexes[availableMoves.IndexOf(currentMove)];
            }
        });

        if (move == -1)
        {
            List<int> freeIndexes = new List<int>();
            for (int i = 0; i < ticTacToeSpaces.Length; i++)
            {
                if (ticTacToeSpaces[i] == Player.None)
                {
                    freeIndexes.Add(i);
                }
            }

            if (freeIndexes.Count == 0)
            {
                return -1;
            }

            Debug.Log("No suitable move was found. Choosing random one");
            return freeIndexes[new System.Random().Next(freeIndexes.Count - 1)];
        }

        return move;
    }

}
