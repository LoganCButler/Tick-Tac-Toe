using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLogic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        string p1 = GameManager.GameInstance.Player1;
        string p2 = GameManager.GameInstance.Player2;

        [TestInitialize]
        public void SetUp()
        {
            var game = GameManager.GameInstance;
            var score = GameManager.ScoreInstance;
            var AI = GameManager.AIInstance;
        }


        [TestCleanup]
        public void Resetgame()
        {
            //set board back to blank state
            for ( var i = 0; i < 9; i++)
            {
                string str = (i + 1).ToString();
                GameManager.GameInstance.board[i] = str;
            }

            //set moves back to available. 
            for (var i = 0; i < 9; i++)
            {
                GameManager.GameInstance.moveAvailable[i] = true;
            }

            GameManager.AIInstance.scores.Clear();
            GameManager.AIInstance.moves.Clear();
            GameManager.AIInstance.computerBestMoveToMake = 0;
            
    }


        [TestMethod]
        public void MinMaxBGlocksAForceBlock()
        {
            //Set 
            var game = GameManager.GameInstance;
            var score = GameManager.ScoreInstance;
            var AI = GameManager.AIInstance;
            string[] board = new string[] { p1, "2", "3", "4", p2, "6", p1, "8", "9" };


            //run
            var move = AI.GetComputerMove(board, game.Player2,0);


            //Assert
            Assert.AreEqual(4, move);
        }

        [TestMethod]
        public void MinMaxTakesAWin()
        {
            //Set up
            var game = GameManager.GameInstance;
            var score = GameManager.ScoreInstance;
            var AI = GameManager.AIInstance;
            string[] board = new string[] { p1, p1, "3", p2, p2, "6", p1, "8", "9" };

            //run
            AI.GetComputerMove(board, game.Player2, 0);

            //Assert
            Assert.AreEqual(5, AI.computerBestMoveToMake);
        }
    }
}
