using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.MenuOptions;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    public class Dirt : DrawableObject, IClickableObject
    {
        public Main Main { get; }
        public Plant Plant { get; set; }
        public int GrowTime { get; set; }
        private Texture2D zaadjes, plantje;
        private MouseState mouseState, prevMouseState;
        private bool collidedWithDirt;

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
            zaadjes = content.Load<Texture2D>("Images/plantzaadjes");
            plantje = content.Load<Texture2D>("Images/plantje");
        }

        public void Update(GameTime gametime)
        {
            if (Plant != null)
            {
                if (GrowTime > 0)
                    GrowTime -= gametime.ElapsedGameTime.Milliseconds;
            }

          

        }
        public MenuItem[] MenuOptions()
        {

            //als plant niet aanwezig geef dit
            if (Plant == null)
                return new MenuItem[]
                {
                    new MenuItemAnanas(this), new MenuItemMango(this), new MenuItemDragonfruit(this), new MenuItemAvocado(this), new MenuItemGranaatappel(this),
                    new MenuItemGuave(this), new MenuItemLychees(this), new MenuItemMarkoesa(this), new MenuItemPapaya(this), new MenuItemPassievrucht(this)
                };
            else
                return new MenuItem[]
                {
                    new MenuItemHarvest(this)
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

            if (Plant != null)
            {
                if (GrowTime > Plant.GrowTime / 3 * 2)
                {
                    spriteBatch.Draw(zaadjes, new Rectangle((int)pos.X, (int)pos.Y, width, height), Color.White);
                }
                else if (GrowTime > 0)
                {
                    spriteBatch.Draw(plantje, new Rectangle((int)pos.X, (int)pos.Y, width / 2, height / 2), Color.White);
                    spriteBatch.Draw(plantje, new Rectangle((int)pos.X, (int)pos.Y + height / 2, width / 2, height / 2), Color.White);
                    spriteBatch.Draw(plantje, new Rectangle((int)pos.X + width / 2, (int)pos.Y, width / 2, height / 2), Color.White);
                    spriteBatch.Draw(plantje, new Rectangle((int)pos.X + width / 2, (int)pos.Y + height / 2, width / 2, height / 2), Color.White);
                }
                else
                {
                    spriteBatch.Draw(Plant.Texture, new Rectangle((int)pos.X, (int)pos.Y, width / 2, height / 2), Color.White);
                    spriteBatch.Draw(Plant.Texture, new Rectangle((int)pos.X, (int)pos.Y + height / 2, width / 2, height / 2), Color.White);
                    spriteBatch.Draw(Plant.Texture, new Rectangle((int)pos.X + width / 2, (int)pos.Y, width / 2, height / 2), Color.White);
                    spriteBatch.Draw(Plant.Texture, new Rectangle((int)pos.X + width / 2, (int)pos.Y + height / 2, width / 2, height / 2), Color.White);
                }
            }

        }
    }
}