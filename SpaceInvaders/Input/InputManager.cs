using SpaceInvaders.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Input
{
    public class InputManager
    {
        private static InputManager instance = new InputManager();
        private Subject pSubjectRightKey;
        private Subject pSubjectLeftKey;
        private Subject pSubjectSpace;
        private Subject pSubjectB;
        private bool privSpaceKeyPrev;
        private bool privBKeyPrev;


        //TODO this probably could be a state
        public bool ignore;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        private InputManager()
        {
            //Create the subjects of this input manager
            this.pSubjectSpace = new Subject();
            this.pSubjectRightKey = new Subject();
            this.pSubjectLeftKey = new Subject();
            this.pSubjectB = new Subject();


            //Attach the observers
            this.pSubjectSpace.Attach(new ShootObserver());
            this.pSubjectRightKey.Attach(new MoveRightObserver());
            this.pSubjectLeftKey.Attach(new MoveLeftObserver());
            this.pSubjectB.Attach(new BoxToggleObserver());

            this.privSpaceKeyPrev = false;
            this.privBKeyPrev = false;

            this.ignore = false;
        }


        public static InputManager GetInstance()
        {
            return instance;
        }

        public static Subject GetSpaceSubject()
        {
            return instance.pSubjectSpace;
        }

        public void Update()
        {
            if (!ignore)
            {
                //TODO you could probably make classes out of these

                // LeftKey: (no history) -----------------------------------------------------------
                if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT) == true)
                {
                    instance.pSubjectLeftKey.Notify();
                }

                // RightKey: (no history) -----------------------------------------------------------
                if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT) == true)
                {
                    instance.pSubjectRightKey.Notify();
                }

                // BKey: : (with key history) -------------------------------------------------------------
                bool bKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_B);
                if (bKeyCurr == true && instance.privBKeyPrev == false)
                {
                    instance.pSubjectB.Notify();
                }

                instance.privBKeyPrev = bKeyCurr;

                // SpaceKey: (with key history) -----------------------------------------------------------
                bool spaceKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE);
                if (spaceKeyCurr == true && instance.privSpaceKeyPrev == false)
                {
                    instance.pSubjectSpace.Notify();
                }

                instance.privSpaceKeyPrev = spaceKeyCurr;
            }

        }
    }
}
