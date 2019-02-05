using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DDEngine
{
	class DDAnimationManager : DDObject
	{
		/// <summary>
		/// Is the animated sprite active?
		/// </summary>
		public bool Active = true;
		/// <summary>
		/// List of all the animations
		/// </summary>
		private Dictionary<string, DDAnimation> animations;
		/// <summary>
		/// Current animation playing
		/// </summary>
		private DDAnimation curAnimation;
		/// <summary>
        /// Time since frame has been updated
        /// </summary>
        private int elapsedTime = 0;

		public void Update(GameTime gameTime, Vector2 Position)
		{
			if (!curAnimation.Active) return;

			//Update elapsed time
			elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

			//Switch frames
			if (elapsedTime > curAnimation.frameSpeed)
			{
				curAnimation.currentFrame++;

				//If the current frame is equal to or bigger the frame count then reset the animation
				if (curAnimation.currentFrame >= curAnimation.frameCount)
				{
					curAnimation.currentFrame = 0;

					if (!curAnimation.Looping) curAnimation.Active = false;
				}

				//Reset elapsed time
				elapsedTime = 0;
			}

			//Set position
			curAnimation.Position = Position;
			//Grab the frame from the strip
			curAnimation.sourceRect = new Rectangle(curAnimation.currentFrame * curAnimation.FrameWidth, 0, curAnimation.FrameWidth, curAnimation.FrameHeight);
			curAnimation.destinationRect = new Rectangle((int)curAnimation.Position.X - (int)(curAnimation.FrameWidth * curAnimation.scale) / 2, (int)curAnimation.Position.Y - (int)(curAnimation.FrameHeight * curAnimation.scale) / 2, (int)(curAnimation.FrameWidth * curAnimation.scale), (int)(curAnimation.FrameHeight * curAnimation.scale));
		}

		/// <summary>
		/// Load Content
		/// </summary>
		/// <param name="Content"></param>
		public override void LoadContent(ContentManager Content)
		{
			foreach (KeyValuePair<string, DDAnimation> anim in animations)
			{
				anim.Value.LoadContent(Content);
			}

			base.LoadContent(Content);
		}

		/// <summary>
		/// Draw the current animation
		/// </summary>
		/// <param name="spriteBatch"></param>
		public void Draw(SpriteBatch spriteBatch)
		{
			if (curAnimation != null)
			{
				if (Active) spriteBatch.Draw(curAnimation.spriteStrip, curAnimation.destinationRect, curAnimation.sourceRect, Color.White);
			}
		}

		/// <summary>
		/// Add a new animation.
		/// </summary>
		/// <param name="animationName"></param>
		/// <param name="spritePath"></param>
		/// <param name="frameWidth"></param>
		/// <param name="frameHeight"></param>
		/// <param name="frameCount"></param>
		/// <param name="frameSpeed"></param>
		/// <param name="scale"></param>
		/// <param name="looping"></param>
		public void Add(string animationName, string spritePath, int frameWidth, int frameHeight, int frameCount, int frameSpeed, float scale, bool looping)
		{
			if (animations == null) animations = new Dictionary<string, DDAnimation>();

			animations.Add(animationName, new DDAnimation(spritePath, frameWidth, frameHeight, frameCount, frameSpeed, scale, looping));
			curAnimation = animations[animationName];
		}
	}
}
