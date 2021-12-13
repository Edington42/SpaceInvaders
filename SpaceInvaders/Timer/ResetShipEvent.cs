using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.Ship;
using SpaceInvaders.Lives;
using SpaceInvaders.Sounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    class ResetShipEvent : Command
    {
        public override void Execute(float deltaTime)
        {
            LivesManager pMan = LivesManager.GetInstance();


            //Only if there are lives left
            if (pMan.GetCount() > 0)
            {
                //Reset the ship
                ShipManager.GetInstance().ActiveShip();
            }
            
        }
    }
}
