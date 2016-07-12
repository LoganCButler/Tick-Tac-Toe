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
            var game = new Game();
            



            //run
            game.xMove(1);
            game.oMove(4);
            game.xMove(2);
            game.oMove(5);
            game.xMove(3);

            //Assert
            // output x wins
            

        }
    }
}
