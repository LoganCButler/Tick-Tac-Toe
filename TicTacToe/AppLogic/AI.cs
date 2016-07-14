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
        int cellToMakeMoveIn;

        public int GetComputerMove(bool[] board)
        {
            currentBoardPosibilities = board;
            GetComputerRandomPlay();
            CheckForForcedBlockingMove();
            CheckForNextMoveWinsAndSetBestMove();

            return cellToMakeMoveIn + 1;
        }


        //private void GetBestMoveToMake()
        //{
        //    GameManager.GameInstance.oMove(cellToMakeMoveIn+1); //cells are zero bassed and board is ones based
        //}

        private bool CheckForNextMoveWinsAndSetBestMove()
        {       
            bool winIsPossible = false;

            for (var i = 0; i < 8; i++)
            {
                if (GameManager.ScoreInstance.ReturnTallyList("O")[i].Count() > 1 && GameManager.ScoreInstance.ReturnTallyList("X")[i].Count() < 1)
                {
                    winIsPossible = true;
                    switch (i)
                    {
                        case 0: // H1 
                            if (GameManager.GameInstance.moveAvailable[0]) { cellToMakeMoveIn = 0; }
                            if (GameManager.GameInstance.moveAvailable[1]) { cellToMakeMoveIn = 1; }
                            if (GameManager.GameInstance.moveAvailable[2]) { cellToMakeMoveIn = 2; }
                            break;
                        case 1: //H2
                            if (GameManager.GameInstance.moveAvailable[3]) { cellToMakeMoveIn = 3; }
                            if (GameManager.GameInstance.moveAvailable[4]) { cellToMakeMoveIn = 4; }
                            if (GameManager.GameInstance.moveAvailable[5]) { cellToMakeMoveIn = 5; }
                            break;
                        case 2: //H3
                            if (GameManager.GameInstance.moveAvailable[6]) { cellToMakeMoveIn = 6; }
                            if (GameManager.GameInstance.moveAvailable[7]) { cellToMakeMoveIn = 7; }
                            if (GameManager.GameInstance.moveAvailable[8]) { cellToMakeMoveIn = 8; }
                            break;
                        case 3: //V1
                            if (GameManager.GameInstance.moveAvailable[0]) { cellToMakeMoveIn = 0; }
                            if (GameManager.GameInstance.moveAvailable[3]) { cellToMakeMoveIn = 3; }
                            if (GameManager.GameInstance.moveAvailable[6]) { cellToMakeMoveIn = 6; }
                            break;
                        case 4: //V2
                            if (GameManager.GameInstance.moveAvailable[1]) { cellToMakeMoveIn = 1; }
                            if (GameManager.GameInstance.moveAvailable[4]) { cellToMakeMoveIn = 4; }
                            if (GameManager.GameInstance.moveAvailable[7]) { cellToMakeMoveIn = 7; }
                            break;
                        case 5: //V3
                            if (GameManager.GameInstance.moveAvailable[2]) { cellToMakeMoveIn = 2; }
                            if (GameManager.GameInstance.moveAvailable[5]) { cellToMakeMoveIn = 5; }
                            if (GameManager.GameInstance.moveAvailable[8]) { cellToMakeMoveIn = 8; }
                            break;
                        case 6: //DNeg
                            if (GameManager.GameInstance.moveAvailable[0]) { cellToMakeMoveIn = 0; }
                            if (GameManager.GameInstance.moveAvailable[4]) { cellToMakeMoveIn = 4; }
                            if (GameManager.GameInstance.moveAvailable[8]) { cellToMakeMoveIn = 8; }
                            break;
                        case 7: //DNeg
                            if (GameManager.GameInstance.moveAvailable[2]) { cellToMakeMoveIn = 2; }
                            if (GameManager.GameInstance.moveAvailable[4]) { cellToMakeMoveIn = 4; }
                            if (GameManager.GameInstance.moveAvailable[6]) { cellToMakeMoveIn = 6; }
                            break;
                    }
                } 
            }
            return winIsPossible;
    }
        private bool CheckForForcedBlockingMove()
        {
            bool BlockIsForced = false;

            for (var i = 0; i < 8; i++)
            {
                if (GameManager.ScoreInstance.ReturnTallyList("X")[i].Count() > 1 && GameManager.ScoreInstance.ReturnTallyList("O")[i].Count() < 1)
                {
                    BlockIsForced = true;
                    switch (i)
                    {
                        case 0: // H1 
                            if (GameManager.GameInstance.moveAvailable[0]) { cellToMakeMoveIn = 0; }
                            if (GameManager.GameInstance.moveAvailable[1]) { cellToMakeMoveIn = 1; }
                            if (GameManager.GameInstance.moveAvailable[2]) { cellToMakeMoveIn = 2; }
                            break;
                        case 1: //H2
                            if (GameManager.GameInstance.moveAvailable[3]) { cellToMakeMoveIn = 3; }
                            if (GameManager.GameInstance.moveAvailable[4]) { cellToMakeMoveIn = 4; }
                            if (GameManager.GameInstance.moveAvailable[5]) { cellToMakeMoveIn = 5; }
                            break;
                        case 2: //H3
                            if (GameManager.GameInstance.moveAvailable[6]) { cellToMakeMoveIn = 6; }
                            if (GameManager.GameInstance.moveAvailable[7]) { cellToMakeMoveIn = 7; }
                            if (GameManager.GameInstance.moveAvailable[8]) { cellToMakeMoveIn = 8; }
                            break;
                        case 3: //V1
                            if (GameManager.GameInstance.moveAvailable[0]) { cellToMakeMoveIn = 0; }
                            if (GameManager.GameInstance.moveAvailable[3]) { cellToMakeMoveIn = 3; }
                            if (GameManager.GameInstance.moveAvailable[6]) { cellToMakeMoveIn = 6; }
                            break;
                        case 4: //V2
                            if (GameManager.GameInstance.moveAvailable[1]) { cellToMakeMoveIn = 1; }
                            if (GameManager.GameInstance.moveAvailable[4]) { cellToMakeMoveIn = 4; }
                            if (GameManager.GameInstance.moveAvailable[7]) { cellToMakeMoveIn = 7; }
                            break;
                        case 5: //V3
                            if (GameManager.GameInstance.moveAvailable[2]) { cellToMakeMoveIn = 2; }
                            if (GameManager.GameInstance.moveAvailable[5]) { cellToMakeMoveIn = 5; }
                            if (GameManager.GameInstance.moveAvailable[8]) { cellToMakeMoveIn = 8; }
                            break;
                        case 6: //DNeg
                            if (GameManager.GameInstance.moveAvailable[0]) { cellToMakeMoveIn = 0; }
                            if (GameManager.GameInstance.moveAvailable[4]) { cellToMakeMoveIn = 4; }
                            if (GameManager.GameInstance.moveAvailable[8]) { cellToMakeMoveIn = 8; }
                            break;
                        case 7: //DNeg
                            if (GameManager.GameInstance.moveAvailable[2]) { cellToMakeMoveIn = 2; }
                            if (GameManager.GameInstance.moveAvailable[4]) { cellToMakeMoveIn = 4; }
                            if (GameManager.GameInstance.moveAvailable[6]) { cellToMakeMoveIn = 6; }
                            break;
                    }
                }
            }
            return BlockIsForced;
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
                    cellToMakeMoveIn = attempt;
                    tryAgain = false;
                }               
            }
        }
    }
}
