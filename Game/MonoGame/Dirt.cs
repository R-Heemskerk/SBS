using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    class Dirt : DrawableObject, ClickableObject
    {
        public Dirt(Vector2 pos, int width, int height)
        {
            this.pos = pos;
            this.height = height;
            this.width = width;
        }

        public override void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Images/dirt");
        }

        public string[] MenuOptions()
        {
            return new string[] { "Hallo", "Hello" };
        }
    }
}
