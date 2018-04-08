using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    /// <summary>
    /// MenuManager regelt alle menu's voor dirt objecten.
    /// </summary>
    /// <seealso cref="Dirt"/>
    public class MenuManager
    {
        public bool IsActive { get; private set; } = false;

        private int textSpace = 15, margin = 40;

        private int x, y, width, height, textHeight;
        private GraphicsDevice graphicsDevice;
        private Texture2D dummyTexture;
        private SpriteFont spriteFont;
        private IClickableObject clickableObject;

        /// <summary>
        /// Laad alle IO blocking content zoals plaatjes en graphics.
        /// </summary>
        /// <param name="graphicsDevice">GraphicsDeviceManager instance van MonoGame</param>
        /// <param name="content">ContentManager instance van MonoGame</param>
        /// <seealso cref="GraphicsDeviceManager"/>
        /// <seealso cref="ContentManager"/>
        public void LoadContent(GraphicsDeviceManager graphicsDevice, ContentManager content)
        {
            this.graphicsDevice = graphicsDevice.GraphicsDevice;
            dummyTexture = new Texture2D(graphicsDevice.GraphicsDevice, 1, 1);
            dummyTexture.SetData(new Color[] {Color.White});

            spriteFont = content.Load<SpriteFont>("Arial");
        }

        /// <summary>
        /// Het verwerken van muis events.
        /// </summary>
        /// <param name="main">Verwijzing naar Main class</param>
        /// <param name="gameTime">GameTime instance van MonoGame</param>
        /// <param name="mouseState">MouseState instance van MonoGame</param>
        /// <param name="prevMouseState">MouseState instance van vorige MouseState update</param>
        /// <seealso cref="Main"/>
        /// <seealso cref="GameTime"/>
        /// <seealso cref="MouseState"/>
        public void Update(Main main, GameTime gameTime, MouseState mouseState, MouseState prevMouseState)
        {
            //check voor collisie / klikken van opties(=zaadjes planten, water geven en grond bemesten)
            if (clickableObject == null) return;

            MenuItem[] options = clickableObject.MenuOptions();
            for (int i = 0; i < options.Length; i++)
            {
                if (mouseState.X >= x
                    && mouseState.X <= x + width
                    && mouseState.Y >= y + textHeight / 2 + textHeight * i
                    && mouseState.Y <= y + textHeight / 2 + textHeight * (i + 1)
                    && mouseState.LeftButton == ButtonState.Pressed
                    && prevMouseState.LeftButton == ButtonState.Released
                    && IsActive)
                {
                    options[i].OnClick(main);
                    HideMenu();
                    Console.WriteLine("Menu clicked " + options[i].GetName());
                }
            }
        }

        /// <summary>
        /// Teken alle visuele objecten.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance van MonoGame</param>
        /// <param name="main">Verwijzing naar de Main class</param>
        /// <seealso cref="SpriteBatch"/>
        /// <seealso cref="Main"/>
        public void Draw(SpriteBatch spriteBatch, Main main)
        {
            if (!IsActive) return;

            // Valt het menu buiten het scherm? Verplaats deze dan.
            if (x + width + 5 > graphicsDevice.Viewport.Bounds.Width)
            {
                x = x - (graphicsDevice.Viewport.Bounds.Width - 5 - x);
            }

            // Dummy texture om een wit vlak te creëren.
            spriteBatch.Draw(dummyTexture, new Rectangle(x, y, width, height), Color.White);

            // Controlleer alle opties en laat deze zien.
            for (var i = 0; i < clickableObject.MenuOptions().Length; i++)
            {
                MenuItem menuOption = clickableObject.MenuOptions()[i];

                if (i != 0)
                    spriteBatch.Draw(dummyTexture,
                        new Rectangle(x + margin / 3, y + textHeight / 2 + textHeight * i,
                            (int) (width - margin / 1.5), 1), Color.LightGray);

                spriteBatch.DrawString(spriteFont, 
                    menuOption.GetName() + (menuOption.IsSubAction() ? "" : "  (" + main.StoreManager.GetSeedInventoryAmount(menuOption.GetPlant()) + ")"),
                    new Vector2(x + margin / 2, y + margin / 2 + textSpace / 2 + textHeight * i),
                    Color.Black);
            }
        }

        /// <summary>
        /// Creëer een menu op een bepaalde plaats.
        /// </summary>
        /// <param name="clickableObject">Het object waar wordt op geklikt.</param>
        /// <param name="x">De X plek waar het menu begint.</param>
        /// <param name="y">De Y plek waar het menu begint.</param>
        /// <seealso cref="IClickableObject"/>
        public void StartMenu(IClickableObject clickableObject, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.clickableObject = clickableObject;
            IsActive = true;

            int maxWidth = 0;
            int maxHeight = 0;

            // Zorgt ervoor dat het menu precies groot genoeg is voor alle opties.
            foreach (var menuOption in clickableObject.MenuOptions())
            {
                maxWidth = Math.Max(maxWidth, (int) spriteFont.MeasureString(menuOption.GetName() + " (99)").X);
                maxHeight = Math.Max(maxHeight, (int) spriteFont.MeasureString(menuOption.GetName()).Y);
            }

            textHeight = textSpace + maxHeight;
            width = margin + maxWidth;
            height = margin + textHeight * clickableObject.MenuOptions().Length;
        }

        /// <summary>
        /// Laat het menu verdwijnen.
        /// </summary>
        public void HideMenu()
        {
            IsActive = false;
        }

        /// <summary>
        /// Controlleerd of de muis op het menu staat.
        /// </summary>
        /// <param name="mouseState">MouseState instance van MonoGame.</param>
        /// <seealso cref="MouseState"/>
        /// <returns>True als de muis op het menu staat.</returns>
        public bool Collide(MouseState mouseState)
        {
            return mouseState.X >= x && mouseState.X <= x + width && mouseState.Y >= y && mouseState.Y <= y + height &&
                   IsActive;
        }
    }
}