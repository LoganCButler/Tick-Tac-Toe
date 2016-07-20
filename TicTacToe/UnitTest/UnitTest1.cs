using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLogic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void MinMaxBGlocksAForceBlock()
        {
            //Set 
            var game = GameManager.GameInstance;
            var score = GameManager.ScoreInstance;
            var AI = GameManager.AIInstance;
            string[] board = new string[] { "a", "2", "3", "4", "z", "6", "a", "8", "9" };

            //run
            AI.GetComputerMove(board, game.Player2,0);


            //Assert
            Assert.AreEqual(3, AI.computerBestMoveToMake);
        }

        [TestMethod]
        public void MinMaxTakesAWin()
        {
            //Set up
            var game = GameManager.GameInstance;
            var score = GameManager.ScoreInstance;
            var AI = GameManager.AIInstance;
            string[] board = new string[] { "a", "a", "3", "z", "z", "6", "a", "8", "9" };

            //run
            AI.GetComputerMove(board, game.Player2, 0);

            //Assert
            Assert.AreEqual(5, AI.computerBestMoveToMake);
        }
    }
}
