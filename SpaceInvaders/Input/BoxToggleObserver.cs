using SpaceInvaders.Layer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Input
{
    class BoxToggleObserver : Observer.Observer
    {
        int priority = -5;

        //---------------------------------------------------------------------------------------------------------
        // Override methods
        //---------------------------------------------------------------------------------------------------------
        public override void Notify()
        {
            this.priority *= -1;
            LayerManager.GetInstance().UpdatePriority(Layer.Layer.Name.BOXES, this.priority);
        }

        public override void Print()
        {
            Debug.WriteLine("Box toggle Observer");
        }
    }
}
