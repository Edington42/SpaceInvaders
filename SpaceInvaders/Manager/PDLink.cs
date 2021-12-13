using System;

namespace SpaceInvaders.Manager
{
    /// <summary>
    /// Priority DLink
    /// </summary>
    public abstract class PDLink : DLink
    {
        /// <summary>
        /// Returns true if the given comparable has a higher priority than this link.
        /// </summary>
        /// <param name="comparable">Comparable intended to be tested against.</param>
        /// <returns>True if the given comparable has a higher priority than this </returns>
        public abstract bool HasHigherPriority(IComparable comparable);
    }
}
