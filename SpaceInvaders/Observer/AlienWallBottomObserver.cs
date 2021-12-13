using SpaceInvaders.DelayedRemove;
using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.Ship;
using SpaceInvaders.GameObjects.UFO;
using SpaceInvaders.Layer;
using SpaceInvaders.Lives;
using SpaceInvaders.Sounds;
using SpaceInvaders.Sprite;
using SpaceInvaders.Timer;
using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    class AlienWallBottomObserver : Observer
    {
        public bool triggered = false;
        public override void Notify()
        {
            //Super cheap beacuse otherwise the collision keeps happening
            if (!triggered)
            {
                //Cheat to set it to one so when we lose a life it is game over
                LivesManager.GetInstance().currentCount = 1;

                //Another cheat to make sure the ufo is reset
                UfoManager pMan = UfoManager.GetInstance();
                if (pMan.flying)
                {
                    Sound pNode = (Sound)SoundManager.GetInstance().Find(Sound.Name.UFO);
                    pNode.StopLoop();
                    pMan.PrepUfo();
                }

                //Hacky but I don't want the missile to leave this state

                //Double check that the missile is gone
                GameTreeManager.GetInstance().Find(GameObject.Name.MISSILE_GROUP).pObject.Empty();

                //Same for the sound
                Sound missileSound = (Sound)SoundManager.GetInstance().Find(Sound.Name.MISSILE);
                missileSound.StopLoop();

                SpaceInvaders.pSceneContext.SetState(Scenes.SceneContext.Scene.Death);
                triggered = true;
            }

        }

        public override void Print()
        {
            Debug.WriteLine("Alien wall bottom Observer");
        }
    }
}
