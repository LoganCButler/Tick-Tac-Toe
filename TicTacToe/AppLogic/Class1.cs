using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppLogic
{



    public class Game
    {
        bool gameContinue = true;
        int moveCounter = 0;
        //board set up
        public string[] board = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public bool[] moveAvailable = new bool[] { true, true, true, true, true, true, true, true, true };


        public void PlayGame()
        {
            PrintGameBoard();
            

            for (var i = 0;  gameContinue; i++)
            {
                if (moveCounter == 9)
                {
                    Console.WriteLine("Cat Game");
                    Console.ReadLine();
                }
                else if (i%2 == 0)
                {
                    xPrompt();
                    PrintGameBoard(); 
                }
                else if (i % 2 == 1)
                {
                    oPrompt();
                    PrintGameBoard();
                }
            }
        }

        
 

        private void PrintGameBoard()
        {
            Console.WriteLine("\n {0} | {1} | {2} \n-----------\n {3} | {4} | {5} \n-----------\n {6} | {7} | {8} \n", board[0], board[1], board[2], board[3], board[4], board[5], board[6], board[7], board[8]);
        }

        private void xPrompt()
        {
            try
            {
                Console.WriteLine("Enter a cell to place an X");
                xMove(Convert.ToInt16(Console.ReadLine()));
            }
            catch (Exception)
            {

                Console.WriteLine("Please only enter in numbers.");
                xPrompt();
            }
        }

        public void oPrompt()
        {
            Console.WriteLine("The Computer will now play it's move.");
            oMove(GameManager.AIInstance.GetComputerMove(moveAvailable));
            
        }

        public void xMove(int cell)
        {
            try
            {
                if (moveAvailable[cell - 1])
                {
                    board[cell - 1] = "X";
                    moveAvailable[cell - 1] = false;
                    GameManager.ScoreInstance.TallyScore(cell, "X");
                    moveCounter += 1;
                    if (GameManager.ScoreInstance.xWins())
                    {
                        gameContinue = false;
                        Console.WriteLine("X Wins!");
                        PrintGameBoard();
                        Console.ReadLine();
                    }
                    
                }
                else
                {
                    Console.WriteLine("Choose another cell");
                    xMove(Convert.ToInt16(Console.ReadLine()));
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Only enter in numbers 1-9");
                xPrompt();
            }

        }

    public void oMove (int cell)
    {
            try
            {
                if (moveAvailable[cell - 1])
                {
                    board[cell - 1] = "O";
                    moveAvailable[cell - 1] = false;
                    GameManager.ScoreInstance.TallyScore(cell, "O");
                    moveCounter += 1;
                    if (GameManager.ScoreInstance.oWins())
                    {
                        gameContinue = false;
                        Console.WriteLine("O Wins!");
                        PrintGameBoard();
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Choose another cell");
                    oMove(Convert.ToInt16(Console.ReadLine()));
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Only enter in numbers 1-9");
                oPrompt();
            }
        }
}
}
