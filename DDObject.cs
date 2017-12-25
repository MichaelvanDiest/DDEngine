using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DDEngine
{
	public class DDObject
	{
		/// <summary>
		/// Reference to the content manager.
		/// </summary>
		protected ContentManager Content;

		public virtual void LoadContent(ContentManager Content)
		{
			this.Content = Content;
		}

		/// <summary>
		/// Update loop with game time.
		/// </summary>
		/// <returns>The update.</returns>
		/// <param name="gameTime">Game time.</param>
		public virtual void Update(GameTime gameTime)
		{
		}

		/// <summary>
		/// Draw function with sprite batch.
		/// </summary>
		/// <returns>The draw.</returns>
		/// <param name="spriteBatch">Sprite batch.</param>
		public virtual void Draw(SpriteBatch spriteBatch)
		{
		}
	}
}
