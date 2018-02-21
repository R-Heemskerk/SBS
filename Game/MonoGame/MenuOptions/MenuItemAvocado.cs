using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemAvocado : MenuItem
    {
        public MenuItemAvocado(Dirt dirt) : base(PlantList.Avocado, dirt)
        {
        }

        public override string GetName()
        {
            return "Avocado";
        }


        public override void OnClick()
        {
            //dirt.SetPlant(this);
        }
    }
}

