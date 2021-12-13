using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Score;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    class ScoreAlienObserver : Observer
    {
        public override void Notify()
        {
            ColPairSubject colPair = (ColPairSubject)this.pSubject;
            AlienObject alienObject = (AlienObject)colPair.GetByRootName(GameObject.Name.ALIEN_GRID);
            ScoreKeeper.GetInstance().Score(alienObject.GetScore());

        }

        public override void Print()
        {
            Debug.WriteLine("Alien Score Observer");
        }
    }
}
