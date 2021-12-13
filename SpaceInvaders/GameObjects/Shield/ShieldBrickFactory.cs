using SpaceInvaders.Composite;
using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Shield
{
    public class ShieldBrickFactory
    {
        //Name of layer this factory adds to
        Layer.Layer.Name layerName;

        //Manager of the bricks
       static GameObjectNodeManager pShieldBrickManager = new GameObjectNodeManager(2, 3);

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="layerName">Name of layer this factory will add to</param>
        public ShieldBrickFactory(Layer.Layer.Name layerName)
        {
            this.layerName = layerName;
        }

        /// <summary>
        /// Creats a shield bricke given the arguments
        /// </summary>
        /// <param name="name">Sprite name of the object to be created</param>
        /// <param name="x">X position of the object</param>
        /// <param name="y">Y Position of the object</param>
        /// <returns></returns>
        public GameObject Create(GameObject.Name name, float x, float y)
        {
            GameObject pObject = null;

            switch (name)
            {
                case GameObject.Name.BRICK:
                    pObject = this.Add(name, GameSpriteNode.Name.BRICK, x, y);
                    break;
                case GameObject.Name.BRICK_TOP_LEFT_0:
                    pObject = this.Add(name, GameSpriteNode.Name.BRICK, x, y);
                    break;
                case GameObject.Name.BRICK_TOP_LEFT_1:
                    pObject = this.Add(name, GameSpriteNode.Name.BRICK_TOP_LEFT_1, x, y);
                    break;
                case GameObject.Name.BRICK_TOP_RIGHT_0:
                    pObject = this.Add(name, GameSpriteNode.Name.BRICK_TOP_RIGHT_0, x, y);
                    break;
                case GameObject.Name.BRICK_TOP_RIGHT_1:
                    pObject = this.Add(name, GameSpriteNode.Name.BRICK_TOP_RIGHT_1, x, y);
                    break;
                case GameObject.Name.BRICK_BOTTOM_LEFT_0:
                    pObject = this.Add(name, GameSpriteNode.Name.BRICK_BOTTOM_LEFT_0, x, y);
                    break;
                case GameObject.Name.BRICK_BOTTOM_LEFT_1:
                    pObject = this.Add(name, GameSpriteNode.Name.BRICK_BOTTOM_LEFT_1, x, y);
                    break;
                case GameObject.Name.BRICK_BOTTOM_RIGHT_0:
                    pObject = this.Add(name, GameSpriteNode.Name.BRICK_BOTTOM_RIGHT_0, x, y);
                    break;
                case GameObject.Name.BRICK_BOTTOM_RIGHT_1:
                    pObject = this.Add(name, GameSpriteNode.Name.BRICK_BOTTOM_RIGHT_1, x, y);
                    break;
                case GameObject.Name.BRICK_BOTTOM:
                    pObject = this.Add(name, GameSpriteNode.Name.BRICK_BOTTOM, x, y);
                    break;
                default:
                    //Not good
                    Debug.Assert(false);
                    break;
            }

            //Attach the object to the layer
            pObject.AttachColObj(Layer.Layer.Name.BOXES);
            ((Leaf)pObject).AttachGameSprite(layerName);

            return pObject;
        }

        private GameObject Add(GameObject.Name name, GameSpriteNode.Name spriteName, float x, float y)
        {
            GameObjectNode pNode = pShieldBrickManager.Pull();
            GameObject pObj = pNode.pObject;
            if (pObj == null)
            {
                pNode.Set(new ShieldBrick());
                pObj = pNode.pObject;
            }
            ((ShieldBrick)pObj).Set(name, spriteName, x, y);
            return pObj;
        }


        public Layer.Layer.Name GetLayerName()
        {
            return this.layerName;
        }
    }
}
