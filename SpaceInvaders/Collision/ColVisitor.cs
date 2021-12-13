using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.Bomb;
using SpaceInvaders.GameObjects.Shield;
using SpaceInvaders.GameObjects.Ship;
using SpaceInvaders.GameObjects.UFO;
using SpaceInvaders.GameObjects.Wall;
using SpaceInvaders.Manager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Collision
{
    public abstract class ColVisitor : DLink
    {

        public virtual void VisitGrid(AlienGrid b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by CrabObject not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitColumn(AlienColumn b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by column not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitAlienObject(AlienObject a)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by alien object not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitMissile(MissileObject m)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Missile not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitMissileGroup(MissileGroup m)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by MissileGroup not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitShipGroup(ShipGroup s)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by ShipGroup not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitShip(Ship s)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Ship not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitWallGroup(WallGroup w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by WallGroup not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitWallTop(WallTop w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by WallTop not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitWallBottom(WallBottom w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by WallBottom not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitWallLeft(WallLeft w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by WallLeft not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitWallRight(WallRight w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by WallRight not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitShieldGrid(ShieldGrid s)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Shield Grid not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitShieldColumn(ShieldColumn s)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by ShieldColumn not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitShieldBrick(ShieldBrick s)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by ShieldBrick not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitBombGroup(BombGroup b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by BombGroup not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitBomb(Bomb b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Bomb not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitUfo(Ufo u)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Bomb not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitUfoGroup(UfoGroup u)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Bomb not implemented");
            Debug.Assert(false);
        }

        abstract public void Accept(ColVisitor other);
    }
}
