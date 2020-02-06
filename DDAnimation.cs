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
        /// Width of the frame
        /// </summary>
        public int frameWidth;
        /// <summary>
        /// Height of the frame
        /// </summary>
        public int frameHeight;
        /// <summary>
        /// If the animation loops
        /// </summary>
        public bool looping;

        public DDAnimation(string spritePath, int frameWidth, int frameHeight, int frameCount, int frameSpeed, float scale, bool looping)
        {
            this.spritePath = spritePath;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameSpeed = frameSpeed;
            this.scale = scale;
            this.looping = looping;
            currentFrame = 0;
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
