using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoGame
{
    /// <summary>
    /// Een MenuItem is een optie voor een menu.
    /// </summary>
    public abstract class MenuItem
    {
        protected PlantList plant;
        protected Dirt dirt;
        protected Boolean action;

        /// <summary>
        /// Constructor voor MenuItem. Deze constructor wordt alleen gebruikt wanneer de dirt veld leeg is.
        /// </summary>
        /// <param name="plant">De plant over waar deze optie gaat.</param>
        /// <param name="dirt">De dirt object waar het is aangekoppeld.</param>
        protected MenuItem(PlantList plant, Dirt dirt)
        {
            this.plant = plant;
            this.dirt = dirt;
            this.action = false;
        }

        /// <summary>
        /// Constructor voor MenuItem. Deze constructor wordt alleen gebruikt wanneer de MenuItem een sub-actie is.
        /// </summary>
        /// <param name="dirt"></param>
        /// <param name="action"></param>
        protected MenuItem(Dirt dirt, Boolean action)
        {
            this.dirt = dirt;
            this.action = action;
        }

        /// <summary>
        /// Krijg de naam van de menu optie.
        /// </summary>
        /// <returns>De naam van de menu optie.</returns>
        public abstract string GetName();

        /// <summary>
        /// Dit regelt wat er gebeurd zodra op de MenuItem word geklikt.
        /// </summary>
        /// <param name="main"><see cref="Main">Main</see> instance</param>
        public virtual void OnClick(Main main)
        {
            // Er zijn genoeg zaadjes dus de plant kan worden geplant.
            if (main.StoreManager.GetSeedInventoryAmount(plant) > 0)
            {
                main.StoreManager.SetSeedInventoryAmount(plant, main.StoreManager.GetSeedInventoryAmount(plant) - 1);
                dirt.Plant = PlantFactory.GetPlant(plant);
                dirt.GrowTime = PlantFactory.GetPlant(plant).GrowTime;
            }
            else // Er zijn niet genoeg zaadjes dus moet er een alert komen.
            {
                main.ShowAlert(Constants.DangerColor, Strings.ErrorNotEnoughSeeds, Strings.ErrorNotEnoughSeedsBody.Replace("%%PLANT", plant.ToString()));
            }
        }

        /// <summary>
        /// Krijg de plant
        /// </summary>
        /// <returns><see cref="PlantList"/></returns>
        public PlantList GetPlant()
        {
            return plant;
        }

        /// <summary>
        /// Is dit een sub-actie.
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean IsSubAction()
        {
            return action;
        }
    }
}
