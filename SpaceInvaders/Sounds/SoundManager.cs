using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Sounds
{
    class SoundManager : Manager.Manager
    {
        private static SoundManager pActiveMan = null;

        //Compare node
        private readonly Sound poNodeCompare;

        //Texture manager to use
        IrrKlang.ISoundEngine pSndEng;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reserveSize">Size of the reserve list</param>
        /// <param name="growthSize">Growth size</param>
        public SoundManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poNodeCompare = new Sound();
            this.pSndEng = new IrrKlang.ISoundEngine();
        }

        /// <summary>
        /// Returns isntatnce of the manager
        /// </summary>
        /// <returns>Instatnce of the manager</returns>
        public static SoundManager GetInstance()
        {
            return SoundManager.pActiveMan;
        }

        public static void SetActive(SoundManager pMan)
        {
            SoundManager.pActiveMan = pMan;
        }

        public void SetVol(float vol)
        {
            this.pSndEng.SoundVolume = vol;
        }

        /// <summary>
        /// Creates a new image node
        /// </summary>
        /// <param name="name">name of image node</param>
        /// <param name="textureName">Name of texture to use for image</param>
        /// <param name="x">X location of image rect</param>
        /// <param name="y">Y location if image rect</param>
        /// <param name="width">Width of image rect</param>
        /// <param name="height">Height of image rect</param>
        /// <returns>New image node</returns>
        public Sound Add(Sound.Name name, String fileName)
        {
            Sound pNode = (Sound)BaseAdd();

            //Initialize the data
            pNode.Set(this.pSndEng, name, fileName);

            return pNode;
        }

        /// <summary>
        /// Finds an image node by name
        /// </summary>
        /// <param name="name">Name of the image node to find</param>
        /// <returns>Image node coresponding to the name. Null if no such image was found</returns>
        public Sound Find(Sound.Name name)
        {
            this.poNodeCompare.name = name;

            Sound pNode = (Sound)BaseFind(this.poNodeCompare);
            return pNode;
        }

        public void Update()
        {
            this.pSndEng.Update();
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        protected override bool CompareNodes(DLink nodeA, DLink nodeB)
        {
            Sound imageNodeA = (Sound)nodeA;
            Sound imageNodeB = (Sound)nodeB;

            bool match = false;

            if (imageNodeA.name == imageNodeB.name) match = true;

            return match;
        }

        protected override DLink GetBlank()
        {
            return new Sound();
        }

        protected override void Wash(DLink pNode)
        {
            Sound pImageNode = (Sound)pNode;
            pImageNode.Wash();
        }
    }
}
