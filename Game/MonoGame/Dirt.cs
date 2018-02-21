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
    public class Dirt : DrawableObject, IClickableObject
    {
        public Main Main { get; } = null;
        public Plant Plant { get; set; } = null;

        public Dirt(Main main, Vector2 pos, int width, int height)
        {
            this.Main = main;
            this.pos = pos;
            this.height = height;
            this.width = width;
        }

        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Images/dirt");
        }

        public MenuItem[] MenuOptions()
        {
            //als plant niet aanwezig geef dit
            return new MenuItem[]
            {
                new MenuItemAnanas(this), new MenuItemMango(this), new MenuItemDragonfruit(this),
                new MenuItemAvocado(this), new MenuItemGranaatappel(this), new MenuItemGuave(this),
                new MenuItemLychees(this),
                new MenuItemMarkoesa(this), new MenuItemPapaya(this), new MenuItemPassievrucht(this)
            };

            //Ander van plant
        }

        /**
         * Misschien niet meer nodig omdat het sluiten van het menu al gebeurd door de MenuManager
         *
        public void CloseMenu()
        {
            Main.MenuManager.HideMenu();
        }
        */

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            //Teken plant als hij aanwezig is
        }
    }
}