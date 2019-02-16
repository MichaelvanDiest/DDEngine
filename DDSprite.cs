using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace DDEngine
{
	class DDSprite : DDObject
    {
		/// <summary>
		/// The position.
		/// </summary>
		public Vector2 Position;
		/// <summary>
		/// Sprite Effect
		/// </summary>
		public SpriteEffects spriteEffect = SpriteEffects.None;
		
		/// <summary>
		/// Animation
		/// </summary>
		private DDAnimationManager animation;
		
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		/// <param name="X">X.</param>
		/// <param name="Y">Y.</param>
        public DDSprite(int X = 0, int Y = 0)
        {
			//Set Positionn
			Position = new Vector2(X, Y);
		}

		/// <summary>
		/// Loads the sprite into the content manager.
		/// </summary>
		/// <param name="Content">Content.</param>
		public override void LoadContent(ContentManager Content)
		{
			animation.LoadContent(Content);
			base.LoadContent(Content);
		}

		/// <summary>
		/// Update event.
		/// </summary>
		/// <param name="gameTime"></param>
		public override void Update(GameTime gameTime)
		{
			if (animation != null)
			{
				animation.spriteEffect = spriteEffect;
				animation.Update(gameTime, Position);
			}
		}

		/// <summary>
		/// Draw the sprite at its position.
		/// </summary>
		/// <returns>The draw.</returns>
		/// <param name="spriteBatch">Sprite batch.</param>
		public override void Draw(SpriteBatch spriteBatch)
		{
			if (animation != null) animation.Draw(spriteBatch);
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
			if (animation == null) animation = new DDAnimationManager();

			animation.Add(animationName, spritePath, frameWidth, frameHeight, frameCount, frameSpeed, scale, looping);
		}

		/// <summary>
		/// Play an animation.
		/// </summary>
		/// <param name="animationName"></param>
		public void playAnimation(string animationName)
		{
			animation.Play(animationName);
		}
    }
}