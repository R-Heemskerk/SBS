using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.MenuOptions;

namespace MonoGame
{
    /// <summary>
    /// De dirt class is een object wat in de game als een stuk aarde wordt weergegeven. 
    /// Op de dirt kan plantjes worden geplaats om deze te laten groeien.
    /// </summary>
    /// <seealso cref="DrawableObject"/>
    public class Dirt : DrawableObject, IClickableObject
    {
        public Main Main { get; }
        public Plant Plant { get; set; }
        public int GrowTime { get; set; }
        private Texture2D zaadjes, plantje;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="main">Reference naar Main.</param>
        /// <param name="pos">Postie waar de dirt moet komen te staan.</param>
        /// <param name="width">Hoe breed moet de dirt zijn.</param>
        /// <param name="height">Hoe lang moet de dirt zijn.</param>
        public Dirt(Main main, Vector2 pos, int width, int height)
        {
            this.Main = main;
            this.pos = pos;
            this.height = height;
            this.width = width;
        }

        /// <summary>
        /// Laad alle IO blocking contents zoals plaatjes en graphics.
        /// </summary>
        /// <param name="content">ContentManager instance van MonoGame.</param>
        /// <seealso cref="ContentManager"/>
        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Images/dirt");
            zaadjes = content.Load<Texture2D>("Images/plantzaadjes");
            plantje = content.Load<Texture2D>("Images/plantje");
        }

        /// <summary>
        /// Update zorgt ervoor dat de plantjes groeien.
        /// </summary>
        /// <param name="gametime">GameTime instance van MonoGame.</param>
        /// <seealso cref="GameTime"/>
        public void Update(GameTime gametime)
        {
            if (Plant != null)
            {
                if (GrowTime > 0)
                    GrowTime -= gametime.ElapsedGameTime.Milliseconds;
            }
        }

        /// <summary>
        /// Krijg alle menu opties die beschikbaar zijn voor de dirt object.
        /// </summary>
        /// <returns>List van <see cref="MenuItem">MenuItems</see>.</returns>
        public MenuItem[] MenuOptions()
        {

            //als plant niet aanwezig geef dit
            if (Plant == null)
                return new MenuItem[]
                {
                    new MenuItemAnanas(this), new MenuItemMango(this), new MenuItemDragonfruit(this), new MenuItemAvocado(this), new MenuItemGranaatappel(this),
                    new MenuItemGuave(this), new MenuItemLychees(this), new MenuItemMarkoesa(this), new MenuItemPapaya(this), new MenuItemPassievrucht(this)
                };
            else //Er is wel een plant aanwezig
                return new MenuItem[]
                {
                    new MenuItemHarvest(this)
                };
        }

        /// <summary>
        /// Draw zorgt ervoor dat alle visuele beelden op het scherm komen.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch instance van MonoGame.</param>
        /// <seealso cref="SpriteBatch"/>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (Plant != null)
            {
                // Het plantje is net geplaatst dus in het eerste 1/3 helft zan zijn levens duur zal het nog een zaadje zijn.
                if (GrowTime > Plant.GrowTime / 3 * 2)
                {
                    spriteBatch.Draw(zaadjes, new Rectangle((int)pos.X, (int)pos.Y, width, height), Color.White);
                }
                else if (GrowTime > 0) // Het plantje is nu volgroeid en laat de vruchten zien.
                {
                    spriteBatch.Draw(plantje, new Rectangle((int)pos.X, (int)pos.Y, width / 2, height / 2), Color.White);
                    spriteBatch.Draw(plantje, new Rectangle((int)pos.X, (int)pos.Y + height / 2, width / 2, height / 2), Color.White);
                    spriteBatch.Draw(plantje, new Rectangle((int)pos.X + width / 2, (int)pos.Y, width / 2, height / 2), Color.White);
                    spriteBatch.Draw(plantje, new Rectangle((int)pos.X + width / 2, (int)pos.Y + height / 2, width / 2, height / 2), Color.White);
                }
                else // Het plantje is nog niet volgroeid en zal ontkiemende zaadjes laten zien.
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