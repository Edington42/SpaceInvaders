using SpaceInvaders.Collision;
using SpaceInvaders.Composite;
using SpaceInvaders.Observer;
using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Ship
{
    public class Ship : Leaf
    {
        ShipWeaponState pWeaponState;
        ShipEngineState pEngineState;
        public Subject pSubject;
        public float shipSpeed = 3.0f;
        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objectName">Name of the game object being created</param>
        /// <param name="spriteName">Name of the spirte being used for the object</param>
        /// <param name="posX">X position of the object</param>
        /// <param name="posY">Y position of the object</param>
        public Ship()
            : base()
        {
            this.pSubject = new Subject();
        }

        /// <summary>
        /// Sets the state of this ship's weapons
        /// </summary>
        /// <param name="state">State to set to</param>
        public void SetWeaponState(ShipManager.WeaponState state)
        {
            this.pWeaponState = ShipManager.GetInstance().GetShipWeaponState(state);
        }

        public void SetEngineState(ShipManager.EngineState state)
        {
            this.pEngineState = ShipManager.GetInstance().GetShipEngineState(state);
        }

        /// <summary>
        /// Fires the missile from this ship if it is ready.
        /// </summary>
        public void ShootMissile()
        {
            this.pWeaponState.ShootMissile(this);
;       }

        public void ReloadMissile()
        {
            this.pWeaponState.ReloadMissile(this);
        }

        public void MoveRight()
        {
            this.pEngineState.MoveRight(this);
        }

        public void MoveLeft()
        {
            this.pEngineState.MoveLeft(this);
        }



        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------

        public override void Accept(ColVisitor other)
        {
            other.VisitShip(this);
        }

        public override void VisitBomb(Bomb.Bomb b)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", b.name, this.name);

            Debug.WriteLine("-------> Done  <--------");

            //Notify the manager of the collision
            ColPairManager.GetInstance().ProcessCol(this, b);
        }
    }
}
