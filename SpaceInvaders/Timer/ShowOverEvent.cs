using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    class ShowOverEvent : Command
    {
        

        public override void Execute(float deltaTime)
        {
            FontSpriteManager.GetInstance().Find(FontSprite.Name.GAME_OVER_LABEL).UpdateMessage("Game Over");
        }
    }
}
