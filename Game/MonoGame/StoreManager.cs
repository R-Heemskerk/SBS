using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    public class StoreManager
    {
        public bool IsActive { get; set; } = false;
        public Rectangle StoreButtonRectangle { get; set; }
        private GraphicsDevice graphicsDevice;
        private Texture2D dummyTexture, closeImage;
        private SpriteFont spriteFont;

        public int Money { get; set; } = 10;
        private Dictionary<PlantList, int> plantInventory = new Dictionary<PlantList, int>();

        public void LoadContent(GraphicsDeviceManager graphicsDevice, ContentManager content)
        {
            this.graphicsDevice = graphicsDevice.GraphicsDevice;
            dummyTexture = new Texture2D(graphicsDevice.GraphicsDevice, 1, 1);
            dummyTexture.SetData(new Color[] {Color.White});
            closeImage = content.Load<Texture2D>("Images/close_black");

            StoreButtonRectangle = new Rectangle(50 + 3 * 200 + (180 - 80), 100 + 180, 80, 80);

            spriteFont = content.Load<SpriteFont>("Arial");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsActive) return;

            int menuWidth = graphicsDevice.Viewport.Width - 100;
            int menuHeight = graphicsDevice.Viewport.Height - 100;

            spriteBatch.Draw(dummyTexture, new Rectangle(50, 50,
                graphicsDevice.Viewport.Width - 100, graphicsDevice.Viewport.Height - 100), Color.White);

            for (int i = 1; i < 4; i++)
            {
                spriteBatch.Draw(dummyTexture,
                    new Rectangle(50 + (int) menuWidth / 4 * i, 50, 2, menuHeight), Color.LightGray);
            }

            for (int i = 1; i < 3; i++)
            {
                spriteBatch.Draw(dummyTexture,
                    new Rectangle(50, 50 + (int) menuHeight / 3 * i, menuWidth, 2), Color.LightGray);
            }

            int index = 0;
            int maxIndex = PlantFactory.Plants.Count;
            int cellWidth = menuWidth / 4;
            int cellHeigth = menuHeight / 3;

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    if (row == 0 && (column < 1 || column > 2)) continue;

                    spriteBatch.Draw(PlantFactory.GetPlant(PlantFactory.Plants[index]).Texture, 
                        new Rectangle(50 + (int)cellWidth / 2 - 25 + cellWidth * column, 50 + 10 + cellHeigth * row, 50, 50), 
                        Color.White);

                    index++;

                    if (index >= maxIndex) break;
                }

                if (index >= maxIndex) break;
            }

            spriteBatch.Draw(closeImage,
                new Rectangle(50 + graphicsDevice.Viewport.Width - 140, 50, 40, 40),
                Color.White);
        }

        public bool Collide(MouseState mouseState)
        {
            return mouseState.X >= 50 && mouseState.X <= graphicsDevice.Viewport.Width - 50
                                      && mouseState.Y >= 50 && mouseState.Y <= graphicsDevice.Viewport.Height - 50 &&
                                      IsActive;
        }

        public bool Collide(MouseState mouseState, int x, int x2, int y, int y2)
        {
            return mouseState.X >= x && mouseState.X <= x2 && mouseState.Y >= y && mouseState.Y <= y2 && IsActive;
        }

        public void Update(GameTime gameTime, MouseState mouseState, MouseState prevMouseState)
        {
            if (IsActive)
            {
                if (mouseState.LeftButton == ButtonState.Pressed &&
                    prevMouseState.LeftButton == ButtonState.Released &&
                    (!Collide(mouseState) || Collide(mouseState, 50 + graphicsDevice.Viewport.Width - 140, 50 + graphicsDevice.Viewport.Width - 100, 50, 50 + 40)) &&
                    IsActive)
                {
                    IsActive = false;
                }

                //update logica.  
            }
        }

        public int GetInventoryAmount(PlantList plant)
        {
            return plantInventory.ContainsKey(plant) ? plantInventory[plant] : 0;
        }

        public void SetInventoryAmount(PlantList plant, int amount)
        {
            if (plantInventory.ContainsKey(plant))
                plantInventory[plant] = amount;
            else
                plantInventory.Add(plant, amount);
        }
    }
}