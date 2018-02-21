using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.MenuOptions
{
    class MenuItemGranaatappel : MenuOption
    {
        public MenuItemGranaatappel(Dirt dirt) : base(dirt)
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

