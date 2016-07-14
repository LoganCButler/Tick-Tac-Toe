using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class GameManager
    {
        private static readonly Game _game = new Game();
        private static readonly Scoring _score = new Scoring();
        private static readonly AI _AI = new AI();

        public static Game GameInstance
        {
            get { return _game; }
        }

        public static Scoring ScoreInstance
        {
            get { return _score; }
        }
      
        public static AI AIInstance
        {
            get { return _AI; }
        }
    }
}
