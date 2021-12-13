using SpaceInvaders.Manager;
using SpaceInvaders.SpriteContainer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Layer
{
    public class Layer : PDLink
    {
        private static int RESERVE_SIZE = 5;
        private static int GROWTH_SIZE = 3;

        public SpriteContainerManager poManager = new SpriteContainerManager(RESERVE_SIZE, GROWTH_SIZE);
        public Name name;
        public int priority;

        /// <summary>
        /// Enum of layer names
        /// </summary>
        public enum Name
        {

            SITCHES,
            BIRDS,
            NUMBERS,
            BOXES,
            ALIENS,
            UNINITIALIZED,
            MISSILES,
            SHIP,
            WALLS,
            SHIELD,
            BOMBS,
            TEXTS,
            UFO
        }

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Sets the name and priority of the layer
        /// </summary>
        /// <param name="name">Node of the layer</param>
        /// <param name="priority">Priority of the layer</param>
        public void Set( Name name, int priority)
        {
            this.name = name;
            this.priority = priority;
        }

        public void Set(Name name, int priority, SpriteContainerManager pManager)
        {
            this.name = name;
            this.priority = priority;
            this.poManager.Accept(pManager);
        }

        /// <summary>
        /// Draws sprites for this layer
        /// </summary>
        public void Draw()
        {
            this.poManager.Draw();
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Print()
        {
            Debug.WriteLine(name + "Layer Start:");
            poManager.PrintMe();
            Debug.WriteLine(name + "Layer End");
        }

        protected override void ToDefault()
        {
            this.poManager.Empty();
            this.name = Name.UNINITIALIZED;
        }

        public override bool HasHigherPriority(IComparable comparable)
        {
            return (this.priority.CompareTo((int)comparable) > 0);
        }
    }
}
