using SpaceInvaders.Observer;
using SpaceInvaders.Timer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Scenes
{
    class SceneOverReset : SceneState
    {
        //Managers unique to this scene
        public TimerManager poTimerManager;

        //Timers
        public static readonly float BOOM_FLICKER = 0.1f;

        //Subject to trigger observers with
        Subject pSubject;

        public SceneOverReset()
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
            this.pSubject.Attach(new CommandTriggerObserver(new RerackEvent(), 0.0f, TimerEvent.Name.TABULATE));

            //Tabulate score
            this.pSubject.Attach(new CommandTriggerObserver(new TabulateScoreEvent(), 0.0f, TimerEvent.Name.TABULATE));

            //Reset level
            this.pSubject.Attach(new CommandTriggerObserver(new ResetLevelEvenet(), 0.0f, TimerEvent.Name.RESET_LEVEL));

            //Reset alien start position
            this.pSubject.Attach(new CommandTriggerObserver(new ResetLivesEvent(), 0.0f, TimerEvent.Name.RESET_LIVES));

            //Tranistion out
            this.pSubject.Attach(new CommandTriggerObserver(new TransitionEvent(SceneContext.Scene.Select), 1.0f, TimerEvent.Name.TRANSITION));
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
