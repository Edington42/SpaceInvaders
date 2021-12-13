using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.UFO;
using SpaceInvaders.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    class UfoMoveEvent : Command
    {

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------


        public override void Execute(float deltaTime)
        {
            UfoGroup pObj = (UfoGroup)GameTreeManager.GetInstance().Find(GameObject.Name.UFO_GROUP).pObject;
            //Move each child of this object
            GameObject child = (GameObject)pObj.GetFirstChild();
            while (child != null)
            {
                child.x += UfoManager.GetInstance().GetDelta();
                child = (GameObject)child.GetSibling();
            }
        }
    }
}
