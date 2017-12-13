using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DDEngine
{
	public class DDStateManager
	{
		private static DDStateManager instance;
		private DDStateManager() { }

		public ContentManager Content { private set; get; }
		public Vector2 Dimensions { private set; get; }

		public static DDStateManager Instance
		{
			get
			{
				if (instance == null) instance = new DDStateManager();

				return instance;
			}
		}


		public DDStateManager()
		{
			Dimensions = new Vector2(384, 216);
		}

		public void LoadContent(ContentManager Content)
		{
			this.Content = new ContentManager(Content.ServiceProvider, "Content");
		}

		public void UnloadContent()
		{
		}

		public void Update(GameTime gameTime)
		{
		}

		public void Draw(SpriteBatch spriteBatch)
		{
		}
	}
}
