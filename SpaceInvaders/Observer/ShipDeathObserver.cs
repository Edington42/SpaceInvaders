using SpaceInvaders.GameObjects;
using SpaceInvaders.Sounds;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    class ShipDeathObserver : Observer
    {
        public override void Notify()
        {
            //Hacky but I don't want the missile to leave this state

            //Double check that the missile is gone
            GameTreeManager.GetInstance().Find(GameObject.Name.MISSILE_GROUP).pObject.Empty();

            //Same for the sound
            Sound pNode = (Sound)SoundManager.GetInstance().Find(Sound.Name.MISSILE);
            pNode.StopLoop();

            //Transiton
            SpaceInvaders.pSceneContext.SetState(Scenes.SceneContext.Scene.Death);
        }

        public override void Print()
        {
            Debug.WriteLine("Ship death observer");
        }
    }
}
