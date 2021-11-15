using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FallingStars
{
	public class FallingStarsGame : Game
	{
		private readonly GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private Piece _piece;

        private const double TickTime = 1.0;
        private double _lastUpdated = 0.0;

		public FallingStarsGame()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			_graphics.PreferredBackBufferWidth = Common.BoardWidth * Common.BlockSize;
			_graphics.PreferredBackBufferHeight = Common.BoardHeight * Common.BlockSize;
			_graphics.ApplyChanges();

			_piece = new Piece(Piece.Shape.J, 5);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			Piece.LoadContent(Content);
		}

		protected override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				Exit();
			}

			if (gameTime.TotalGameTime.TotalSeconds >= _lastUpdated + TickTime)
			{
				_lastUpdated += TickTime;
				_piece.Update();
			}

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			_piece.Draw(_spriteBatch);

			base.Draw(gameTime);
		}
	}
}
