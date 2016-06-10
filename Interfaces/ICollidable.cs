using System;
using Microsoft.Xna.Framework;

namespace TrafficKing
{
	public interface ICollidable
	{
		Rectangle Rectangle{ get; }
		void OnCollision(ICollidable gameObject);
	}
}

