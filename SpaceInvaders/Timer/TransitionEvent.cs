using SpaceInvaders.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    class TransitionEvent : Command
    {
        SceneContext.Scene scene;

        //TODO use these for transitions

        public TransitionEvent(SceneContext.Scene scene)
        {
            this.scene = scene;
        }


        public override void Execute(float deltaTime)
        {
            SpaceInvaders.pSceneContext.SetState(scene);
        }
    }
}
