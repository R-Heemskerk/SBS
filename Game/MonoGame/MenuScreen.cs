using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public enum Screen
    {
        Veld,
        Opslag,
        Inkopen
    }

    class MenuScreen
    {
        public void Update(GameTime gametime)
        {
            if (mouseState.LeftButton == ButtonState.Pressed &&
                prevMouseState.LeftButton == ButtonState.Released &&
                ic_shopping_basket_black_24dp_2x.CollideWith(mouseState)

            if (Screen = Veld)



        }

        public static void LoadContent(ContentManager content)
        {
            textures.Add(Screen.Inkopen, content.Load<Texture2D>("images/ic_shopping_basket_black_24dp_2x"));
        }




    }
}
