using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Ship
{
    /// <summary>
    /// Represents the state of the ship
    /// </summary>
    public abstract class ShipWeaponState
    {
        //---------------------------------------------------------------------------------------------------------
        // Abstract Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Handles a fire command 
        /// </summary>
        /// <param name="pShip">Ship to handle command with</param>
        public abstract void ShootMissile(Ship pShip);

        /// <summary>
        /// Handles a reload command 
        /// </summary>
        /// <param name="pShip">Ship to handle command with</param>
        public abstract void ReloadMissile(Ship pShip);


    }
}
