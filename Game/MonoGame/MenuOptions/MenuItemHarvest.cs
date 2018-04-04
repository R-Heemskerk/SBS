using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

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
                main.StoreManager.SetInventoryAmount(dirt.Plant.PlantList, main.StoreManager.GetInventoryAmount(dirt.Plant.PlantList) + 4);
                dirt.Plant = null;
            }
            else
            {
                main.ShowAlert(Constants.DangerColor, Strings.ErrorHarvestTitle, Strings.ErrorHarvestBody);
            }
        }
    }
}
