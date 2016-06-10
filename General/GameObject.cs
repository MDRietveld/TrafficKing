using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficKing
{
    public abstract class GameObject
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public float Rotation { get; set; } // default value is 0
        public Vector2 Origin { get; set; } // default value is new Vector2(0, 0)
        public float Scale { get; set; }
        public Vector2 Speed;
        public float Alpha { get; set; }



        public GameObject(Vector2 position)
        {
            Position = position;
            Scale = 1f;
            Alpha = 1f;
            Color = Color.White;
            Speed = Vector2.Zero;
        }

		public abstract void Update (GameTime gameTime);

		public Rectangle Rectangle {
			get {
				return new Rectangle(
					(int)Position.X,
					(int)Position.Y,
					(int)(Texture.Width * Scale),
					(int)(Texture.Height * Scale)
				);
			}
		}


        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Texture,
                Position,
                null,
                Color * Alpha,
                Rotation,
                Origin,
                Scale,
                SpriteEffects.None,
                0
                );
        }
    }
}
