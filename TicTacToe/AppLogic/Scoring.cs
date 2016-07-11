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
        List<int> xWinsH1 = new List<int>();
        List<int> xWinsH2 = new List<int>();
        List<int> xWinsH3 = new List<int>();

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

        public bool xWins()
        {
            if (xWinsH1.Count == 3 || xWinsH2.Count == 3 || xWinsH3.Count == 3 || xWinsV1.Count == 3 || xWinsV2.Count == 3 || xWinsV3.Count == 3 || xWinsDPos.Count == 3 || xWinsDPos.Count == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool oWins()
        {
            if (oWinsH1.Count == 3 || oWinsH2.Count == 3 || oWinsH3.Count == 3 || oWinsV1.Count == 3 || oWinsV2.Count == 3 || oWinsV3.Count == 3 || oWinsDPos.Count == 3 || oWinsDPos.Count == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
