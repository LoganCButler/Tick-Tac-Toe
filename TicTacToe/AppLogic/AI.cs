using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    

    

    public class AI
    {


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
                var node = 0;
                minimax(cloneGrid(currentBoard), playerLetter, node);
                Console.WriteLine(string.Format("The Computer choses: spot {0}", computerBestMoveToMake + 1));
                scores.Clear();
                moves.Clear();
            }



            return computerBestMoveToMake + 1; //making the move takes integers in a 1 bassed index

       
        }

        private int BlockFork(string[] currentBoard)
        {
            if (currentBoard[0] == "X" && currentBoard[8] == "X") { return 5; }
            if (currentBoard[2] == "X" && currentBoard[6] == "X") { return 1; }
            else return -1;
        }
        private bool CheckForFork(string[] currentBoard, int movecounter)
        {
            if (currentBoard[0]=="X" && currentBoard[8] == "X" && movecounter==3) { return true; }
            if (currentBoard[2] == "X" && currentBoard[6] == "X" && movecounter == 3) { return true; }
            else { return false; }
        }

        //private void CheckAndSetNextMove(string strategy, string playerLetter, string oponentLetter)
        //{
        //    string player ="";
        //    string oponent ="";
        //    int checkThreshold = 0;

        //    switch (strategy)
        //    {
        //        case "openLine":
        //            player = playerLetter;
        //            oponent = oponentLetter;
        //            checkThreshold = -1;
        //            break;
        //        case "offence":
        //            player = playerLetter;
        //            oponent = oponentLetter;
        //            checkThreshold = 1;
        //            break;
        //        case "planning":
        //            player = playerLetter;
        //            oponent = oponentLetter;
        //            checkThreshold = 0;
        //            break;
        //        case "deffence":
        //            player = oponentLetter;
        //            oponent = playerLetter;
        //            checkThreshold = 1;
        //            break;

        //    }

        //    for (var i = 7; i > -1; i--)
        //    {
        //        if (GameManager.ScoreInstance.ReturnTallyList(player)[i].Count() > checkThreshold && GameManager.ScoreInstance.ReturnTallyList(oponent)[i].Count() == 0)
        //        {
        //            switch (i)
        //            {
        //                case 0: // H1 
        //                    if (GameManager.GameInstance.moveAvailable[0]) { cellToMakeMoveIn = 0; }
        //                    if (GameManager.GameInstance.moveAvailable[1]) { cellToMakeMoveIn = 1; }
        //                    if (GameManager.GameInstance.moveAvailable[2]) { cellToMakeMoveIn = 2; }
        //                    break;
        //                case 1: //H2
        //                    if (GameManager.GameInstance.moveAvailable[3]) { cellToMakeMoveIn = 3; }
        //                    if (GameManager.GameInstance.moveAvailable[4]) { cellToMakeMoveIn = 4; }
        //                    if (GameManager.GameInstance.moveAvailable[5]) { cellToMakeMoveIn = 5; }
        //                    break;
        //                case 2: //H3
        //                    if (GameManager.GameInstance.moveAvailable[6]) { cellToMakeMoveIn = 6; }
        //                    if (GameManager.GameInstance.moveAvailable[7]) { cellToMakeMoveIn = 7; }
        //                    if (GameManager.GameInstance.moveAvailable[8]) { cellToMakeMoveIn = 8; }
        //                    break;
        //                case 3: //V1
        //                    if (GameManager.GameInstance.moveAvailable[0]) { cellToMakeMoveIn = 0; }
        //                    if (GameManager.GameInstance.moveAvailable[3]) { cellToMakeMoveIn = 3; }
        //                    if (GameManager.GameInstance.moveAvailable[6]) { cellToMakeMoveIn = 6; }
        //                    break;
        //                case 4: //V2
        //                    if (GameManager.GameInstance.moveAvailable[1]) { cellToMakeMoveIn = 1; }
        //                    if (GameManager.GameInstance.moveAvailable[4]) { cellToMakeMoveIn = 4; }
        //                    if (GameManager.GameInstance.moveAvailable[7]) { cellToMakeMoveIn = 7; }
        //                    break;
        //                case 5: //V3
        //                    if (GameManager.GameInstance.moveAvailable[2]) { cellToMakeMoveIn = 2; }
        //                    if (GameManager.GameInstance.moveAvailable[5]) { cellToMakeMoveIn = 5; }
        //                    if (GameManager.GameInstance.moveAvailable[8]) { cellToMakeMoveIn = 8; }
        //                    break;
        //                case 6: //DNeg
        //                    if (GameManager.GameInstance.moveAvailable[0]) { cellToMakeMoveIn = 0; }
        //                    if (GameManager.GameInstance.moveAvailable[4]) { cellToMakeMoveIn = 4; }
        //                    if (GameManager.GameInstance.moveAvailable[8]) { cellToMakeMoveIn = 8; }
        //                    break;
        //                case 7: //DNeg
        //                    if (GameManager.GameInstance.moveAvailable[2]) { cellToMakeMoveIn = 2; }
        //                    if (GameManager.GameInstance.moveAvailable[4]) { cellToMakeMoveIn = 4; }
        //                    if (GameManager.GameInstance.moveAvailable[6]) { cellToMakeMoveIn = 6; }
        //                    break;
        //            }
        //        }
        //    }

        //}

        //public void GetRandomPlayAndSetIt()
        //{
        //    bool tryAgain = true;
        //    while (tryAgain)
        //    {
        //        Random R = new Random();
        //        int attempt = R.Next(0, 8);
        //        if (currentBoardPosibilities[attempt])
        //        {
        //            cellToMakeMoveIn = attempt;
        //            tryAgain = false;
        //        }               
        //    }
        //}


        static string[] cloneGrid(string[] inputBoard)
        {
            string[] cloneGrid = new string[9];
            for ( var i=0; i < 9; i++)
            {
                cloneGrid[i] = inputBoard[i];
            }
            return cloneGrid;
        }

        static int checkScore(string[] Grid, int node)
        {
            if (checkGameWin(Grid, "X"))
            {
                var score = -10 + node;
                var moveScore = score;
                return moveScore;
            }
            else if (checkGameWin(Grid, "O"))
            {
                var score = +10 - node;
                var moveScore = score;
                return moveScore;
            }
            else return 0;
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

        static bool checkGameWin(string[] Grid, string player)
        {
            for (int i = 0; i < 8; i++)
            {
                if
                (
                    Grid[GameManager.AIInstance.winningLines[i, 0]] == player &&
                    Grid[GameManager.AIInstance.winningLines[i, 1]] == player &&
                    Grid[GameManager.AIInstance.winningLines[i, 2]] == player
                )
                {
                    return true;
                }
            }
            return false;
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

        int minimax(string[] InputGrid, string player, int nodeCount)
        {
            string[] Grid = cloneGrid(InputGrid);//make a copy of the current board to manipulate

            if (checkScore(Grid, nodeCount) != 0) // check if the game is over and someone won
            {
                return checkScore(Grid, nodeCount); // return +10-turns for win -10+turns for a loss
            }
            else if (checkGameEnd(InputGrid)) // check for a filled board (no more spots available and no win)
            {
                return 0; // tie game and score is 0
            }

            

            for (int i = 0; i < 9; i++)
            {
                if (InputGrid[i] != "X" && InputGrid[i] != "O")
                {                    
                    scores.Add(minimax(makeGridMove(Grid, player, i), switchPiece(player), nodeCount + 1));
                    moves.Add(i);                  
                }
                
            }

            //if (player == "X")
            //{
            //    int MaxScoreIndex = scores.IndexOf(scores.Max());
            //    computerBestMoveToMake = moves[MaxScoreIndex];
            //    return scores.Max();
            //}
            //else
            //{
            //    int MinScoreIndex = scores.IndexOf(scores.Min());
            //    computerBestMoveToMake = moves[MinScoreIndex];
            //    return scores.Min();

                if (player == "X")
            {
                computerBestMoveToMake = GetModeForMaxScore(scores, moves);
                return computerBestMoveToMake;
            }
            else
            {
                computerBestMoveToMake = GetModeForMinScore(scores, moves);
                return GetModeForMinScore(scores, moves);
            }
        }


        /// Method to take all moves for tying Max scores. Then selecting the mode of the moves. 
        static int GetModeForMaxScore(List<int> scores, List<int> moves)
        {
            List<int> MaxMoveScoreTies = new List<int> { };
       
            for (var i = 0; i < scores.Count(); i++)
            {
                if (scores.Max() == scores[i])
                {
                    MaxMoveScoreTies.Add(moves[i]);
                }
            }
            //sorts the list and gets the move that has the highest score and most options. 
            int BestBestMove = MaxMoveScoreTies.GroupBy(v => v)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;

            return BestBestMove;
        }
        static int GetModeForMinScore(List<int> scores, List<int> moves)
        {
            List<int> MinMoveScoreTies = new List<int> { };

            for (var i = 0; i < scores.Count(); i++)
            {
                if (scores.Min() == scores[i])
                {
                    MinMoveScoreTies.Add(moves[i]);
                }
            }
            //sorts the list and gets the move that has the Lowest score and most options. 
            int WorstWorstMove = MinMoveScoreTies.GroupBy(v => v)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;

            return WorstWorstMove;
        }

        static string[] makeGridMove(string[] Grid, string Move, int Position)
        {
            string[] newGrid = cloneGrid(Grid);
            newGrid[Position] = Move;
            return newGrid;
        }

    }
}
