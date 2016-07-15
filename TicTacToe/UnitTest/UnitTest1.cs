using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLogic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void xWins()
        {
            //Set up
            var game = GameManager.GameInstance;
            var score = GameManager.ScoreInstance;

            //run
            game.playMakeMove(1, "X");
            game.playMakeMove(4, "O");
            game.playMakeMove(2, "X");
            game.playMakeMove(5, "O");
            game.playMakeMove(3, "X");

            //Assert
            Assert.IsTrue(score.CheckForPlayerWin("X"));
            Assert.IsFalse(score.CheckForPlayerWin("O"));
        }
        [TestMethod]
        public void ComputerPlaysAWinningMove()
        {
            //Set up
            var game = GameManager.GameInstance;
            var score = GameManager.ScoreInstance;
            var AI = GameManager.AIInstance;

            //run
            game.playMakeMove(1,"X");
            game.playMakeMove(4,"O");
            game.playMakeMove(2,"X");
            game.playMakeMove(5,"O");
            game.playMakeMove(7,"X");
            //game.playMakeMove(AI.GetComputerMove(game.moveAvailable, "O", "X"), "O"); // lets the computer pick a move


            //Assert
            Assert.IsTrue(score.CheckForPlayerWin("O"));
            Assert.IsFalse(score.CheckForPlayerWin("X"));

        }
    }
}
