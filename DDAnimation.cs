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
        Texture2D spriteStrip;
        /// <summary>
        /// Sprite scale.
        /// </summary>
        float scale;
        /// <summary>
        /// Time since frame has been updated
        /// </summary>
        int elapsedTime;
        /// <summary>
        /// Time a frame is displayed
        /// </summary>
        int frameTime;
        /// <summary>
        /// Total number of frames
        /// </summary>
        int frameCount;
        /// <summary>
        /// Index of the current frame we are displaying
        /// </summary>
        int currentFrame;
        /// <summary>
        /// Color of the frame
        /// </summary>
        Color color;
        /// <summary>
        /// Area of the frame to display
        /// </summary>
        Rectangle sourceRect = new Rectangle();
        /// <summary>
        /// Area to display the image in game
        /// </summary>
        Rectangle destinationRect = new Rectangle();
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

        public Vector2 Position;

        public DDAnimation(Texture2D texture, Vector2 position, int frameWidth, int frameHeight, int frameCount, int frameTime, Color color, float scale, bool looping)
        {
            this.color = color;
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frameTime;
            this.Looping = looping;
            this.Position = position;
            this.spriteStrip = texture;

            //Set time to zero
            elapsedTime = 0;
            currentFrame = 0;

			Active = true;
        }

        public void Update(GameTime gameTime)
        {
			if (!Active) return;

			//Update elapsed time
			elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

			//Switch frames
			if (elapsedTime > frameTime)
			{
				currentFrame++;

				if (!Looping) Active = false;
			}

			//Reset elapsed time
			elapsedTime = 0;
			
			//Grab the frame from the strip
			sourceRect = new Rectangle(currentFrame * FrameWidth, 0, FrameWidth, FrameHeight);
			destinationRect = new Rectangle((int)Position.X - (int)(FrameWidth * scale) / 2, (int)Position.Y - (int)(FrameHeight * scale) / 2, (int)(FrameWidth * scale), (int)(FrameHeight * scale));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
			if (Active) spriteBatch.Draw(spriteStrip, destinationRect, sourceRect, color);
        }
    }
}
