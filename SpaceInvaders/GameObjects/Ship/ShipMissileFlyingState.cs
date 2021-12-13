using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Ship
{
    /// <summary>
    /// Represents state of ship that has already fired a missile
    /// </summary>
    class ShipMissileFlyingState : ShipWeaponState
    {
        

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        public override void ShootMissile(Ship pShip)
        {
            //Do nothing
        }

        public override void ReloadMissile(Ship pShip)
        {
            pShip.pSubject.Set(true);
            pShip.SetWeaponState(ShipManager.WeaponState.READY);
        }
    }
}
