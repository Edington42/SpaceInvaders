using SpaceInvaders.Font;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Input;
using SpaceInvaders.Layer;
using SpaceInvaders.Sounds;
using SpaceInvaders.Sprite;
using SpaceInvaders.Util;
using System.Diagnostics;

namespace SpaceInvaders.Scenes
{
    class SceneSelect : SceneState
    {
        //Managers unique to this scene
        public LayerManager poLayerManager;
        public SoundManager poSoundManager;
        

        public SceneSelect()
        {
            this.Initialize();
        }
        public override void Initialize()
        {
            //---------------------------------------------------------------------------------------------------------
            // Prep the managers
            //---------------------------------------------------------------------------------------------------------
            this.poLayerManager = new LayerManager(5, 3);
            LayerManager.SetActive(this.poLayerManager);
            this.poSoundManager = new SoundManager(1, 2);
            SoundManager.SetActive(this.poSoundManager);

            LayerManager.GetInstance().Add(Layer.Layer.Name.TEXTS, 0);

            FontSpriteManager.GetInstance().Add(FontSprite.Name.TestMessage, Layer.Layer.Name.TEXTS, ">Press <1> for 1 Player!", Glyph.Name.CONSOLAS_36_PT, Screen.SELECT_X, Screen.MIDDILE_Y);
        }
        public override void Update(float systemTime)
        {
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_1) == true)
            {
                SpaceInvaders.pSceneContext.SetState(SceneContext.Scene.Play);
            }
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
            LayerManager.SetActive(this.poLayerManager);
            SoundManager.SetActive(this.poSoundManager);
            
        }

        public override void TransitionFrom()
        {
            //Do nothing
        }
        
    }
}
