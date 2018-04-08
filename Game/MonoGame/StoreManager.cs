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
    /// <summary>
    /// StoreManager regelt alle interacties met de winkel.
    /// </summary>
    public class StoreManager
    {
        public bool IsActive { get; set; } = false;
        public Rectangle StoreButtonRectangle { get; set; }
        private GraphicsDevice graphicsDevice;
        private Texture2D dummyTexture, closeImage;
        private SpriteFont titleFont, spriteFont;

        public int Money { get; set; } = 10;
        private Dictionary<PlantList, int> plantInventory = new Dictionary<PlantList, int>();
        private Dictionary<PlantList, int> plantSeedInventory = new Dictionary<PlantList, int>();

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
            closeImage = content.Load<Texture2D>("Images/close_black");

            StoreButtonRectangle = new Rectangle(50 + 3 * 200 + (180 - 80), 100 + 180, 80, 80);

            titleFont = content.Load<SpriteFont>("AlertTitle");
            spriteFont = content.Load<SpriteFont>("Arial");
        }

        /// <summary>
        /// Teken alle visuele objecten.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance van MonoGame</param>
        /// <seealso cref="SpriteBatch"/>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsActive) return;

            int menuWidth = graphicsDevice.Viewport.Width - 100;
            int menuHeight = graphicsDevice.Viewport.Height - 100;

            spriteBatch.Draw(dummyTexture, new Rectangle(50, 50,
                graphicsDevice.Viewport.Width - 100, graphicsDevice.Viewport.Height - 100), Color.White);

            // Een lijn om verschillende producten te onderscheiden.
            for (int i = 1; i < 4; i++)
            {
                spriteBatch.Draw(dummyTexture,
                    new Rectangle(50 + (int) menuWidth / 4 * i, 50, 1, menuHeight), Color.LightGray);
            }
