using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    class AlienWallRightObserver : Observer
    {
        public override void Notify()
        {
            ColPairSubject colPairSubject = (ColPairSubject)this.pSubject;
            AlienGrid pGrid = (AlienGrid)colPairSubject.GetByName(GameObject.Name.ALIEN_GRID);
            pGrid.TurnLeft();
        }

        public override void Print()
        {
            Debug.WriteLine("Alien wall left Observer");
        }
    }
}
