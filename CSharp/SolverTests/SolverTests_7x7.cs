using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameController;

namespace SolverTests
{
    [TestClass]
    public class SolverTests_7x7
    {
        [TestMethod]
        public void IsTerminal_Test01()
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

            bool expected = false;
            Player expectedWinner = Player.None;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner, MainMenu.GameMode.GameMode7x7);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test02()
        {
            Player[] board = new Player[49]
            {
                Player.None, Player.XPlayer, Player.XPlayer, Player.XPlayer, Player.XPlayer, Player.XPlayer, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None
            };

            bool expected = true;
            Player expectedWinner = Player.XPlayer;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner, MainMenu.GameMode.GameMode7x7);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test03()
        {
            Player[] board = new Player[49]
            {
                Player.None, Player.XPlayer, Player.XPlayer, Player.OPlayer, Player.XPlayer, Player.XPlayer, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None
            };

            bool expected = false;
            Player expectedWinner = Player.None;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner, MainMenu.GameMode.GameMode7x7);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test04()
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

            board[0] = board[8] = board[16] = board[24] = board[32] = Player.OPlayer;

            bool expected = true;
            Player expectedWinner = Player.OPlayer;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner, MainMenu.GameMode.GameMode7x7);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test05()
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

            board[40] = board[8] = board[16] = board[24] = board[32] = Player.OPlayer;

            bool expected = true;
            Player expectedWinner = Player.OPlayer;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner, MainMenu.GameMode.GameMode7x7);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test06()
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

            board[28] = board[22] = board[16] = board[10] = board[4] = Player.XPlayer;

            bool expected = true;
            Player expectedWinner = Player.XPlayer;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner, MainMenu.GameMode.GameMode7x7);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test07()
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

            board[28] = board[22] = board[10] = board[4] = Player.XPlayer;
            board[16] = Player.OPlayer;

            bool expected = false;
            Player expectedWinner = Player.None;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner, MainMenu.GameMode.GameMode7x7);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

    }
}
