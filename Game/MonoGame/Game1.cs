using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public SpriteBatch SpriteBatch;

        private GraphicsDeviceManager graphics;

        private Texture2D ananasImage,
            plantzaadjesImage,
            avocadoImage,
            dragonfruitImage,
            granaatappelImage,
            guaveImage,
            lycheesImage,
            mangoImage,
            markoesaImage,
            papayaImage,
            passievruchtImage,
            storeButtonImage;

        private MenuManager menuManager = new MenuManager();
        private Dirt[] dirtFields = new Dirt[4];
        private MouseState prevState, newState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            this.IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 200 * 4 + 100;
            graphics.PreferredBackBufferHeight = 400;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            for (int i = 0; i < dirtFields.Length; i++)
            {
                dirtFields[i] = new Dirt(new Vector2(50 + i * 200, 50), 180, 180);
                dirtFields[i].LoadContent(Content);
            }

            //Alle plaatjes van de vruchten
            ananasImage = Content.Load<Texture2D>("Images/ananas");
            plantzaadjesImage = Content.Load<Texture2D>("Images/plantzaadjes");
            avocadoImage = Content.Load<Texture2D>("Images/avocado");
            dragonfruitImage = Content.Load<Texture2D>("Images/dragonfruit");
            granaatappelImage = Content.Load<Texture2D>("Images/granaatappel");
            guaveImage = Content.Load<Texture2D>("Images/guave");
            lycheesImage = Content.Load<Texture2D>("Images/lychees");
            mangoImage = Content.Load<Texture2D>("Images/mango");
            markoesaImage = Content.Load<Texture2D>("Images/Markoesa");
            papayaImage = Content.Load<Texture2D>("Images/papaya");
            passievruchtImage = Content.Load<Texture2D>("Images/passievrucht");
            storeButtonImage = Content.Load<Texture2D>("Images/ic_shopping_basket_black_24dp_2x");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            menuManager = null;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            newState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            prevState = newState;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.ForestGreen);

            SpriteBatch.Begin();

            //Land renderen
            foreach (var field in dirtFields)
            {
                if (!(newState.LeftButton == ButtonState.Pressed && field.CollidesWith(newState)))
                    field.Draw(SpriteBatch);
            }

            SpriteBatch.Draw(storeButtonImage, new Rectangle(50 + 3 * 200 + (180 - 80), 100 + 180, 80, 80), Color.White);

            menuManager.Draw(SpriteBatch);
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}