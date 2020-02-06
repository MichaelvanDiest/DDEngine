using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace DDEngine
{
	class DDSprite : DDObject
    {
		/// <summary>
		/// Position.
		/// </summary>
		protected Vector2 position;
		public Vector2 Position { get { return position; } }
        /// <summary>
		/// List of all the animations
		/// </summary>
		private Dictionary<string, DDAnimation> animations;
		/// <summary>
		/// Current animation playing.
		/// </summary>
		private DDAnimation curAnimation;
		/// <summary>
		/// Previous animation playing.
		/// </summary>
		private DDAnimation prevAnimation;
		/// <summary>
        /// Area to display the image in game
        /// </summary>
        private Rectangle destinationRect = new Rectangle();
		/// <summary>
		/// Time since frame has been updated
		/// </summary>
		private int elapsedTime = 0;
		/// <summary>
		/// BoundingBox for collision.
		/// </summary>
		protected BoundingBox boundingBox;
		/// <summary>
		/// Sprite Effect
		/// </summary>
		protected SpriteEffects spriteEffect;
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		/// <param name="X">X.</param>
		/// <param name="Y">Y.</param>
        public DDSprite(int X = 0, int Y = 0)
        {
			position = new Vector2(X, Y);
			spriteEffect = SpriteEffects.None;
            animations = new Dictionary<string, DDAnimation>();
		}
		/// <summary>
		/// Loads the sprite into the content manager.
		/// </summary>
		/// <param name="Content">Content.</param>
		public override void LoadContent(ContentManager Content)
		{
			foreach (KeyValuePair<string, DDAnimation> anim in animations)
			{
				anim.Value.LoadContent(Content);
			}
			base.LoadContent(Content);
		}
		/// <summary>
		/// Update event.
		/// </summary>
		/// <param name="gameTime"></param>
		public override void Update(GameTime gameTime)
		{
			//Grab the frame from the strip
			curAnimation.sourceRect = new Rectangle(curAnimation.currentFrame * curAnimation.frameWidth, 0, curAnimation.frameWidth, curAnimation.frameHeight);
			destinationRect = new Rectangle((int)Position.X - (int)(curAnimation.frameWidth * curAnimation.scale) / 2, (int)Position.Y - (int)(curAnimation.frameHeight * curAnimation.scale) / 2, (int)(curAnimation.frameWidth * curAnimation.scale), (int)(curAnimation.frameHeight * curAnimation.scale));
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

					if (!curAnimation.looping) curAnimation.Active = false;
				}

				//Reset elapsed time
				elapsedTime = 0;
			}
		}
		/// <summary>
		/// Draw the sprite at its position.
		/// </summary>
		/// <returns>The draw.</returns>
		/// <param name="spriteBatch">Sprite batch.</param>
		public override void Draw(SpriteBatch spriteBatch)
		{
			if (curAnimation != null)
			{
				Texture2D _texture;
				_texture = new Texture2D(DDGame.Instance.Graphics.GraphicsDevice, 1, 1);
				_texture.SetData(new Color[] { Color.Red });
				spriteBatch.Draw(_texture, destinationRect, Color.White);
				spriteBatch.Draw(curAnimation.spriteStrip, destinationRect, curAnimation.sourceRect, Color.White, 0, Vector2.Zero, spriteEffect, 0f);
			}
		}
		/// <summary>
		/// Adding animated sprite.
		/// </summary>
		/// <param name="animationName"></param>
		/// <param name="spritePath"></param>
		/// <param name="frameWidth"></param>
		/// <param name="frameHeight"></param>
		/// <param name="frameCount"></param>
		/// <param name="frameSpeed"></param>
		/// <param name="scale"></param>
		/// <param name="looping"></param>
		public void addAnimation(string animationName, string spritePath, int frameWidth, int frameHeight, int frameCount, int frameSpeed, float scale, bool looping)
		{
			animations.Add(animationName, new DDAnimation(spritePath, frameWidth, frameHeight, frameCount, frameSpeed, scale, looping));
			curAnimation = animations[animationName];
		}
		/// <summary>
		/// Play an animation.
		/// </summary>
		/// <param name="animationName"></param>
		public void playAnimation(string animationName)
		{
			prevAnimation = curAnimation;
			curAnimation = animations[animationName];
			//Reset previous animation's Active state if its different than the current animation
			if (prevAnimation != curAnimation) prevAnimation.Active = true;
		}
    }
}