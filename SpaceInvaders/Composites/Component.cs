using SpaceInvaders.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Composite
{
    /// <summary>
    /// Component pattern template.  Allows a collection of collection to be treated as a single object
    /// </summary>
   public abstract  class Component : ColVisitor
    {

        public Component pParent = null;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Gets the sibling of this component if there is one.
        /// </summary>
        /// <returns>Sibling of this component.</returns>
        public Component GetSibling()
        {
            return (Component)this.pNext;
        }

        /// <summary>
        /// Returns the parent of this node.  Null if this is a root.
        /// </summary>
        /// <returns>Parent of this node.  Null if this is a root.</returns>
        public Component GetParent()
        {
            return this.pParent;
        }

        //---------------------------------------------------------------------------------------------------------
        // Abstract Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Adds a component to the node
        /// </summary>
        /// <param name="c">Component to be added</param>
        public abstract void Add(Component c);

        /// <summary>
        /// Removes a component from this node
        /// </summary>
        /// <param name="c">Compoent to remove</param>
        public abstract void Remove(Component c);

        /// <summary>
        /// Returns the first child of this node or null if this is a leaf.
        /// </summary>
        /// <returns>First child of this node or null if this is a leaf.</returns>
        public abstract Component GetFirstChild();

        


        
    }
}
