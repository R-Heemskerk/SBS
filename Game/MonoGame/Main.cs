using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    /// <summary>
    /// Dit is waar de game start. Deze class is de link tussen ons spel en MonoGame. 
    /// Deze class zorgt ook ervoor dat alle objecten worden geladen en worden weergegeven.
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

        /// <summary>
        /// Constructor voor Main
        /// </summary>
        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            MenuManager = new MenuManager();
            StoreManager = new StoreManager();
        }

        /// <summary>
        /// Initialize zorgt voor alle instellingen worden geladen voordat het spel start
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
        /// LoadContent laad alle objecten. Dit gebeurd maar één keer tijdens het laden van het spel.
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
        /// UnloadContent zal alle objecten weggooien. Dit wordt alleen geroepen wanneer het spel stopt.
        /// </summary>
        protected override void UnloadContent()
        {
            MenuManager = null;
            StoreManager = null;
        }

        /// <summary>
        /// Update is het brein van het spel. 
        /// Dit zorgt ervoor dat alle knoppen werken en dat er interactie zit in het spel.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// <seealso cref="GameTime"/>
        protected override void Update(GameTime gameTime)
        {
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Alle dirt objecten bijwerken.
            foreach (Dirt item in dirtFields)
            {
                item.Update(gameTime);
            }

            // Als er een alert actief is zal deze prioriteit hebben en als eerst muis events verwerken. 
            // Ook wordt de rest van het beeld niet meer klikbaar.
            if (alertActive)
            {
                if (mouseState.LeftButton == ButtonState.Pressed &&
                    prevMouseState.LeftButton == ButtonState.Released)
                    alertActive = false;
                return;
            }

            // Laat een menu verschijnen als er op een dirt object wordt gedrukt.
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

                // Laat het menu verdwijnen als er buiten het menu wordt gedrukt.
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released &&
                    !collidedWithDirt)
                    MenuManager.HideMenu();
            }

            // Laat de winkel zien zodra er op de afbeelding van het winkelmandje wordt gedrukt.
            if (mouseState.LeftButton == ButtonState.Pressed &&
                prevMouseState.LeftButton == ButtonState.Released &&
                StoreManager.StoreButtonRectangle.Contains(mouseState.Position) &&
                !MenuManager.IsActive &&
                !StoreManager.IsActive)
            {
                StoreManager.IsActive = true;
                MenuManager.HideMenu();
            }

            // Zorgt ervoor dat de menu en de winkel muis events kan verwerken.
            MenuManager.Update(this, gameTime, mouseState, prevMouseState);
            StoreManager.Update(this, gameTime, mouseState, prevMouseState);

            base.Update(gameTime);
        }

        /// <summary>
        /// Het tekenen van visuele objecten.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// <seealso cref="GameTime"/>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            spriteBatch.Draw(grassImage,
                new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight),
                Color.White);

            //Dirt renderen
            foreach (var field in dirtFields)
            {
//                if (!(mouseState.LeftButton == ButtonState.Pressed && field.CollidesWith(mouseState)))
                field.Draw(spriteBatch);
            }

            spriteBatch.Draw(storeButtonImage, StoreManager.StoreButtonRectangle,
                Color.White);

            //Menu en winkels renderen
            MenuManager.Draw(spriteBatch, this);
            StoreManager.Draw(spriteBatch);

            // Alert renderen als deze actief is
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

        /// <summary>
        /// Actieveer een alert zodat de gebruiker aandacht krijgt.
        /// </summary>
        /// <param name="backgroundColor">De kleur van de achtergrond van de alert.</param>
        /// <param name="title">De titel van de alert.</param>
        /// <param name="body">De tekst van de alert.</param>
        public void ShowAlert(Color backgroundColor, string title, string body)
        {
            alertTitle = title;
            alertBody = body;
            dummyTexture.SetData(new Color[] { backgroundColor });
            alertActive = true;
        }
    }
}