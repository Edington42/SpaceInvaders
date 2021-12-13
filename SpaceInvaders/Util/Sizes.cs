using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Util
{
    public class Sizes
    {

        public static TextureSize SHIELD_BRICK_TS = new TextureSize(114.0f, 31.0f, 2.0f, 2.66f);


        public static TextureSize SQUID_OPEN_TS = new TextureSize(72f, 2f, 8.0f, 10.0f);
        public static TextureSize SQUID_CLOSED_TS = new TextureSize(61f, 2f, 9.0f, 10.0f);
        public static TextureSize CRAB_OPEN_TS = new TextureSize(47f, 2f, 11.0f, 8.0f);
        public static TextureSize CRAB_CLOSED_TS = new TextureSize(33f, 2f, 11f, 8f);
        public static TextureSize OCTO_OPEN_TS = new TextureSize(18f, 2f, 12f, 8.0f);
        public static TextureSize OCTO_CLOSED_TS = new TextureSize(3.0f, 2f, 12.0f, 9.0f);

        public static TextureSize SHIP_TS = new TextureSize(3.0f, 14f, 13.0f, 8.0f);
        public static TextureSize SHIP_BOOM_0_TS = new TextureSize(20.0f, 14f, 15.0f, 8.0f);
        public static TextureSize SHIP_BOOM_1_TS = new TextureSize(38.0f, 14f, 16.0f, 8.0f);

        public static TextureSize UFO_TS = new TextureSize(99.0f, 4f, 16.0f, 7.0f);
        public static TextureSize UFO_BOOM_TS = new TextureSize(118.0f, 3f, 21.0f, 8.0f);

        public static Screen2D SHIELD_BRICK_SCREEN = new Screen2D(7.0f, 10.0f);

        public static Screen2D SQUID_SCREEN = new Screen2D(33f, 33f);
        public static Screen2D CRAB_SCREEN = new Screen2D(45f, 33f);
        public static Screen2D OCTO_SCREEN = new Screen2D(49f, 33f);

        public static Screen2D SHIP_SCREEN = new Screen2D(39f, 24f);
        public static Screen2D SHIP_BOOM_0_SCREEN = new Screen2D(42f, 24f);
        public static Screen2D SHIP_BOOM_1_SCREEN = new Screen2D(45f, 24f);

        public static Screen2D UFO_SCREEN = new Screen2D(45f, 21f);
        public static Screen2D UFO_BOOM_SCREEN = new Screen2D(48f, 24f);

        public static Screen2D WALL_BOTTOM_SCREEN = new Screen2D(Screen.WIDTH, 20F);
        public static Screen2D WALL_TOP_SCREEN = new Screen2D(Screen.WIDTH, 55F);
        public static Screen2D WALL_SIDE_SCREEN = new Screen2D(20F, Screen.HEIGHT);
    }
}
