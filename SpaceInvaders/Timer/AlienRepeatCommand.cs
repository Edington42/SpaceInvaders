using SpaceInvaders.Composite;
using SpaceInvaders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    class AlienRepeatCommand : DecayingRepeatCommand
    {
        public AlienRepeatCommand(TimerEvent.Name name, Command command, float deltaRepeatTime) : base(name, command, deltaRepeatTime)
        {
        }

        protected override float GetDecayedDelta()
        {
            AlienGrid pGrid = (AlienGrid)GameTreeManager.GetInstance().Find(GameObject.Name.ALIEN_GRID).pObject;

            //TODO find a better solution that doesn't involve this much walking of the list
            int remaining = 0;
            Composite.Composite pNode = (Composite.Composite)pGrid.GetFirstChild();
            while(pNode != null)
            {
                remaining += pNode.numChildren;
                pNode = (Composite.Composite)pNode.GetSibling();
            }

            //Bottoms out at about 3% of the original delta
            int destroyed = 55 - remaining;
            float power = (float)Math.Pow(destroyed, 2);
            float adjusted = (power / 2950);
            return this.initialDelta - adjusted;
        }
    }
}
