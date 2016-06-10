using System;
using Microsoft.Xna.Framework;

namespace TrafficKing
{
	public class Floating : IState
	{
		public PoliceBoat police { get; set; }
		public Floating (PoliceBoat p)
		{
			police = p;
		}

		public void Message ()
		{
			police.ChangeState (new Patrolling(police));
		}

		public void Movement (GameTime gameTime)
		{
			
		}

		public void Collision (ICollidable gameObject)
		{
			
		}
	}
}

