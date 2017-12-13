using System;
using Microsoft.Xna.Framework;

namespace DDEngine
{
    class DDSprite : DDBasic
    {
        /*
         * Sprites position
         */
        public Vector2 Position;

        public DDSprite(int X = 0, int Y = 0)
        {
            Position.X = X;
            Position.Y = Y;
        }
    }
}
