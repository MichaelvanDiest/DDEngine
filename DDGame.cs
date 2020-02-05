using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DDEngine
{
	public class DDGame
	{
		/// <summary>
		/// The instance.
		/// </summary>
		private static DDGame _instance;
		/// <summary>
		/// The native render target.
		/// </summary>
		private RenderTarget2D _nativeRenderTarget;
		/// <summary>
		/// Gets the content.
		/// </summary>
		/// <value>The content.</value>
		public ContentManager Content { get; private set; }
		/// <summary>
		/// Gets the graphics.
		/// </summary>
		/// <value>The graphics.</value>
		public GraphicsDeviceManager Graphics { get; private set;}
		/// <summary>
		/// Gets the dimensions.
		/// </summary>
		/// <value>The dimensions.</value>
		public Vector3 Dimensions { get; private set; }
		/// <summary>
		/// Current state.
		/// </summary>
		public DDState State;
		/// <summary>
		/// The color of the background.
		/// </summary>
		public Color BackgroundColor = Color.Black;
		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static DDGame Instance
		{
			get
			{
				if (_instance == null) _instance = new DDGame();

				return _instance;
			}
		}
		private DDGame() { }

		/// <summary>
		/// Initialize the specified graphics, State, Width, Height and Zoom.
		/// </summary>
		/// <returns>The initialize.</returns>
		/// <param name="graphics">Graphics.</param>
		/// <param name="State">State.</param>
		/// <param name="Width">Width.</param>
		/// <param name="Height">Height.</param>
		/// <param name="Zoom">Zoom.</param>
		public void Initialize(GraphicsDeviceManager graphics, DDState State, int Width, int Height, int Zoom = 1)
		{
			this.Graphics = graphics;
			this.Dimensions = new Vector3(Width, Height, Zoom);
            this.State = State;

			State.Initialize();

			_nativeRenderTarget = new RenderTarget2D(Graphics.GraphicsDevice, (int)Dimensions.X, (int)Dimensions.Y);

			Graphics.PreferredBackBufferWidth = (int)(Dimensions.X*Dimensions.Z);
			Graphics.PreferredBackBufferHeight = (int)(Dimensions.Y*Dimensions.Z);
			Graphics.ApplyChanges();
		}
		/// <summary>
		/// Loads the content.
		/// </summary>
		/// <param name="Content">Content.</param>
		public void LoadContent(ContentManager Content)
		{
			this.Content = new ContentManager(Content.ServiceProvider, "Content");
			State.LoadContent();
		}
		/// <summary>
		/// Unloads the content.
		/// </summary>
		public void UnloadContent()
		{
			State.UnloadContent();
		}
		/// <summary>
		/// Update the specified gameTime.
		/// </summary>
		/// <returns>The update.</returns>
		/// <param name="gameTime">Game time.</param>
		public void Update(GameTime gameTime)
		{
			State.Update(gameTime);
		}
		/// <summary>
		/// Draw the specified spriteBatch.
		/// </summary>
		/// <returns>The draw.</returns>
		/// <param name="spriteBatch">Sprite batch.</param>
		public void Draw(SpriteBatch spriteBatch)
		{
			Graphics.GraphicsDevice.SetRenderTarget(_nativeRenderTarget);
			Graphics.GraphicsDevice.Clear(BackgroundColor);
			spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null, State.Camera.TranslationMatrix);
			State.Draw(spriteBatch);
			spriteBatch.End();
			Graphics.GraphicsDevice.SetRenderTarget(null);
			spriteBatch.Begin(samplerState: SamplerState.PointClamp);
			spriteBatch.Draw(_nativeRenderTarget, new Rectangle(0, 0, (int)(Dimensions.X*Dimensions.Z), (int)(Dimensions.Y*Dimensions.Z)), Color.White);
			spriteBatch.End();
		}
	}
}