using SpaceInvaders.Collision;
using SpaceInvaders.Composite;
using SpaceInvaders.Composites;
using SpaceInvaders.Observer;
using SpaceInvaders.Sprite;
using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects
{
    public class AlienGrid : Composite.Composite
    {
        private static readonly float DELTA_RIGHT = 20.0f * Screen.SCALE;
        private static readonly float DELTA_LEFT = -DELTA_RIGHT;
        private static readonly float DELTA_ADVANCE = Sizes.CRAB_SCREEN.scaledScreenY;

        public float delta = DELTA_RIGHT;
        public Subject pSubject;
        public bool notified;

        private int level = 0;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of the object to be created</param>
        public AlienGrid(Name name): base(name)
        {
            pSubject = new Subject();
            notified = false;
        }

        //TODO these are starting to look like a state pattern 

        public void TurnRight()
        {
            if(this.delta != DELTA_RIGHT)
            {
                this.delta = DELTA_RIGHT;
                this.Advance();
                
            }
        }

        public void TurnLeft()
        {
            if(this.delta != DELTA_LEFT)
            {
                this.delta = DELTA_LEFT;
                this.Advance();
                
                
            }
        }

        private void Advance()
        {
            Iterator iterator = new ForwardIterator(this);

            while (!iterator.IsDone())
            {
                GameObject node = (GameObject)iterator.Next();
                node.y -= DELTA_ADVANCE;
            }
            this.March();
        }

        public void March()
        {
            Iterator iterator = new ForwardIterator(this);

            while (!iterator.IsDone())
            {
                GameObject node = (GameObject)iterator.Next();
                node.x += delta;
            }
        }

        public override void Update()
        {
            base.Update();
            if (this.numChildren == 0 && !notified)
            {
                pSubject.Notify();
                notified = true;
            }
        }

        public float GetStartPos()
        {
            float startPos = Screen.ALIEN_START_Y;

            startPos -= Screen.ALIEN_LEVEL_DELTA_Y * this.level;

            //Lazy catch because it is unlikely but make sure the aliens don't start on the sheild
            if(startPos < Screen.ALIEN_LEVEL_BOTTOM_Y)
            {
                startPos = Screen.ALIEN_LEVEL_BOTTOM_Y;
            }

            this.level++;

            return startPos;
        }

        public void ResetLevel()
        {
            this.level = 0;
        }



        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Accept(ColVisitor other)
        {
            other.VisitGrid(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);
            GameObject pGameObject = (GameObject)this.GetFirstChild();
            ColPair.Collide(m, pGameObject);
        }
    }
}
