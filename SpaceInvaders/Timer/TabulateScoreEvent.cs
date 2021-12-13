using SpaceInvaders.Score;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    class TabulateScoreEvent : Command
    {
        public override void Execute(float deltaTime)
        {
            ScoreKeeper.GetInstance().ResetCurrent();
        }
    }
}
