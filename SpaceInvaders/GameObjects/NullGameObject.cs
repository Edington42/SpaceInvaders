using SpaceInvaders.Collision;
using SpaceInvaders.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects
{
    /// <summary>
    /// Null game object just used for comparison.
    /// </summary>
    class NullGameObject : GameObject
    {

        public NullGameObject()
            : base(GameObject.Name.NULL_OBJECT)
        {

        }
        public override void Accept(ColVisitor other)
        {
            throw new NotImplementedException();
        }

        public override void Add(Component c)
        {
            throw new NotImplementedException();
        }

        public override Component GetFirstChild()
        {
            throw new NotImplementedException();
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }

        public override void Remove(Component c)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Empty()
        {
            throw new NotImplementedException();
        }
    }
}
