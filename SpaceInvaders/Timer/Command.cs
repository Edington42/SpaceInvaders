using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    /// <summary>
    /// Abstract command.
    /// </summary>
    public abstract class Command
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="deltaTime">Time between instantiation and when the execution should occur.</param>
        abstract public void Execute(float deltaTime);
    }
}
