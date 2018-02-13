using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    class DrawableObject
    {
        protected Vector2 pos;
        protected int width, height;
        protected Texture2D texture;

        public virtual void LoadContent(ContentManager content) {}

        public bool CollidesWith(MouseState mouse)
        {
            return (mouse.X > pos.X && mouse.X < pos.X + width
                && mouse.Y > pos.Y && mouse.Y < pos.Y + height);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture: texture, color: Color.White, destinationRectangle: new Rectangle((int)pos.X, (int)pos.Y, width, height));
        }
    }
}
