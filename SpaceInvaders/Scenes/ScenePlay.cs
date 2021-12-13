using SpaceInvaders.Collision;
using SpaceInvaders.DelayedRemove;
using SpaceInvaders.Font;
using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.Aliens;
using SpaceInvaders.GameObjects.Bomb;
using SpaceInvaders.GameObjects.Shield;
using SpaceInvaders.GameObjects.Ship;
using SpaceInvaders.GameObjects.UFO;
using SpaceInvaders.GameObjects.Wall;
using SpaceInvaders.Images;
using SpaceInvaders.Input;
using SpaceInvaders.Layer;
using SpaceInvaders.Lives;
using SpaceInvaders.Observer;
using SpaceInvaders.Score;
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
    class ScenePlay : SceneState
    {


        //Managers unique to this scene
        public LayerManager poLayerManager;
        public GameTreeManager poGameTreeManager;
        public ColPairManager poColPairManager;
        public LivesManager poLivesManager;
        public TimerManager poTimerManager;
        public SoundManager poSoundManager;

        //Timers
        public static readonly float BOMB_MOVE_UPDATE = 0.02f;
        public static readonly float ALIEN_MOVE_UPDATE = 1.1f;
        public static readonly float UFO_MOVE_UPDATE = .05f;
        public static readonly float BOMB_DROP_UPDATE = 1.5f;
        public static readonly float BOMB_ANIMATION_UPDATE = 0.1f;
        public static readonly float BOOM_TIME = 1.0f;

        //Really cheap way to handle the aliens on the bottom
        AlienWallBottomObserver wallBottomObserver;

        public ScenePlay()
        {
            this.Initialize();
        }

        public override void Initialize()
        {
            //---------------------------------------------------------------------------------------------------------
            // Prep the managers
            //---------------------------------------------------------------------------------------------------------
            this.poLayerManager = new LayerManager(3, 1);
            LayerManager.SetActive(this.poLayerManager);
            this.poGameTreeManager = new GameTreeManager(5, 3);
            GameTreeManager.SetActive(this.poGameTreeManager);
            this.poColPairManager = new ColPairManager(7, 3);
            ColPairManager.SetActive(this.poColPairManager);
            this.poLivesManager = new LivesManager(3);
            LivesManager.SetActive(this.poLivesManager);
            this.poTimerManager = new TimerManager(7, 3);
            TimerManager.SetActive(this.poTimerManager);
            this.poSoundManager = new SoundManager(8, 2);
            SoundManager.SetActive(this.poSoundManager);

            //---------------------------------------------------------------------------------------------------------
            // Load the sounds
            //---------------------------------------------------------------------------------------------------------
            poSoundManager.Add(Sound.Name.ALIEN_BOOM, "shoot.wav");
            poSoundManager.Add(Sound.Name.UFO, "ufo_highpitch.wav");
            poSoundManager.Add(Sound.Name.MISSILE, "invaderkilled3.wav");
            poSoundManager.Add(Sound.Name.SHIP, "explosion1.wav");
            poSoundManager.Add(Sound.Name.ALIEN_MOVE_0, "fastinvader1.wav");
            poSoundManager.Add(Sound.Name.ALIEN_MOVE_1, "fastinvader2.wav");
            poSoundManager.Add(Sound.Name.ALIEN_MOVE_2, "fastinvader3.wav");
            poSoundManager.Add(Sound.Name.ALIEN_MOVE_3, "fastinvader4.wav");

            //---------------------------------------------------------------------------------------------------------
            // Create layers
            //---------------------------------------------------------------------------------------------------------
            poLayerManager.Add(Layer.Layer.Name.ALIENS, 0);
            poLayerManager.Add(Layer.Layer.Name.MISSILES, 1);
            poLayerManager.Add(Layer.Layer.Name.SHIP, 2);
            poLayerManager.Add(Layer.Layer.Name.WALLS, 3);
            poLayerManager.Add(Layer.Layer.Name.SHIELD, 4);
            poLayerManager.Add(Layer.Layer.Name.BOMBS, 5);
            poLayerManager.Add(Layer.Layer.Name.TEXTS, 0);
            poLayerManager.Add(Layer.Layer.Name.UFO, 6);
            poLayerManager.Add(Layer.Layer.Name.BOXES, -5);

            //---------------------------------------------------------------------------------------------------------
            // Create objects and attach the sprites
            //---------------------------------------------------------------------------------------------------------

            //Create the overall grid 
            AlienGrid pGrid = new AlienGrid(GameObject.Name.ALIEN_GRID);
            pGrid = (AlienGrid)AlienGridFactory.GetInstance().Populate(pGrid, Screen.MIDDILE_X, pGrid.GetStartPos());

            pGrid.AttachColObj(Layer.Layer.Name.BOXES);
            poGameTreeManager.Attach(pGrid);

            //Create the ship group and active the ship
            ShipGroup shipGroup = new ShipGroup(GameObject.Name.SHIP_GROUP);
            shipGroup.AttachColObj(Layer.Layer.Name.BOXES);
            poGameTreeManager.Attach(shipGroup);
            ShipManager.GetInstance().ActiveShip();

            //Create Ufo group
            UfoGroup pUfoGroup = new UfoGroup(GameObject.Name.UFO_GROUP);
            pUfoGroup.AttachColObj(Layer.Layer.Name.BOXES);
            poGameTreeManager.Attach(pUfoGroup);

            //Create Missile group
            MissileGroup missileGroup = new MissileGroup(GameObject.Name.MISSILE_GROUP);
            missileGroup.AttachColObj(Layer.Layer.Name.BOXES);
            poGameTreeManager.Attach(missileGroup);

            //Create the bomb group
            BombGroup bombGroup = new BombGroup(GameObject.Name.BOMB_GROUP);
            bombGroup.AttachColObj(Layer.Layer.Name.BOXES);
            poGameTreeManager.Attach(bombGroup);

            //Create a shield grid
            ShieldGroup pShieldGroup = (ShieldGroup)ShieldGroupFactory.GetInstance().Populate(new ShieldGroup(GameObject.Name.SHIELD_GROUP), Screen.MIDDILE_X, Screen.SHIELD_Y);
            pShieldGroup.AttachColObj(Layer.Layer.Name.BOXES);
            poGameTreeManager.Attach(pShieldGroup);

            //Top
            WallGroup pWallTopGroup = new WallGroup(GameObject.Name.WALL_GROUP);
            pWallTopGroup.AttachColObj(Layer.Layer.Name.BOXES);
            WallTop pWallTop = new WallTop(GameObject.Name.WALL_TOP, Screen.MIDDILE_X, Screen.HEIGHT - Sizes.WALL_TOP_SCREEN.screenY / 2, Sizes.WALL_TOP_SCREEN.screenX, Sizes.WALL_TOP_SCREEN.screenY);
            pWallTop.AttachColObj(Layer.Layer.Name.BOXES);
            pWallTopGroup.Add(pWallTop);
            poGameTreeManager.Attach(pWallTopGroup);

            //Left
            WallGroup pWallLeftGroup = new WallGroup(GameObject.Name.WALL_GROUP);
            pWallLeftGroup.AttachColObj(Layer.Layer.Name.BOXES);
            WallLeft pWallLeft = new WallLeft(GameObject.Name.WALL_LEFT, Sizes.WALL_SIDE_SCREEN.screenX / 2, Screen.MIDDILE_Y, Sizes.WALL_SIDE_SCREEN.screenX, Sizes.WALL_SIDE_SCREEN.screenY);
            pWallLeft.AttachColObj(Layer.Layer.Name.BOXES);
            pWallLeftGroup.Add(pWallLeft);
            poGameTreeManager.Attach(pWallLeftGroup);

            //Right
            WallGroup pWallRightGroup = new WallGroup(GameObject.Name.WALL_GROUP);
            pWallRightGroup.AttachColObj(Layer.Layer.Name.BOXES);
            WallRight pWallRight = new WallRight(GameObject.Name.WALL_BOTTOM, Screen.WIDTH - (Sizes.WALL_SIDE_SCREEN.screenX / 2), Screen.MIDDILE_Y, Sizes.WALL_SIDE_SCREEN.screenX, Sizes.WALL_SIDE_SCREEN.screenY);
            pWallRight.AttachColObj(Layer.Layer.Name.BOXES);
            pWallRightGroup.Add(pWallRight);
            poGameTreeManager.Attach(pWallRightGroup);

            //Bottom
            WallGroup pWallBottomGroup = new WallGroup(GameObject.Name.WALL_GROUP);
            pWallBottomGroup.AttachColObj(Layer.Layer.Name.BOXES);
            WallBottom pWallBottom = new WallBottom(GameObject.Name.WALL_BOTTOM, Screen.MIDDILE_X, Sizes.WALL_BOTTOM_SCREEN.screenY / 2, Sizes.WALL_BOTTOM_SCREEN.screenX, Sizes.WALL_BOTTOM_SCREEN.screenY);
            pWallBottom.AttachColObj(Layer.Layer.Name.BOXES);
            pWallBottomGroup.Add(pWallBottom);
            poGameTreeManager.Attach(pWallBottomGroup);

            //---------------------------------------------------------------------------------------------------------
            // Preprare animations
            //---------------------------------------------------------------------------------------------------------

            //Aliens
            AnimationSprite animationSquid = new AnimationSprite(GameSpriteNode.Name.SQUID);
            animationSquid.Attach(ImageNode.Name.SQUID_CLOSED);
            animationSquid.Attach(ImageNode.Name.SQUID_OPEN);
            

            AnimationSprite animationCrab = new AnimationSprite(GameSpriteNode.Name.CRAB);
            animationCrab.Attach(ImageNode.Name.CRAB_CLOSED);
            animationCrab.Attach(ImageNode.Name.CRAB_OPEN);
            

            AnimationSprite animationOcto = new AnimationSprite(GameSpriteNode.Name.OCTOPUS);
            animationOcto.Attach(ImageNode.Name.OCTO_CLOSED);
            animationOcto.Attach(ImageNode.Name.OCTO_OPEN);
            

            Command squidCommand = new AlienRepeatCommand(TimerEvent.Name.SQUID, animationSquid, ALIEN_MOVE_UPDATE);
            Command crabCommand = new AlienRepeatCommand(TimerEvent.Name.CRAB, animationCrab, ALIEN_MOVE_UPDATE);
            Command octoCommand = new AlienRepeatCommand(TimerEvent.Name.OCTO, animationOcto, ALIEN_MOVE_UPDATE);

            //Bombs
            AnimationSprite animationSquigly = new AnimationSprite(GameSpriteNode.Name.SQUIGLY);
            animationSquigly.Attach(ImageNode.Name.SQUIGLY_0);
            animationSquigly.Attach(ImageNode.Name.SQUIGLY_1);
            animationSquigly.Attach(ImageNode.Name.SQUIGLY_2);
            animationSquigly.Attach(ImageNode.Name.SQUIGLY_3);

            AnimationSprite animationPlunger = new AnimationSprite(GameSpriteNode.Name.PLUNGER);
            animationPlunger.Attach(ImageNode.Name.PLUNGER_0);
            animationPlunger.Attach(ImageNode.Name.PLUNGER_1);
            animationPlunger.Attach(ImageNode.Name.PLUNGER_2);
            animationPlunger.Attach(ImageNode.Name.PLUNGER_3);

            AnimationSprite animationRolling = new AnimationSprite(GameSpriteNode.Name.ROLLING);
            animationRolling.Attach(ImageNode.Name.ROLLING_0);
            animationRolling.Attach(ImageNode.Name.ROLLING_1);
            animationRolling.Attach(ImageNode.Name.ROLLING_2);
            animationRolling.Attach(ImageNode.Name.ROLLING_3);

            Command squiglyCommand = new RepeatCommand(TimerEvent.Name.SQUIGLY, animationSquigly, BOMB_ANIMATION_UPDATE);
            Command plungerCommand = new RepeatCommand(TimerEvent.Name.PLUNGER, animationPlunger, BOMB_ANIMATION_UPDATE);
            Command rollingCommand = new RepeatCommand(TimerEvent.Name.ROLLING, animationRolling, BOMB_ANIMATION_UPDATE);

            //---------------------------------------------------------------------------------------------------------
            // Prepare the fire events
            //---------------------------------------------------------------------------------------------------------
            BombDropEvent bombDropEvent = new BombDropEvent((AlienGrid)pGrid);
            Command bombDropCommand = new BombDropRepeatCommand(TimerEvent.Name.DROP_BOMB, bombDropEvent, BOMB_DROP_UPDATE);


            //---------------------------------------------------------------------------------------------------------
            // Prepare move sounds
            //---------------------------------------------------------------------------------------------------------
            SoundLoopObserver pMoveSoundObserver = new SoundLoopObserver();
            pMoveSoundObserver.Attach(Sound.Name.ALIEN_MOVE_1);
            pMoveSoundObserver.Attach(Sound.Name.ALIEN_MOVE_0);
            pMoveSoundObserver.Attach(Sound.Name.ALIEN_MOVE_3);
            pMoveSoundObserver.Attach(Sound.Name.ALIEN_MOVE_2);

            //---------------------------------------------------------------------------------------------------------
            // Prepare move events
            //---------------------------------------------------------------------------------------------------------

            //Aliens
            Subject alienMoveSubject = new Subject();
            alienMoveSubject.Attach(pMoveSoundObserver);
            AlienMoveEvent moveEvent = new AlienMoveEvent(alienMoveSubject);
            Command moveCommand = new AlienRepeatCommand(TimerEvent.Name.MOVE_ALIENS, moveEvent, ALIEN_MOVE_UPDATE);

            //Ufo
            UfoMoveEvent ufoMoveEvent = new UfoMoveEvent();
            Command ufoMoveCommand = new RepeatCommand(TimerEvent.Name.MOVE_UFO, ufoMoveEvent, UFO_MOVE_UPDATE);

            //Bombs
            BombMoveEvent bombMoveEvent = new BombMoveEvent(bombGroup);
            Command bombMoveCommand = new RepeatCommand(TimerEvent.Name.MOVE_BOMBS, bombMoveEvent, BOMB_MOVE_UPDATE);

            //Missile
            Subject missileMoveSubject = new Subject();
            MissileMoveEvent missileMoveEvent = new MissileMoveEvent(missileGroup, missileMoveSubject);
            Command missileMoveCommand = new RepeatCommand(TimerEvent.Name.MOVE_MISSILE, missileMoveEvent, BOMB_MOVE_UPDATE);

            //---------------------------------------------------------------------------------------------------------
            // Add collision pairs
            //---------------------------------------------------------------------------------------------------------

            //First do one update so everything is in place 
            GameTreeManager.GetInstance().Update();

            //MISSILE -> WALL_TOP
            ColPair pMissileWall = poColPairManager.Add(ColPair.Name.WALL_MISSILE, missileGroup, pWallTopGroup);
            pMissileWall.subject.Attach(new DelayRemoveObserver(GameObject.Name.MISSILE_GROUP));
            pMissileWall.subject.Attach(new SplatObserver(GameObject.Name.MISSILE_GROUP, Layer.Layer.Name.MISSILES, GameSpriteNode.Name.MISSILE_BOOM));
            pMissileWall.subject.Attach(new ShipReadyObserver());
            pMissileWall.subject.Attach(new SndStopLoopObserver(Sound.Name.MISSILE));

            //MISSILE -> BRICK
            ColPair pMissileBrick = poColPairManager.Add(ColPair.Name.SHIELD_MISSILE, missileGroup, pShieldGroup);
            pMissileBrick.subject.Attach(new DelayRemoveObserver(GameObject.Name.MISSILE_GROUP));
            pMissileBrick.subject.Attach(new DelayRemoveObserver(GameObject.Name.SHIELD_GROUP));
            pMissileBrick.subject.Attach(new SplatObserver(GameObject.Name.MISSILE_GROUP, Layer.Layer.Name.MISSILES, GameSpriteNode.Name.MISSILE_BOOM));
            pMissileBrick.subject.Attach(new ShipReadyObserver());
            pMissileBrick.subject.Attach(new SndStopLoopObserver(Sound.Name.MISSILE));

            //BOMB -> BRICK
            ColPair pBombBrick = poColPairManager.Add(ColPair.Name.SHIELD_BOMB, bombGroup, pShieldGroup);
            pBombBrick.subject.Attach(new DelayRemoveObserver(GameObject.Name.SHIELD_GROUP));
            pBombBrick.subject.Attach(new DelayRemoveObserver(GameObject.Name.BOMB_GROUP));
            pBombBrick.subject.Attach(new SplatObserver(GameObject.Name.BOMB_GROUP, Layer.Layer.Name.BOMBS, GameSpriteNode.Name.BOMB_BOOM));

            //BOMB -> WALL_BOTTOM
            ColPair pBombWall = poColPairManager.Add(ColPair.Name.WALL_BOMB, bombGroup, pWallBottomGroup);
            pBombWall.subject.Attach(new DelayRemoveObserver(GameObject.Name.BOMB_GROUP));
            pBombWall.subject.Attach(new SplatObserver(GameObject.Name.BOMB_GROUP, Layer.Layer.Name.BOMBS, GameSpriteNode.Name.BOMB_BOOM));

            //MISSILE -> ALIEN
            ColPair pAlienMissile = poColPairManager.Add(ColPair.Name.ALIEN_MISSILE, missileGroup, pGrid);
            pAlienMissile.subject.Attach(new DelayRemoveObserver(GameObject.Name.MISSILE_GROUP));
            pAlienMissile.subject.Attach(new DelayRemoveObserver(GameObject.Name.ALIEN_GRID));
            pAlienMissile.subject.Attach(new SplatObserver(GameObject.Name.ALIEN_GRID, Layer.Layer.Name.ALIENS, GameSpriteNode.Name.ALIEN_BOOM));
            pAlienMissile.subject.Attach(new ShipReadyObserver());
            pAlienMissile.subject.Attach(new SoundObserver(Sound.Name.ALIEN_BOOM));
            pAlienMissile.subject.Attach(new ScoreAlienObserver());
            pAlienMissile.subject.Attach(new SndStopLoopObserver(Sound.Name.MISSILE));

            //ALIEN -> SHIELD
            ColPair pAlienShield = poColPairManager.Add(ColPair.Name.ALIEN_SHIELD, pGrid, pShieldGroup);
            pAlienShield.subject.Attach(new DelayRemoveObserver(GameObject.Name.SHIELD_GROUP));

            //MISSILE -> BOMB
            ColPair pMissileBomb = poColPairManager.Add(ColPair.Name.MISSILE_BOMB, missileGroup, bombGroup);
            pMissileBomb.subject.Attach(new DelayRemoveObserver(GameObject.Name.MISSILE_GROUP));
            pMissileBomb.subject.Attach(new SplatObserver(GameObject.Name.MISSILE_GROUP, Layer.Layer.Name.MISSILES, GameSpriteNode.Name.MISSILE_BOOM));
            pMissileBomb.subject.Attach(new DelayRemoveObserver(GameObject.Name.BOMB_GROUP));
            pMissileBomb.subject.Attach(new SplatObserver(GameObject.Name.BOMB_GROUP, Layer.Layer.Name.BOMBS, GameSpriteNode.Name.BOMB_BOOM));
            pMissileBomb.subject.Attach(new ShipReadyObserver());
            pMissileBomb.subject.Attach(new SndStopLoopObserver(Sound.Name.MISSILE));

            //UFO -> WALL_LEFT
            ColPair pUfoWallLeft = poColPairManager.Add(ColPair.Name.WALL_LEFT_UFO, pUfoGroup, pWallLeftGroup);
            pUfoWallLeft.subject.Attach(new DelayRemoveObserver(GameObject.Name.UFO_GROUP));
            pUfoWallLeft.subject.Attach(new ResetUfoLaunchObserver());
            pUfoWallLeft.subject.Attach(new SndStopLoopObserver(Sound.Name.UFO));

            //UFO -> WALL_RIGHT
            ColPair pUfoWallRight = poColPairManager.Add(ColPair.Name.WALL_RIGHT_UFO, pUfoGroup, pWallRightGroup);
            pUfoWallRight.subject.Attach(new DelayRemoveObserver(GameObject.Name.UFO_GROUP));
            pUfoWallRight.subject.Attach(new ResetUfoLaunchObserver());
            pUfoWallRight.subject.Attach(new SndStopLoopObserver(Sound.Name.UFO));
            

            //UFO -> MISSILE
            ColPair pUfoMissile = poColPairManager.Add(ColPair.Name.MISSILE_UFO, missileGroup, pUfoGroup);
            pUfoMissile.subject.Attach(new DelayRemoveObserver(GameObject.Name.UFO_GROUP));
            pUfoMissile.subject.Attach(new DelayRemoveObserver(GameObject.Name.MISSILE_GROUP));
            pUfoMissile.subject.Attach(new ShipReadyObserver());
            pUfoMissile.subject.Attach(new ResetUfoLaunchObserver());
            pUfoMissile.subject.Attach(new ScoreUfoObserver());
            pUfoMissile.subject.Attach(new SplatObserver(GameObject.Name.UFO_GROUP, Layer.Layer.Name.UFO, GameSpriteNode.Name.UFO_BOOM));
            pUfoMissile.subject.Attach(new SndStopLoopObserver(Sound.Name.UFO));
            pUfoMissile.subject.Attach(new SndStopLoopObserver(Sound.Name.MISSILE));

            //ALIEN_GRID -> WALL_LEFT
            ColPair pAlienLeft = poColPairManager.Add(ColPair.Name.ALIEN_LEFT, pGrid, pWallLeftGroup);
            pAlienLeft.subject.Attach(new AlienWallLeftObserver());

            //ALIEN_GRID -> WALL_RIGHT
            ColPair pAlienRight = poColPairManager.Add(ColPair.Name.ALIEN_RIGHT, pGrid, pWallRightGroup);
            pAlienRight.subject.Attach(new AlienWallRightObserver());

            //ALIEN -> WALL_BOTTOM
            ColPair pAlienBottom = poColPairManager.Add(ColPair.Name.ALIEN_BOTTOM, pGrid, pWallBottom);
            this.wallBottomObserver = new AlienWallBottomObserver();
            pAlienBottom.subject.Attach(this.wallBottomObserver);
            pAlienBottom.subject.Attach(new ShipRemoveObserver());

            //SHIP -> WALL_LEFT
            ColPair pShipLeft = poColPairManager.Add(ColPair.Name.SHIP_LEFT, shipGroup, pWallLeftGroup);
            pShipLeft.subject.Attach(new ShipWallLeftObserver());

            //SHIP -> WALL_RIGHT
            ColPair pShipRight = poColPairManager.Add(ColPair.Name.SHIP_RIGHT, shipGroup, pWallRightGroup);
            pShipRight.subject.Attach(new ShipWallRightObserver());

            //SHIP -> BOMB
            ColPair pShipBomb = poColPairManager.Add(ColPair.Name.SHIP_BOMB, bombGroup, shipGroup);
            pShipBomb.subject.Attach(new DelayRemoveObserver(GameObject.Name.BOMB_GROUP));
            pShipBomb.subject.Attach(new DelayRemoveObserver(GameObject.Name.SHIP_GROUP));
            pShipBomb.subject.Attach(new ShipDeathObserver());

            //---------------------------------------------------------------------------------------------------------
            // Attach additional observers
            //---------------------------------------------------------------------------------------------------------

            //Attach observer for when missile fires
            ShipManager.GetInstance().GetShip().pSubject.Attach(new SndStartLoopObserver(Sound.Name.MISSILE));

            //Attach observer for when all the aliens are gone
            Subject bSub = ((AlienGrid)pGrid).pSubject;
            bSub.Attach(new UfoLevelObserver());
            bSub.Attach(new CommandTriggerObserver(new ClearEvent(), 0.5f, TimerEvent.Name.CLEAR_COMMAND));
            bSub.Attach(new CommandTriggerObserver(new TransitionEvent(SceneContext.Scene.LevelReset), 0.5f, TimerEvent.Name.TRANSITION));

            //---------------------------------------------------------------------------------------------------------
            // Add font
            //---------------------------------------------------------------------------------------------------------

            //Get the manager
            FontSpriteManager pFontSpriteManager = FontSpriteManager.GetInstance();

            //Add life counter
            pFontSpriteManager.Add(FontSprite.Name.LIFE_COUNT, Layer.Layer.Name.TEXTS, poLivesManager.GetCount().ToString(), Glyph.Name.CONSOLAS_36_PT, Screen.LIFE_NUM_X, Screen.LIFE_NUM_Y);

            //Add score labels
            pFontSpriteManager.Add(FontSprite.Name.GAME_OVER_LABEL, Layer.Layer.Name.TEXTS, "SCORE<1>", Glyph.Name.CONSOLAS_36_PT, Screen.P1_LABEL_X, Screen.SCORE_LABEL_Y);
            pFontSpriteManager.Add(FontSprite.Name.P2_SCORE_LABEL, Layer.Layer.Name.TEXTS, "SCORE<2>", Glyph.Name.CONSOLAS_36_PT, Screen.P2_LABEL_X, Screen.SCORE_LABEL_Y);
            pFontSpriteManager.Add(FontSprite.Name.HIGH_SCORE_LABEL, Layer.Layer.Name.TEXTS, "HI-SCORE", Glyph.Name.CONSOLAS_36_PT, Screen.HI_LABEL_X, Screen.SCORE_LABEL_Y);

            //---------------------------------------------------------------------------------------------------------
            // Score
            //---------------------------------------------------------------------------------------------------------

            ScoreKeeper.GetInstance().ActivateScores(Layer.Layer.Name.TEXTS);

            //---------------------------------------------------------------------------------------------------------
            // Add timer events
            //---------------------------------------------------------------------------------------------------------
            poTimerManager.Add(TimerEvent.Name.SQUID, squidCommand, ALIEN_MOVE_UPDATE);
            poTimerManager.Add(TimerEvent.Name.CRAB, crabCommand, ALIEN_MOVE_UPDATE);
            poTimerManager.Add(TimerEvent.Name.OCTO, octoCommand, ALIEN_MOVE_UPDATE);
            poTimerManager.Add(TimerEvent.Name.MOVE_ALIENS, moveCommand, ALIEN_MOVE_UPDATE);
            poTimerManager.Add(TimerEvent.Name.DROP_BOMB, bombDropCommand, BOMB_DROP_UPDATE);
            poTimerManager.Add(TimerEvent.Name.MOVE_UFO, ufoMoveCommand, UFO_MOVE_UPDATE);
            poTimerManager.Add(TimerEvent.Name.SQUIGLY, squiglyCommand, BOMB_ANIMATION_UPDATE);
            poTimerManager.Add(TimerEvent.Name.PLUNGER, plungerCommand, BOMB_ANIMATION_UPDATE);
            poTimerManager.Add(TimerEvent.Name.ROLLING, rollingCommand, BOMB_ANIMATION_UPDATE);
            poTimerManager.Add(TimerEvent.Name.MOVE_BOMBS, bombMoveCommand, BOMB_MOVE_UPDATE);
            poTimerManager.Add(TimerEvent.Name.MOVE_MISSILE, missileMoveCommand, BOMB_MOVE_UPDATE);

            //Also add the ufo event.  Looking now, seems odd that this is all alone.
            UfoManager.GetInstance().PrepUfo();

            //Pause the timer manager until further notice
            TimerManager.GetInstance().Pause();
        }

        public override void Update(float systemTime)
        {
            SoundManager.GetInstance().Update();
            poTimerManager.Update(systemTime);
            poGameTreeManager.Update();
            poColPairManager.Process();
            DelayRemoveManager.GetInstance().Process();
            InputManager.GetInstance().Update();

            
        }

        public override void Draw()
        {
            //This might be shared by all scenes 
            // draw all objects
            LayerManager.GetInstance().Draw();
        }

        public override void TransitionTo()
        {
            // Set the scene with the correct managers
            LayerManager.SetActive(this.poLayerManager);
            GameTreeManager.SetActive(this.poGameTreeManager);
            ColPairManager.SetActive(this.poColPairManager);
            LivesManager.SetActive(this.poLivesManager);
            TimerManager.SetActive(this.poTimerManager);
            SoundManager.SetActive(this.poSoundManager);

            //Sound manager has to transition
            this.poSoundManager.SetVol(0.2f);

            //Reset for a few observers
            this.wallBottomObserver.triggered = false;
            AlienGrid pGrid = (AlienGrid)poGameTreeManager.Find(GameObject.Name.ALIEN_GRID).pObject;
            pGrid.notified = false;

        }

        public override void TransitionFrom()
        {
            //Pause the timer before leaving
            TimerManager.GetInstance().Pause();

            //Sound manager has to transition
            this.poSoundManager.SetVol(0.0f);
        }

    }
}
