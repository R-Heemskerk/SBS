using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public abstract class MenuItem
    {
        protected PlantList plant;
        protected Dirt dirt;

        protected MenuItem(PlantList plant, Dirt dirt)
        {
            this.plant = plant;
            this.dirt = dirt;
        }

        public abstract string GetName();

        public void OnClick(Main main)
        {
            main.StoreManager.SetInventoryAmount(plant, main.StoreManager.GetInventoryAmount(plant) - 1);
            dirt.Plant = PlantFactory.GetPlant(plant);
            dirt.GrowTime = PlantFactory.GetPlant(plant).GrowTime;
        }

        public PlantList GetPlant()
        {
            return plant;
        }
    }
}
