﻿using System;
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
        private SpriteBatch spriteBatch;
        private readonly GraphicsDeviceManager graphics;

        private Texture2D plantzaadjesImage,
            storeButtonImage,
            plantjeImage,
            grassImage;

        private MenuManager menuManager;
        private Dirt[] dirtFields = new Dirt[4];
        private MouseState prevMouseState, mouseState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            menuManager = new MenuManager();
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

            for (int i = 0; i < dirtFields.Length; i++)
            {
                dirtFields[i] = new Dirt(new Vector2(50 + i * 200, 50), 180, 180);
                dirtFields[i].LoadContent(Content);
            }

            menuManager.LoadContent(graphics, Content);

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
            menuManager = null;
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

            menuManager.Update(gameTime, mouseState, prevMouseState);

            if (!menuManager.Collide(mouseState))
            {
                bool collidedWithDirt = false;
                foreach (var dirtField in dirtFields)
                {
                    if (mouseState.LeftButton == ButtonState.Pressed &&
                        prevMouseState.LeftButton == ButtonState.Released &&
                        dirtField.CollidesWith(mouseState))
                    {
                        menuManager.StartMenu(dirtField, mouseState.X, mouseState.Y);
                    }

                    if (dirtField.CollidesWith(mouseState))
                        collidedWithDirt = true;
                }

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released &&
                    !collidedWithDirt)
                    menuManager.HideMenu();
            }


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

            menuManager.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}