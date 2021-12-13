using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.UFO;
using SpaceInvaders.Score;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    class ScoreUfoObserver : Observer
    {
        public override void Notify()
        {
            ColPairSubject colPair = (ColPairSubject)this.pSubject;
            Ufo ufo = (Ufo)colPair.GetByRootName(GameObject.Name.UFO_GROUP);
            ScoreKeeper.GetInstance().Score(ufo.GetScore());

        }

        public override void Print()
        {
            Debug.WriteLine("Ufo Score Observer");
        }
    }
}
