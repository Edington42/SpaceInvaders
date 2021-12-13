using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Layer;
using SpaceInvaders.Sprite;
using SpaceInvaders.Timer;
using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observer
{
    class SplatObserver : Observer
    {
        GameObject.Name rootName;
        Layer.Layer.Name layerName;
        GameSpriteNode.Name spriteName;

        public SplatObserver(GameObject.Name rootName, Layer.Layer.Name layerName, GameSpriteNode.Name spriteName) :
            base()
        {
            this.rootName = rootName;
            this.layerName = layerName;
            this.spriteName = spriteName;
        }

        public override void Notify()
        {
             ColPairSubject colPairSubject = (ColPairSubject)this.pSubject;
            GameObject toSplat = colPairSubject.GetByRootName(rootName);
            StaticCommands.Splat(this.spriteName, this.layerName, toSplat);
        }

        public override void Print()
        {
            Debug.WriteLine("Splat Observer");
        }


    }
}
