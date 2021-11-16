using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FallingStars
{
	public class Piece
	{
		private static Texture2D s_spriteSheet;
		private static readonly Dictionary<Shape, Rectangle> s_sourceRectMapping = new Dictionary<Shape, Rectangle>
		{
			{ Shape.J ,new Rectangle(0  * Common.BlockSize, 0 * Common.BlockSize, 3 * Common.BlockSize, 2 * Common.BlockSize) },
			{ Shape.L ,new Rectangle(3  * Common.BlockSize, 0 * Common.BlockSize, 3 * Common.BlockSize, 2 * Common.BlockSize) },
			{ Shape.O ,new Rectangle(6  * Common.BlockSize, 0 * Common.BlockSize, 2 * Common.BlockSize, 2 * Common.BlockSize) },
			{ Shape.S ,new Rectangle(8  * Common.BlockSize, 0 * Common.BlockSize, 3 * Common.BlockSize, 2 * Common.BlockSize) },
			{ Shape.Z ,new Rectangle(11 * Common.BlockSize, 0 * Common.BlockSize, 3 * Common.BlockSize, 2 * Common.BlockSize) },
			{ Shape.T ,new Rectangle(14 * Common.BlockSize, 0 * Common.BlockSize, 3 * Common.BlockSize, 2 * Common.BlockSize) },
			{ Shape.I ,new Rectangle(17 * Common.BlockSize, 0 * Common.BlockSize, 4 * Common.BlockSize, 1 * Common.BlockSize) },
		};

		private readonly Rectangle _sourceRect;

		public static void LoadContent(ContentManager content)
		{
			s_spriteSheet = content.Load<Texture2D>("tetris");
		}

		public Piece(Shape type, int position)
		{
			Type = type;
			_sourceRect = s_sourceRectMapping[type];
			Width = _sourceRect.Width / 30;
			Height = _sourceRect.Height / 30;
			Position = new Vector2(position, 0);
		}

		public void Update()
		{
			Position = new Vector2(Position.X, Position.Y + 1);

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Begin();
			spriteBatch.Draw(s_spriteSheet, Position * 30, _sourceRect, Color.White);
			spriteBatch.End();
		}

		public Shape Type { get; }

		public int Width { get; }

		public int Height { get; }

		public Vector2 Position { get; private set; }

		public enum Shape
		{
			I,
			O,
			T,
			S,
			Z,
			J,
			L
		}

	}
}
