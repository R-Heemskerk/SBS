using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemGranaatappel : MenuItem
    {
        public MenuItemGranaatappel(Dirt dirt) : base(PlantList.Granaatappel, dirt)
        {
        }

        public override string GetName()
        {
            return "Granaatappel";
        }


        public override void OnClick()
        {
            //dirt.SetPlant(this);
        }
    }
}

