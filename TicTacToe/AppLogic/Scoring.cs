using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    

    public class Scoring
    {
        //X  horizontal win
        public List<int> xWinsH1 = new List<int>();
        public List<int> xWinsH2 = new List<int>();
        public List<int> xWinsH3 = new List<int>();

        //X Vertical win
        List<int> xWinsV1 = new List<int>();
        List<int> xWinsV2 = new List<int>();
        List<int> xWinsV3 = new List<int>();

        //X Diagonal win
        List<int> xWinsDNeg = new List<int>();
        List<int> xWinsDPos = new List<int>();


        //O  horizontal win
        List<int> oWinsH1 = new List<int>();
        List<int> oWinsH2 = new List<int>(); 
        List<int> oWinsH3 = new List<int>();

        //O Vertical win
        List<int> oWinsV1 = new List<int>();
        List<int> oWinsV2 = new List<int>();
        List<int> oWinsV3 = new List<int>();

        //O Diagonal win
        List<int> oWinsDNeg = new List<int>(); 
        List<int> oWinsDPos = new List<int>();

        //List of Tally List
        public List<List<int>> ReturnTallyList(string player)
        {
           
                if (GameManager.GameInstance.Player1 == player)
                {
                    List<List<int>> xTallyLists = new List<List<int>>();
                    xTallyLists.Add(xWinsH1);
                    xTallyLists.Add(xWinsH2);
                    xTallyLists.Add(xWinsH3);
                    xTallyLists.Add(xWinsV1);
                    xTallyLists.Add(xWinsV2);
                    xTallyLists.Add(xWinsV3);
                    xTallyLists.Add(xWinsDNeg);
                    xTallyLists.Add(xWinsDPos);
                    return xTallyLists;
                }   
                else
                {
                    List<List<int>> oTallyLists = new List<List<int>>();
                    oTallyLists.Add(oWinsH1);
                    oTallyLists.Add(oWinsH2);
                    oTallyLists.Add(oWinsH3);
                    oTallyLists.Add(oWinsV1);
                    oTallyLists.Add(oWinsV2);
                    oTallyLists.Add(oWinsV3);
                    oTallyLists.Add(oWinsDNeg);
                    oTallyLists.Add(oWinsDPos);
                    return oTallyLists;
                }
            

                   

        }
              
        public void TallyScore(int cell, string player)
        {
            switch (cell)
            {
                case 1:
                    if (player == "X")
                    {
                        xWinsH1.Add(1);
                        xWinsV1.Add(1);
                        xWinsDNeg.Add(1);
                    }
                    if (player == "O")
                    {
                        oWinsH1.Add(1);
                        oWinsV1.Add(1);
                        oWinsDNeg.Add(1);
                    }
                    break;
                case 2:
                    if (player == "X")
                    {
                        xWinsH1.Add(1);
                        xWinsV2.Add(1);
                    }
                    if (player == "O")
                    {
                        oWinsH1.Add(1);
                        oWinsV2.Add(1);
                    }
                    break;
                case 3:
                    if (player == "X")
                    {
                        xWinsH1.Add(1);
                        xWinsV3.Add(1);
                        xWinsDPos.Add(1);
                    }
                    if (player == "O")
                    {
                        oWinsH1.Add(1);
                        oWinsV3.Add(1);
                        oWinsDPos.Add(1);
                    }
                    break;
                case 4:
                    if (player == "X")
                    {
                        xWinsH2.Add(1);
                        xWinsV1.Add(1);
                    }
                    if (player == "O")
                    {
                        oWinsH2.Add(1);
                        oWinsV1.Add(1);
                    }
                    break;
                case 5:
                    if (player == "X")
                    {
                        xWinsH2.Add(1);
                        xWinsV2.Add(1);
                        xWinsDPos.Add(1);
                        xWinsDNeg.Add(1);
                    }
                    if (player == "O")
                    {
                        oWinsH2.Add(1);
                        oWinsV2.Add(1);
                        oWinsDPos.Add(1);
                        oWinsDNeg.Add(1);
                    }
                    break;
                case 6:
                    if (player == "X")
                    {
                        xWinsH2.Add(1);
                        xWinsV3.Add(1);
                    }
                    if (player == "O")
                    {
                        oWinsH2.Add(1);
                        oWinsV3.Add(1);
                    }
                    break;
                case 7:
                    if (player == "X")
                    {
                        xWinsH3.Add(1);
                        xWinsV1.Add(1);
                        xWinsDPos.Add(1);
                    }
                    if (player == "O")
                    {
                        oWinsH3.Add(1);
                        oWinsV1.Add(1);
                        oWinsDPos.Add(1);
                    }
                    break;
                case 8:
                    if (player == "X")
                    {
                        xWinsH3.Add(1);
                        xWinsV2.Add(1);
                    }
                    if (player == "O")
                    {
                        oWinsH3.Add(1);
                        oWinsV2.Add(1);
                    }
                    break;
                case 9:
                    if (player == "X")
                    {
                        xWinsH3.Add(1);
                        xWinsV3.Add(1);
                        xWinsDNeg.Add(1);
                    }
                    if (player == "O")
                    {
                        oWinsH3.Add(1);
                        oWinsV3.Add(1);
                        oWinsDNeg.Add(1);
                    }
                    break;
            }
        }

        public bool CheckForPlayerWin(string playerLetter)
        {
            bool aListEqualsThree = false;

            foreach (var list in ReturnTallyList(playerLetter))
            {
                if (list.Count() == 3) { aListEqualsThree = true; }
            }

            return aListEqualsThree;
        }
    }
}
