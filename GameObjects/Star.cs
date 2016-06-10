using System;
using Microsoft.Xna.Framework;

namespace TrafficKing
{
	public class Star : GameObject
	{
		public override void Update(GameTime gameTime){
		}
		public Star (Vector2 pos) : base(pos)
		{
			Texture = AssetsManager.Star;
		}
	}
}

