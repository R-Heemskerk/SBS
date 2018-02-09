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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D dirtImage, ananasImage, plantzaadjesImage, avocadoImage, dragonfruitImage, granaatappelImage, guaveImage, lycheesImage, mangoImage, MarkoesaImage, papayaImage, passievruchtImage;
        MenuManager menuManager = new MenuManager();

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
            // TODO: Add your initialization logic here

            base.Initialize();

            this.IsMouseVisible = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            dirtImage = Content.Load<Texture2D>("Images/dirt");
            ananasImage = Content.Load<Texture2D>("Images/ananas");
            plantzaadjesImage = Content.Load<Texture2D>("Images/plantzaadjes");
            avocadoImage = Content.Load<Texture2D>("Images/avocado");
            dragonfruitImage = Content.Load<Texture2D>("Images/dragonfruit");
            granaatappelImage = Content.Load<Texture2D>("Images/granaatappel");
            guaveImage = Content.Load<Texture2D>("Images/guave");
            lycheesImage = Content.Load<Texture2D>("Images/lychees");
            mangoImage = Content.Load<Texture2D>("Images/mango");
            MarkoesaImage = Content.Load<Texture2D>("Images/Markoesa");
            papayaImage = Content.Load<Texture2D>("Images/papaya");
            passievruchtImage = Content.Load<Texture2D>("Images/passievrucht");
            //Alle plaatjes van de vruchten. 


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.ForestGreen);

            spriteBatch.Begin();

            int dirtImageSize = 180;

            spriteBatch.Draw(dirtImage, new Rectangle(50, 50, dirtImageSize, dirtImageSize), Color.White);
            spriteBatch.Draw(dirtImage, new Rectangle(50, 250, dirtImageSize, dirtImageSize), Color.White);
            spriteBatch.Draw(dirtImage, new Rectangle(250, 50, dirtImageSize, dirtImageSize), Color.White);
            spriteBatch.Draw(dirtImage, new Rectangle(250, 250, dirtImageSize, dirtImageSize), Color.White);

            menuManager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
