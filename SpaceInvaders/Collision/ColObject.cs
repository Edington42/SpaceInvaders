using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Collision
{
    /// <summary>
    /// Collision object for a proxy sprite 
    /// </summary>
    public class ColObject
    {
        public ColRect pColRect;
        public BoxSpriteNode pColSprite;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pProxySprite">Sprite the collision object is for</param>
        public ColObject(ProxySprite pProxySprite)
        {
            GameSpriteNode pSprite = pProxySprite.pNode;

            this.pColRect = new ColRect(pSprite.GetScreenRect());

            this.pColSprite = BoxSpriteManager.GetInstance().Add(BoxSpriteNode.Name.BOX, this.pColRect.x, this.pColRect.y, this.pColRect.width, this.pColRect.height);
            
            this.pColSprite.SwapColor(1.0f, 1.0f, 0.0f);
        }

        public ColObject()
        {
            this.pColRect = new ColRect();

            this.pColSprite = BoxSpriteManager.GetInstance().Add(BoxSpriteNode.Name.BOX, this.pColRect.x, this.pColRect.y, this.pColRect.width, this.pColRect.height);
            this.pColSprite.SwapColor(1.0f, 0.0f, 0.0f);
        }

        public void Set(Azul.Rect colRect)
        {
            this.pColRect.Set(colRect);
        }

        /// <summary>
        /// Updates the position of the colision object
        /// </summary>
        /// <param name="x">X Position to update to</param>
        /// <param name="y">Y positon to update to</param>
        public void UpdatePos(float x, float y)
        {
            this.pColRect.x = x;
            this.pColRect.y = y;

            this.pColSprite.x = this.pColRect.x;
            this.pColSprite.y = this.pColRect.y;
        }

        /// <summary>
        /// Updates the collision object to match its rectangle and calls update on the sprite
        /// </summary>
        public void Update()
        {

            this.pColSprite.UpdateRect(this.pColRect.x, this.pColRect.y, this.pColRect.width, this.pColRect.height);
            this.pColSprite.Update();
        }
    }
}
