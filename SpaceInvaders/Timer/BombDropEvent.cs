using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.Bomb;
using SpaceInvaders.Manager;
using SpaceInvaders.Score;
using SpaceInvaders.Sprite;
using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    class BombDropEvent : Command
    {
        protected AlienGrid pObj;
        Random random;
        protected BombFactory pBombFactory;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pObj">Component collection that will be moved.</param>
        public BombDropEvent(AlienGrid pObj)
        {
            this.pObj = pObj;
            this.random = new Random();
            pBombFactory = new BombFactory(Layer.Layer.Name.BOMBS);
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Execute(float deltaTime)
        {
            

            //Get the number of columns that can drop bombs
            int numColumns = this.pObj.numChildren;

            //Make sure that there is at least one.  Probably should have a more graceful handling of not having any more alines that would cause this timer to stop
            if (numColumns > 0)
            {
                //Get a random column to drop the bomb from.
                int col = this.random.Next(this.pObj.numChildren);

                //Get the first column
                AlienColumn alienColumn = (AlienColumn)this.pObj.GetFirstChild();

                //Get the column that was selected
                for (int i = 1; i < col; i++)
                {
                    alienColumn = (AlienColumn)alienColumn.GetSibling();
                }

                //Now find the bottom alien in the column to drop from. Luckly that should be the first in the list
                AlienObject alien = (AlienObject)alienColumn.GetFirstChild();

                //Get the bomb
                Bomb pBomb = (Bomb)pBombFactory.Create(alienColumn.x, alien.y - Screen.BOMB_START_Y_OFFSET);

                // Attach to the root
                GameObject pBombGroup = GameTreeManager.GetInstance().Find(GameObject.Name.BOMB_GROUP).pObject;

                pBombGroup.Add(pBomb);
            }
        }
    }
}
