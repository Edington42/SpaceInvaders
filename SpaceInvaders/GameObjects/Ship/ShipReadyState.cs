using SpaceInvaders.Timer;
using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Ship
{
    /// <summary>
    /// Represents state of ship when it is ready to fire
    /// </summary>
    class ShipReadyState: ShipWeaponState
    {
        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        public override void ShootMissile(Ship pShip)
        {
            

            

            pShip.SetWeaponState(ShipManager.WeaponState.NOT_READY);

            MissileObject pMissile = ShipManager.ActivateMissile();

            pMissile.x = pShip.x;
            pMissile.y = pShip.y + Screen.MISSILE_START_Y_OFFSET;

            //Notify that the missile is flying
            pShip.pSubject.Notify();
        }

        public override void ReloadMissile(Ship pShip)
        {
            //Do nothing
        }
    }
}
