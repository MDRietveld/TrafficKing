using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TrafficKing
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        public static Game1 Instance;


        public Random Random;

        public World _world;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 700;
        }


        protected override void Initialize()
        {
            // Eerst moet de verwijzing naar de game er zijn. 
            Instance = this;
            Random = new Random();
            // Daarna kunnen alle assets ingeladen worden. Dit gebeurt door base.Initialize() aan te roepen (deze roept LoadContent aan)
            base.Initialize();


            _world = new World();

        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            AssetsManager am = new AssetsManager();

        }

        protected override void Update(GameTime gameTime)
        {
			KeyboardState keyb = Keyboard.GetState ();
			_world.Update (gameTime);
			if(_world.busted && keyb.IsKeyDown(Keys.Space)){
				_world = new World ();
				_world.busted = false;
			}
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(42, 167, 173));

            spriteBatch.Begin();
            _world.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
