using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static GameController;

namespace SolverTests
{
    [TestClass]
    public class MiniMaxSolverTests
    {
        [TestMethod]
        public void IsTerminal_Test01()
        {
            Player[] board = new Player[9]
            {
                Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None
            };

            bool expected = false;
            Player expectedWinner = Player.None;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test02()
        {
            Player[] board = new Player[9]
            {
                Player.XPlayer, Player.OPlayer, Player.None,
                Player.None, Player.XPlayer, Player.None,
                Player.None, Player.OPlayer, Player.XPlayer
            };

            bool expected = true;
            Player expectedWinner = Player.XPlayer;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test03()
        {
            Player[] board = new Player[9]
            {
                Player.None, Player.None, Player.XPlayer,
                Player.None, Player.XPlayer, Player.None,
                Player.XPlayer, Player.None, Player.None
            };

            bool expected = true;
            Player expectedWinner = Player.XPlayer;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test04()
        {
            Player[] board = new Player[9]
            {
                Player.OPlayer, Player.None, Player.OPlayer,
                Player.None, Player.XPlayer, Player.None,
                Player.XPlayer, Player.None, Player.None
            };

            bool expected = false;
            Player expectedWinner = Player.None;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test05()
        {
            Player[] board = new Player[9]
            {
                Player.None, Player.None, Player.None,
                Player.None, Player.XPlayer, Player.OPlayer,
                Player.None, Player.None, Player.None
            };

            bool expected = false;
            Player expectedWinner = Player.None;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test06()
        {
            Player[] board = new Player[9]
            {
                Player.XPlayer, Player.OPlayer, Player.XPlayer,
                Player.OPlayer, Player.OPlayer, Player.OPlayer,
                Player.None, Player.None, Player.None
            };

            bool expected = true;
            Player expectedWinner = Player.OPlayer;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test07()
        {
            Player[] board = new Player[9]
            {
                Player.XPlayer, Player.OPlayer, Player.None,
                Player.XPlayer, Player.OPlayer, Player.XPlayer,
                Player.None, Player.OPlayer, Player.XPlayer
            };

            bool expected = true;
            Player expectedWinner = Player.OPlayer;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test08()
        {
            Player[] board = new Player[9]
            {
                Player.None, Player.None, Player.OPlayer,
                Player.None, Player.XPlayer, Player.None,
                Player.XPlayer, Player.None, Player.None
            };

            bool expected = false;
            Player expectedWinner = Player.None;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test09()
        {
            Player[] board = new Player[9]
            {
                Player.None, Player.None, Player.XPlayer,
                Player.None, Player.OPlayer, Player.None,
                Player.OPlayer, Player.None, Player.None
            };

            bool expected = false;
            Player expectedWinner = Player.None;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test10()
        {
            Player[] board = new Player[9]
            {
                Player.XPlayer, Player.None, Player.None,
                Player.None, Player.XPlayer, Player.None,
                Player.None, Player.None, Player.XPlayer
            };

            bool expected = true;
            Player expectedWinner = Player.XPlayer;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test11()
        {
            Player[] board = new Player[9]
            {
                Player.XPlayer, Player.OPlayer, Player.OPlayer,
                Player.OPlayer, Player.XPlayer, Player.XPlayer,
                Player.OPlayer, Player.XPlayer, Player.OPlayer
            };

            bool expected = true;
            Player expectedWinner = Player.None;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test12()
        {
            Player[] board = new Player[9]
            {
                Player.OPlayer, Player.XPlayer, Player.OPlayer,
                Player.XPlayer, Player.OPlayer, Player.XPlayer,
                Player.XPlayer, Player.OPlayer, Player.XPlayer
            };

            bool expected = true;
            Player expectedWinner = Player.None;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }
    }
}
