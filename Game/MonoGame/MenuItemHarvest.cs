using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public class MenuItemHarvest : MenuItem
    {
        public MenuItemHarvest(Dirt dirt) : base(dirt, true)
        {
        }

        public override string GetName()
        {
            return "Oogsten";
        }

        public override void OnClick(Main main)
        {
            if (dirt.GrowTime <= 0)
            {
                main.StoreManager.SetInventoryAmount(dirt.Plant.PlantList, main.StoreManager.GetInventoryAmount(dirt.Plant.PlantList) + 1);
                dirt.Plant = null;
            }
        }
    }
}
