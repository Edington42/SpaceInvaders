using SpaceInvaders.Composite;
using SpaceInvaders.Manager;
using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Bomb
{
    class BombFactory
    {
        Layer.Layer.Name layerName;

        protected static GameObjectNodeManager pBombManager = new GameObjectNodeManager(2, 3);

        SCircleManager pBombNames = new SCircleManager();

        private class BombName : SLink
        {
            public GameSpriteNode.Name name;

            public BombName(GameSpriteNode.Name name)
            {
                this.name = name;
            }
        }

        public BombFactory(Layer.Layer.Name name)
        {
            this.layerName = name;
            pBombNames.Add(new BombName(GameSpriteNode.Name.SQUIGLY));
            pBombNames.Add(new BombName(GameSpriteNode.Name.PLUNGER));
            pBombNames.Add(new BombName(GameSpriteNode.Name.ROLLING));
        }

        public GameObject Create(float x, float y)
        {
            //Get the name of the sprite for this bomb
            BombName bombName = (BombName)pBombNames.GetNext();

            //Drop the bomb
            Leaf pBomb = this.Add(GameObject.Name.BOMB, bombName.name, x, y);

            // Attached to SpriteBatches
            pBomb.AttachGameSprite(Layer.Layer.Name.BOMBS);
            pBomb.AttachColObj(Layer.Layer.Name.BOXES);

            return pBomb;
        }


        private Leaf Add(GameObject.Name name, GameSpriteNode.Name spriteName, float x, float y)
        {
            GameObjectNode pNode = pBombManager.Pull();
            Leaf pObj = (Leaf)pNode.pObject;
            if (pObj == null)
            {
                pNode.Set(new Bomb());
                pObj = (Leaf)pNode.pObject;
            }
            ((Bomb)pObj).Set(name, spriteName, x, y);
            return pObj;
        }

    }
}
