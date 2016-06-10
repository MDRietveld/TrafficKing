using System;
using Microsoft.Xna.Framework;

namespace TrafficKing
{
	public class Aggressive : IState
	{
		public PoliceBoat police { get; set; }
		float time = 0;
		public Aggressive (PoliceBoat p)
		{
			police = p;
		}

		public void Message ()
		{
			
		}

		public void Movement (GameTime gameTime)
		{
			time += (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (time > 3) {
				police.ChangeState (new Floating(police));
			}
			police.Position += police.AggSpeed * police.Direction;

			police.checkCollision();
		}

		public void Collision (ICollidable gameObject)
		{
			if (gameObject is Arrestable) {
				police.drugsBoat.Arrested ();
				Game1.Instance._world.busted = true;
			}
		}
	}
}


