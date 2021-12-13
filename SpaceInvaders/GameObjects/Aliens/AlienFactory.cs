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
    /// <summary>
    /// Factory for creation of alien objects
    /// </summary>
    public class AlienFactory
    {
        //Name of layer this factory adds to
        Layer.Layer.Name layerName;

        static GameObjectNodeManager pCrabManager = new GameObjectNodeManager(2, 3);
        static GameObjectNodeManager pSquidManager = new GameObjectNodeManager(2, 3);
        static GameObjectNodeManager pOctoManager = new GameObjectNodeManager(2, 3);

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="layerName">Name of layer this factory will add to</param>
        public AlienFactory(Layer.Layer.Name layerName)
        {
            this.layerName = layerName;
        }
        
        /// <summary>
        /// Creats an alien node given the arguments
        /// </summary>
        /// <param name="name">Sprite name of the alien to be created</param>
        /// <param name="x">X position of the alien</param>
        /// <param name="y">Y Position of the alien</param>
        /// <returns></returns>
        public GameObject Create(GameObject.Name name, float x, float y)
        {
            Leaf pObject = null;

            switch(name){
                case GameObject.Name.SQUID:
                    //TODO don't really need to give the name if we already know it here
                    //TODO would it make more sense to just give name/type as a static NAME for each type?
                    pObject = this.Add(pSquidManager, name, GameSpriteNode.Name.SQUID, x, y);
                    break;
                case GameObject.Name.CRAB:
                    //TODO don't really need to give the name if we already know it here
                    //TODO would it make more sense to just give name/type as a static NAME for each type?
                    pObject = this.Add(pCrabManager, name, GameSpriteNode.Name.CRAB, x, y);
                    break;
                case GameObject.Name.OCTO:
                    //TODO don't really need to give the name if we already know it here
                    //TODO would it make more sense to just give name/type as a static NAME for each type?
                    pObject = this.Add(pOctoManager, name, GameSpriteNode.Name.OCTOPUS, x, y);
                    break;
                default:
                    //Not good
                    Debug.Assert(false);
                    break;
            }

            //Attach the object to the layer
            pObject.AttachColObj(Layer.Layer.Name.BOXES);
            pObject.AttachGameSprite(layerName);

            return pObject;
        }

        private Leaf Add(GameObjectNodeManager pManager,GameObject.Name name, GameSpriteNode.Name spriteName, float x, float y)
        {
            GameObjectNode pNode = pManager.Pull();
            Leaf pObj = (Leaf)pNode.pObject;
            if (pObj == null)
            {
                pNode.Set(this.CreateNew(name));
                pObj = (Leaf)pNode.pObject;
            }
            ((AlienObject)pObj).Set(name, spriteName, x, y);
            return pObj;
        }

        private Leaf CreateNew(GameObject.Name name)
        {
            Leaf pObject = null;
            switch (name)
            {
                case GameObject.Name.SQUID:
                    pObject = new SquidObject();
                    break;
                case GameObject.Name.CRAB:
                    pObject = new CrabObject();
                    break;
                case GameObject.Name.OCTO:
                    pObject = new OctoObject();
                    break;
                default:
                    //Not good
                    Debug.Assert(false);
                    break;
            }
            return pObject;
        }

        public Layer.Layer.Name GetLayerName()
        {
            return this.layerName;
        }
    }
}
