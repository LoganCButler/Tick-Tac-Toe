using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    class AI
    {
        bool[] currentBoardPosibilities;
        int computerPlay;

        public int GetComputerMove(bool[] board)
        {
            currentBoardPosibilities = board;

            ComputerTryAndPlay();
            return computerPlay;
       }

        public void ComputerTryAndPlay()
        {
            bool tryAgain = true;
            while (tryAgain)
            {
                Random R = new Random();
                int attempt = R.Next(0, 8);
                if (currentBoardPosibilities[attempt])
                {
                    computerPlay = attempt + 1;
                    tryAgain = false;
                }               
            }
        }
    }
}
