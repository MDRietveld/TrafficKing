using System;
using Microsoft.Xna.Framework;

namespace TrafficKing
{
	public interface IState
	{
		PoliceBoat police { get; set; }
		void Message();
		void Movement(GameTime gameTime);
		void Collision(ICollidable gameObject);

	}
}

