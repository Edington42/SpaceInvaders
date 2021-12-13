using SpaceInvaders.Sprite;
using SpaceInvaders.SpriteContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Layer
{
    class LayerManager : Manager.PriorityManager
    {
        private static LayerManager pActiveMan = null;

        //Compare node
        private readonly Layer poNodeCompare;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reserveSize">Size of the reserve list</param>
        /// <param name="growthSize">Growth size</param>
        public  LayerManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poNodeCompare = new Layer();
        }

        /// <summary>
        /// Returns isntatnce of the manager
        /// </summary>
        /// <returns>Instatnce of the manager</returns>
        public static LayerManager GetInstance()
        {
            return LayerManager.pActiveMan;
        }

        public static void SetActive(LayerManager layerManager)
        {
            LayerManager.pActiveMan = layerManager;
        }

        /// <summary>
        /// Creates a layer and adds it to the list based on priority
        /// </summary>
        /// <param name="name">Name of layer</param>
        /// /// <param name="priority">Priority of the layer.  Higher number means the layer will appear coser to the front.</param>
        /// <returns>Newly created layer</returns>
        public Layer Add(Layer.Name name, int priority) { 

            Layer pNode = (Layer)BaseAdd(priority);

            //Initialize the data
            pNode.Set(name, priority);

            return pNode;
        }

        /// <summary>
        /// Finds an layer  by name
        /// </summary>
        /// <param name="name">Name of the layer to find</param>
        /// <returns>Layer coresponding to the name. Null if no such alyer was found</returns>
        public Layer Find(Layer.Name name)
        {
            this.poNodeCompare.name = name;

            Layer pNode = (Layer)BaseFind(this.poNodeCompare);
            return pNode;
        }

        /// <summary>
        /// Updates the priority of the given node
        /// </summary>
        public void UpdatePriority(Layer.Name name, int priority)
        {
            Layer pNode = this.Find(name);

            Layer newNode = (Layer)BaseAdd(priority);

            //Initialize the data
            newNode.Set(name, priority, pNode.poManager);

            this.Remove(pNode);


        }

        /// <summary>
        /// Attaches a specified sprite node to a specified layer
        /// </summary>
        /// <param name="layerName">Name of layer to attach to</param>
        /// <param name="spriteName">Name of sprite to attach</param>
        public void AttachToLayer(Layer.Name layerName, GameSpriteNode.Name spriteName)
        {
            Layer layer = this.Find(layerName);

            layer.poManager.Attach(spriteName);
        }

        /// <summary>
        /// Attaches a specified box sprite node to a specified layer
        /// </summary>
        /// <param name="layerName">Name of layer to attach to</param>
        /// <param name="spriteName">Name of sprite to attach</param>
        public void AttachToLayer(Layer.Name layerName, BoxSpriteNode.Name spriteName)
        {
            Layer layer = this.Find(layerName);

            layer.poManager.Attach(spriteName);
        }

        /// <summary>
        /// Attaches a given sprite to the layer
        /// </summary>
        /// <param name="layerName">Layer to attach to</param>
        /// <param name="pSprite">Sprite to attach</param>
        public void AttachToLayer(Layer.Name layerName, BaseSpriteNode pSprite)
        {
            Layer layer = this.Find(layerName);

            layer.poManager.Attach(pSprite);
        }

        public void Remove(Layer.Name layerName, BaseSpriteNode pSprite)
        {
            Layer layer = this.Find(layerName);

            layer.poManager.Remove(pSprite);
        }

        /// <summary>
        /// Draws all layers in the order that they exist
        /// </summary>
        public void Draw()
        {
            Layer layer = (Layer)BaseGetActive();

            while(layer != null)
            {
                if (layer.priority >= 0)
                {
                    layer.Draw();
                }
                layer = (Layer)layer.pNext;
            }
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        protected override bool CompareNodes(DLink nodeA, DLink nodeB)
        {
            Layer layerA = (Layer)nodeA;
            Layer layerB = (Layer)nodeB;

            bool match = false;

            if (layerA.name == layerB.name) match = true;

            return match;
        }

        protected override DLink GetBlank()
        {
            return new Layer();
        }

        protected override void Wash(DLink pNode)
        {
            Layer pLayerNode = (Layer)pNode;
            pLayerNode.Wash();
        }
    }
}

