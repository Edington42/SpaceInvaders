using SpaceInvaders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    class ClearEvent : Command
    {

        public override void Execute(float deltaTime)
        {
            GameTreeManager pManager = GameTreeManager.GetInstance();

            //Removing everything except for the walls so maybe there is a better way to do this
            pManager.Find(GameObject.Name.SHIELD_GROUP).pObject.Empty();
            pManager.Find(GameObject.Name.ALIEN_GRID).pObject.Empty();
            pManager.Find(GameObject.Name.SHIP_GROUP).pObject.Empty();
            pManager.Find(GameObject.Name.MISSILE_GROUP).pObject.Empty();
            pManager.Find(GameObject.Name.BOMB_GROUP).pObject.Empty();
            pManager.Find(GameObject.Name.UFO_GROUP).pObject.Empty();
        }
    }
}
