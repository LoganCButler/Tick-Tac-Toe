using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppLogic
{
    public class Game
    {
        public string Player1 = "X";
        public string Player2 = "Y";       
        bool computerPlayer = false; 

        bool gameContinue = true;
        public int moveCounter = 0;
        //board set up
        public string[] board = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public bool[] moveAvailable = new bool[] { true, true, true, true, true, true, true, true, true };



        public void PlayGame()
        {
            GetPlayerSetup();
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
                    playPrompt(Player1);
                    PrintGameBoard(); 
                }
                else if (i % 2 == 1)
                {                                    
                        playPrompt(Player2);
                        PrintGameBoard(); 
                }
            }
        }

        private void GetPlayerSetup()
        {
            Console.WriteLine("Please enter \n 1 for : Player vs. Player \n     Or\n 2 for : Player vs. Computer");
            
                var responce = Console.ReadLine().ToString();
                if (responce == "1")
                {
                    computerPlayer = false;
                    Console.WriteLine("You chose: Player vs. Player.");
            }
               else if (responce == "2")
                {
                    computerPlayer = true;
                    Console.WriteLine("Player vs. Computer it is.");
                }
                else
                {
                    Console.WriteLine("Please only enter a 1 or a 2.");
                    GetPlayerSetup();
                }
            
        }

        private void PrintGameBoard()
        {
            Console.WriteLine("\n {0} | {1} | {2} \n-----------\n {3} | {4} | {5} \n-----------\n {6} | {7} | {8} \n", board[0], board[1], board[2], board[3], board[4], board[5], board[6], board[7], board[8]);
        }

        private void playPrompt(string playerLetter)
        {

            if (playerLetter == Player1)
            {
                try
                {
                    Console.WriteLine("Enter a cell to place an {0}",Player1);
                    playMakeMove(Convert.ToInt16(Console.ReadLine()), Player1);
                }
                catch (Exception)
                {

                    Console.WriteLine("Please only enter in numbers.");
                    playPrompt(Player1);
                }
            }
            else
            {
                if (computerPlayer)
                {
                    Console.WriteLine("The Computer will now play it's move.");
                    playMakeMove(GameManager.AIInstance.GetComputerMove(board, Player2, moveCounter), Player2); 
                }
                else
                {
                    try
                    {
                        Console.WriteLine("Enter a cell to place an {0}", Player2);
                        playMakeMove(Convert.ToInt16(Console.ReadLine()), Player2);
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Please only enter in numbers.");
                        playPrompt(Player2);
                    }
                }
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
                playPrompt(Player1);
            }
        }
    }
}
