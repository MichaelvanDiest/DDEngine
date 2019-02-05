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
		/// Animation
		/// </summary>
		public DDAnimationManager Animation = new DDAnimationManager();
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		/// <param name="X">X.</param>
		/// <param name="Y">Y.</param>
        public DDSprite(int X = 0, int Y = 0)
        {
			//Set Positionn
			Position = new Vector2();
            Position.X = X;
            Position.Y = Y;
        }

		/// <summary>
		/// Loads the sprite into the content manager.
		/// </summary>
		/// <param name="Content">Content.</param>
		public override void LoadContent(ContentManager Content)
		{
			Animation.LoadContent(Content);
			base.LoadContent(Content);
		}

		public override void Update(GameTime gameTime)
		{
			if (Animation != null) Animation.Update(gameTime, Position);
		}

		/// <summary>
		/// Draw the sprite at its position.
		/// </summary>
		/// <returns>The draw.</returns>
		/// <param name="spriteBatch">Sprite batch.</param>
		public override void Draw(SpriteBatch spriteBatch)
		{
			//spriteBatch.Draw(image, Position, Color.White);
			Animation.Draw(spriteBatch);
		}
    }
}