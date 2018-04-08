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
            grassImage,
            dummyTexture,
            closeImage;

        private SpriteFont titleFont, spriteFont;

        public MenuManager MenuManager { get; private set; } = null;
        public StoreManager StoreManager { get; private set; } = null;

        private readonly Dirt[] dirtFields = new Dirt[4];
        private MouseState prevMouseState, mouseState;

        private Boolean alertActive;
        private string alertTitle, alertBody;

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

            StoreManager.SetSeedInventoryAmount(PlantList.Ananas, 10);

            //Alle plaatjes van de vruchten
            plantzaadjesImage = Content.Load<Texture2D>("Images/plantzaadjes");
            storeButtonImage = Content.Load<Texture2D>("Images/ic_shopping_basket_black_24dp_2x");
            grassImage = Content.Load<Texture2D>("Images/grass");
            closeImage = Content.Load<Texture2D>("Images/close_black");

            titleFont = Content.Load<SpriteFont>("AlertTitle");
            spriteFont = Content.Load<SpriteFont>("Arial");

            dummyTexture = new Texture2D(graphics.GraphicsDevice, 1, 1);
            dummyTexture.SetData(new Color[] { Color.White });
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

            if (alertActive)
            {
                if (mouseState.LeftButton == ButtonState.Pressed &&
                    prevMouseState.LeftButton == ButtonState.Released)
                    alertActive = false;
                return;
            }

            if (!MenuManager.Collide(mouseState) && !StoreManager.IsActive)
            {
                bool collidedWithDirt = false;
                foreach (var dirtField in dirtFields)
                {
                    if (mouseState.LeftButton == ButtonState.Pressed &&
                        prevMouseState.LeftButton == ButtonState.Released &&
                        dirtField.CollidesWith(mouseState))
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


            if (mouseState.LeftButton == ButtonState.Pressed &&
                prevMouseState.LeftButton == ButtonState.Released &&
                StoreManager.StoreButtonRectangle.Contains(mouseState.Position) &&
                !MenuManager.IsActive &&
                !StoreManager.IsActive)
            {
                StoreManager.IsActive = true;
                MenuManager.HideMenu();
            }


            MenuManager.Update(this, gameTime, mouseState, prevMouseState);
            StoreManager.Update(this, gameTime, mouseState, prevMouseState);

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

            spriteBatch.Draw(grassImage,
                new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight),
                Color.White);

            //Land renderen
            foreach (var field in dirtFields)
            {
//                if (!(mouseState.LeftButton == ButtonState.Pressed && field.CollidesWith(mouseState)))
                field.Draw(spriteBatch);
            }

            spriteBatch.Draw(storeButtonImage, StoreManager.StoreButtonRectangle,
                Color.White);

            MenuManager.Draw(spriteBatch, this);
            StoreManager.Draw(spriteBatch);

            if (alertActive)
            {
                spriteBatch.Draw(dummyTexture,
                    new Rectangle(100, 100, graphics.PreferredBackBufferWidth - 200, graphics.PreferredBackBufferHeight - 200),
                    Color.White);

                spriteBatch.DrawString(titleFont,
                    alertTitle, new Vector2(100 + (graphics.PreferredBackBufferWidth - 200) / 2 - (int)(titleFont.MeasureString(alertTitle).X / 2), 120),
                    Color.Black);

                spriteBatch.DrawString(spriteFont,
                    alertBody, new Vector2(100 + (graphics.PreferredBackBufferWidth - 200) / 2 - (int)(spriteFont.MeasureString(alertBody).X / 2), 250),
                    Color.Black);

                spriteBatch.Draw(closeImage,
                    new Rectangle(100 + graphics.PreferredBackBufferWidth - 255, 115, 40, 40),
                    Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ShowAlert(Color backgroundColor, string title, string body)
        {
            alertTitle = title;
            alertBody = body;
            dummyTexture.SetData(new Color[] { backgroundColor });
            alertActive = true;
        }
    }
}