using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static GameController;
using static MainMenu;

public class AlphaBetaPruningSolver : TicTacToeSolver
{
    protected int m_fieldSize = 9;
    protected GameMode m_gamemode;
    protected int m_maxDepthIterations = 4; // -1 no limitations
    protected bool m_improveAvailableMoves;

    public AlphaBetaPruningSolver(bool improveAvailableMoves = false)
    {
        m_improveAvailableMoves = improveAvailableMoves;
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
                m_fieldSize = 49;
                break;
        }

        m_gamemode = gamemode;

        int[] indexes = new int[m_fieldSize];
        List<Player[]> availableMoves = GetAvailableMoves(ticTacToeSpaces, AI_player, ref indexes);

        double bestValue = LoseValue * 2;
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

        if (availableMoves.Count() == 0)
        {
            return 25;
        }

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

            //Debug.Log("No suitable move was found. Choosing random one");
            return freeIndexes[new System.Random().Next(freeIndexes.Count - 1)];
        }

        return move;
    }

    protected virtual double alphabeta(Player[] board, int depth, bool isMaximizing, Player AI_player, double alpha, double beta)
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

    protected List<Player[]> GetAvailableMoves(Player[] board, Player AI_player, ref int[] choosenIndex)
    {
        List<Player[]> moves = new List<Player[]>();
        if (m_gamemode == GameMode.GameMode3x3)
        {
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
        }
        else
        {
            int size = (int)Math.Round(Math.Sqrt(board.Length));

            List<int> truncatedMoves = new List<int>();
            if (m_improveAvailableMoves)
            {
                for (int i = 0; i < board.Length; i++)
                {
                    if (board[i] != Player.None)
                    {
                        int xIndex = i / size;
                        int yIndex = i % size;
                        int index = 0;

                        if (IsCorrectIndex(xIndex - 1, yIndex, size, out index))
                        {
                            truncatedMoves.Add(index);
                        }

                        if (IsCorrectIndex(xIndex - 1, yIndex - 1, size, out index))
                        {
                            truncatedMoves.Add(index);
                        }

                        if (IsCorrectIndex(xIndex, yIndex - 1, size, out index))
                        {
                            truncatedMoves.Add(index);
                        }

                        if (IsCorrectIndex(xIndex + 1, yIndex - 1, size, out index))
                        {
                            truncatedMoves.Add(index);
                        }

                        if (IsCorrectIndex(xIndex + 1, yIndex, size, out index))
                        {
                            truncatedMoves.Add(index);
                        }

                        if (IsCorrectIndex(xIndex + 1, yIndex + 1, size, out index))
                        {
                            truncatedMoves.Add(index);
                        }

                        if (IsCorrectIndex(xIndex, yIndex + 1, size, out index))
                        {
                            truncatedMoves.Add(index);
                        }
                        
                        if (IsCorrectIndex(xIndex - 1, yIndex + 1, size, out index))
                        {
                            truncatedMoves.Add(index);
                        }

                        
                    }
                }
            }

            int d = 0; // current direction; 0=RIGHT, 1=DOWN, 2=LEFT, 3=UP
            int c = 0; // counter
            int s = 1; // chain size

            // starting point
            int x = ((int)Math.Floor(size / 2.0));
            int y = ((int)Math.Floor(size / 2.0));

            int currentSuccessMove = 0;

            for (int k = 1; k <= (size - 1); k++)
            {
                for (int j = 0; j < (k < (size - 1) ? 2 : 3); j++)
                {
                    for (int i = 0; i < s; i++)
                    {
                        if (m_improveAvailableMoves && truncatedMoves.Contains(x * size + y) || !m_improveAvailableMoves)
                        {
                            if (board[x * size + y] == Player.None)
                            {
                                Player[] movesElement = new Player[m_fieldSize];
                                board.CopyTo(movesElement, 0);
                                movesElement[x * size + y] = AI_player;
                                moves.Add(movesElement);

                                choosenIndex[currentSuccessMove] = x * size + y;
                                currentSuccessMove++;
                            }
                        }

                        c++;

                        switch (d)
                        {
                            case 0: y += 1; break;
                            case 1: x += 1; break;
                            case 2: y -= 1; break;
                            case 3: x -= 1; break;
                        }
                    }
                    d = (d + 1) % 4;
                }
                s++;
            }
        }

        return moves;
    }

    private bool IsCorrectIndex(int x, int y, int lineSize, out int index)
    {
        index = y * lineSize + x;

        return x >= 0 && y >= 0 && x < lineSize && y < lineSize && index > 0 && index < lineSize * lineSize;
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