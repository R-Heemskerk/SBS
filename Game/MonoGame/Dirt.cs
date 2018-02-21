                                                                                                                                                                                                                                                                                                                          using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.MenuOptions;

namespace MonoGame
{
    class Dirt : DrawableObject, IClickableObject
    {
        
        public Dirt(Vector2 pos, int width, int height)
        {
            this.pos = pos;
            this.height = height;
            this.width = width;
        }

        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Images/dirt");
        }

        public IMenuOption[] MenuOptions()
        {
            //als plant niet aanwezig geef dit
            return new IMenuOption[] { new MenuItemPineapple(), new MenuItemMango(), new MenuItemDragonfruit(), new MenuItemAvocado(), new MenuItemGranaatappel(), new MenuItemGuave(), new MenuItemLychees(), new MenuItemMarkoesa(), new MenuItemPapaya(), new MenuItemPassievrucht() };

            //Ander van plant
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            //Teken plant als hij aanwezig is
        }
    }
}
