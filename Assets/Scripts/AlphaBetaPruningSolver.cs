using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static GameController;
using static MainMenu;

public class AlphaBetaPruningSolver : TicTacToeSolver
{
    private int m_fieldSize = 9;
    private GameMode m_gamemode;
    private int m_maxDepthIterations = 4; // -1 no limitations

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

        double bestValue = -1;
        int move = -1;
        for (int i = 0; i < availableMoves.Count(); i++)
        {
            double value = alphabeta(availableMoves[i], 0, false, AI_player, Double.NegativeInfinity, Double.PositiveInfinity);
            if (value > bestValue)
            {
                bestValue = value;
                move = indexes[i];
            }

            if (bestValue == WinValue)
            {
                break;
            }
        }

        return move;
    }

    private double alphabeta(Player[] board, int depth, bool isMaximizing, Player AI_player, double alpha, double beta)
    {
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

    private List<Player[]> GetAvailableMoves(Player[] board, Player AI_player, ref int[] choosenIndex)
    {
        List<Player[]> moves = new List<Player[]>();
        int currentSuccessMove = 0;

        for (int i = 0; i < m_fieldSize; i++)
        {
            if (board[i] == Player.None)
            {
                Player[] movesElement = new Player[m_fieldSize];
                board.CopyTo(movesElement, 0);
                movesElement[i] = AI_player;
                moves.Add(movesElement);

                choosenIndex[currentSuccessMove] = i;
                currentSuccessMove++;
            }
        }

        return moves;
    }

    protected virtual int CalculateValue(Player winner, Player AI_player, int depth)
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