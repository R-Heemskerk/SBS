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
        private Texture2D dummyTexture;
        private SpriteFont spriteFont;


        public void LoadContent(GraphicsDeviceManager graphicsDevice, ContentManager content)
        {
            this.graphicsDevice = graphicsDevice.GraphicsDevice;
            dummyTexture = new Texture2D(graphicsDevice.GraphicsDevice, 1, 1);
            dummyTexture.SetData(new Color[] {Color.White});
            StoreButtonRectangle = new Rectangle(50 + 3 * 200 + (180 - 80), 100 + 180, 80, 80);

            spriteFont = content.Load<SpriteFont>("Arial");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive)
            {
                spriteBatch.Draw(dummyTexture, new Rectangle(50, 50,
                    graphicsDevice.Viewport.Width - 100, graphicsDevice.Viewport.Height - 100), Color.White);
            }
        }

        public bool Collide(MouseState mouseState)
        {
            return mouseState.X >= 50 && mouseState.X <= graphicsDevice.Viewport.Width - 50
                                      && mouseState.Y >= 50 && mouseState.Y <= graphicsDevice.Viewport.Height - 50 &&
                                      IsActive;
        }

        public void Update(GameTime gameTime, MouseState mouseState, MouseState prevMouseState)
        {
            if (IsActive)
            {
                if (mouseState.LeftButton == ButtonState.Pressed &&
                    prevMouseState.LeftButton == ButtonState.Released &&
                    !Collide(mouseState) &&
                    IsActive)
                {
                    IsActive = false;
                }

                //update logica.  
            }
        }
    }
}