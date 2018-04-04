using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    public class MenuManager
    {
        public bool IsActive { get; private set; } = false;

        private int textSpace = 15, margin = 40;

        private int x, y, width, height, textHeight;
        private GraphicsDevice graphicsDevice;
        private Texture2D dummyTexture;
        private SpriteFont spriteFont;
        private IClickableObject clickableObject;

        public void LoadContent(GraphicsDeviceManager graphicsDevice, ContentManager content)
        {
            this.graphicsDevice = graphicsDevice.GraphicsDevice;
            dummyTexture = new Texture2D(graphicsDevice.GraphicsDevice, 1, 1);
            dummyTexture.SetData(new Color[] {Color.White});

            spriteFont = content.Load<SpriteFont>("Arial");
        }

        public void Update(GameTime gameTime, Main main, MouseState mouseState, MouseState prevMouseState)
        {
            //check voor collisie / klikken van opties(=zaadjes planten, water geven en grond bemesten)
            if (clickableObject != null)
            {
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
                        if (main.StoreManager.GetInventoryAmount(options[i].GetPlant()) > 0)
                        {
                            options[i].OnClick(main);
                            HideMenu();
                            Console.WriteLine("Menu clicked " + options[i].GetName());
                        }
                        else
                        {
                            options[i].OnClick(main);
                            HideMenu();
                            Console.WriteLine("Menu clicked " + options[i].GetName());
                        }
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Main main)
        {
            if (IsActive)
            {
                if (x + width + 5 > graphicsDevice.Viewport.Bounds.Width)
                {
                    x = x - (graphicsDevice.Viewport.Bounds.Width - 5 - x);
                }

                spriteBatch.Draw(dummyTexture, new Rectangle(x, y, width, height), Color.White);

                for (var i = 0; i < clickableObject.MenuOptions().Length; i++)
                {
                    MenuItem menuOption = clickableObject.MenuOptions()[i];

                    if (i != 0)
                        spriteBatch.Draw(dummyTexture,
                            new Rectangle(x + margin / 3, y + textHeight / 2 + textHeight * i,
                                (int) (width - margin / 1.5), 1), Color.LightGray);

                    spriteBatch.DrawString(spriteFont, 
                        menuOption.GetName() + (menuOption.IsSubAction() ? "" : "  (" + main.StoreManager.GetInventoryAmount(menuOption.GetPlant()) + ")"),
                        new Vector2(x + margin / 2, y + margin / 2 + textSpace / 2 + textHeight * i),
                        Color.Black);
                }
            }
        }

        public void StartMenu(IClickableObject clickableObject, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.clickableObject = clickableObject;
            IsActive = true;

            int maxWidth = 0;
            int maxHeight = 0;
            foreach (var menuOption in clickableObject.MenuOptions())
            {
                maxWidth = Math.Max(maxWidth, (int) spriteFont.MeasureString(menuOption.GetName() + " (99)").X);
                maxHeight = Math.Max(maxHeight, (int) spriteFont.MeasureString(menuOption.GetName()).Y);
            }

            textHeight = textSpace + maxHeight;
            width = margin + maxWidth;
            height = margin + textHeight * clickableObject.MenuOptions().Length;
        }

        public void HideMenu()
        {
            IsActive = false;
        }

        public bool Collide(MouseState mouseState)
        {
            return mouseState.X >= x && mouseState.X <= x + width && mouseState.Y >= y && mouseState.Y <= y + height &&
                   IsActive;
        }
    }
}