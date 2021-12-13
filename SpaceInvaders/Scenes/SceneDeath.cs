using SpaceInvaders.DelayedRemove;
using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.Ship;
using SpaceInvaders.Images;
using SpaceInvaders.Layer;
using SpaceInvaders.Observer;
using SpaceInvaders.Sounds;
using SpaceInvaders.Sprite;
using SpaceInvaders.Timer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Scenes
{
    class SceneDeath : SceneState
    {
        //Managers unique to this scene
        public SoundManager poSoundManager;
        public TimerManager poTimerManager;

        //Timers
        public static readonly float BOOM_FLICKER = 0.1f;

        //Subject to trigger observers with
        Subject pSubject;

        public SceneDeath()
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
            // Load the sounds
            //---------------------------------------------------------------------------------------------------------
            poSoundManager.Add(Sound.Name.SHIP, "explosion1.wav");

            //---------------------------------------------------------------------------------------------------------
            // Preprare animations
            //---------------------------------------------------------------------------------------------------------
            //Ship
            AnimationSprite animationBoom = new AnimationSprite(GameSpriteNode.Name.SHIP_BOOM);
            animationBoom.Attach(ImageNode.Name.SHIP_BOOM_0);
            animationBoom.Attach(ImageNode.Name.SHIP_BOOM_1);

            Command shipBoomCommand = new RepeatCommand(TimerEvent.Name.SHIP_BOOM, animationBoom, BOOM_FLICKER);

            poTimerManager.Add(TimerEvent.Name.SHIP_BOOM, shipBoomCommand, BOOM_FLICKER);

            //---------------------------------------------------------------------------------------------------------
            // Add the observers to this subject
            //---------------------------------------------------------------------------------------------------------

            //Step 1 ------

            //Play sound
            this.pSubject.Attach(new LoopedSoundObserver(Sound.Name.SHIP, 1.0f));

            //Play animation
            this.pSubject.Attach(new ShipSplatObserver(Layer.Layer.Name.SHIP, GameSpriteNode.Name.SHIP_BOOM));

            //Step 2 -----
             
            //Decrement Lives
            this.pSubject.Attach(new LifeLostObvserser());

            //Step 3 ---- 

            //Tranistion out
            this.pSubject.Attach(new CommandTriggerObserver(new DeathTransitionEvent(), 3.0f, TimerEvent.Name.DEATH_TRANSITION));

            //Reset event
            this.pSubject.Attach(new ResetShipObserver());
        }
        public override void Update(float systemTime)
        {
            SoundManager.GetInstance().Update();
            poTimerManager.Update(systemTime);
            DelayRemoveManager.GetInstance().Process();
        }

        public override void Draw()
        {
            //This might be shared by all scenes 
            // draw all objects
            LayerManager.GetInstance().Draw();
        }

        public override void TransitionTo()
        {
            // update SpriteBatchMan()
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
