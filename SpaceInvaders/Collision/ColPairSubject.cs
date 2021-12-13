using SpaceInvaders.GameObjects;
using SpaceInvaders.Observer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Collision
{
    public class ColPairSubject : Subject
    {
        public GameObject pObjA;
        public GameObject pObjB;

        /// <summary>
        /// Gets the object in this subject that matches the given name
        /// </summary>
        /// <param name="name">Name of object to match</param>
        /// <returns>game object matching the give name</returns>
        public GameObject GetByName(GameObject.Name name)
        {
            return MatchName(name, pObjA.name, pObjB.name);
        }

        /// <summary>
        /// Gets the object in this subject that matches the given root name
        /// </summary>
        /// <param name="name">Name of root object to match</param>
        /// <returns>game object matching the given root name</returns>
        public GameObject GetByRootName(GameObject.Name name)
        {
            GameObject.Name nameRootA = pObjA.GetRoot().name;
            GameObject.Name nameRootB = pObjB.GetRoot().name;

            return MatchName(name, nameRootA, nameRootB);
        }

        /// <summary>
        /// Compares the given names and returns the object associated with the match
        /// </summary>
        /// <param name="nameToMatch"></param>
        /// <param name="nameA">Name that if matched give object A</param>
        /// <param name="nameB">Name that if matched give object B</param>
        /// <returns>Object associated with the match</returns>
        private GameObject MatchName(GameObject.Name nameToMatch, GameObject.Name nameA, GameObject.Name nameB)
        {
            GameObject pMatch = null;
            if (nameA == nameToMatch)
            {
                pMatch = pObjA;
            }
            else if (nameB == nameToMatch)
            {
                pMatch = pObjB;
            }
            else
            {
                //Name was incorrect
                Debug.Assert(false);
            }
            return pMatch;
        }
    }
}
