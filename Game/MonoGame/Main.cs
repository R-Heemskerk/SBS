using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        private SpriteBatch spriteBatch;
        private readonly GraphicsDeviceManager graphics;

        private Texture2D plantzaadjesImage,
            storeButtonImage,
            plantjeImage,
            grassImage;

        public MenuManager MenuManager { get; private set; } = null;
        public StoreManager StoreManager { get; private set; } = null;

        private readonly Dirt[] dirtFields = new Dirt[4];
        private MouseState prevMouseState, mouseState;
        private bool collidedWithStoreManager;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            MenuManager = new MenuManager();
            StoreManager = new StoreManager();
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
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            PlantFactory.LoadContent(Content);

            for (int i = 0; i < dirtFields.Length; i++)
            {
                dirtFields[i] = new Dirt(this, new Vector2(50 + i * 200, 50), 180, 180);
                dirtFields[i].LoadContent(Content);
            }

            MenuManager.LoadContent(graphics, Content);
            StoreManager.LoadContent(graphics, Content);

            //Alle plaatjes van de vruchten
            plantzaadjesImage = Content.Load<Texture2D>("Images/plantzaadjes");
            storeButtonImage = Content.Load<Texture2D>("Images/ic_shopping_basket_black_24dp_2x");
            plantjeImage = Content.Load<Texture2D>("Images/plantje");
            grassImage = Content.Load<Texture2D>("Images/grass");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            MenuManager = null;
            StoreManager = null;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            foreach (Dirt item in dirtFields)
            {
                item.Update(gameTime);
            }
            if (!MenuManager.Collide(mouseState))
            {
                bool collidedWithDirt = false;
                foreach (var dirtField in dirtFields)
                {
                    if (mouseState.LeftButton == ButtonState.Pressed &&
                        prevMouseState.LeftButton == ButtonState.Released &&
                        dirtField.CollidesWith(mouseState) &&
                        dirtField.Plant == null)
                    {
                        MenuManager.StartMenu(dirtField, mouseState.X, mouseState.Y);
                    }

                    if (dirtField.CollidesWith(mouseState))
                        collidedWithDirt = true;
                }

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released &&
                    !collidedWithDirt)
                    MenuManager.HideMenu();
            }
            if (StoreManager.CollidesWith(mouseState))
            {
                collidedWithStoreManager = true;
            }

            MenuManager.Update(gameTime, mouseState, prevMouseState);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            spriteBatch.Draw(grassImage, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            //Land renderen
            foreach (var field in dirtFields)
            {
//                if (!(mouseState.LeftButton == ButtonState.Pressed && field.CollidesWith(mouseState)))
                field.Draw(spriteBatch);
            }

            spriteBatch.Draw(storeButtonImage, new Rectangle(50 + 3 * 200 + (180 - 80), 100 + 180, 80, 80),
                Color.White);

            MenuManager.Draw(spriteBatch);
            StoreManager.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}