using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoGame
{
    public abstract class MenuItem
    {
        protected PlantList plant;
        protected Dirt dirt;
        protected Boolean action;

        protected MenuItem(PlantList plant, Dirt dirt)
        {
            this.plant = plant;
            this.dirt = dirt;
            this.action = false;
        }

        protected MenuItem(Dirt dirt, Boolean action)
        {
            this.dirt = dirt;
            this.action = action;
        }

        protected MenuItem(Dirt dirt)
        {
            this.dirt = dirt;
        }

        public abstract string GetName();

        public virtual void OnClick(Main main)
        {
            if (main.StoreManager.GetSeedInventoryAmount(plant) > 0)
            {
                main.StoreManager.SetSeedInventoryAmount(plant, main.StoreManager.GetSeedInventoryAmount(plant) - 1);
                dirt.Plant = PlantFactory.GetPlant(plant);
                dirt.GrowTime = PlantFactory.GetPlant(plant).GrowTime;
            }
            else
            {
                main.ShowAlert(Constants.DangerColor, Strings.ErrorNotEnoughSeeds, Strings.ErrorNotEnoughSeedsBody.Replace("%%PLANT", plant.ToString()));
            }
        }

        public PlantList GetPlant()
        {
            return plant;
        }

        public Boolean IsSubAction()
        {
            return action;
        }
    }
}
