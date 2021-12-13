using SpaceInvaders.Font;
using SpaceInvaders.Images;
using SpaceInvaders.Scenes;
using SpaceInvaders.Sprite;
using SpaceInvaders.Timer;
using SpaceInvaders.Util;

namespace SpaceInvaders
{
    class SpaceInvaders : Azul.Game
    {
        //Managers
        TextureManager textureManager;
        ImageManager imageManager;
        GameSpriteManager spriteManager;
        GlyphManager glyphManager;

        //Context
        public static SceneContext pSceneContext = null;



        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("SPACE INVADERS");
            this.SetWidthHeight((int)(Screen.WIDTH), (int)(Screen.HEIGHT));
            this.SetClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            //Initilize the time
            TimerManager.mCurrTime = this.GetTime();
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {

            this.textureManager = TextureManager.GetInstance();
            this.imageManager = ImageManager.GetInstance();
            this.spriteManager = GameSpriteManager.GetInstance();
            this.glyphManager = GlyphManager.GetInstance();

            //---------------------------------------------------------------------------------------------------------
            // Load the Textures
            //---------------------------------------------------------------------------------------------------------

            //Add all the textures to the manager
            textureManager.Add(TextureNode.Name.SPACE_INVADERS, "SpaceInvaders.tga");
            textureManager.Add(TextureNode.Name.CONSOLAS_36_PT, "Consolas36pt.tga");

            //---------------------------------------------------------------------------------------------------------
            // Prepare the glyphs
            //---------------------------------------------------------------------------------------------------------
            glyphManager.AddXml(Glyph.Name.CONSOLAS_36_PT, "Consolas36pt.xml", TextureNode.Name.CONSOLAS_36_PT);

            //---------------------------------------------------------------------------------------------------------
            // Create Images
            //---------------------------------------------------------------------------------------------------------

            //Aliens
            imageManager.Add(ImageNode.Name.SQUID_OPEN, TextureNode.Name.SPACE_INVADERS, Sizes.SQUID_OPEN_TS);
            imageManager.Add(ImageNode.Name.SQUID_CLOSED, TextureNode.Name.SPACE_INVADERS, Sizes.SQUID_CLOSED_TS);
            imageManager.Add(ImageNode.Name.CRAB_OPEN, TextureNode.Name.SPACE_INVADERS, Sizes.CRAB_OPEN_TS);
            imageManager.Add(ImageNode.Name.CRAB_CLOSED, TextureNode.Name.SPACE_INVADERS, Sizes.CRAB_CLOSED_TS);
            imageManager.Add(ImageNode.Name.OCTO_OPEN, TextureNode.Name.SPACE_INVADERS, Sizes.OCTO_OPEN_TS);
            imageManager.Add(ImageNode.Name.OCTO_CLOSED, TextureNode.Name.SPACE_INVADERS, Sizes.OCTO_CLOSED_TS);

            //Bombs
            imageManager.Add(ImageNode.Name.SQUIGLY_0, TextureNode.Name.SPACE_INVADERS, 18f, 26f, 3.0f, 7.0f);
            imageManager.Add(ImageNode.Name.SQUIGLY_1, TextureNode.Name.SPACE_INVADERS, 24f, 26f, 3.0f, 7.0f);
            imageManager.Add(ImageNode.Name.SQUIGLY_2, TextureNode.Name.SPACE_INVADERS, 30f, 26f, 3.0f, 7.0f);
            imageManager.Add(ImageNode.Name.SQUIGLY_3, TextureNode.Name.SPACE_INVADERS, 35f, 26f, 3.0f, 7.0f);
            imageManager.Add(ImageNode.Name.PLUNGER_0, TextureNode.Name.SPACE_INVADERS, 42f, 27f, 3.0f, 6.0f);
            imageManager.Add(ImageNode.Name.PLUNGER_1, TextureNode.Name.SPACE_INVADERS, 48f, 27f, 3.0f, 6.0f);
            imageManager.Add(ImageNode.Name.PLUNGER_2, TextureNode.Name.SPACE_INVADERS, 54f, 27f, 3.0f, 6.0f);
            imageManager.Add(ImageNode.Name.PLUNGER_3, TextureNode.Name.SPACE_INVADERS, 60f, 27f, 3.0f, 6.0f);
            imageManager.Add(ImageNode.Name.ROLLING_0, TextureNode.Name.SPACE_INVADERS, 65f, 26f, 3.0f, 7.0f);
            imageManager.Add(ImageNode.Name.ROLLING_1, TextureNode.Name.SPACE_INVADERS, 70f, 26f, 3.0f, 7.0f);
            imageManager.Add(ImageNode.Name.ROLLING_2, TextureNode.Name.SPACE_INVADERS, 65f, 26f, 3.0f, 7.0f);
            imageManager.Add(ImageNode.Name.ROLLING_3, TextureNode.Name.SPACE_INVADERS, 80f, 26f, 3.0f, 7.0f);


            imageManager.Add(ImageNode.Name.MISSILE, TextureNode.Name.SPACE_INVADERS, 65.0f, 26.0f, 3.0f, 7.0f);

            imageManager.Add(ImageNode.Name.SHIP, TextureNode.Name.SPACE_INVADERS, Sizes.SHIP_TS);

            imageManager.Add(ImageNode.Name.SHIP_BOOM_0, TextureNode.Name.SPACE_INVADERS, Sizes.SHIP_BOOM_0_TS);
            imageManager.Add(ImageNode.Name.SHIP_BOOM_1, TextureNode.Name.SPACE_INVADERS, Sizes.SHIP_BOOM_1_TS);

            imageManager.Add(ImageNode.Name.UFO, TextureNode.Name.SPACE_INVADERS, Sizes.UFO_TS);

            imageManager.Add(ImageNode.Name.UFO_BOOM, TextureNode.Name.SPACE_INVADERS, Sizes.UFO_BOOM_TS);

            imageManager.Add(ImageNode.Name.ALIEN_BOOM, TextureNode.Name.SPACE_INVADERS, 84.0f, 3.0f, 13.0f, 8.0f);
            imageManager.Add(ImageNode.Name.MISSILE_BOOM, TextureNode.Name.SPACE_INVADERS, 7.0f, 25.0f, 8.0f, 8.0f);
            imageManager.Add(ImageNode.Name.BOMB_BOOM, TextureNode.Name.SPACE_INVADERS, 86.0f, 25.0f, 6.0f, 8.0f);

            //Values to make sheild easier
            float shieldX = Sizes.SHIELD_BRICK_TS.textureX;
            float shieldY = Sizes.SHIELD_BRICK_TS.textureY;
            float shieldIncX = Sizes.SHIELD_BRICK_TS.textureWidth;
            float shieldIncY = Sizes.SHIELD_BRICK_TS.textureHeight;

            //Guide to sheild bricks.  Really lame way of doing this.
            //NA              |BRICK_TOP_LEFT_1 |BRICK              |BRICK              |BRICK       |BRICK       |BRICK       |BRICK               |BRICK               |BRICK_TOP_RIGHT_1|NA
            //BRICK_TOP_LEFT_0|BRICK            |BRICK              |BRICK              |BRICK       |BRICK       |BRICK       |BRICK               |BRICK               |BRICK            |BRICK_TOP_RIGHT_0
            //BRICK           |BRICK            |BRICK              |BRICK              |BRICK       |BRICK       |BRICK       |BRICK               |BRICK               |BRICK            |BRICK
            //BRICK           |BRICK            |BRICK              |BRICK              |BRICK       |BRICK       |BRICK       |BRICK               |BRICK               |BRICK            |BRICK
            //BRICK           |BRICK            |BRICK              |BRICK_BOTTOM_LEFT_1|BRICK_BOTTOM|BRICK_BOTTOM|BRICK_BOTTOM|BRICK_BOTTOM_RIGHT_1|BRICK               |BRICK            |BRICK
            //BRICK           |BRICK            |BRICK_BOTTOM_LEFT_0|NA                 |NA          |NA          |NA          |BRICK_BOTTOM_RIGHT_0|BRICK               |BRICK            |BRICK
            imageManager.Add(ImageNode.Name.BRICK_TOP_LEFT_0, TextureNode.Name.SPACE_INVADERS, shieldX + (shieldIncX * 0), shieldY + (shieldIncY * 1), shieldIncX, shieldIncY);
            imageManager.Add(ImageNode.Name.BRICK_TOP_LEFT_1, TextureNode.Name.SPACE_INVADERS, shieldX + (shieldIncX * 1), shieldY + (shieldIncY * 0), shieldIncX, shieldIncY);

            imageManager.Add(ImageNode.Name.BRICK_BOTTOM_LEFT_0, TextureNode.Name.SPACE_INVADERS, shieldX + (shieldIncX * 2), shieldY + (shieldIncY * 5), shieldIncX, shieldIncY);
            imageManager.Add(ImageNode.Name.BRICK_BOTTOM_LEFT_1, TextureNode.Name.SPACE_INVADERS, shieldX + (shieldIncX * 3), shieldY + (shieldIncY * 4), shieldIncX, shieldIncY);

            imageManager.Add(ImageNode.Name.BRICK_TOP_RIGHT_0, TextureNode.Name.SPACE_INVADERS, shieldX + (shieldIncX * 10), shieldY + (shieldIncY * 1), shieldIncX, shieldIncY);
            imageManager.Add(ImageNode.Name.BRICK_TOP_RIGHT_1, TextureNode.Name.SPACE_INVADERS, shieldX + (shieldIncX * 9), shieldY + (shieldIncY * 0), shieldIncX, shieldIncY);

            imageManager.Add(ImageNode.Name.BRICK_BOTTOM_RIGHT_0, TextureNode.Name.SPACE_INVADERS, shieldX + (shieldIncX * 7), shieldY + (shieldIncY * 5), shieldIncX, shieldIncY);
            imageManager.Add(ImageNode.Name.BRICK_BOTTOM_RIGHT_1, TextureNode.Name.SPACE_INVADERS, shieldX + (shieldIncX * 7), shieldY + (shieldIncY * 4), shieldIncX, shieldIncY);

            imageManager.Add(ImageNode.Name.BRICK_BOTTOM, TextureNode.Name.SPACE_INVADERS, shieldX + (shieldIncX * 4), shieldY + (shieldIncY * 4), shieldIncX, shieldIncY);

            imageManager.Add(ImageNode.Name.BRICK, TextureNode.Name.SPACE_INVADERS, shieldX + (shieldIncX * 1), shieldY + (shieldIncY * 1), shieldIncX, shieldIncY);


            //---------------------------------------------------------------------------------------------------------
            // Create Sprites 
            //---------------------------------------------------------------------------------------------------------
            spriteManager.Add(GameSpriteNode.Name.SQUID, ImageNode.Name.SQUID_OPEN, Sizes.SQUID_SCREEN);
            spriteManager.Add(GameSpriteNode.Name.CRAB, ImageNode.Name.CRAB_OPEN, Sizes.CRAB_SCREEN);
            spriteManager.Add(GameSpriteNode.Name.OCTOPUS, ImageNode.Name.OCTO_OPEN, Sizes.OCTO_SCREEN);

            spriteManager.Add(GameSpriteNode.Name.MISSILE, ImageNode.Name.MISSILE, 0, 0, 6 * Screen.SCALE, 21 * Screen.SCALE);
            spriteManager.Add(GameSpriteNode.Name.SQUIGLY, ImageNode.Name.SQUIGLY_0, 300, 466, 9 * Screen.SCALE, 21 * Screen.SCALE);
            spriteManager.Add(GameSpriteNode.Name.PLUNGER, ImageNode.Name.PLUNGER_0, 300, 466, 9 * Screen.SCALE, 18 * Screen.SCALE);
            spriteManager.Add(GameSpriteNode.Name.ROLLING, ImageNode.Name.ROLLING_0, 300, 466, 9 * Screen.SCALE, 21 * Screen.SCALE);

            spriteManager.Add(GameSpriteNode.Name.SHIP, ImageNode.Name.SHIP, Sizes.SHIP_SCREEN);

            spriteManager.Add(GameSpriteNode.Name.SHIP_BOOM, ImageNode.Name.SHIP, Sizes.SHIP_BOOM_1_SCREEN);

            spriteManager.Add(GameSpriteNode.Name.UFO, ImageNode.Name.UFO, Sizes.UFO_SCREEN);

            spriteManager.Add(GameSpriteNode.Name.UFO_BOOM, ImageNode.Name.UFO_BOOM, Sizes.UFO_BOOM_SCREEN);

            spriteManager.Add(GameSpriteNode.Name.ALIEN_BOOM, ImageNode.Name.ALIEN_BOOM, 0, 0, 49 * Screen.SCALE, 33 * Screen.SCALE);
            spriteManager.Add(GameSpriteNode.Name.MISSILE_BOOM, ImageNode.Name.MISSILE_BOOM, 0, 0, 33 * Screen.SCALE, 33 * Screen.SCALE);
            spriteManager.Add(GameSpriteNode.Name.BOMB_BOOM, ImageNode.Name.BOMB_BOOM, 0, 0, 24 * Screen.SCALE, 33 * Screen.SCALE);

            //TODO maybe this could be a for loop
            spriteManager.Add(GameSpriteNode.Name.BRICK_TOP_LEFT_0, ImageNode.Name.BRICK_TOP_LEFT_0, Sizes.SHIELD_BRICK_SCREEN);
            spriteManager.Add(GameSpriteNode.Name.BRICK_TOP_LEFT_1, ImageNode.Name.BRICK_TOP_LEFT_1, Sizes.SHIELD_BRICK_SCREEN);
            spriteManager.Add(GameSpriteNode.Name.BRICK_BOTTOM_LEFT_0, ImageNode.Name.BRICK_BOTTOM_LEFT_0, Sizes.SHIELD_BRICK_SCREEN);
            spriteManager.Add(GameSpriteNode.Name.BRICK_BOTTOM_LEFT_1, ImageNode.Name.BRICK_BOTTOM_LEFT_1, Sizes.SHIELD_BRICK_SCREEN);
            spriteManager.Add(GameSpriteNode.Name.BRICK_TOP_RIGHT_0, ImageNode.Name.BRICK_TOP_RIGHT_0, Sizes.SHIELD_BRICK_SCREEN);
            spriteManager.Add(GameSpriteNode.Name.BRICK_TOP_RIGHT_1, ImageNode.Name.BRICK_TOP_RIGHT_1, Sizes.SHIELD_BRICK_SCREEN);
            spriteManager.Add(GameSpriteNode.Name.BRICK_BOTTOM_RIGHT_0, ImageNode.Name.BRICK_BOTTOM_RIGHT_0, Sizes.SHIELD_BRICK_SCREEN);
            spriteManager.Add(GameSpriteNode.Name.BRICK_BOTTOM_RIGHT_1, ImageNode.Name.BRICK_BOTTOM_RIGHT_1, Sizes.SHIELD_BRICK_SCREEN);
            spriteManager.Add(GameSpriteNode.Name.BRICK_BOTTOM, ImageNode.Name.BRICK_BOTTOM, Sizes.SHIELD_BRICK_SCREEN);
            spriteManager.Add(GameSpriteNode.Name.BRICK, ImageNode.Name.BRICK, Sizes.SHIELD_BRICK_SCREEN);

            pSceneContext = new SceneContext();

            pSceneContext.SetState(SceneContext.Scene.Select);
        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        { 
            pSceneContext.GetState().Update(this.GetTime());
        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            // Draw the scene
            pSceneContext.GetState().Draw();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload content (resources loaded above
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {
            TextureManager.Destroy();
            textureManager = null;
            ImageManager.Destroy();
            imageManager = null;
            GameSpriteManager.Destroy();
            spriteManager = null;

        }

    }
}

