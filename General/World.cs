using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficKing
{
    public class World
    {
        private DrugsBoat _drugsBoat;
		private List<GameObject> _gameobjects = new List<GameObject>();
		public bool busted = false;
		List<Star> stars = new List<Star> ();
		int y = 400;
        public World()
        {

			_gameobjects.Add (new Package(new Vector2(Game1.Instance.Random.Next(0, 100),Game1.Instance.Random.Next(150, 250))));
			_gameobjects.Add (new Package(new Vector2(Game1.Instance.Random.Next(0, 100),Game1.Instance.Random.Next(450, 550))));
			_gameobjects.Add (new Package(new Vector2(Game1.Instance.Random.Next(200, 300),Game1.Instance.Random.Next(0, 100))));
			_gameobjects.Add (new Package(new Vector2(Game1.Instance.Random.Next(200, 300),Game1.Instance.Random.Next(450, 550))));
			_gameobjects.Add (new Package(new Vector2(Game1.Instance.Random.Next(400, 500),Game1.Instance.Random.Next(350, 450))));
			_gameobjects.Add (new Package(new Vector2(Game1.Instance.Random.Next(400, 500),Game1.Instance.Random.Next(150, 250))));
			_gameobjects.Add (new Package(new Vector2(Game1.Instance.Random.Next(600, 700),Game1.Instance.Random.Next(450, 550))));
			_gameobjects.Add (new Package(new Vector2(Game1.Instance.Random.Next(600, 700),Game1.Instance.Random.Next(250, 350))));

			_gameobjects.Add (_drugsBoat  = new DrugsBoat(new Vector2(100, 100)));
			_gameobjects.Add (new PoliceBoat(new Vector2(600, 580), _drugsBoat));

        }


        // __________________________________________________________________________________________
        // all update functions
        // __________________________________________________________________________________________
        public void Update(GameTime gameTime)
        {
			if (!busted) {
				foreach (GameObject g in _gameobjects) {
					g.Update (gameTime);
				}

				CheckCollisions ();
				CheckRemovables ();
			} else {
			}
        }

		public void AddPolice(){
			_gameobjects.Add (new PoliceBoat(new Vector2(Game1.Instance.Random.Next(580, 620), 580), _drugsBoat));
		}

		public void Danger(){
			stars.Add (new Star(new Vector2(y, 10)));
			y += 50;
		}
		private void CheckCollisions(){

			List<ICollidable> IC = new List<ICollidable> (_gameobjects.OfType<ICollidable>());


			foreach(ICollidable obj1 in IC) {
				bool hit = false;
				foreach (ICollidable obj2 in IC) {
					if(obj1 != obj2) {
						if (obj1.Rectangle.Intersects (obj2.Rectangle)) {
							obj1.OnCollision (obj2);
							obj2.OnCollision (obj1);
							hit = true;
						}
					}
				}
				if (hit)
					break;
			}

		}
		public void CheckRemovables() 
		{

			for(int i = _gameobjects.Count - 1; i >= 0; i--) {
				GameObject go = _gameobjects[i];

				// remove
				if(go is IRemovable) {

					IRemovable rmv = go as IRemovable;

					if(rmv.RemoveMe == true) {
						_gameobjects.Remove(go);
					}
				}
			}



		}
        // __________________________________________________________________________________________
        // draw
        // __________________________________________________________________________________________
        public void Draw(SpriteBatch spriteBatch)
        {
			
            //Draw background
            spriteBatch.Draw(AssetsManager.Dock, Vector2.Zero, Color.White);

			if (busted) {
				spriteBatch.Draw (AssetsManager.Busted, new Vector2 (0, 0), Color.White);
				spriteBatch.DrawString (AssetsManager.Verdana, "You got caught, press space to play again", new Vector2 (300, 350), Color.White);
			}

			foreach (GameObject g in _gameobjects) {
				g.Draw (spriteBatch);
			}
        }
    }
}
