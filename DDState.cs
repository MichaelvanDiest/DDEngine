using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace DDEngine
{
	public class DDState
	{
		protected ContentManager Content;

        /// <summary>
        /// Gets the members.
        /// </summary>
        /// <value>The members.</value>
		public List<DDObject> Members { get; private set; }
        /// <summary>
        /// Camera.
        /// </summary>
        public DDCamera Camera { get; private set; }

		/// <summary>
		/// Initialize this state.
		/// </summary>
        public virtual void Initialize()
        {
			Members = new List<DDObject>();
            Camera = new DDCamera();
            Camera.Initialize();
        }

        /// <summary>
        /// Create a Content Manager for the state then pass the content manager to every member.
        /// </summary>
        public virtual void LoadContent()
		{
			Content = new ContentManager(DDGame.Instance.Content.ServiceProvider, "Content");
            
			foreach (DDObject i in Members)
            {
                i.LoadContent(Content);
            }
		}

        /// <summary>
        /// Unloads the content.
        /// </summary>
		public virtual void UnloadContent()
		{
			Content.Unload();
		}

        /// <summary>
        /// Update the specified gameTime and update for every member.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="gameTime">Game time.</param>
		public virtual void Update(GameTime gameTime)
		{
			foreach (DDObject i in Members)
            {
                i.Update(gameTime);
            }
		}

        /// <summary>
        /// Draw the specified spriteBatch and draw every member.
        /// </summary>
        /// <returns>The draw.</returns>
        /// <param name="spriteBatch">Sprite batch.</param>
		public virtual void Draw(SpriteBatch spriteBatch)
		{
			foreach (DDObject i in Members)
            {
                i.Draw(spriteBatch);
            }
		}

        /// <summary>
        /// Add the specified item to this state.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="item">Item.</param>
		public DDObject Add(DDObject item)
        {
            Members.Add(item);
            return item;
        }
	}
}