using System;
using Microsoft.Xna.Framework;

namespace TrafficKing
{
	public class Patrolling : IState
	{
		public PoliceBoat police { get; set; }
		public Patrolling (PoliceBoat p)
		{
			police = p;
		}

		public void Message ()
		{
			police.ChangeState (new Aggressive(police));
		}

		public void Movement (GameTime gameTime)
		{
			police.Position += police.Speed * police.Direction;

			police.checkCollision();
		}

		public void Collision (ICollidable gameObject)
		{
			
		}
	}
}


