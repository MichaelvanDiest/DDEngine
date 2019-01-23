using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DDEngine.DDEngine
{
	class DDAnimationManager
	{
		private DDAnimation curAnimation;

		public void Update(GameTime gameTime)
		{
			if (!curAnimation.Active) return;

			//Update elapsed time
			curAnimation.elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

			//Switch frames
			if (curAnimation.elapsedTime > curAnimation.frameSpeed)
			{
				curAnimation.currentFrame++;

				//If the current frame is equal to or bigger the frame count then reset the animation
				if (curAnimation.currentFrame >= curAnimation.frameCount)
				{
					curAnimation.currentFrame = 0;

					if (!curAnimation.Looping) curAnimation.Active = false;
				}

				//Reset elapsed time
				curAnimation.elapsedTime = 0;
			}

			//Grab the frame from the strip
			curAnimation.sourceRect = new Rectangle(curAnimation.currentFrame * curAnimation.FrameWidth, 0, curAnimation.FrameWidth, curAnimation.FrameHeight);
			curAnimation.destinationRect = new Rectangle((int)curAnimation.Position.X - (int)(curAnimation.FrameWidth * curAnimation.scale) / 2, (int)curAnimation.Position.Y - (int)(curAnimation.FrameHeight * curAnimation.scale) / 2, (int)(curAnimation.FrameWidth * curAnimation.scale), (int)(curAnimation.FrameHeight * curAnimation.scale));
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			if (curAnimation.Active) spriteBatch.Draw(curAnimation.spriteStrip, curAnimation.destinationRect, curAnimation.sourceRect, curAnimation.color);
		}

		public void Add()
		{
			
		}
	}
}
