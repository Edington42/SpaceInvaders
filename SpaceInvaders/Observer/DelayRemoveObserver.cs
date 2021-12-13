using SpaceInvaders.Collision;
using SpaceInvaders.Composite;
using SpaceInvaders.DelayedRemove;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    public class DelayRemoveObserver : Observer
    {
        public GameObject.Name rootName;

        public DelayRemoveObserver(GameObject.Name rootName) :
            base()
        {
            this.rootName = rootName;
        }

        public override void Notify()
        {
            ColPairSubject colPairSubject = (ColPairSubject)this.pSubject;
            Leaf toRemove = (Leaf)colPairSubject.GetByRootName(rootName);
            DelayRemoveManager.GetInstance().Attach(toRemove);
        }

        public override void Print()
        {
            Debug.WriteLine("Delay remove observer");
        }

        //---------------------------------------------------------------------------------------------------------
        // Abstract methods
        //---------------------------------------------------------------------------------------------------------
        //protected abstract Manager.Manager GetManager();
    }
}
