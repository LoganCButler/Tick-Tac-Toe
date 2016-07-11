using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{



    public class Game
    {
        //board set up
        public string[] board = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public bool[] moveAvailable = new bool[] { true, true, true, true, true, true, true, true, true };

        public void PlayGame()
        {
            PrintGameBoard();

            while (true)
            {
                xPrompt();
                PrintGameBoard();
                oPrompt();
                PrintGameBoard();
            }
            
        }

        
 

        public void PrintGameBoard()
        {
            Console.WriteLine("\n {0} | {1} | {2} \n-----------\n {3} | {4} | {5} \n-----------\n {6} | {7} | {8} \n", board[0], board[1], board[2], board[3], board[4], board[5], board[6], board[7], board[8]);
        }

        public void xPrompt()
        {
            Console.WriteLine("Enter a cell to place an X");
            xMove(Convert.ToInt16(Console.ReadLine()));
        }

        public void oPrompt()
        {
            Console.WriteLine("Enter a cell to place an O");
            oMove(Convert.ToInt16(Console.ReadLine()));
        }

        public void xMove(int cell)
        {
            if (moveAvailable[cell-1])
            {
                board[cell-1] = "X";
                moveAvailable[cell - 1] = false;
            }
            else
            {
                Console.WriteLine("Choose another cell");
                xMove(Convert.ToInt16(Console.ReadLine()));
            }

        }

    public void oMove (int cell)
    {
            if (moveAvailable[cell-1])
            {
                board[cell - 1] = "O";
                moveAvailable[cell - 1] = false;
            }
            else
            {
                Console.WriteLine("Choose another cell");
                oMove(Convert.ToInt16(Console.ReadLine()));
            }
        }
}
}
