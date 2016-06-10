using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficKing
{
	public class DrugsBoat : GameObject, ICollidable, IRemovable, Arrestable
    {
        private const float ROTATION_SPEED      = 0.04f;
        private const float ACCELERATION_SPEED  = 0.04f;
        private const float BRAKE_SPEED         = 0.05f;
        private const float MAX_SPEED           = 6f;
		public bool RemoveMe { get; set; }
//		List<IObserver> observer = new List<IObserver>();
        /// <summary> 
        /// Constructor          
        /// </summary>         
        /// <param name="game">verwijzing naar de Game</param>         
		public DrugsBoat(Vector2 position) : base(position)
        {
            Position = new Vector2(200, 150);
            Texture = AssetsManager.Drugsboat;
            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
        }
			

		public void OnCollision (ICollidable gameObject)
		{
			
			if (gameObject is IObserver) {
			} else {
				PoliceStation.Notify ();
//				Notify ();
//				Game1.Instance._world.AddPolice ();
			}
		}

		public void Arrested(){
			RemoveMe = true;
		}

//		public void Notify(){
//			foreach (IObserver obs in observer) {
//				obs.OnPackage ();
//			}
//		}


//		public void Register(IObserver obs){
//			observer.Add (obs);
//		}

        public override void Update(GameTime gameTime)
        {
            HandleKeyboard();

            Position += new Vector2(
                (float)(Math.Cos(Rotation)) * Speed.X,
                (float)(Math.Sin(Rotation)) * Speed.Y);
            
            // Zorg ervoor dat de boot in het scherm blijft.
            Position = Vector2.Clamp(
                    Position, 
                    Vector2.Zero, 
                    new Vector2(Game1.Instance.GraphicsDevice.Viewport.Width,
                                Game1.Instance.GraphicsDevice.Viewport.Height - 80));
        }

        private void HandleKeyboard()
        {
            KeyboardState keyboardState = Keyboard.GetState();


            if (Speed.X > 0.5 || Speed.X < -0.5)
            {
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    Rotation -= ROTATION_SPEED;
                }
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    Rotation += ROTATION_SPEED;
                }
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                if (Speed.X < MAX_SPEED || Speed.Y < MAX_SPEED)
                {
                    Speed.X += ACCELERATION_SPEED;
                    Speed.Y += ACCELERATION_SPEED;
                }
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                if (Speed.X < MAX_SPEED || Speed.Y < MAX_SPEED)
                {
                    Speed.X -= BRAKE_SPEED;
                    Speed.Y -= BRAKE_SPEED;
                }

            }
            else
            {
                if (Speed.X >= 0)
                    Speed.X -= 0.01f;
                if (Speed.Y >= 0)
                    Speed.Y -= 0.01f;
            }
        }
    }
}
