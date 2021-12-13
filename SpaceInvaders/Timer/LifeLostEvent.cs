using SpaceInvaders.GameObjects;
using SpaceInvaders.Lives;
using SpaceInvaders.Score;
using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    class LifeLostEvent : Command
    {
        public override void Execute(float deltaTime)
        {
            //Get the lives manager
            LivesManager livesManager = LivesManager.GetInstance();

            FontSprite livesMessage = FontSpriteManager.GetInstance().Find(FontSprite.Name.LIFE_COUNT);
            livesManager.LoseLife();
            livesMessage.UpdateMessage(livesManager.GetCount().ToString());

        }
    }
}
