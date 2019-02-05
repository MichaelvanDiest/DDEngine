using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DDEngine
{
    class DDAnimation : DDObject
    {
        /// <summary>
        /// Sprite Sheet
        /// </summary>
        public Texture2D spriteStrip;
		/// <summary>
		/// Path to the image.
		/// </summary>
		private string spritePath;
        /// <summary>
        /// Sprite scale.
        /// </summary>
        public float scale;
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

        public DDAnimation(string spritePath, int frameWidth, int frameHeight, int frameCount, int frameSpeed, float scale, bool looping)
        {
			this.spritePath = spritePath;
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameSpeed = frameSpeed;
			this.scale = scale;
            this.Looping = looping;

            //Set time to zero
            currentFrame = 0;

			Active = true;
        }

		/// <summary>
		/// Load Content
		/// </summary>
		/// <param name="Content"></param>
		public override void LoadContent(ContentManager Content)
		{
			spriteStrip = Content.Load<Texture2D>(spritePath);
			base.LoadContent(Content);
		}
    }
}
