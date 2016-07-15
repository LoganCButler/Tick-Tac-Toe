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
        public int moveCounter = 0;
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
                    playPrompt("X");
                    PrintGameBoard(); 
                }
                else if (i % 2 == 1)
                {
                    playPrompt("O");
                    PrintGameBoard();
                }
            }
        }

        private void PrintGameBoard()
        {
            Console.WriteLine("\n {0} | {1} | {2} \n-----------\n {3} | {4} | {5} \n-----------\n {6} | {7} | {8} \n", board[0], board[1], board[2], board[3], board[4], board[5], board[6], board[7], board[8]);
        }

        private void playPrompt(string playerLetter)
        {
            switch (playerLetter)
            {
                case "X":
                    try
                    {
                        Console.WriteLine("Enter a cell to place an X");
                        playMakeMove(Convert.ToInt16(Console.ReadLine()),"X");
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Please only enter in numbers.");
                        playPrompt("X");
                    }
                    break;
                case "O":
                    Console.WriteLine("The Computer will now play it's move.");
                    playMakeMove(GameManager.AIInstance.GetComputerMove(moveAvailable, "O", "X"),"O");
                    break;

            }
        }

        public void playMakeMove(int cell, string playerLetter)
        {
            try
            {
                if (moveAvailable[cell - 1])
                {
                    board[cell - 1] = playerLetter;
                    moveAvailable[cell - 1] = false;
                    GameManager.ScoreInstance.TallyScore(cell, playerLetter);
                    moveCounter += 1;
                    if (GameManager.ScoreInstance.CheckForPlayerWin(playerLetter))
                    {
                        gameContinue = false;
                        Console.WriteLine("{0} Wins!",playerLetter);
                        PrintGameBoard();
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Choose another cell");
                    playMakeMove(Convert.ToInt16(Console.ReadLine()),playerLetter);
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Only enter in numbers 1-9");
                playPrompt("X");
            }
        }
    }
}
