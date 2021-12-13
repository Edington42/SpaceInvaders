using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Lives
{
    public class LivesManager
    {
        public static LivesManager pActiveMan;

        public int startCount;
        public int currentCount;

        public LivesManager(int startCount)
        {
            this.startCount = startCount;
            this.currentCount = startCount;
        }

        public static LivesManager GetInstance()
        {
            return LivesManager.pActiveMan;
        }

        public static void SetActive(LivesManager pMan)
        {
            LivesManager.pActiveMan = pMan;
        }

        public bool LoseLife()
        {
            this.currentCount--;
            return this.currentCount <= 0;
        }

        public void Reset()
        {
            this.currentCount = this.startCount;
        }

        public int GetCount()
        {
            return this.currentCount;
        }
    }
}
