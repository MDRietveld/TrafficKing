using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace TrafficKing
{
	public class Package : GameObject, ICollidable, IRemovable
	{
		public bool RemoveMe { get; set; }
		public Package (Vector2 pos) : base(pos)
		{
			Texture = AssetsManager.Drugs;

		}

		public override void Update(GameTime gameTime){
		}

		public void OnCollision (ICollidable gameobject)
		{
			RemoveMe = true;

			if (gameobject is Arrestable) {
				Game1.Instance._world.Danger ();
			}
		}
	}
}

