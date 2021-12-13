using SpaceInvaders.Collision;
using SpaceInvaders.Composite;
using SpaceInvaders.Layer;
using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects
{
    public abstract class GameObject : Component
    {
        public Name name;

        public float x;
        public float y;
        public ColObject poColObj;
        public bool markedForDeath;
        public GameObjectNode backPointer;


        /// <summary>
        /// Enum of image node names
        /// </summary>
        public enum Name
        {
            SQUID,

            CRAB,

            OCTO,

            ALIEN_COL,

            ALIEN_GRID,

            DEFAULT,


            UNINITIALIZED,
            MISSILE_GROUP,
            BOMB,
            BOMB_GROUP,
            SHIP_GROUP,
            SHIP,

            NULL_OBJECT,
            WALL_GROUP,
            WALL_TOP,
            WALL_LEFT,
            WALL_BOTTOM,
            SHIELD_COLUMN,
            SHIELD_GRID,
            BRICK,
            BRICK_TOP_LEFT_0,
            BRICK_TOP_LEFT_1,
            BRICK_BOTTOM_LEFT_0,
            BRICK_BOTTOM_LEFT_1,
            BRICK_TOP_RIGHT_0,
            BRICK_TOP_RIGHT_1,
            BRICK_BOTTOM_RIGHT_0,
            BRICK_BOTTOM_RIGHT_1,
            BRICK_BOTTOM,

            COLUMN_BRICK,
            COLUMN_TOP_LEFT_0,
            COLUMN_TOP_LEFT_1,
            COLUMN_BOTTOM_LEFT_0,
            COLUMN_BOTTOM_LEFT_1,
            COLUMN_TOP_RIGHT_0,
            COLUMN_TOP_RIGHT_1,
            COLUMN_BOTTOM_RIGHT,
            COLUMN_BOTTOM,
            MISSILE,
            SHIELD_GROUP,
            UFO_GROUP,
            UFO
        }

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        protected GameObject(GameObject.Name gameName)
            :base()
        {
            this.name = gameName;
            this.x = 0.0f;
            this.y = 0.0f;
            markedForDeath = false;
        }

        public abstract void Update();

        public abstract void Empty();

        public ColObject GetColObject()
        {
            return this.poColObj;
        }

       public void AttachColObj(Layer.Layer.Name layerName)
        {
            LayerManager.GetInstance().AttachToLayer(layerName, this.poColObj.pColSprite);
        }

        /// <summary>
        /// Returns the root of this game object
        /// </summary>
        /// <returns>Root of this game object</returns>
        public GameObject GetRoot()
        {
            GameObject pNode = this;
            GameObject pParent = (GameObject)pNode.GetParent();
            while(pParent != null)
            {
                pNode = pParent;
                pParent = (GameObject)pNode.GetParent();
            }
            return pNode;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //----------------------------------------------------------------------------------------------------

        protected override void ToDefault()
        {
            this.name = Name.UNINITIALIZED;
            this.x = 0.0f;
            this.y = 0.0f;
            markedForDeath = false;
        }


    }
}
