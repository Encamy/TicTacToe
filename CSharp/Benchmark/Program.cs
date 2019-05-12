using BenchmarkDotNet.Attributes;
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
        public void AlphaBeta5x5()
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
        public void AlphaBetaTransposition5x5_depth4()
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

            TicTacToeSolver solver = new AlphaBetaPruningTranspositionSolver(board.Length, 5);
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

            TicTacToeSolver solver = new AlphaBetaPruningTranspositionSolver(board.Length, 6);
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode5x5);
        }

        [Benchmark]
        public void AlphaBetaTranspositionParallel5x5_depth5()
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

            TicTacToeSolver solver = new AlphaBetaPruningTranspositionParallelSolver(board.Length, 6);
            solver.GetNextMove(board, Player.XPlayer, MainMenu.GameMode.GameMode5x5);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //new AlgorithmBenchmark().AlphaBetaTranspositionParallel5x5_depth5();
            BenchmarkRunner.Run<AlgorithmBenchmark>();
        }
    }
}
