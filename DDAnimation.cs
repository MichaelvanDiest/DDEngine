using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DDEngine
{
    class DDAnimation
    {
        /// <summary>
        /// Sprite Sheet
        /// </summary>
        public Texture2D spriteStrip;
        /// <summary>
        /// Sprite scale.
        /// </summary>
        public float scale;
        /// <summary>
        /// Time since frame has been updated
        /// </summary>
        public int elapsedTime;
        /// <summary>
        /// Time a frame is displayed
        /// </summary>
        public int frameSpeed;
        /// <summary>
        /// Total number of frames
        /// </summary>
        public int frameCount;
        /// <summary>
        /// Index of the current frame we are displaying
        /// </summary>
        public int currentFrame;
        /// <summary>
        /// Color of the frame
        /// </summary>
        public Color color;
        /// <summary>
        /// Area of the frame to display
        /// </summary>
        public Rectangle sourceRect = new Rectangle();
        /// <summary>
        /// Area to display the image in game
        /// </summary>
        public Rectangle destinationRect = new Rectangle();
        /// <summary>
        /// Width of the frame
        /// </summary>
        public int FrameWidth;
        /// <summary>
        /// Height of the frame
        /// </summary>
        public int FrameHeight;
        /// <summary>
        /// State of the animation
        /// </summary>
        public bool Active;
        /// <summary>
        /// If the animation loops
        /// </summary>
        public bool Looping;
		/// <summary>
		/// Position to draw the sprite
		/// </summary>
        public Vector2 Position;

        public DDAnimation(Texture2D texture, Vector2 position, int frameWidth, int frameHeight, int frameCount, int frameSpeed, Color color, float scale, bool looping)
        {
            this.color = color;
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameSpeed = frameSpeed;
            this.Looping = looping;
            this.Position = position;
            this.spriteStrip = texture;

            //Set time to zero
            elapsedTime = 0;
            currentFrame = 0;

			Active = true;
        }
    }
}
