using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AI
    {
        bool[] currentBoardPosibilities;
        //bool nextMoveWins=false;
        int computerPlay;
        int winningCell;

        public int GetComputerMove(bool[] board)
        {
            currentBoardPosibilities = board;
            
            if (CheckForNextMoveWins())
            {
                MakeWinningMove();
            }
            else
            {
                GetComputerRandomPlay();
            }
            
            return computerPlay;
       }

        private void MakeWinningMove()
        {
            GameManager.GameInstance.oMove(winningCell+1); //cells are zero bassed and bard is ones based
        }

        private bool CheckForNextMoveWins()
        {       
            bool IsPossible = false;

            for (var i = 0; i < 8; i++)
            {
                if (GameManager.ScoreInstance.ReturnTallyList("O")[i].Count() > 1 && GameManager.ScoreInstance.ReturnTallyList("X")[i].Count() < 1)
                {
                    IsPossible = true;
                    switch (i)
                    {
                        case 0: // H1 
                            if (GameManager.GameInstance.moveAvailable[0]) { winningCell = 0; }
                            if (GameManager.GameInstance.moveAvailable[1]) { winningCell = 1; }
                            if (GameManager.GameInstance.moveAvailable[2]) { winningCell = 2; }
                            break;
                        case 1: //H2
                            if (GameManager.GameInstance.moveAvailable[3]) { winningCell = 3; }
                            if (GameManager.GameInstance.moveAvailable[4]) { winningCell = 4; }
                            if (GameManager.GameInstance.moveAvailable[5]) { winningCell = 5; }
                            break;
                        case 2: //H3
                            if (GameManager.GameInstance.moveAvailable[6]) { winningCell = 6; }
                            if (GameManager.GameInstance.moveAvailable[7]) { winningCell = 7; }
                            if (GameManager.GameInstance.moveAvailable[8]) { winningCell = 8; }
                            break;
                        case 3: //V1
                            if (GameManager.GameInstance.moveAvailable[0]) { winningCell = 0; }
                            if (GameManager.GameInstance.moveAvailable[3]) { winningCell = 3; }
                            if (GameManager.GameInstance.moveAvailable[6]) { winningCell = 6; }
                            break;
                        case 4: //V2
                            if (GameManager.GameInstance.moveAvailable[1]) { winningCell = 1; }
                            if (GameManager.GameInstance.moveAvailable[4]) { winningCell = 4; }
                            if (GameManager.GameInstance.moveAvailable[7]) { winningCell = 7; }
                            break;
                        case 5: //V3
                            if (GameManager.GameInstance.moveAvailable[2]) { winningCell = 2; }
                            if (GameManager.GameInstance.moveAvailable[5]) { winningCell = 5; }
                            if (GameManager.GameInstance.moveAvailable[8]) { winningCell = 8; }
                            break;
                        case 6: //DNeg
                            if (GameManager.GameInstance.moveAvailable[0]) { winningCell = 0; }
                            if (GameManager.GameInstance.moveAvailable[4]) { winningCell = 4; }
                            if (GameManager.GameInstance.moveAvailable[8]) { winningCell = 8; }
                            break;
                        case 7: //DNeg
                            if (GameManager.GameInstance.moveAvailable[2]) { winningCell = 2; }
                            if (GameManager.GameInstance.moveAvailable[4]) { winningCell = 4; }
                            if (GameManager.GameInstance.moveAvailable[6]) { winningCell = 6; }
                            break;
                    }
                } 
            }
            return IsPossible;
    }

        public void GetComputerRandomPlay()
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
