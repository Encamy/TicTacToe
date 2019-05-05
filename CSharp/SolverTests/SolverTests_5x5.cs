using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static GameController;

namespace SolverTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class SolverTests_5x5
    {
        [TestMethod]
        public void IsTerminal_Test01()
        {
            Player[] board = new Player[25]
            {
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None
            };

            bool expected = false;
            Player expectedWinner = Player.None;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner, MainMenu.GameMode.GameMode5x5);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test02()
        {
            Player[] board = new Player[25]
            {
                Player.XPlayer, Player.None, Player.None, Player.None, Player.None,
                Player.XPlayer, Player.None, Player.None, Player.None, Player.None,
                Player.XPlayer, Player.None, Player.None, Player.None, Player.None,
                Player.XPlayer, Player.None, Player.None, Player.None, Player.None,
                Player.None,    Player.None, Player.None, Player.None, Player.None
            };

            bool expected = true;
            Player expectedWinner = Player.XPlayer;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner, MainMenu.GameMode.GameMode5x5);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test03()
        {
            Player[] board = new Player[25]
            {
                Player.None, Player.OPlayer, Player.OPlayer, Player.OPlayer, Player.OPlayer,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.None, Player.None
            };

            bool expected = true;
            Player expectedWinner = Player.OPlayer;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner, MainMenu.GameMode.GameMode5x5);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test04()
        {
            Player[] board = new Player[25]
            {
                Player.None, Player.None,    Player.None,    Player.None,    Player.None,
                Player.None, Player.XPlayer, Player.None,    Player.None,    Player.None,
                Player.None, Player.None,    Player.XPlayer, Player.None,    Player.None,
                Player.None, Player.None,    Player.None,    Player.XPlayer, Player.None,
                Player.None, Player.None,    Player.None,    Player.None,    Player.XPlayer
            };

            bool expected = true;
            Player expectedWinner = Player.XPlayer;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner, MainMenu.GameMode.GameMode5x5);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test05()
        {
            Player[] board = new Player[25]
            {
                Player.XPlayer, Player.OPlayer, Player.XPlayer, Player.OPlayer, Player.XPlayer,
                Player.OPlayer, Player.OPlayer, Player.XPlayer, Player.OPlayer, Player.XPlayer,
                Player.XPlayer, Player.XPlayer, Player.OPlayer, Player.XPlayer, Player.OPlayer,
                Player.OPlayer, Player.OPlayer, Player.XPlayer, Player.OPlayer, Player.XPlayer,
                Player.XPlayer, Player.OPlayer, Player.XPlayer, Player.OPlayer, Player.XPlayer
            };

            bool expected = true;
            Player expectedWinner = Player.None;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner, MainMenu.GameMode.GameMode5x5);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test06()
        {
            Player[] board = new Player[25]
            {
                Player.None, Player.None, Player.None, Player.None, Player.None,
                Player.XPlayer, Player.OPlayer, Player.OPlayer, Player.OPlayer, Player.None,
                Player.None, Player.XPlayer, Player.None, Player.None, Player.None,
                Player.None, Player.None, Player.XPlayer, Player.None, Player.None,
                Player.None, Player.None, Player.None, Player.XPlayer, Player.None
            };

            bool expected = true;
            Player expectedWinner = Player.XPlayer;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner, MainMenu.GameMode.GameMode5x5);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test07()
        {
            Player[] board = new Player[25]
            {
                Player.XPlayer, Player.OPlayer, Player.XPlayer, Player.XPlayer, Player.OPlayer,
                Player.XPlayer, Player.XPlayer, Player.OPlayer, Player.XPlayer, Player.XPlayer,
                Player.OPlayer, Player.XPlayer, Player.OPlayer, Player.OPlayer, Player.XPlayer,
                Player.OPlayer, Player.OPlayer, Player.OPlayer, Player.XPlayer, Player.OPlayer,
                Player.XPlayer, Player.OPlayer, Player.XPlayer, Player.OPlayer, Player.None,
            };

            bool expected = true;
            Player expectedWinner = Player.OPlayer;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner, MainMenu.GameMode.GameMode5x5);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test08()
        {
            Player[] board = new Player[25]
            {
                Player.OPlayer, Player.None, Player.None, Player.XPlayer, Player.None,
                Player.None, Player.None, Player.OPlayer, Player.XPlayer, Player.None,
                Player.None, Player.XPlayer, Player.OPlayer, Player.OPlayer, Player.OPlayer,
                Player.OPlayer, Player.XPlayer, Player.XPlayer, Player.XPlayer, Player.XPlayer,
                Player.None, Player.None, Player.None, Player.None, Player.None,
            };

            bool expected = true;
            Player expectedWinner = Player.XPlayer;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner, MainMenu.GameMode.GameMode5x5);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void IsTerminal_Test09()
        {
            Player[] board = new Player[25]
            {
                Player.XPlayer, Player.XPlayer, Player.XPlayer, Player.OPlayer, Player.XPlayer,
                Player.OPlayer, Player.OPlayer, Player.OPlayer, Player.XPlayer, Player.XPlayer,
                Player.OPlayer, Player.XPlayer, Player.OPlayer, Player.OPlayer, Player.XPlayer,
                Player.OPlayer, Player.OPlayer, Player.XPlayer, Player.XPlayer, Player.OPlayer,
                Player.XPlayer, Player.XPlayer, Player.OPlayer, Player.OPlayer, Player.XPlayer,
            };

            bool expected = true;
            Player expectedWinner = Player.None;

            bool actual = TicTacToeSolver.IsTerminal(board, out Player actualWinner, MainMenu.GameMode.GameMode5x5);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedWinner, actualWinner);
        }
    }
}
