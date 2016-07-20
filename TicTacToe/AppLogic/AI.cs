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
        int centerSquare = 4;


        public int computerBestMoveToMake = 0;
        public int numberOfTurns = 0;
        public string currentPlayer = GameManager.GameInstance.Player2;
        public List<int> scores = new List<int>();
        List<int> moves = new List<int>();

        public int[,] winningLines = new int[8,3]
            { 
              { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 },{ 1, 4, 7 }, { 2, 5, 8 },{ 0, 4, 8 }, { 2, 4, 6 }
            };

        public int GetComputerMove(string[] currentBoard, string playerLetter, int moveCount)
        {
            //opponent opening move was center scquare , play the corner square.
            if (currentBoard[centerSquare] == player1 && moveCount == 1)
            {
                computerBestMoveToMake = 0;
                Console.WriteLine(string.Format("The Computer choses: spot {0}", computerBestMoveToMake + 1));
                return computerBestMoveToMake+1;
            }

            // opponent has set up a forking move, fiol thier plan.
            if (CheckForFork(currentBoard, moveCount))
            {
                computerBestMoveToMake = BlockFork(currentBoard);
                Console.WriteLine(string.Format("The Computer choses: spot {0}", computerBestMoveToMake + 1));
                return computerBestMoveToMake+1;
            }

            //center square is available , take it. 
            if (currentBoard[centerSquare] != player1 && currentBoard[centerSquare] != player2)
            {
                computerBestMoveToMake = centerSquare;
                Console.WriteLine(string.Format("The Computer choses: spot {0}", computerBestMoveToMake + 1));
                return computerBestMoveToMake + 1;
            }
            //Must Play a Block
            if (OpponentIsAboutToWin(switchPiece(playerLetter)) && OpponentIsAboutToWin(playerLetter) == false)
            {
                BlockAWinningMove(currentBoard, playerLetter);
                Console.WriteLine(string.Format("The Computer choses: spot {0}", computerBestMoveToMake + 1));
                scores.Clear();
                moves.Clear();
                return computerBestMoveToMake + 1;
            }
            // run MinMax to find best move, take best move. 
            else
            {
                var node = 0;
                minimaxOff(cloneGrid(currentBoard), playerLetter, node);
                //pickAndSetWinningMove();
                Console.WriteLine(string.Format("The Computer choses: spot {0}", computerBestMoveToMake + 1));
                scores.Clear();
                moves.Clear();
            }

            

            return computerBestMoveToMake + 1; //making the move takes integers in a 1 bassed index

       
        }

        private bool OpponentIsAboutToWin(string player)
        {
            if (GameManager.ScoreInstance.CheckForPlayerAlmostWin(player))
                {
                    return true;
                }
            return false;
        }

        private void BlockAWinningMove(string[] currentBoard, string player)
        {
            minimaxDef(currentBoard, player, 0);
        }

        public int minimaxOff(string[] InputGrid, string player, int nodeCount)
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
                if (InputGrid[i] != player1 && InputGrid[i] != player2)
                {
                    scores.Add(minimaxOff(makeGridMove(Grid, player, i), switchPiece(player), nodeCount + 1));
                    moves.Add(i);
                }

            }


            if (player == player1)
            {
                //int MaxScoreIndex = scores.IndexOf(scores.Max());
                computerBestMoveToMake = GetModeForMaxScore(scores, moves);
                return scores.Max();
            }
            else
            {
                // int MinScoreIndex = scores.IndexOf(scores.Min());
                computerBestMoveToMake = GetModeForMinScore(scores, moves);
                return scores.Min();
            }
        }
        public int minimaxDef(string[] InputGrid, string player, int nodeCount)
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
                if (InputGrid[i] != player1 && InputGrid[i] != player2)
                {
                    scores.Add(minimaxOff(makeGridMove(Grid, player, i), switchPiece(player), nodeCount + 1));
                    moves.Add(i);
                }

            }


            if (player == player2)
            {
                //int MaxScoreIndex = scores.IndexOf(scores.Max());
                computerBestMoveToMake = GetModeForMaxScore(scores, moves);
                return scores.Max();
            }
            else
            {
                // int MinScoreIndex = scores.IndexOf(scores.Min());
                computerBestMoveToMake = GetModeForMinScore(scores, moves);
                return scores.Min();
            }
        }


        //MinMax does not block a fork well, this mothod does. 
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
            if (currentBoard[1] == player1 && currentBoard[5] == player1 ) { return 2; }
            if (currentBoard[5] == player1 && currentBoard[7] == player1 ) { return 8; }
            if (currentBoard[7] == player1 && currentBoard[3] == player1 ) { return 6; }
            if (currentBoard[3] == player1 && currentBoard[1] == player1 ) { return 0; } 
            else return -1;
        }
  



       
        //returns minmax score for a completed board
        static int checkScore(string[] Grid, int node)
        {
            if (checkGameWin(Grid, GameManager.GameInstance.Player1)) // user/player1wins the game
            {
                var score = 100 - node;
                //var score = -10;
                var moveScore = score;
                return moveScore;
            }
            else if (checkGameWin(Grid, GameManager.GameInstance.Player2)) // computer/player2 wins the game
            {
                var score = -100 + node;
                //var score = 10;
                var moveScore = score;
                return moveScore;
            }
            else return 0;
        }

        //Makes a copy of the board so the game board is not changed.
        static string[] cloneGrid(string[] inputBoard)
        {
            string[] cloneGrid = new string[9];
            for (var i = 0; i < 9; i++)
            {
                cloneGrid[i] = inputBoard[i];
            }
            return cloneGrid;
        }
        // checks a player has won
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
        // checks if the board game is filled up.
        static bool checkGameEnd(string[] board)  
        {
            for (var i= 0; i < 9; i++) 
            {
                if (board[i] != GameManager.GameInstance.Player1 && board[i] != GameManager.GameInstance.Player2)
                {
                    return false;
                }
            }
            return true;
        }
        private static string switchPiece(string player)
        {

            if (player == GameManager.GameInstance.Player1)
            {
                return GameManager.GameInstance.Player2;
            }
            else
            {
                return GameManager.GameInstance.Player1;
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
