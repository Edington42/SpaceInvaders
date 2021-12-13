using SpaceInvaders.Composite;
using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.Shield;
using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.DelayedRemove
{
    public class DelayRemoveNode : DLink
    {
        public GameObject pToRemove;

        public DelayRemoveNode(Leaf pToRemove)
            : base()
        {
            this.pToRemove = pToRemove;
        }

        public void Execute()
        {
            pToRemove.Empty();
        
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }

        protected override void ToDefault()
        {
            this.pToRemove = null;
        }
    }
}
