using SpaceInvaders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Timer
{
    class ResetLevelEvenet : Command
    {
        public override void Execute(float deltaTime)
        {
            AlienGrid pGrid = (AlienGrid)GameTreeManager.GetInstance().Find(GameObject.Name.ALIEN_GRID).pObject;
            pGrid.ResetLevel();
        }
    }
}
