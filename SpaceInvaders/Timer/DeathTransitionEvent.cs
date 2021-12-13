using SpaceInvaders.Lives;
using SpaceInvaders.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    class DeathTransitionEvent : Command
    {
        public override void Execute(float deltaTime)
        {
            LivesManager pMan = LivesManager.GetInstance();

            SceneContext.Scene scene;

            if (pMan.GetCount() <= 0)
            {
                scene = SceneContext.Scene.Over;
            }
            else
            {
                scene = SceneContext.Scene.Play;
            }

            SpaceInvaders.pSceneContext.SetState(scene);
        }
    }
}
