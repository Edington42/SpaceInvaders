using SpaceInvaders.Observer;
using SpaceInvaders.Sounds;
using SpaceInvaders.Sprite;
using SpaceInvaders.Timer;
using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.UFO
{
    class UfoManager
    {
        private static UfoManager instance = new UfoManager();
        private Random r;
        private Ufo ufo;
        private static readonly float UFO_RIGHT_DELTA = 10 * Screen.SCALE;
        private static readonly float UFO_LEFT_DELTA = -UFO_RIGHT_DELTA;
        private float delta = UFO_RIGHT_DELTA;
        public bool flying = false;

        private UfoManager()
        {
           this.r = new Random();
           this.ufo = new Ufo();
        }

        public static UfoManager GetInstance()
        {
            return instance;
        }

        public void LunchUfo()
        {
            //TODO starting to smell like a state patern
            if (!flying)
            {
                flying = true;

                SoundManager.GetInstance().Find(Sound.Name.UFO).PlayLoop();

                ufo.Set(GameObject.Name.UFO, GameSpriteNode.Name.UFO, this.GetUfoStart(), Screen.UFO_Y, this.GetUfoPoints());

                ufo.AttachGameSprite(Layer.Layer.Name.UFO);
                ufo.AttachColObj(Layer.Layer.Name.BOXES);

                GameObject pUfoGroup = GameTreeManager.GetInstance().Find(GameObject.Name.UFO_GROUP).pObject;
                pUfoGroup.Add(ufo);
                
            }
        }

        public float GetUfoStart()
        {
            //Coin flip
            if(r.Next(0, 2) == 0)
            {
                delta = UFO_RIGHT_DELTA;
                return Screen.UFO_X_0;
            } else
            {
                delta = UFO_LEFT_DELTA;
                return Screen.UFO_X_1;
            }
        }

        public int GetUfoPoints()
        {
            int point = r.Next(1, 4);
            return point * 50;   
        }

        public float GetDelta()
        {
            return delta;
        }

        public void PrepUfo()
        {
            flying = false;
            int delta = r.Next(10, 20);
            TimerManager.GetInstance().Add(TimerEvent.Name.UFO_LAUNCH, new UfoLaunchEvent(), delta);
        }

    }
}
