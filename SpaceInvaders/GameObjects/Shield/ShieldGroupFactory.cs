using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Shield
{
    public class ShieldGroupFactory
    {
        static ShieldGroupFactory instance = new ShieldGroupFactory(Layer.Layer.Name.SHIELD, Sizes.SHIELD_BRICK_SCREEN);

        //Name of layer this factory adds to
        Layer.Layer.Name layerName;

        ShieldGridFactory shieldGridFactory;

        float brickWidth;

        protected static GameObjectNodeManager pManager = new GameObjectNodeManager(2, 3);

        private readonly int numShields;

        private float shieldWidth;

        private float xOffset;

        public static ShieldGroupFactory GetInstance()
        {
            return ShieldGroupFactory.instance;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="layerName">Name of layer this factory will add to</param>
        private ShieldGroupFactory(Layer.Layer.Name name, Screen2D brickSize)
        {
            this.layerName = name;
            this.brickWidth = brickSize.scaledScreenX;
            ShieldBrickFactory shieldBrickFactory = new ShieldBrickFactory(this.layerName);
            ShieldColumnFactory shieldColumnFactory = new ShieldColumnFactory(shieldBrickFactory, brickSize.scaledScreenY);
            this.shieldGridFactory = new ShieldGridFactory(shieldColumnFactory, brickSize.scaledScreenX);
            this.numShields = 4;

            //I am only making the number of columns configurable for debug purposes so we will assume it is an even number
            shieldWidth = ShieldGridFactory.numCol * brickSize.scaledScreenX;
            this.xOffset = (shieldWidth + Screen.SHIELD_SPACE_X) * ((numShields/2 - .5f));

        }

        public Composite.Composite Populate(ShieldGroup pGroup, float midX, float midY)
        {
            //Start the x value at the first column's middle
            float x = midX - xOffset;
            for (int i = 0; i < numShields; i++)
            {
                pGroup.Add(shieldGridFactory.Create(GameObject.Name.SHIELD_GRID, x + (i * (this.shieldWidth + Screen.SHIELD_SPACE_X)), midY));
            }


            return pGroup;

        }
    }
}
