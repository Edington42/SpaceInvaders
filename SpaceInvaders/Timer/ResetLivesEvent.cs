using SpaceInvaders.Lives;
using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    class ResetLivesEvent : Command
    {
        public override void Execute(float deltaTime)
        {
            FontSprite livesMessage = FontSpriteManager.GetInstance().Find(FontSprite.Name.LIFE_COUNT);
            LivesManager livesManager = LivesManager.GetInstance();
            livesManager.Reset();
            livesMessage.UpdateMessage(livesManager.GetCount().ToString());
        }
    }
}
