using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Aliens
{
    public class AlienColumnFactory
    {
        //Name of layer this factory adds to
        Layer.Layer.Name layerName;

        AlienFactory alienFactory;

        float screenHeight;

        protected static GameObjectNodeManager pManager = new GameObjectNodeManager(2, 3);

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="layerName">Name of layer this factory will add to</param>
        public AlienColumnFactory(AlienFactory pFactory, float screenHeight)
        {
            this.layerName = pFactory.GetLayerName();
            this.alienFactory = pFactory;
            this.screenHeight = screenHeight;
        }

        /// <summary>
        /// Creats a shield brick column given the arguments
        /// </summary>
        /// <param name="name">Sprite name of the object to be created</param>
        /// <param name="x">X position of the first object</param>
        /// <param name="y">Y Position of the first object</param>
        /// <returns></returns>
        public Composite.Composite Create(GameObject.Name name, float x, float midY)
        {
            //Get the middle of the y axis on the first element of the column
            float y = midY + (this.screenHeight * 2.5f);

            AlienColumn pObject = (AlienColumn)this.Add(name);

            pObject.Add(alienFactory.Create(GameObject.Name.SQUID, x, y + ((screenHeight + Screen.ALIEN_SPACE_Y) * 4)));
            pObject.Add(alienFactory.Create(GameObject.Name.CRAB, x, y + ((screenHeight + Screen.ALIEN_SPACE_Y) * 3)));
            pObject.Add(alienFactory.Create(GameObject.Name.CRAB, x, y + ((screenHeight + Screen.ALIEN_SPACE_Y) * 2)));
            pObject.Add(alienFactory.Create(GameObject.Name.OCTO, x, y + ((screenHeight + Screen.ALIEN_SPACE_Y) * 1)));
            pObject.Add(alienFactory.Create(GameObject.Name.OCTO, x, y));
            
            
            
            

            //Attach the object to the layer
            pObject.AttachColObj(Layer.Layer.Name.BOXES);

            return pObject;
        }

        private GameObject Add(GameObject.Name name)
        {
            GameObjectNode pNode = pManager.Pull();
            GameObject pObj = pNode.pObject;
            if (pObj == null)
            {
                pNode.Set(new AlienColumn(name));
                pObj = pNode.pObject;
            }
            pObj.name = name;
            return pObj;
        }


        public Layer.Layer.Name GetLayerName()
        {
            return this.layerName;
        }
    }
}
