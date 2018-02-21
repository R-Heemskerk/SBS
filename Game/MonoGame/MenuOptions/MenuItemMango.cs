using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemMango : MenuItem
    {
        public MenuItemMango(Dirt dirt) : base(PlantList.Mango, dirt)
        {
        }

        public override string GetName()
        {
            return "Mango";
        }


        public override void OnClick()
        {
            //dirt.SetPlant(this);
        }
    }
}
