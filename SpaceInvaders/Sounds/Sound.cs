using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Sounds
{
    public class Sound : DLink
    {
        public IrrKlang.ISoundSource pSndSource;
        public IrrKlang.ISound pSound;
        private IrrKlang.ISoundEngine pSngEng;
        public Sound.Name name;

        /// <summary>
        /// Enum of image node names
        /// </summary>
        public enum Name
        {
            ALIEN_MOVE_0,
            ALIEN_MOVE_1,
            ALIEN_MOVE_2,
            ALIEN_MOVE_3,

            UNINITIALIZED,
            ALIEN_BOOM,
            SHIP,
            MISSILE,
            UFO
        }

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        public Sound() : base()
        {
            this.name = Sound.Name.UNINITIALIZED;
            this.pSndSource = null;
            this.pSound = null;
            this.pSngEng = null;
        }

        /// <summary>
        /// Sets the variables for the image
        /// </summary>
        /// <param name="name">Name of the image</param>
        /// <param name="pTexture">Texture node for the image</param>
        /// <param name="x">X location of image rect</param>
        /// <param name="y">Y location of image rect</param>
        /// <param name="width">Width of image rect</param>
        /// <param name="height">Height of image rect</param>
        public void Set(IrrKlang.ISoundEngine pSndEng, Sound.Name name, String fileName)
        {
            this.name = name;
            this.pSndSource = pSndEng.AddSoundSourceFromFile(fileName);
            this.pSngEng = pSndEng;
            pSndEng.SoundVolume = 0;
            //Play once with no vloume so it get cached
            //pSndEng.Play2D(pSndSource, false, false, false);
        }

        public void Play()
        {
            this.pSngEng.SoundVolume = 0.2f;
            this.pSngEng.Play2D(this.pSndSource, false, false, false);
        }

        public void PlayLoop()
        {
            this.pSngEng.SoundVolume = 0.2f;
            this.pSound = this.pSngEng.Play2D(pSndSource, true, false, false);
        }

        public void StopLoop()
        {
            if (this.pSound != null)
            {
                this.pSound.Stop();
            }
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        public override void Print()
        {
            Debug.WriteLine("Sound node: " + this.name);
        }

        protected override void ToDefault()
        {
            this.name = Sound.Name.UNINITIALIZED;
            this.pSndSource = null;
            this.pSound = null;
            this.pSngEng = null;
        }
    }
}
