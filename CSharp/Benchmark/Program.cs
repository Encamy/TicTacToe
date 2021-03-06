﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameController;

namespace Benchmark
{
    public class AlgorithmBenchmark
    {
        [Benchmark]
        public void MiniMax3x3()
        {
            Player[] board = new Player[9]
            {
                Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None
            };

            TicTacToeSolver solver = new MiniMaxSolver();
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode3x3);
        }

        [Benchmark]
        public void MiniMaxShortest3x3()
        {
            Player[] board = new Player[9]
            {
                Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None
            };

            TicTacToeSolver solver = new MiniMaxShortestSolver();
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode3x3);
        }

        [Benchmark]
        public void AlphaBeta3x3()
        {
            Player[] board = new Player[9]
            {
                Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None
            };

            TicTacToeSolver solver = new AlphaBetaPruningSolver();
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode3x3);
        }

        [Benchmark]
        public void AlphaBetaTransposition3x3()
        {
            Player[] board = new Player[9]
            {
                Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None
            };

            TicTacToeSolver solver = new AlphaBetaPruningTranspositionSolver(board.Length);
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode3x3);
        }

        [Benchmark]
        public void AlphaBeta5x5_depth5()
        {
            Player[] board = new Player[25]
            {
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None
            };

            TicTacToeSolver solver = new AlphaBetaPruningSolver();
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode5x5);
        }

        [Benchmark]
        public void AlphaBetaTransposition5x5_depth5()
        {
            Player[] board = new Player[25]
            {
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None
            };

            TicTacToeSolver solver = new AlphaBetaPruningTranspositionSolver(board.Length, 4);
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode5x5);
        }

        [Benchmark]
        public void AlphaBetaTransposition5x5_depth6()
        {
            Player[] board = new Player[25]
            {
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None
            };

            TicTacToeSolver solver = new AlphaBetaPruningTranspositionSolver(board.Length, 5);
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode5x5);
        }

        [Benchmark]
        public void AlphaBetaTransposition5x5_depth7()
        {
            Player[] board = new Player[25]
            {
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None
            };

            TicTacToeSolver solver = new AlphaBetaPruningTranspositionSolver(board.Length, 6);
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode5x5);
        }

        [Benchmark]
        public void AlphaBetaTranspositionParallel5x5_depth6()
        {
            Player[] board = new Player[25]
            {
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None
            };

            TicTacToeSolver solver = new AlphaBetaPruningTranspositionParallelSolver(board.Length, 5);
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode5x5);
        }

        [Benchmark]
        public void AlphaBetaTranspositionParallel5x5_depth7()
        {
            Player[] board = new Player[25]
            {
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None
            };

            TicTacToeSolver solver = new AlphaBetaPruningTranspositionParallelSolver(board.Length, 6);
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode5x5);
        }

        [Benchmark]
        public void AlphaBeta7x7_depth5()
        {
            Player[] board = new Player[49]
            {
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None
            };

            TicTacToeSolver solver = new AlphaBetaPruningSolver();
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode7x7);
        }

        [Benchmark]
        public void AlphaBetaTransposition7x7_depth5()
        {
            Player[] board = new Player[49]
            {
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None
            };

            TicTacToeSolver solver = new AlphaBetaPruningTranspositionSolver(board.Length, 4);
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode7x7);
        }

        [Benchmark]
        public void AlphaBetaTransposition7x7_depth6()
        {
            Player[] board = new Player[49]
            {
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None
            };

            TicTacToeSolver solver = new AlphaBetaPruningTranspositionSolver(board.Length, 5);
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode7x7);
        }

        [Benchmark]
        public void AlphaBetaTransposition7x7_depth5_improvedMoves()
        {
            Player[] board = new Player[49]
            {
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None
            };

            TicTacToeSolver solver = new AlphaBetaPruningTranspositionSolver(board.Length, 4, true);
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode7x7);
        }

        [Benchmark]
        public void AlphaBetaTransposition7x7_depth6_improvedMoves()
        {
            Player[] board = new Player[49]
            {
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None
            };

            TicTacToeSolver solver = new AlphaBetaPruningTranspositionSolver(board.Length, 5, true);
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode7x7);
        }

        [Benchmark]
        public void AlphaBetaTranspositionParallel7x7_depth5()
        {
            Player[] board = new Player[49]
            {
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None
            };

            TicTacToeSolver solver = new AlphaBetaPruningTranspositionParallelSolver(board.Length, 4);
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode7x7);
        }

        [Benchmark]
        public void AlphaBetaTranspositionParallel7x7_depth6()
        {
            Player[] board = new Player[49]
            {
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None
            };

            TicTacToeSolver solver = new AlphaBetaPruningTranspositionParallelSolver(board.Length, 5);
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode7x7);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            //new AlgorithmBenchmark().AlphaBetaTranspositionParallel5x5_depth6();
            BenchmarkRunner.Run<AlgorithmBenchmark>();
        }
    }
}
