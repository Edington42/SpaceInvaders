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
    public class ShieldColumnFactory
    {
        //Name of layer this factory adds to
        Layer.Layer.Name layerName;

        ShieldBrickFactory brickFactory;

        float brickHeight;

        protected static GameObjectNodeManager pManager = new GameObjectNodeManager(2, 3);

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="layerName">Name of layer this factory will add to</param>
        public ShieldColumnFactory(ShieldBrickFactory pShieldBrickFactory, float brickHeight)
        {
            this.layerName = pShieldBrickFactory.GetLayerName();
            this.brickFactory = pShieldBrickFactory;
            this.brickHeight = brickHeight;
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
            float y = midY + (this.brickHeight * 2.5f);

            ShieldColumn pObject = (ShieldColumn)this.Add(name);

            switch (name)
            {
                case GameObject.Name.COLUMN_TOP_LEFT_0:
                    pObject.Add(brickFactory.Create(ShieldBrick.Name.BRICK_TOP_LEFT_0, x, y - this.brickHeight));
                    AddBricks(pObject, x, y - (this.brickHeight * 2), 4);
                    break;
                case GameObject.Name.COLUMN_TOP_LEFT_1:
                    pObject.Add(brickFactory.Create(ShieldBrick.Name.BRICK_TOP_LEFT_1, x, y));
                    AddBricks(pObject, x, y - (this.brickHeight), 5);
                    break;
                case GameObject.Name.COLUMN_TOP_RIGHT_0:
                    pObject.Add(brickFactory.Create(ShieldBrick.Name.BRICK_TOP_RIGHT_0, x, y - this.brickHeight));
                    AddBricks(pObject, x, y - (this.brickHeight * 2), 4);
                    break;
                case GameObject.Name.COLUMN_TOP_RIGHT_1:
                    pObject.Add(brickFactory.Create(ShieldBrick.Name.BRICK_TOP_RIGHT_1, x, y));
                    AddBricks(pObject, x, y - (this.brickHeight), 5);
                    break;
                case GameObject.Name.COLUMN_BOTTOM_LEFT_0:
                    AddBricks(pObject, x, y , 5);
                    pObject.Add(brickFactory.Create(ShieldBrick.Name.BRICK_BOTTOM_LEFT_0, x, y - (this.brickHeight*5)));
                    break;
                case GameObject.Name.COLUMN_BOTTOM_LEFT_1:
                    AddBricks(pObject, x, y, 4);
                    pObject.Add(brickFactory.Create(ShieldBrick.Name.BRICK_BOTTOM_LEFT_1, x, y - (this.brickHeight * 4)));
                    break;
                case GameObject.Name.COLUMN_BOTTOM_RIGHT:
                    AddBricks(pObject, x, y, 4);
                    pObject.Add(brickFactory.Create(ShieldBrick.Name.BRICK_BOTTOM_RIGHT_1, x, y - (this.brickHeight * 4)));
                    pObject.Add(brickFactory.Create(ShieldBrick.Name.BRICK_BOTTOM_RIGHT_0, x, y - (this.brickHeight * 5)));
                    break;
                case GameObject.Name.COLUMN_BOTTOM:
                    AddBricks(pObject, x, y, 4);
                    pObject.Add(brickFactory.Create(ShieldBrick.Name.BRICK_BOTTOM, x, y - (this.brickHeight * 4)));
                    break;
                case GameObject.Name.COLUMN_BRICK:
                    AddBricks(pObject, x, y, 6);
                    break;
                default:
                    pObject = null;
                    //Not good
                    Debug.Assert(false);
                    break;
            }

            //Attach the object to the layer
            pObject.AttachColObj(Layer.Layer.Name.BOXES);

            return pObject;
        }

        private void AddBricks(ShieldColumn column, float x, float firstY, int num)
        {
            for(int i = 0; i < num; i++)
            {
                column.Add(brickFactory.Create(GameObject.Name.BRICK, x, firstY - (i * this.brickHeight)));
            }
        }

        private GameObject Add(GameObject.Name name)
        {
            GameObjectNode pNode = pManager.Pull();
            GameObject pObj = pNode.pObject;
            if (pObj == null)
            {
                pNode.Set(new ShieldColumn(name));
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
