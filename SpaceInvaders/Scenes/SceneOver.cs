using SpaceInvaders.Font;
using SpaceInvaders.Layer;
using SpaceInvaders.Observer;
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

namespace SpaceInvaders.Scenes
{
    class SceneOver : SceneState
    {
        //Managers unique to this scene
        public SoundManager poSoundManager;
        public TimerManager poTimerManager;

        //Subject to trigger observers with
        Subject pSubject;

        public SceneOver()
        {
            this.pSubject = new Subject();
            this.Initialize();

        }

        public override void Initialize()
        {
            //---------------------------------------------------------------------------------------------------------
            // Prep the managers
            //---------------------------------------------------------------------------------------------------------
            this.poSoundManager = new SoundManager(1, 2);
            SoundManager.SetActive(this.poSoundManager);
            this.poTimerManager = new TimerManager(1, 2);
            TimerManager.SetActive(this.poTimerManager);

            //---------------------------------------------------------------------------------------------------------
            // Add font
            //---------------------------------------------------------------------------------------------------------

            //Get the manager
            FontSpriteManager pFontSpriteManager = FontSpriteManager.GetInstance();

            //Add score labels
            pFontSpriteManager.Add(FontSprite.Name.GAME_OVER_LABEL, Layer.Layer.Name.TEXTS, "", Glyph.Name.CONSOLAS_36_PT, Screen.GAME_OVER_X, Screen.GAME_OVER_Y);

            //---------------------------------------------------------------------------------------------------------
            // Add the observers to this subject
            //---------------------------------------------------------------------------------------------------------

            //Step 1 ------

            //Show Game over
            this.pSubject.Attach(new CommandTriggerObserver(new ShowOverEvent(), 0.0f, TimerEvent.Name.SHOW_OVER));


            //Step 2 -----

            //Remove Game Over
            this.pSubject.Attach(new CommandTriggerObserver(new HideOverEvent(), 1.0f, TimerEvent.Name.HIDE_OVER));

            //Clear the screen
            this.pSubject.Attach(new CommandTriggerObserver(new ClearEvent(), 1.0f, TimerEvent.Name.CLEAR_COMMAND));

            //Step 4 -----

            //Tranistion out
            this.pSubject.Attach(new CommandTriggerObserver(new TransitionEvent(SceneContext.Scene.OverReset), 2.0f, TimerEvent.Name.TRANSITION_RESET));

            //Reset play space
        }
        public override void Update(float systemTime)
        {
            SoundManager.GetInstance().Update();
            poTimerManager.Update(systemTime);
        }

        public override void Draw()
        {
            //This might be shared by all scenes 
            // draw all objects
            LayerManager.GetInstance().Draw();
        }

        public override void TransitionTo()
        {
            TimerManager.SetActive(this.poTimerManager);
            SoundManager.SetActive(this.poSoundManager);

            //Note we are not changing the layer manager, we are using the same layer

            //Notify the observers that we have entered
            this.pSubject.Notify();
        }

        public override void TransitionFrom()
        {
            //Do nothing
        }

    }
}
