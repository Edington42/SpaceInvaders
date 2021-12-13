using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Shield
{
    public class ShieldGridFactory
    {
        //Name of layer this factory adds to
        Layer.Layer.Name layerName;

        ShieldColumnFactory shieldColumnFactory;

        float brickWidth;

        protected static GameObjectNodeManager pManager = new GameObjectNodeManager(2, 3);

        public static readonly int numCol = 11;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="layerName">Name of layer this factory will add to</param>
        public ShieldGridFactory(ShieldColumnFactory pShieldColumnFactory, float screenWidth)
        {

            this.layerName = pShieldColumnFactory.GetLayerName();
            this.brickWidth = screenWidth;
            this.shieldColumnFactory = pShieldColumnFactory;
            
        }

        public Composite.Composite Create(GameObject.Name name, float midX, float midY)
        {
            ShieldGrid pGrid = (ShieldGrid)this.Add(name);
            //Start the x value at the first column's middle
            float x = midX - (this.brickWidth * 5);
            pGrid.Add(shieldColumnFactory.Create(GameObject.Name.COLUMN_TOP_LEFT_0, x + (this.brickWidth * 0), midY));
            pGrid.Add(shieldColumnFactory.Create(GameObject.Name.COLUMN_TOP_LEFT_1, x + (this.brickWidth * 1), midY));
            pGrid.Add(shieldColumnFactory.Create(GameObject.Name.COLUMN_BOTTOM_LEFT_0, x + (this.brickWidth * 2), midY));
            pGrid.Add(shieldColumnFactory.Create(GameObject.Name.COLUMN_BOTTOM_LEFT_1, x + (this.brickWidth * 3), midY));
            pGrid.Add(shieldColumnFactory.Create(GameObject.Name.COLUMN_BOTTOM, x + (this.brickWidth * 4), midY));
            pGrid.Add(shieldColumnFactory.Create(GameObject.Name.COLUMN_BOTTOM, x + (this.brickWidth * 5), midY));
            pGrid.Add(shieldColumnFactory.Create(GameObject.Name.COLUMN_BOTTOM, x + (this.brickWidth * 6), midY));
            pGrid.Add(shieldColumnFactory.Create(GameObject.Name.COLUMN_BOTTOM_RIGHT, x + (this.brickWidth * 7), midY));
            pGrid.Add(shieldColumnFactory.Create(GameObject.Name.COLUMN_BRICK, x + (this.brickWidth * 8), midY));
            pGrid.Add(shieldColumnFactory.Create(GameObject.Name.COLUMN_TOP_RIGHT_1, x+ (this.brickWidth * 9), midY));
            pGrid.Add(shieldColumnFactory.Create(GameObject.Name.COLUMN_TOP_RIGHT_0, x + (this.brickWidth * 10), midY));

            pGrid.AttachColObj(Layer.Layer.Name.BOXES);

            return pGrid;

        }

        private GameObject Add(GameObject.Name name)
        {
            GameObjectNode pNode = pManager.Pull();
            GameObject pObj = pNode.pObject;
            if (pObj == null)
            {
                pNode.Set(new ShieldGrid(name));
                pObj = pNode.pObject;
            }
            pObj.name = name;
            return pObj;
        }
    }
}

