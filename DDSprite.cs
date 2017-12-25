﻿using System;
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
		/// The path for the sprite.
		/// </summary>
		private String path;
		/// <summary>
		/// The texture for the sprite.
		/// </summary>
		private Texture2D image;

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
			base.LoadContent(Content);
			image = Content.Load<Texture2D>(path);
		}

		/// <summary>
		/// Draw the sprite at its position.
		/// </summary>
		/// <returns>The draw.</returns>
		/// <param name="spriteBatch">Sprite batch.</param>
		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(image, Position, Color.White);
			base.Draw(spriteBatch);
		}

		/// <summary>
		/// Loads the sprite.
		/// </summary>
		/// <param name="path">Path.</param>
		public void loadSprite(String path)
		{
			this.path = path;
		}
    }
}