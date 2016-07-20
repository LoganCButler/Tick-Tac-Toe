using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    

    

    public class AI
    {
        string player1 = GameManager.GameInstance.Player1;
        string player2 = GameManager.GameInstance.Player2;

        int computerBestMoveToMake = 0;
        public int numberOfTurns = 0;
        public string currentPlayer = "O";
        public List<int> scores = new List<int>();
        List<int> moves = new List<int>();

        public int[,] winningLines = new int[8,3]{ 
                                    //H1
                                    { 0, 1, 2 }, 
                                    //H2
                                    { 3, 4, 5 },
                                    //H3
                                    { 6, 7, 8 }, 

                                    //V1
                                    { 0, 3, 6 },
                                    //V2       
                                    { 1, 4, 7 }, 
                                    //V3
                                    { 2, 5, 8 },

                                    //DNeg
                                    { 0, 4, 8 }, 
                                    //DPpos
                                    { 2, 4, 6 }
                               };

        public int GetComputerMove(string[] currentBoard, string playerLetter, string oponentLetter, int moveCount)
        {

            if (currentBoard[4] == "X" && moveCount == 1)
            {
                computerBestMoveToMake = 0;
                return computerBestMoveToMake+1;
            }
            if (CheckForFork(currentBoard, moveCount))
            {
                computerBestMoveToMake = BlockFork(currentBoard);
                return computerBestMoveToMake+1;
            }
            if (currentBoard[4] != "X" && currentBoard[4] != "O")
            {
                computerBestMoveToMake = 4;
            }           
            else
            {
                CheckAndSetNextMove("planning", playerLetter, switchPiece(playerLetter));              
                CheckAndSetNextMove("deffence", playerLetter, switchPiece(playerLetter));
                CheckAndSetNextMove("offence", playerLetter, switchPiece(playerLetter));

            }



            return computerBestMoveToMake + 1; //making the move takes integers in a 1 bassed index

       
        }

        private bool CheckForFork(string[] currentBoard, int movecounter)
        {
            //Diagonal For
            if (currentBoard[0] == player1 && currentBoard[8] == player1 && movecounter == 3) { return true; }
            if (currentBoard[2] == player1 && currentBoard[6] == player1 && movecounter == 3) { return true; }

            //Cornner Fork
            if (currentBoard[1] == player1 && currentBoard[5] == player1 && movecounter == 3) { return true; }
            if (currentBoard[5] == player1 && currentBoard[7] == player1 && movecounter == 3) { return true; }
            if (currentBoard[7] == player1 && currentBoard[3] == player1 && movecounter == 3) { return true; }
            if (currentBoard[3] == player1 && currentBoard[1] == player1 && movecounter == 3) { return true; }

            else { return false; }
        }
        private int BlockFork(string[] currentBoard)
        {
            //Diagonal Responce
            if (currentBoard[0] == player1 && currentBoard[8] == player1) { return 5; }
            if (currentBoard[2] == player1 && currentBoard[6] == player1) { return 1; }

            //Cornner Fork
            if (currentBoard[1] == player1 && currentBoard[5] == player1) { return 2; }
            if (currentBoard[5] == player1 && currentBoard[7] == player1) { return 8; }
            if (currentBoard[7] == player1 && currentBoard[3] == player1) { return 6; }
            if (currentBoard[3] == player1 && currentBoard[1] == player1) { return 0; }
            else return -1;
        }

        private void CheckAndSetNextMove(string strategy, string playerLetter, string oponentLetter)
        {
            string player = "";
            string oponent = "";
            int checkThreshold = 0;

            switch (strategy)
            {
                case "openLine":
                    player = playerLetter;
                    oponent = oponentLetter;
                    checkThreshold = -1;
                    break;
                case "offence":
                    player = playerLetter;
                    oponent = oponentLetter;
                    checkThreshold = 1;
                    break;
                case "planning":
                    player = playerLetter;
                    oponent = oponentLetter;
                    checkThreshold = 0;
                    break;
                case "deffence":
                    player = oponentLetter;
                    oponent = playerLetter;
                    checkThreshold = 1;
                    break;

            }

            for (var i = 7; i > -1; i--)
            {
                if (GameManager.ScoreInstance.ReturnTallyList(player)[i].Count() > checkThreshold && GameManager.ScoreInstance.ReturnTallyList(oponent)[i].Count() == 0)
                {
                    switch (i)
                    {
                        case 0: // H1 
                            if (GameManager.GameInstance.moveAvailable[0]) { computerBestMoveToMake = 0; }
                            if (GameManager.GameInstance.moveAvailable[1]) { computerBestMoveToMake = 1; }
                            if (GameManager.GameInstance.moveAvailable[2]) { computerBestMoveToMake = 2; }
                            break;
                        case 1: //H2
                            if (GameManager.GameInstance.moveAvailable[3]) { computerBestMoveToMake = 3; }
                            if (GameManager.GameInstance.moveAvailable[4]) { computerBestMoveToMake = 4; }
                            if (GameManager.GameInstance.moveAvailable[5]) { computerBestMoveToMake = 5; }
                            break;
                        case 2: //H3
                            if (GameManager.GameInstance.moveAvailable[6]) { computerBestMoveToMake = 6; }
                            if (GameManager.GameInstance.moveAvailable[7]) { computerBestMoveToMake = 7; }
                            if (GameManager.GameInstance.moveAvailable[8]) { computerBestMoveToMake = 8; }
                            break;
                        case 3: //V1
                            if (GameManager.GameInstance.moveAvailable[0]) { computerBestMoveToMake = 0; }
                            if (GameManager.GameInstance.moveAvailable[3]) { computerBestMoveToMake = 3; }
                            if (GameManager.GameInstance.moveAvailable[6]) { computerBestMoveToMake = 6; }
                            break;
                        case 4: //V2
                            if (GameManager.GameInstance.moveAvailable[1]) { computerBestMoveToMake = 1; }
                            if (GameManager.GameInstance.moveAvailable[4]) { computerBestMoveToMake = 4; }
                            if (GameManager.GameInstance.moveAvailable[7]) { computerBestMoveToMake = 7; }
                            break;
                        case 5: //V3
                            if (GameManager.GameInstance.moveAvailable[2]) { computerBestMoveToMake = 2; }
                            if (GameManager.GameInstance.moveAvailable[5]) { computerBestMoveToMake = 5; }
                            if (GameManager.GameInstance.moveAvailable[8]) { computerBestMoveToMake = 8; }
                            break;
                        case 6: //DNeg
                            if (GameManager.GameInstance.moveAvailable[0]) { computerBestMoveToMake = 0; }
                            if (GameManager.GameInstance.moveAvailable[4]) { computerBestMoveToMake = 4; }
                            if (GameManager.GameInstance.moveAvailable[8]) { computerBestMoveToMake = 8; }
                            break;
                        case 7: //DNeg
                            if (GameManager.GameInstance.moveAvailable[2]) { computerBestMoveToMake = 2; }
                            if (GameManager.GameInstance.moveAvailable[4]) { computerBestMoveToMake = 4; }
                            if (GameManager.GameInstance.moveAvailable[6]) { computerBestMoveToMake = 6; }
                            break;
                    }
                }
            }

        }

 




        private static string switchPiece(string player)
        {
            switch (player)
            {
                case "X":
                    return "O";
                case "O":
                    return "X";
                default:
                    return GameManager.AIInstance.currentPlayer;
            }
                
        }

     

        static bool checkGameEnd(string[] board) // checks if the board game is filled up. 
        {
            for (var i= 0; i < 9; i++) 
            {
                if (board[i] != "X" && board[i] != "O")
                {
                    return false;
                }
            }
            return true;
        }

    }
}