//
//            for (int i = 1; i < 3; i++)
//            {
//                spriteBatch.Draw(dummyTexture,
//                    new Rectangle(50, 50 + (int) menuHeight / 3 * i, menuWidth, 1), Color.LightGray);
//            }

            int index = 0;
            int maxIndex = PlantFactory.Plants.Count;
            int cellWidth = menuWidth / 4;
            int cellHeigth = menuHeight / 3;

            // Ga over alle planten.
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    String text = "";

                    // Laat zien hoeveel geld de gebruiker heeft.
                    if (row == 0 && column == 0)
                    {
                        text = "Geld: $" + Money;
                        spriteBatch.DrawString(titleFont, text,
                            new Vector2(50 + (int) cellWidth / 2 - (int) (titleFont.MeasureString(text).X / 2),
                                50 + (int) cellHeigth / 2 - (int) (titleFont.MeasureString(text).Y / 2)), Color.Black);
                    }

                    // Sla de eerste een laatste hokje over op de eerste rij.
                    if (row == 0 && (column < 1 || column > 2)) continue;

                    // Schrijf over welke plant het gaat.
                    text = PlantFactory.GetPlant(PlantFactory.Plants[index]).Name;
                    spriteBatch.DrawString(spriteFont, text,
                        new Vector2(50 + (int) cellWidth / 2 - (int) (spriteFont.MeasureString(text).X / 2) + cellWidth * column, 50 + 10 + cellHeigth * row), Color.Black);

                    // Hoeveel zaadjes heeft de gebruiker over deze plant.
                    text = "Zaadjes: " + GetSeedInventoryAmount(PlantFactory.Plants[index]); 
                    spriteBatch.DrawString(spriteFont, text,
                        new Vector2(50 + (int)cellWidth / 2 - (int)(spriteFont.MeasureString(text).X / 2) + cellWidth * column, 50 + 30 + cellHeigth * row), Color.Black);

                    // Hoeveel vruchten heeft de gebruiker over deze plant.
                    text = "Vruchten: " + GetInventoryAmount(PlantFactory.Plants[index]);
                    spriteBatch.DrawString(spriteFont, text,
                        new Vector2(50 + (int)cellWidth / 2 - (int)(spriteFont.MeasureString(text).X / 2) + cellWidth * column, 50 + 50 + cellHeigth * row), Color.Black);

                    // Laat een plaatje zien van de plant.
                    spriteBatch.Draw(PlantFactory.GetPlant(PlantFactory.Plants[index]).Texture,
                        new Rectangle(50 + (int) cellWidth / 2 - 25 + cellWidth * column, 80 + 50 + (int) cellHeigth * row, 50, 50),
                        Color.White);

                    // Teken een koop knop.
                    text = "Kopen $" + PlantFactory.GetCostPrice(PlantFactory.Plants[index]);
                    spriteBatch.Draw(dummyTexture,
                        new Rectangle(50 + 5 + cellWidth * column, 50 + (int) cellHeigth - 30 + cellHeigth * row, (int) cellWidth / 2 - 18,
                            (int) (spriteFont.MeasureString(text).Y) + 4),
                        Color.LightBlue);
                    spriteBatch.DrawString(spriteFont, text, new Vector2(50 + 10 + cellWidth * column, 50 + (int) cellHeigth - 28 + cellHeigth * row), Color.Black);

                    // Teken een verkoop knop.
                    text = "Verkopen $" + PlantFactory.GetSellPrice(PlantFactory.Plants[index]);
                    spriteBatch.Draw(dummyTexture,
                        new Rectangle(45 + (int) cellWidth / 2 + cellWidth * column, 50 + (int) cellHeigth - 30 + cellHeigth * row, (int) cellWidth / 2 + 3,
                            (int) (spriteFont.MeasureString(text).Y) + 4),
                        Color.LightBlue);
                    spriteBatch.DrawString(spriteFont, text, new Vector2(45 + (int) cellWidth / 2 + cellWidth * column, 50 + (int) cellHeigth - 28 + cellHeigth * row),
                        Color.Black);

                    // Ga naar he volgende product.
                    index++;

                    if (index >= maxIndex) break;
                }

                if (index >= maxIndex) break;
            }

            // Laat een kruisje rechts bovenin het scherm zien.
            spriteBatch.Draw(closeImage,
                new Rectangle(50 + graphicsDevice.Viewport.Width - 140, 50, 40, 40),
                Color.White);
        }

        /// <summary>
        /// Controlleerd of de muis op de winkel staat.
        /// </summary>
        /// <param name="mouseState">MouseState instance van MonoGame.</param>
        /// <seealso cref="MouseState"/>
        /// <returns>True als de muis op het menu staat.</returns>
        public bool Collide(MouseState mouseState)
        {
            return mouseState.X >= 50 && mouseState.X <= graphicsDevice.Viewport.Width - 50
                                      && mouseState.Y >= 50 && mouseState.Y <= graphicsDevice.Viewport.Height - 50 &&
                                      IsActive;
        }

        /// <summary>
        /// Controlleerd of de muis binnen bepaalde X en Y waardes staat.
        /// </summary>
        /// <param name="mouseState">MouseState instance van MonoGame.</param>
        /// <param name="x">Linker X waarde.</param>
        /// <param name="x2">Rechter X waarde.</param>
        /// <param name="y">Boven Y waarde.</param>
        /// <param name="y2">Onder Y waarde.</param>
        /// <returns>True als de muis binnen de bepaalde waardes valt.</returns>
        public bool Collide(MouseState mouseState, int x, int x2, int y, int y2)
        {
            return mouseState.X >= x && mouseState.X <= x2 && mouseState.Y >= y && mouseState.Y <= y2 && IsActive;
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
            if (!IsActive) return;

            // Sluit de winkel als er buiten de winkel wordt gedrukt.
            if (mouseState.LeftButton == ButtonState.Pressed &&
                prevMouseState.LeftButton == ButtonState.Released &&
                (!Collide(mouseState) || Collide(mouseState, 50 + graphicsDevice.Viewport.Width - 140, 50 + graphicsDevice.Viewport.Width - 100, 50, 50 + 40)) &&
                IsActive)
            {
                IsActive = false;
            }

            if (mouseState.LeftButton != ButtonState.Pressed || prevMouseState.LeftButton != ButtonState.Released || !IsActive) return;

            int menuWidth = graphicsDevice.Viewport.Width - 100;
            int menuHeight = graphicsDevice.Viewport.Height - 100;
            int index = 0;
            int maxIndex = PlantFactory.Plants.Count;
            int cellWidth = menuWidth / 4;
            int cellHeigth = menuHeight / 3;

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    // Sla de eerst en laatste vak over van de eerste rij.
                    if (row == 0 && (column < 1 || column > 2)) continue;

                    PlantList plant = PlantFactory.Plants[index];
                    String text = "Placeholder";

                    // Creëer een rechthoek voor de koop en verkoop knop.
                    Rectangle buyRectangle = new Rectangle(50 + 5 + cellWidth * column, 50 + (int)cellHeigth - 30 + cellHeigth * row, (int)cellWidth / 2 - 18,
                        (int)(spriteFont.MeasureString(text).Y) + 4);
                    Rectangle sellRectangle = new Rectangle(45 + (int)cellWidth / 2 + cellWidth * column, 50 + (int)cellHeigth - 30 + cellHeigth * row, (int)cellWidth / 2 + 3,
                        (int)(spriteFont.MeasureString(text).Y) + 4);

                    // De muis drukt op de koop knop.
                    if (buyRectangle.Intersects(new Rectangle(mouseState.X, mouseState.Y, 1, 1)))
                    {
                        // De gebruiker heeft genoeg geld en de plant wordt gekocht.
                        if (Money >= PlantFactory.GetCostPrice(plant))
                        {
                            SetSeedInventoryAmount(plant, GetSeedInventoryAmount(plant) + 1);
                            Money -= PlantFactory.GetCostPrice(plant);
                        }
                        else // De gebruiker heeft niet genoeg geld en zal een alert worden getoont.
                        {
                            main.ShowAlert(Constants.DangerColor, Strings.ErrorNotEnoughMoney, Strings.ErrorNotEnoughMoneyBody.Replace("%%PLANT", plant.ToString()));
                        }
                    }
                    else if (sellRectangle.Intersects(new Rectangle(mouseState.X, mouseState.Y, 1, 1))) // De muis drukt op de verkoop knop.
                    {
                        // De gebruiker heeft genoeg vruchten van de plant.
                        if (GetInventoryAmount(plant) >= 1)
                        {
                            SetInventoryAmount(plant, GetInventoryAmount(plant) - 1);
                            Money += PlantFactory.GetSellPrice(plant);
                        }
                        else // De gebruiker heeft niet genoeg vruchten en zal een alert worden getoont.
                        {
                            main.ShowAlert(Constants.DangerColor, Strings.ErrorNotEnoughInventory, Strings.ErrorNotEnoughInventoryBody.Replace("%%PLANT", plant.ToString()));
                        }
                    }

                    index++;
                    if (index >= maxIndex) break;
                }

                if (index >= maxIndex) break;
            }
        }

        /// <summary>
        /// Hoeveel vruchten heeft de gebruiker over een bepaalde plant.
        /// </summary>
        /// <param name="plant">De plant.</param>
        /// <seealso cref="PlantList"/>
        /// <returns>Een nummer hoeveel vruchten de gebruiker heeft.</returns>
        public int GetInventoryAmount(PlantList plant)
        {
            return plantInventory.ContainsKey(plant) ? plantInventory[plant] : 0;
        }

        /// <summary>
        /// Verander hoeveel vruchten de gebruiker heeft over een bepaalde plant.
        /// </summary>
        /// <param name="plant">De plant.</param>
        /// <param name="amount">Hoeveelheid.</param>
        /// <seealso cref="PlantList"/>
        public void SetInventoryAmount(PlantList plant, int amount)
        {
            if (plantInventory.ContainsKey(plant))
                plantInventory[plant] = amount;
            else
                plantInventory.Add(plant, amount);
        }

        /// <summary>
        /// Hoeveel zaadjes heeft de gebruiker over een bepaalde plant.
        /// </summary>
        /// <param name="plant">De plant.</param>
        /// <seealso cref="PlantList"/>
        /// <returns>Een nummer hoeveel zaadjes de gebruiker heeft.</returns>
        public int GetSeedInventoryAmount(PlantList plant)
        {
            return plantSeedInventory.ContainsKey(plant) ? plantSeedInventory[plant] : 0;
        }

        /// <summary>
        /// Verander hoeveel zaadjes de gebruiker heeft over een bepaalde vrucht.
        /// </summary>
        /// <param name="plant">De plant.</param>
        /// <param name="amount">Hoeveelheid.</param>
        /// <seealso cref="PlantList"/>
        public void SetSeedInventoryAmount(PlantList plant, int amount)
        {
            if (plantSeedInventory.ContainsKey(plant))
                plantSeedInventory[plant] = amount;
            else
                plantSeedInventory.Add(plant, amount);
        }
    }
}