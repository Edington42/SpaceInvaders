using SpaceInvaders.Font;
using SpaceInvaders.Sprite;
using SpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Score
{
    public class ScoreKeeper
    {
        private static ScoreKeeper instance = new ScoreKeeper();

        private PlayerScore p1;
        private PlayerScore p2;
        private PlayerScore hi;

        private PlayerScore curPlayer;

        private ScoreKeeper()
        {
            this.p1 = new PlayerScore(FontSprite.Name.P1_SCORE);
            this.p2 = new PlayerScore(FontSprite.Name.P2_SCORE);
            this.hi = new PlayerScore(FontSprite.Name.HIGH_SCORE);
            this.curPlayer = this.p1;
        }

        public static ScoreKeeper GetInstance()
        {
            return instance;
        }

        public void Score(int points)
        {
            curPlayer.Add(points);
        }

        public void ResetCurrent()
        {
            int finalScore = curPlayer.GetScore();
            if (finalScore > this.hi.GetScore()) this.hi.SetScore(finalScore);
            curPlayer.Reset();
        }

        public void SwitchPlayer(int player)
        {
            if(player == 1)
            {
                this.curPlayer = this.p1;
            } else
            {
                this.curPlayer = this.p2;
            }
        }

        public void ActivateScores(Layer.Layer.Name name)
        {
            FontSpriteManager fontSpriteManager = FontSpriteManager.GetInstance();
            fontSpriteManager.Add(FontSprite.Name.P1_SCORE, Layer.Layer.Name.TEXTS, p1.GenerateDisplayString(), Glyph.Name.CONSOLAS_36_PT, Screen.P1_X, Screen.SCORE_Y);
            fontSpriteManager.Add(FontSprite.Name.P2_SCORE, Layer.Layer.Name.TEXTS, p2.GenerateDisplayString(), Glyph.Name.CONSOLAS_36_PT, Screen.P2_X, Screen.SCORE_Y);
            fontSpriteManager.Add(FontSprite.Name.HIGH_SCORE, Layer.Layer.Name.TEXTS, hi.GenerateDisplayString(), Glyph.Name.CONSOLAS_36_PT, Screen.HI_X, Screen.SCORE_Y);
        }

        public int GetScore()
        {
            return this.curPlayer.GetScore();
        }
    }
}
