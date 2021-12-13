using SpaceInvaders.Layer;
using SpaceInvaders.Observer;
using SpaceInvaders.Sprite;
using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects.Ship
{
    public class ShipManager
    {
        private static ShipManager instance = new ShipManager();

        private  Ship pShip;
        private MissileObject pMissile;

        private ShipReadyState pReady;
        private ShipNotReadyState pNotReady;

        private DefaultEngineState pDefaultEngineState;
        private LeftEngineState pLeftEngineState;
        private RightEngineState pRightEngineState;

        public enum WeaponState
        {
            READY,
            NOT_READY
        }

        public enum EngineState
        {
            DEFAULT,
            LEFT,
            RIGHT
        }

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        private ShipManager()
        {
            //Store the states
            this.pReady = new ShipReadyState();
            this.pNotReady = new ShipNotReadyState();

            this.pDefaultEngineState = new DefaultEngineState();
            this.pLeftEngineState = new LeftEngineState();
            this.pRightEngineState = new RightEngineState();

            //The ship and missile 
        }

        public static ShipManager GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// Creates the ship and attaches it where appropriate
        /// </summary>
        public void ActiveShip()
        {
            Ship ship = this.GetShip();
            ship.BaseSet(GameObject.Name.SHIP, GameSpriteNode.Name.SHIP, Screen.MIDDILE_X, Sizes.WALL_BOTTOM_SCREEN.screenY + (Sizes.SHIP_SCREEN.screenY/2));

            ship.AttachGameSprite(Layer.Layer.Name.SHIP);
            ship.AttachColObj(Layer.Layer.Name.BOXES);

            GameObject pShipGroup = GameTreeManager.GetInstance().Find(GameObject.Name.SHIP_GROUP).pObject;
            pShipGroup.Add(ship);

            ship.SetWeaponState(WeaponState.READY);
            ship.SetEngineState(EngineState.DEFAULT);
        }

        public Ship GetShip()
        {
            if(instance.pShip == null)
            {
                instance.pShip = new Ship();
            }
            return instance.pShip;
        }

        public MissileObject GetMissile()
        {
            if (instance.pMissile == null)
            {
                instance.pMissile = new MissileObject();
            }
            return instance.pMissile;
        }

        /// <summary>
        /// Creates a missile that is ready to fire
        /// </summary>
        /// <returns>Missile, ready to fire</returns>
        public static MissileObject ActivateMissile()
        {

            MissileObject missile = instance.GetMissile();
            missile.BaseSet(GameObject.Name.MISSILE, GameSpriteNode.Name.MISSILE, 0, 0);

            // Attached to SpriteBatches
            missile.AttachGameSprite(Layer.Layer.Name.MISSILES);
            missile.AttachColObj(Layer.Layer.Name.BOXES);

            // Attach the missile to the missile root
            GameObject pMissileGroup = GameTreeManager.GetInstance().Find(GameObject.Name.MISSILE_GROUP).pObject;

            // Add to GameObject Tree - {update and collisions}
            pMissileGroup.Add(missile);

            return missile;
        }


        /// <summary>
        /// Returns a ship state based on a state enum
        /// </summary>
        /// <param name="state">State enum to derive state from</param>
        /// <returns>Ship state based off of the give enum</returns>
        public ShipWeaponState GetShipWeaponState(WeaponState state)
        {
            ShipWeaponState pShipState = null;

            switch(state){
                case WeaponState.READY:
                    pShipState =  this.pReady;
                    break;
                case WeaponState.NOT_READY:
                    pShipState = this.pNotReady;
                    break;
                default:
                    break;
            }

            return pShipState;
        }

        public ShipEngineState GetShipEngineState(EngineState state)
        {
            ShipEngineState pShipState = null;

            switch (state)
            {
                case EngineState.DEFAULT:
                    pShipState = this.pDefaultEngineState;
                    break;
                case EngineState.LEFT:
                    pShipState = this.pLeftEngineState;
                    break;
                case EngineState.RIGHT:
                    pShipState = this.pRightEngineState;
                    break;
                default:
                    break;
            }
            return pShipState;
        }
    }
}
