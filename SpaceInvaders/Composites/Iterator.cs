using SpaceInvaders.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Composites
{
    /// <summary>
    /// Abstract iterator
    /// </summary>
    public abstract class Iterator
    {
        //---------------------------------------------------------------------------------------------------------
        // Abstract Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Returns the next component in the iteration
        /// </summary>
        /// <returns>Next component in the iteration</returns>
        abstract public Component Next();

        /// <summary>
        /// Returns true if the iteration has comleted
        /// </summary>
        /// <returns>true if iteration has completed</returns>
        abstract public bool IsDone();

        /// <summary>
        /// resets the iteration and returns the first component in the iteration
        /// </summary>
        /// <returns>First component in the iteration</returns>
        abstract public Component First();

    }
}
