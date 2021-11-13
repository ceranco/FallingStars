using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FallingStars
{
	public class FallingStarsGame : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private Piece piece;

		double tickTime = 1.0;
		double lastUpdated = 0;

		public FallingStarsGame()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			graphics.PreferredBackBufferWidth = Common.BoardWidth * Common.BlockSize;
			graphics.PreferredBackBufferHeight = Common.BoardHeight * Common.BlockSize;
			graphics.ApplyChanges();

			piece = new Piece(Piece.Shape.J, 5);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			Piece.LoadContent(Content);
		}

		protected override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				Exit();
			}

			if (gameTime.TotalGameTime.TotalSeconds >= lastUpdated + tickTime)
			{
				lastUpdated += tickTime;
				piece.Update();
			}

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			piece.Draw(spriteBatch);

			base.Draw(gameTime);
		}
	}
}
