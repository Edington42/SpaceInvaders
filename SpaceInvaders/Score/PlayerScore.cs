using SpaceInvaders.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Score
{
    class PlayerScore
    {
        public int score;
        private FontSprite.Name name;

        public PlayerScore(FontSprite.Name name)
        {
            this.score = 0;
            this.name = name;
        }

        public void Add(int points)
        {
            this.score += points;
            FontSpriteManager.GetInstance().Find(this.name).UpdateMessage(this.GenerateDisplayString());
        }

        public int GetScore()
        {
            return this.score;
        }

        public void Reset()
        {
            this.score = 0;
            FontSpriteManager.GetInstance().Find(this.name).UpdateMessage(this.GenerateDisplayString());
        }

        public String GenerateDisplayString()
        {
            return score.ToString("D4");
        }

        public void SetScore(int score)
        {
            this.score += score;
            FontSpriteManager.GetInstance().Find(this.name).UpdateMessage(this.GenerateDisplayString());
        }
    }
}
