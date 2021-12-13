using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.Aliens;
using SpaceInvaders.GameObjects.Shield;
using SpaceInvaders.GameObjects.Ship;
using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    public class RerackEvent : Command
    {

        public override void Execute(float deltaTime)
        {
            ShieldGroup pGroup = (ShieldGroup)GameTreeManager.GetInstance().Find(GameObject.Name.SHIELD_GROUP).pObject;
            AlienGrid pGrid = (AlienGrid)GameTreeManager.GetInstance().Find(GameObject.Name.ALIEN_GRID).pObject;

            ShieldGroupFactory.GetInstance().Populate(pGroup, Screen.MIDDILE_X, Screen.SHIELD_Y);
            AlienGridFactory.GetInstance().Populate(pGrid, Screen.MIDDILE_X, pGrid.GetStartPos());

            ShipManager.GetInstance().ActiveShip();
        }
    }
}
