using SpaceInvaders.Util;

namespace SpaceInvaders.GameObjects.Aliens
{
    public class AlienGridFactory
    {
        private static AlienGridFactory instance = new AlienGridFactory(Layer.Layer.Name.ALIENS, Sizes.OCTO_SCREEN);

        //Name of layer this factory adds to
        Layer.Layer.Name layerName;

        AlienColumnFactory alienColumnFactory;

        float screenWidth;

        protected static GameObjectNodeManager pManager = new GameObjectNodeManager(2, 3);

        private readonly int numCol;

        private float xOffset;

        public static AlienGridFactory GetInstance()
        {
            return AlienGridFactory.instance;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="layerName">Name of layer this factory will add to</param>
        private AlienGridFactory(Layer.Layer.Name name, Screen2D screenSize)
        {
            this.layerName = name;
            this.screenWidth = screenSize.scaledScreenX;
            AlienFactory alienFactory = new AlienFactory(name);
            this.alienColumnFactory = new AlienColumnFactory(alienFactory, screenSize.scaledScreenY);
            this.numCol = 11;

            //I am only making the number of columns configurable for debug purposes so we will assume it is an odd number
            this.xOffset = (this.screenWidth + Screen.ALIEN_SPACE_X) * ((numCol / 2) - .5f);

        }

        public Composite.Composite Populate(AlienGrid pGrid, float midX, float midY)
        {
            //Start the x value at the first column's middle
            float x = midX - xOffset;
            for(int i = 0; i < numCol; i++)
            {
                pGrid.Add(alienColumnFactory.Create(GameObject.Name.ALIEN_COL, x + (i * (this.screenWidth + Screen.ALIEN_SPACE_X)), midY));
            }


            return pGrid;

        }
    }
}
