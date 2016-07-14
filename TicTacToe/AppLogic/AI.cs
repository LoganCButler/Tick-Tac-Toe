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
        int cellToMakeMoveIn;

        public int GetComputerMove(bool[] board, string playerLetter, string oponentLetter)
        {
            currentBoardPosibilities = board;
            GetRandomPlayAndSetIt();
            //CheckForForcedBlockingMoveAndSetIt();
            //CheckForNextMoveWinsAndSetIt();
            CheckAndSetNextMove("deffence", playerLetter, oponentLetter);
            CheckAndSetNextMove("offence", playerLetter, oponentLetter);

            return cellToMakeMoveIn + 1;
        }

        private bool CheckAndSetNextMove(string strategy, string playerLetter, string oponentLetter)
        {
            bool outcome = false;
            string v1;
            string v2;

            switch (strategy)
            {
                case "offence":
                    v1 = playerLetter;
                    v2 = oponentLetter;
                    break;
                case "deffence":
                    v1 = oponentLetter;
                    v2 = playerLetter;
                    break;
            }

            for (var i = 0; i < 8; i++)
            {
                if (GameManager.ScoreInstance.ReturnTallyList("X")[i].Count() > 1 && GameManager.ScoreInstance.ReturnTallyList("O")[i].Count() < 1)
                {
                    outcome = true;
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


            return outcome;
        }

        public void GetRandomPlayAndSetIt()
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
