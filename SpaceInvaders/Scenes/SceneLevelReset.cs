using SpaceInvaders.DelayedRemove;
using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.Aliens;
using SpaceInvaders.GameObjects.Shield;
using SpaceInvaders.GameObjects.Ship;
using SpaceInvaders.Layer;
using SpaceInvaders.Observer;
using SpaceInvaders.Sounds;
using SpaceInvaders.Timer;
using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Scenes
{
    class SceneLevelReset : SceneState
    {
        //Managers unique to this scene
        public TimerManager poTimerManager;

        //Timers
        public static readonly float BOOM_FLICKER = 0.1f;

        //Subject to trigger observers with
        Subject pSubject;

        public SceneLevelReset()
        {
            this.pSubject = new Subject();
            this.Initialize();

        }
        public override void Initialize()
        {
            //---------------------------------------------------------------------------------------------------------
            // Prep the managers
            //---------------------------------------------------------------------------------------------------------
            this.poTimerManager = new TimerManager(2, 2);
            TimerManager.SetActive(this.poTimerManager);

            //---------------------------------------------------------------------------------------------------------
            // Add the observers to this subject
            //---------------------------------------------------------------------------------------------------------

            //Step 1 ------

            //Rerack
            this.pSubject.Attach(new CommandTriggerObserver(new RerackEvent(), 0.0f, TimerEvent.Name.RERACK));

            //Tranistion out
            this.pSubject.Attach(new CommandTriggerObserver(new TransitionEvent(SceneContext.Scene.Play), 1.0f, TimerEvent.Name.TRANSITION));
        }

        public override void Update(float systemTime)
        {
            poTimerManager.Update(systemTime);
        }

        public override void Draw()
        {
            //This is the magic of this scene, it does not draw so we can reloat the layer all we want
        }

        public override void TransitionTo()
        {
            TimerManager.SetActive(this.poTimerManager);

            //Notify the observers that we have entered
            this.pSubject.Notify();
        }

        public override void TransitionFrom()
        {
            //Do nothing
        }

    }
}
