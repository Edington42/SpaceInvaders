using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Sprite
{
    /// <summary>
    /// Contains a pointer to a game sprite.
    /// </summary>
    public class ProxySprite : BaseSpriteNode
    {
        public GameSpriteNode pNode;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor
        /// </summary>
        public ProxySprite()
        {
            this.pNode = null;
            this.x = 0;
            this.y = 0;
        }

        /// <summary>
        /// Sets the game sprite node to be proxied and the initial location.
        /// </summary>
        /// <param name="name">Name of the game sprite to be proxied.</param>
        /// <param name="x">X position of the proxy.</param>
        /// <param name="y">Y position of the proxy.</param>
        public void Set(GameSpriteNode.Name name, float x, float y)
        {
            this.pNode = GameSpriteManager.GetInstance().Find(name);
            this.x = x;
            this.y = y;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Print()
        {
            Debug.WriteLine("Proxy--------");
            pNode.Print();
            Debug.WriteLine("--------------");
        }

        public override void Render()
        {
            this.Update();
            this.pNode.Render();
        }

        public override void Update()
        {
            this.pNode.x = this.x;
            this.pNode.y = this.y;
            this.pNode.Update();
        }

        protected override void ToDefault()
        {
            base.ToDefault();
            this.pNode = null;
        }
    }
}
