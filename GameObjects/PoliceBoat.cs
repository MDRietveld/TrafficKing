using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficKing
{
	public class PoliceBoat : GameObject, IObserver, ICollidable
    {
        public Vector2 Direction;
		public DrugsBoat drugsBoat;
		public IState state;
		public Vector2 AggSpeed;


		public PoliceBoat(Vector2 position, DrugsBoat d) : base(position)
        {
			state = new Floating (this);
			drugsBoat = d;
			PoliceStation.Register (this);
            Texture     = AssetsManager.Policeboat;
            Origin      = new Vector2(Texture.Width / 2, Texture.Height / 2);
            Rotation    = MathHelper.ToRadians(45);
            Speed       = new Vector2(2, 2);
			AggSpeed    = new Vector2 (4, 4);

            if (Game1.Instance.Random.NextDouble() < 0.5)
                Direction = new Vector2(1, -1);
            else
                Direction = new Vector2(-1, -1);
        }

		public void OnCollision (ICollidable gameObject)
		{
			state.Collision (gameObject);

		}

		public void OnPackage ()
		{
			state.Message ();
		}

		public void ChangeState(IState s){
			state = s;
		}

        public override void Update(GameTime gameTime)
        {
			state.Movement(gameTime);

        }

        public void checkCollision()
        {
            Rectangle ViewBounds = Game1.Instance.GraphicsDevice.Viewport.Bounds;
            if (Position.X - Origin.X < 0 || Position.X + Origin.X > ViewBounds.Right) Direction.X *= -1;
            if (Position.Y - Origin.X < 0 || Position.Y + Origin.X > ViewBounds.Bottom - 60) Direction.Y *= -1;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Direction.X == 1 &&  Direction.Y == 1)   Rotation = MathHelper.ToRadians(45);
            if (Direction.X == 1 &&  Direction.Y == -1)  Rotation = MathHelper.ToRadians(-45);
            if (Direction.X == -1 && Direction.Y == 1)   Rotation = MathHelper.ToRadians(135);
            if (Direction.X == -1 && Direction.Y == -1)  Rotation = MathHelper.ToRadians(-135);

            base.Draw(spriteBatch);
        }
    }
}
