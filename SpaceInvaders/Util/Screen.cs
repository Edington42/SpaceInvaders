using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Util
{
    class Screen
    {
        public static readonly float SCALE = 0.5f;
        public static readonly float WIDTH = 896 * SCALE;
        public static readonly float HEIGHT = 1024 * SCALE;
        public static readonly float MIDDILE_X = WIDTH / 2;
        public static readonly float MIDDILE_Y = HEIGHT / 2;

        //public static readonly float ALIEN_START_Y = 500f * SCALE;
        public static readonly float ALIEN_START_Y = 500 * SCALE;

        public static readonly float ALIEN_LEVEL_DELTA_Y = 100F * SCALE;

        public static readonly float ALIEN_LEVEL_BOTTOM_Y = 200f * SCALE;

        public static readonly float SHIELD_Y = 140 * SCALE;

        public static readonly float ALIEN_SPACE_X = 17 * SCALE;
        public static readonly float ALIEN_SPACE_Y = 33 * SCALE;

        public static readonly float SHIELD_SPACE_X = 96 * SCALE;

        public static readonly float SCORE_LABEL_Y = 1000 * SCALE;
        public static readonly float SCORE_Y = 950 * SCALE;

        public static readonly float UFO_Y = 900 * SCALE;

        public static readonly float UFO_X_OFFSET = 100 * SCALE;

        public static readonly float UFO_X_0 = UFO_X_OFFSET;
        public static readonly float UFO_X_1 = WIDTH - UFO_X_OFFSET;

        //TODO clean this up

        public static readonly float SCORE_CENTERING = 100 * SCALE;

        public static readonly float LABEL_SHIFT_X = 50 * SCALE;

        public static readonly float P1_X = MIDDILE_X - (MIDDILE_X / 2) - SCORE_CENTERING;
        public static readonly float P2_X = MIDDILE_X + (MIDDILE_X / 2) - SCORE_CENTERING;
        public static readonly float HI_X = MIDDILE_X - SCORE_CENTERING;

        public static readonly float P1_LABEL_X = P1_X - LABEL_SHIFT_X;
        public static readonly float P2_LABEL_X = P2_X - LABEL_SHIFT_X;
        public static readonly float HI_LABEL_X = HI_X - LABEL_SHIFT_X;

        

        public static readonly float LIFE_NUM_X = 20 * SCALE;
        public static readonly float LIFE_NUM_Y = 15 * SCALE;

        public static readonly float GAME_OVER_OFFSET = 50 * SCALE;

        public static readonly float GAME_OVER_Y = 900 * SCALE;
        public static readonly float GAME_OVER_X = MIDDILE_X - GAME_OVER_OFFSET;

        public static readonly float SELECT_X = MIDDILE_X - 200;


        //TODO these probably should just be half the heights of the sprites
        public static readonly float MISSILE_START_Y_OFFSET = 20 * SCALE;

        public static readonly float BOMB_START_Y_OFFSET = 20 * SCALE;

    }
}
